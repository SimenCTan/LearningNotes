import os
from datetime import datetime
from typing import List

import openai
from database import get_db
from dotenv import load_dotenv
from models import (IndividualTranslations, TranslationRequest,
                    TranslationResponse)
from sqlalchemy.orm import Session

load_dotenv()
openai.api_key=os.getenv("OPENAI_APIKEY")

async def translate_text(text:str,language:str)->str:
    response = await openai.ChatCompletion.acreate(
        model="gpt-3.5-turbo",
        messages=[
            {"role": "system", "content": f"Translate the following text to {language}:"},
            {"role": "user", "content": text},
        ],
        max_tokens=1000
    )
    return response['choices'][0]['message']['content'].strip()


async def process_translations(request_id:int,text:str,languages:List[str]):
    with get_db() as session:
        for language in languages:
            translated_text = await translate_text(text,language)
            translation_result = TranslationResponse(request_id=request_id,response=translated_text,language=language)
            individual_translation = IndividualTranslations(request_id=request_id,translated_text=translated_text)
            session.add(translation_result)
            session.add(individual_translation)
            session.commit()
        request = session.query(TranslationRequest).filter(TranslationRequest.id==request_id).first()
        request.status = "completed"
        request.updated_at = datetime.now()
        session.add(request)
        session.commit()
