from app.api.endpoints import agent
from fastapi import APIRouter

api_router = APIRouter()

api_router.include_router(agent.router, prefix="/agent", tags=["agent"])
