"""
OpenAI客户端工具类

负责处理与OpenAI API的交互和API密钥管理
"""

import logging
import os
from typing import Any, Dict, Optional

from app.core.config import settings
from openai import OpenAI

logger = logging.getLogger(__name__)

class OpenAIClientManager:
    """
    OpenAI客户端管理器

    负责创建和配置OpenAI客户端实例，处理API密钥设置
    """

    @classmethod
    def get_client(cls, api_key: Optional[str] = None) -> OpenAI:
        """
        获取配置好的OpenAI客户端

        优先级：
        1. 参数传入的API密钥
        2. 环境变量中的OPENAI_API_KEY
        3. 配置文件中的OPENAI_API_KEY设置

        如果所有方式都没有找到API密钥，将抛出异常
        """
        # 确定要使用的API密钥
        key_to_use = api_key or os.environ.get("OPENAI_API_KEY") or settings.OPENAI_API_KEY

        if not key_to_use:
            raise ValueError(
                "The api_key client option must be set either by passing api_key to the client "
                "or by setting the OPENAI_API_KEY environment variable"
            )

        # 创建客户端实例
        return OpenAI(api_key=key_to_use)

    @classmethod
    def get_default_model(cls) -> str:
        """获取默认模型名称"""
        return settings.DEFAULT_MODEL


# 创建默认实例，便于导入
client_manager = OpenAIClientManager()
