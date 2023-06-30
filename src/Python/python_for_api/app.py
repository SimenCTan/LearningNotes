from flask import Flask,Response
import os
import json
from pymongo import MongoClient

app = Flask(__name__)

MONGODB_URI='mongodb://admin:6KqpLbIT7j@localhost:27017/admin'
client = MongoClient(MONGODB_URI)
db = client['thirty_days_of_python'] # accessing the database
query = {
    "country":"Finland"
}
students = db.students.find(query)

@app.route('/api/v1.0/students', methods = ['GET'])
def students ():
    student_list = []
    for student in students:
        student_list(student)
    return Response(student_list, mimetype='application/json')


if __name__ == '__main__':
    # for deployment
    # to make it work for both production and development
    port = int(os.environ.get("PORT", 5000))
    app.run(debug=True, host='0.0.0.0', port=port)
