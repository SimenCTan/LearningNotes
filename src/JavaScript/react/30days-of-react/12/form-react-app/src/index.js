// index.js
import React, { Component } from "react";
import ReactDOM from "react-dom";

class App extends Component {
  constructor() {
    super();
  }
  state = {
    fristName: "",
    lastName:'',
    country:'',
    title:''
  };
  handleChange = (e) => {
    const {name,value} = e.target;
    this.setState({ [name]: value });
  };
  handleSubmit=(e)=>{
    e.preventDefault();
    console.log(this.state)
  }
  render() {
    const {firstName,lastName,title,country }= this.state;
    return (
      <div className="App">
        <h3>Add Student</h3>
        <form>
          <div>
            <input
              type="text"
              name="firstName"
              placeholder="firstName"
              value={firstName}
              onChange={this.handleChange}
            />
          </div>
          <div>
            <input
              type="text"
              name="lastName"
              placeholder="lastName"
              value={lastName}
              onChange={this.handleChange}
            />
          </div>
          <div>
            <input
              type="text"
              name="country"
              placeholder="Country"
              value={country}
              onChange={this.handleChange}
            />
          </div>
          <div>
            <input
              type="text"
              name="title"
              placeholder="Title"
              value={title}
              onChange={this.handleChange}
            />
          </div>
          <button>Submit</button>
        </form>
      </div>
    );
  }
}

const rootElement = document.getElementById("root");
ReactDOM.render(<App />, rootElement);
