import os
from contextlib import contextmanager
from datetime import datetime
from typing import List

from database import get_db
from dotenv import load_dotenv
from models import (IndividualTranslations, TranslationRequest,
                    TranslationResponse)
from openai import OpenAI
from sqlalchemy.orm import Session

load_dotenv()

api_key=os.getenv("OPENAI_APIKEY")
client = OpenAI(api_key=api_key)
def translate_text(text:str,language:str)->str:
    response = client.chat.completions.create(
        model="gpt-3.5-turbo",
        messages=[
            {"role": "system", "content": f"Translate the following text to {language}:"},
            {"role": "user", "content": text},
        ],
        max_tokens=1000
    )
    str_response = str(response.choices[0].message.content)
    return str_response

@contextmanager
def get_db_session():
    session = next(get_db())
    try:
        yield session
    finally:
        session.close()

async def process_translations(request_id:int,text:str,languages:List[str]):
    with get_db_session() as session:
        list_of_languages = languages.split(",")
        for language in list_of_languages:
            translated_text = translate_text(text,language)
            translation_result = TranslationResponse(request_id=request_id,translated_text=translated_text,language=language,response="")
            individual_translation = IndividualTranslations(request_id=request_id,translated_text=translated_text)
            session.add(translation_result)
            session.add(individual_translation)
            session.commit()
        request = session.query(TranslationRequest).filter(TranslationRequest.id==request_id).first()
        request.status = "completed"
        request.updated_at = datetime.now()
        session.add(request)
        session.commit()
