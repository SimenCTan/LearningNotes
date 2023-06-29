from flask import Flask,render_template,request, redirect, url_for
import os

app = Flask(__name__)
# to stop caching static file
app.config['SEND_FILE_MAX_AGE_DEFAULT'] = 0

@app.route('/')
def home():
    techs = ['HTML', 'CSS', 'Flask', 'Python']
    name = '30 Days Of Python Programming'
    return render_template('home.html',techs=techs,name=name,title='Post')

@app.route('/about')
def about():
    name = '30 Days Of Python Programming'
    return render_template('about.html',name=name,title='About me')

@app.route('/post', methods= ['GET','POST'])
def post():
    name = 'Text Analyzer'
    if request.method == 'GET':
         return render_template('post.html', name = name, title = name)
    if request.method =='POST':
        content = request.form['content']
        print(content)
        return redirect(url_for('/about'))

if __name__=='__main__':
    port = int(os.environ.get('PORT',5000))
    app.run(debug=True,host='0.0.0.0',port=port)
