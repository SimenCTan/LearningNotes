from sqlalchemy import create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker
import os
from dotenv import load_dotenv

# load environment variables from .env file
load_dotenv()

# get database url from environment variables
DATABASE_URL = os.getenv("DATABASE_URL")

# create a database engine
engine = create_engine(DATABASE_URL)

# create a session maker
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)

# create a base class for our models to inherit from
Base = declarative_base()
