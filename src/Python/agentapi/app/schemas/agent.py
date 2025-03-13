from datetime import datetime
from typing import Any, Dict, List, Optional

from pydantic import BaseModel, Field


class MessageBase(BaseModel):
    content: str
    role: str = "user"

class MessageCreate(MessageBase):
    pass

class MessageResponse(MessageBase):
    id: str
    created_at: datetime
    tokens: int

    class Config:
        from_attributes = True

class ConversationBase(BaseModel):
    title: str

class ConversationCreate(ConversationBase):
    messages: Optional[List[MessageCreate]] = None

class ConversationResponse(ConversationBase):
    id: str
    created_at: datetime
    updated_at: datetime
    messages: Optional[List[MessageResponse]] = None

    class Config:
        from_attributes = True

class CompletionRequest(BaseModel):
    prompt: str
    model: Optional[str] = None
    max_tokens: Optional[int] = 100
    temperature: Optional[float] = Field(0.7, ge=0.0, le=1.0)
    user_id: Optional[str] = None

class CompletionResponse(BaseModel):
    id: str
    response: str
    created_at: datetime
    model: str
    tokens_used: int
