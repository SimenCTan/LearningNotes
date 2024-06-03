from fastapi import FastAPI

#run command fastapi dev main.py

# instance
app = FastAPI()

# decorator
@app.get("/")
async def read_root():
    return {"message": "Hello, World"}

# if __name__ == "__main__":
#     import uvicorn
#     uvicorn.run(app, host="0.0.0.0", port=9000)

