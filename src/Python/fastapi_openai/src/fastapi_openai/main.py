import logging

import models
from database import get_db
from fastapi import BackgroundTasks, Depends, FastAPI, HTTPException, Request
from fastapi.middleware.cors import CORSMiddleware
from fastapi.responses import HTMLResponse
from fastapi.templating import Jinja2Templates
from models import TranslationRequest, TranslationResponse
from schemas import TranslationRequestSchema
from sqlalchemy.orm import Session
from utils import process_translations, translate_text

models.Base.metadata.create_all(models.engine)
app = FastAPI()

# Configure logging
logging.basicConfig(level=logging.INFO)


# add cors middleware
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

templates = Jinja2Templates(directory="templates")

@app.get("/index",response_class=HTMLResponse)
async def read_index(request: Request):
    return templates.TemplateResponse("index.html", {"request": request})


@app.post("/translate")
async def translate(request:TranslationRequestSchema,background_tasks:BackgroundTasks,db:Session=Depends(get_db)):
    print(request.text)
    print(request.languages)

    # requests above is a pydantic model,my_dict below is a dictionary,incase you need to use one or another
    my_dict = request.model_dump()
    print(my_dict)

    request_data = TranslationRequest(text=request.text,languages=request.languages)
    db.add(request_data)
    db.commit()
    db.refresh(request_data)
    background_tasks.add_task(process_translations,request_data.id,request_data.text,request_data.languages)
    return {"payload":request_data}

@app.get("/translate/{request_id}")
async def get_translation_status(request_id:int,request:Request,db:Session=Depends(get_db)):
    request_obj = db.query(TranslationRequest).filter(TranslationRequest.id==request_id).first()
    if not request_obj:
        raise HTTPException(status_code=404,detail="Request not found")
    if request_obj.status == "in progress":
        return {"status":request_obj.status}
    translations = db.query(TranslationResponse).filter(TranslationResponse.request_id==request_id).all()
    return templates.TemplateResponse("results.html",{"request":request,"translations":translations})

