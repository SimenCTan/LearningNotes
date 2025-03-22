import asyncio
import base64
import json
import os
import uuid
from datetime import datetime
from typing import Any, Dict, List, Optional, Union

from agents import Agent, Runner, WebSearchTool  # 添加 openai-agents 的导入
from fastapi import APIRouter, Depends, Header, HTTPException
from IPython.display import Image, display
from pydantic import BaseModel, Field

from app.core.config import settings
from app.core.openai_client import client_manager
from app.schemas.agent import CompletionRequest, CompletionResponse

# 设置 OpenAI API 密钥
os.environ["OPENAI_API_KEY"] = settings.OPENAI_API_KEY or ""

router = APIRouter()


class Tool(BaseModel):
    type: str
    settings: Optional[Dict[str, Any]] = None
class AgentRequest(BaseModel):
    prompt: str
    max_tokens: Optional[int] = 100
    temperature: Optional[float] = 0.7
    api_key: Optional[str] = None

class AgentResponse(BaseModel):
    response: str
    tokens_used: int

class OpenAIAgentRequest(BaseModel):
    prompt: str
    instructions: Optional[str] = "You are a helpful assistant"
    name: Optional[str] = "Assistant"
    tools: List[Tool]

class ToolsRequest(BaseModel):
    model: str = "gpt-4o"
    input: str
    tools: List[Tool]
    temperature: Optional[float] = 0.7
    api_key: Optional[str] = None

class ToolResponseContent(BaseModel):
    content: str
    tool_use_id: Optional[str] = None

class ToolsResponse(BaseModel):
    id: str
    created_at: datetime = Field(default_factory=datetime.now)
    content: str
    model: str
    usage: Optional[Dict[str, int]] = None

class MultimodalRequest(BaseModel):
    model: str = "gpt-4o"
    input_text: str
    image_url: str
    tools: List[Tool]
    temperature: Optional[float] = 0.7
    api_key: Optional[str] = None

class MultimodalResponse(BaseModel):
    id: str
    created_at: datetime = Field(default_factory=datetime.now)
    content: str
    model: str
    usage: Optional[Dict[str, int]] = None

def get_api_key(x_api_key: Optional[str] = Header(None)):
    """获取API密钥，优先从请求头获取"""
    return x_api_key

@router.post("/generate", response_model=AgentResponse)
async def generate_response(request: AgentRequest, api_key: Optional[str] = Depends(get_api_key)):
    """
    生成AI响应
    """
    try:
        # 尝试使用API密钥创建客户端
        # 优先级：请求中的api_key > 请求头中的x-api-key > 环境变量
        openai_api_key = request.api_key or api_key

        # 这里在实际应用中会调用OpenAI API
        # client = client_manager.get_client(api_key=openai_api_key)
        # response = client.chat.completions.create(...)

        # 模拟响应
        response = f"这是对'{request.prompt}'的模拟响应"
        tokens_used = len(response) // 4  # 简单模拟token计算

        return AgentResponse(
            response=response,
            tokens_used=tokens_used
        )
    except ValueError as e:
        # 捕获API密钥缺失错误
        if "api_key" in str(e):
            raise HTTPException(
                status_code=401,
                detail="API密钥未提供。请通过请求参数、请求头或环境变量设置OPENAI_API_KEY"
            )
        raise HTTPException(status_code=400, detail=str(e))
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"生成过程中出错: {str(e)}")

@router.post("/openai-agent", response_model=AgentResponse)
async def openai_agent_response(request: OpenAIAgentRequest):
    """
    使用 OpenAI Agents 生成响应 (同步版本，但确保有事件循环)
    """
    try:
        # 检查 API 密钥是否已设置
        if not settings.OPENAI_API_KEY:
            raise ValueError("未设置 OPENAI_API_KEY 环境变量。请在 .env 文件中添加有效的 API 密钥。")

        # 转换工具为OpenAI API格式
        tools_for_api = [{"type": tool.type, **(tool.settings or {})} for tool in request.tools]

        # 创建 Agent 并在事件循环中运行
        agent = Agent(
            name=request.name,
            instructions=request.instructions,
            tools=[WebSearchTool()]
        )
        result = await Runner.run(agent, request.prompt)

        # 返回结果
        return AgentResponse(
            response=result.final_output,
            tokens_used=len(result.final_output) // 4  # 简单估算 token 数量
        )
    except Exception as e:
        # 包含更详细的错误信息，以便调试
        error_msg = f"OpenAI Agent 生成过程中出错: {str(e)}, 类型: {type(e).__name__}"
        raise HTTPException(status_code=500, detail=error_msg)

