import os
import threading
from concurrent.futures import ThreadPoolExecutor

import curd
import models
from dotenv import load_dotenv
from openai import OpenAI
from sqlalchemy.orm import Session

# load environment variables from .env file
load_dotenv()

OPENAI_API_KEY = os.getenv("OPENAI_APIKEY")
openai_client = OpenAI(api_key=OPENAI_API_KEY)

# define a semphore to limit the number of concurrent threads
semaphore = threading.Semaphore(5)

def get_generated_content(db:Session,topic:str)->str:
    with semaphore:
        search_term = curd.get_search_term(db=db,term=topic)
        if not search_term:
            search_term = curd.create_search_term(db=db,term=topic)
        response = openai_client.chat.completions.create(
            model="gpt-3.5-turbo",
            messages=[
                {"role":"system","content":"You are a helpful assistant."},
                {"role":"user","content":f"write a detailed article about {topic}"}
                ])
        generated_content = response.choices[0].message.content
        curd.create_generated_content(db=db,content=generated_content,search_term_id=search_term.id)
        return generated_content

def analyze_content(db:Session,content:str):
    with semaphore:
        search_term = curd.get_search_term(db=db,term=content)
        if not search_term:
            search_term = curd.create_search_term(db=db,term=content)
        readability = get_readability(content)
        sentiment = get_sentiment_analysis(content)
        curd.create_sentiment_analysis(db=db,readability=readability,sentiment=sentiment,search_term_id=search_term.id)
        return readability,sentiment


def get_readability(content:str)->str:
    # simulate readability score for the example
    # replace this with actual readability api call if available
    return f"Readability score: Good"

def get_sentiment_analysis(content:str)->str:
    response = openai_client.chat.completions.create(
        model="gpt-3.5-turbo",
        messages=[
            {"role":"system","content":"You are a helpful assistant."},
            {"role": "user", "content": f"Analyze the sentiment of the following text:\n\n{content}\n\nIs the sentiment positive, negative, or neutral?"},
            ],
            max_tokens=20)
    return response.choices[0].message.content
