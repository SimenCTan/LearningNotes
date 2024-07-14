from pydantic import BaseModel


class TranslationRequestSchema(BaseModel):
    text: str
    languages:str

    class Config:
        json_schema_extra = {
            "example": {
                "text": "Hello, how are you?",
                "languages": "english, german, russian"
            }
        }
