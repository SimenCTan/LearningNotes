# let's import the flask
from flask import Flask, render_template
import os # importing operating system module
from pymongo import MongoClient

MONGODB_URI='mongodb://admin:6KqpLbIT7j@localhost:27017/admin'
client = MongoClient(MONGODB_URI)
db = client['thirty_days_of_python'] # accessing the database
query = {
    "country":"Finland"
}
students = db.students.find(query)

for student in students:
    print(student)

app = Flask(__name__)

@app.route('/')
def home():
    return '<h1>Welcome</h1>'

if __name__ == '__main__':
    # for deployment we use the environ
    # to make it work for both production and development
    port = int(os.environ.get("PORT", 5000))
    app.run(debug=True, host='0.0.0.0', port=port)
