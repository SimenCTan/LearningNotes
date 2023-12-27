// index.js
import React, { Component } from "react";
import ReactDOM from "react-dom";

class App extends Component {
  firstName = React.createRef();
  lastName = React.createRef();
  country = React.createRef();
  title = React.createRef();
  handleSubmit = (e) => {
    e.preventDefault();
    console.log(this.firstName.current.value);
    console.log(this.lastName.current.value);
    console.log(this.title.current.value);
    console.log(this.country.current.value);
    const data = {
      firstName: this.firstName.current.value,
      lastName: this.lastName.current.value,
      title: this.title.current.value,
      country: this.country.current.value,
    };
    // the is the place we connect backend api to send the data to the database
    console.log(data);
  };
  render() {
    return (
      <div className="App">
        <form onSubmit={this.handleSubmit} noValidate>
          <div>
            <label htmlFor="firstName">First Name</label>
            <input
              type="text"
              id="firstName"
              name="firstName"
              placeholder="firstname"
              ref={this.firstName}
            />
          </div>
          <div>
            <input
              type="text"
              name="lastName"
              placeholder="Last Name"
              ref={this.lastName}
              onChange={this.handleChange}
            />
          </div>
          <div>
            <input
              type="text"
              name="country"
              placeholder="Country"
              ref={this.country}
              onChange={this.handleChange}
            />
          </div>
          <div>
            <input
              type="text"
              name="title"
              placeholder="Title"
              ref={this.title}
              onChange={this.handleChange}
            />
          </div>
          <button type="submit">Submit</button>
        </form>
      </div>
    );
  }
}

const rootElement = document.getElementById("root");
ReactDOM.render(<App />, rootElement);
