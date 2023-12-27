// index.js
import React, { Component } from "react";
import ReactDOM from "react-dom";

class App extends Component {
  constructor() {
    super();
  }
  state = {
    fristName: "",
  };
  handleChange = (e) => {
    const value = e.target.value;
    this.setState({ firstName: value });
  };
  render() {
    const firstName = this.state.fristName;
    return (
      <div className="App">
        <label htmlFor="firstName">First Name: </label>
        <input
          type="text"
          id="firstName"
          name="firstName"
          placeholder="First Name"
          value={firstName}
          onChange={this.handleChange}
        />
        <h1>{this.state.firstName}</h1>
      </div>
    );
  }
}

const rootElement = document.getElementById("root");
ReactDOM.render(<App />, rootElement);
