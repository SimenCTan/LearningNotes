// index.js
import React,{Component} from "react";
import ReactDOM from "react-dom";
import {BrowserRouter,Route,NavLink,Switch,Redirect,Prompt,withRouter} from 'react-router-dom'

class App extends Component {
  render(){
    return (
      <BrowserRouter>
        <div className="App">
          <h1>React Router DOM</h1>
        </div>
      </BrowserRouter>
    );
  }
}


const rootElement = document.getElementById("root");
ReactDOM.render(<App />, rootElement);
