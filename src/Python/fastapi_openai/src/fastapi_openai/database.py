from contextlib import asynccontextmanager

from sqlalchemy import create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import scoped_session, sessionmaker

SQLALCHEMY_DATABASE = "postgresql+psycopg2://root:c9TUrVtkR1pC4znp9D@localhost:5432/fastapi_openai"

engine = create_engine(SQLALCHEMY_DATABASE,echo=True)
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)
Base = declarative_base()

def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()
