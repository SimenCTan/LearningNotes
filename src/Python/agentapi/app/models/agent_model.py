from datetime import datetime
from typing import List, Optional

from pydantic import BaseModel


class Conversation(BaseModel):
    id: str
    user_id: str
    title: str
    created_at: datetime
    updated_at: datetime

class Message(BaseModel):
    id: str
    conversation_id: str
    role: str  # "user" 或 "assistant"
    content: str
    created_at: datetime
    tokens: int

class Usage(BaseModel):
    user_id: str
    date: datetime
    model: str
    tokens_used: int
    request_count: int