@router.post("/tools-response", response_model=ToolsResponse)
async def create_response_with_tools(
    request: ToolsRequest,
    api_key: Optional[str] = Depends(get_api_key)
):
    """
    创建带工具的响应，支持网络搜索等功能
    """
    try:
        # 获取有效的API密钥
        openai_api_key = request.api_key or api_key or settings.OPENAI_API_KEY

        if not openai_api_key:
            raise ValueError("API密钥未提供。请通过请求参数、请求头或环境变量设置OPENAI_API_KEY")

        # 获取OpenAI客户端
        client = client_manager.get_client(api_key=openai_api_key)

        # 转换工具为OpenAI API格式
        tools_for_api = [{"type": tool.type, **(tool.settings or {})} for tool in request.tools]

        # 调用OpenAI API
        try:
            response = client.responses.create(
                model=request.model,
                input=request.input,
                tools=tools_for_api,
                temperature=request.temperature
            )

            # 提取并格式化响应内容
            print(json.dumps(response.output, default=lambda o: o.__dict__, indent=2))

            # 提取usage信息
            usage = None
            if hasattr(response, 'usage'):
                usage = {
                    "prompt_tokens": getattr(response.usage, 'prompt_tokens', 0),
                    "completion_tokens": getattr(response.usage, 'completion_tokens', 0),
                    "total_tokens": getattr(response.usage, 'total_tokens', 0)
                }

            return ToolsResponse(
                id=response.id,
                content=response.output,
                model=response.model,
                usage=usage
            )

        except Exception as api_error:
            # 处理API调用特定错误
            raise HTTPException(
                status_code=500,
                detail=f"OpenAI API调用失败: {str(api_error)}"
            )

    except ValueError as e:
        # 捕获API密钥缺失错误
        if "api_key" in str(e):
            raise HTTPException(
                status_code=401,
                detail=str(e)
            )
        raise HTTPException(status_code=400, detail=str(e))
    except Exception as e:
        # 捕获其他所有错误
        raise HTTPException(
            status_code=500,
            detail=f"工具响应请求处理出错: {str(e)}, 类型: {type(e).__name__}"
        )

@router.post("/multimodal-response", response_model=MultimodalResponse)
async def create_multimodal_response(
    request: MultimodalRequest,
    api_key: Optional[str] = Depends(get_api_key)
):
    """
    创建多模态响应，处理图像和文本输入
    """
    try:
        # 获取有效的API密钥
        openai_api_key = request.api_key or api_key or settings.OPENAI_API_KEY

        if not openai_api_key:
            raise ValueError("API密钥未提供。请通过请求参数、请求头或环境变量设置OPENAI_API_KEY")

        # 获取OpenAI客户端
        client = client_manager.get_client(api_key=openai_api_key)

        # 转换工具为OpenAI API格式
        tools_for_api = [{"type": tool.type, **(tool.settings or {})} for tool in request.tools]

        # 调用OpenAI API
        try:
            response = client.responses.create(
                model=request.model,
                input=[
                    {
                        "role": "user",
                        "content": [
                            {"type": "input_text", "text": request.input_text},
                            {"type": "input_image", "image_url": request.image_url}
                        ]
                    }
                ],
                tools=tools_for_api,
                temperature=request.temperature
            )

            # 提取并格式化响应内容
            content = json.dumps(response.output, default=lambda o: o.__dict__, indent=2)

            # 提取usage信息
            usage = None
            if hasattr(response, 'usage'):
                usage = {
                    "prompt_tokens": getattr(response.usage, 'prompt_tokens', 0),
                    "completion_tokens": getattr(response.usage, 'completion_tokens', 0),
                    "total_tokens": getattr(response.usage, 'total_tokens', 0)
                }

            return MultimodalResponse(
                id=response.id,
                content=content,
                model=response.model,
                usage=usage
            )

        except Exception as api_error:
            # 处理API调用特定错误
            raise HTTPException(
                status_code=500,
                detail=f"OpenAI API调用失败: {str(api_error)}"
            )

    except ValueError as e:
        # 捕获API密钥缺失错误
        if "api_key" in str(e):
            raise HTTPException(
                status_code=401,
                detail=str(e)
            )
        raise HTTPException(status_code=400, detail=str(e))
    except Exception as e:
        # 捕获其他所有错误
        raise HTTPException(
            status_code=500,
            detail=f"多模态响应请求处理出错: {str(e)}, 类型: {type(e).__name__}"
        )

@router.get("/models", response_model=List[str])
async def list_models():
    """
    列出可用的AI模型
    """
    # 模拟可用模型列表
    return ["gpt-3.5-turbo", "gpt-4", "claude-3-sonnet"]

@router.post("/completions", response_model=CompletionResponse)
async def create_completion(
    request: CompletionRequest,
    api_key: Optional[str] = Depends(get_api_key)
):
    """
    创建完成请求

    这个端点展示了如何使用模式验证和OpenAI客户端
    """
    try:
        # 使用OpenAI客户端管理器获取客户端
        # client = client_manager.get_client(api_key=api_key)

        # 使用默认或指定的模型
        model = request.model or client_manager.get_default_model()

        # 这里在实际应用中会调用OpenAI API
        # response = client.chat.completions.create(...)

        # 模拟响应
        return CompletionResponse(
            id=str(uuid.uuid4()),
            response=f"这是对'{request.prompt}'的完成回复",
            created_at=datetime.now(),
            model=model,
            tokens_used=50  # 模拟值
        )

    except ValueError as e:
        # 捕获API密钥缺失错误
        if "api_key" in str(e):
            raise HTTPException(
                status_code=401,
                detail="API密钥未提供。请通过请求参数、请求头或环境变量设置OPENAI_API_KEY"
            )
        raise HTTPException(status_code=400, detail=str(e))
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"请求处理出错: {str(e)}")



