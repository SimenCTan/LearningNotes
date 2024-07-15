import logging
import os
from io import BytesIO

import requests
# import speech_recognition as sr
from dotenv import load_dotenv
from fastapi import FastAPI, File, Form, HTTPException, Request, UploadFile
from fastapi.middleware.cors import CORSMiddleware
from fastapi.responses import FileResponse, HTMLResponse
from fastapi.staticfiles import StaticFiles
from fastapi.templating import Jinja2Templates
from openai import OpenAI
from PIL import Image
from pydantic import BaseModel
from pydub import AudioSegment

# Load environment variables
load_dotenv()
OPENAI_API_KEY = os.getenv("OPENAI_API_KEY")
openai_client = OpenAI(api_key=OPENAI_API_KEY)

# Initialize FastAPI app
app = FastAPI()

# configure logging
logging.basicConfig(level=logging.INFO)

# mount static files
app.mount("/static", StaticFiles(directory="static"), name="static")

# initialize templates
templates = Jinja2Templates(directory="templates")

# cors middleware
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# ensure the converted_files directory exists
if not os.path.exists("converted_files"):
    os.makedirs("converted_files")

# models
class LyricsPayload(BaseModel):
    lyrics:str

# helper functions
def convert_mp3_to_wav(mp3_path,wav_path):
    """
    convert mp3 file to wav file
    """
    # Check if the file exists
    if not os.path.isfile(mp3_path):
        raise FileNotFoundError(f"The file at {mp3_path} does not exist.")
    try:
        audio = AudioSegment.from_file(file=mp3_path,format="mp4")
        audio.export(wav_path, format="wav")
        logging.info(f"Converted {mp3_path} to {wav_path}")
    except Exception as e:
        logging.error(f"Error converting {mp3_path} to {wav_path}: {e}")
        raise RuntimeError(f"Error converting {mp3_path} to {wav_path}: {e}")

def split_audio(wav_path,chunk_length_ms=60000):
    audio = AudioSegment.from_wav(wav_path)
    chunks = [audio[i:i+chunk_length_ms] for i in range(0,len(audio),chunk_length_ms) ]
    return chunks

def transcribe_audio_chunk(chunk,chunk_index):
    chunk_path = f"chunk_{chunk_index}.wav"
    chunk.export(chunk_path,format="wav")
    try:
        with open(chunk_path,"rb") as audio_file:
            response = openai_client.audio.transcriptions.create(
                model="whisper-1",
                file=audio_file,
                )
            text = response.text
    except Exception as e:
        logging.error(f"Error transcribing chunk {chunk_index}: {e}")
        text=""
    finally:
        os.remove(chunk_path) # remove the chunk file
    return text

def transcribe_wav_to_text(wav_path):
    chunks = split_audio(wav_path)
    full_text = ""
    for i,chunk in enumerate(chunks):
        chunk_text = transcribe_audio_chunk(chunk,i)
        full_text += chunk_text+" "
    logging.info(f"Transcribed {wav_path} to text")
    return full_text.strip()

def summarize_text(text):
    response = openai_client.chat.completions.create(
        model="gpt-3.5-turbo",
        messages=[
            {"role": "system", "content": "you are a helpful assistant."},
            {"role": "user", "content": f"summarize the following text in one sentence: {text}"},
        ],
        max_tokens=200
    )
    return response.choices[0].message.content

# routes
@app.get("/",response_class=HTMLResponse)
async def home(request:Request):
    return templates.TemplateResponse("index.html",{"request":request})

@app.post("/uploadfile/")
async def create_upload_file(file:UploadFile=File(...),language:str=Form(...)):
    # ensure the uploads directory exists
    if not os.path.exists("uploads"):
        os.makedirs("uploads")

    # save the uploaded file
    file_location = f"uploads/{file.filename}"
    with open(file_location,"wb") as f:
        f.write(file.file.read())

    # convert the mp3 file to wav
    wav_file = f"converted_files/{file.filename.replace('.mp3','.wav')}"
    convert_mp3_to_wav(file_location,wav_file)

    # extract lyrics from the converted wav file
    lyrics = transcribe_wav_to_text(wav_file)

    # clean up the uploaded mp3 file
    os.remove(file_location)

    # summarize the lyrics
    summary = summarize_text(lyrics)

    return {"lyrics":lyrics,"summary":summary}

@app.post("/generate_image/")
async def generate_image(payload:LyricsPayload):
    prompt = f"Create an image with the following lyrics: {payload.lyrics}"
    if len(prompt)>1000:
        prompt = prompt[:1000]
    response = openai_client.images.generate(
        model="dall-e-3",
        prompt=prompt,
        n=1,
        size="1024x1024")

    image_url = response.data[0].url
    logging.info(f"Generated image for lyrics: {image_url}")
    image_response = requests.get(image_url)
    image_response.raise_for_status()

    image = Image.open(BytesIO(image_response.content))
    if not os.path.exists("media"):
        os.makedirs("media")
    image_path = os.path.join("media","generated_image.png")
    image.save(image_path)
    logging.info(f"Saved image to {image_path}")
    return {"image_path":image_path}

@app.get("/media/generated_image.png")
async def get_generated_image():
    return FileResponse("media/generated_image.png")
