import secrets
from typing import List, Optional, Union

from pydantic import validator
from pydantic_settings import BaseSettings


class Settings(BaseSettings):
    # 基本配置
    API_V1_STR: str = "/api"
    SECRET_KEY: str = secrets.token_urlsafe(32)
    PROJECT_NAME: str = "Agent API"

    # CORS配置
    BACKEND_CORS_ORIGINS: List[str] = ["*"]

    # 服务端口
    PORT: int = 8000

    # API密钥
    API_KEY: Optional[str] = None

    # OpenAI 配置
    OPENAI_API_KEY: Optional[str] = None

    # 模型配置
    DEFAULT_MODEL: str = "gpt-3.5-turbo"

    @validator("BACKEND_CORS_ORIGINS", pre=True)
    def assemble_cors_origins(cls, v: Union[str, List[str]]) -> Union[List[str], str]:
        if isinstance(v, str) and not v.startswith("["):
            return [i.strip() for i in v.split(",")]
        elif isinstance(v, (list, str)):
            return v
        raise ValueError(v)

    class Config:
        case_sensitive = True
        env_file = ".env"

settings = Settings()
