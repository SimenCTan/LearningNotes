import models
import schemas
import utils
from database import SessionLocal, engine
from fastapi import Depends, FastAPI, Request
from fastapi.templating import Jinja2Templates
from sqlalchemy.orm import Session
from starlette.concurrency import run_in_threadpool

models.Base.metadata.create_all(bind=engine)

app = FastAPI()

# set up jinja2 templates
templates = Jinja2Templates(directory="templates")

# dependency to get db session
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()

@app.get("/")
def home(request: Request):
    return templates.TemplateResponse("index.html", {"request": request})

@app.post("/generate/")
async def generate_content(payload:schemas.GeneratePayload,db:Session=Depends(get_db)):
    generated_text = await run_in_threadpool(utils.get_generated_content,db,payload.topic)
    return {"generated_text":generated_text}

@app.post("/analyze/")
async def analyze_content(payload:schemas.AnalyzePayload,db:Session=Depends(get_db)):
    readability,sentiment = await run_in_threadpool(utils.analyze_content,db,payload.content)
    return {"readability":readability,"sentiment":sentiment}




