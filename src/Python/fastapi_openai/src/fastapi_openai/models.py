from datetime import datetime

from sqlalchemy import (JSON, Column, DateTime, ForeignKey, Integer, String,
                        create_engine)
from sqlalchemy.ext.declarative import declarative_base

Base = declarative_base()

class TranslationRequest(Base):
    __tablename__ = 'translation_requests'
    id = Column(Integer, primary_key=True,index=True)
    text = Column(String,nullable=False)
    languages = Column(String,nullable=False)
    status = Column(String,default="in progress",nullable=False)
    created_at = Column(DateTime, default=datetime.now)
    updated_at = Column(DateTime, default=datetime.now, onupdate=datetime.now)

class TranslationResponse(Base):
    __tablename__ = 'translation_responses'
    id = Column(Integer, primary_key=True,index=True)
    request_id = Column(Integer,ForeignKey('translation_requests.id'),nullable=False)
    response = Column(JSON,nullable=False)
    language = Column(String, nullable=False)
    translated_text = Column(String, nullable=False)
    created_at = Column(DateTime, default=datetime.now)

class IndividualTranslations(Base):
    __tablename__ = 'individual_translations'
    id = Column(Integer, primary_key=True,index=True)
    request_id = Column(Integer,ForeignKey('translation_requests.id'),nullable=False)
    translated_text = Column(String, nullable=False)
    create_at = Column(DateTime, default=datetime.now)

# Create an engine that stores data in the postgres database
engine = create_engine("postgresql+psycopg2://root:c9TUrVtkR1pC4znp9D@localhost:5432/fastapi_openai")
Base.metadata.create_all(engine)
