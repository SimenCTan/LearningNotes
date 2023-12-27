// index.js
import React, { Component } from "react";
import ReactDOM from "react-dom";

const User = ({ firstName }) => (
  <div>
    <h1>{firstName}</h1>
  </div>
);

class App extends Component {
  constructor(props) {
    super(props);
    console.log("I am  the constructor and  I will be the first to run.");
    this.state = {
      firstName: "John",
      data: [],
      day: 1,
      congratulate: true,
    };
  }

  shouldComponentUpdate(nextProps, nextState) {
    console.log(nextProps, nextState);
    console.log(nextState.day);
    if (nextState.day > 31) {
      return false;
    } else {
      return true;
    }
  }
  // the doChallenge increment the day by one
  doChallenge = () => {
    this.setState({
      day: this.state.day + 5,
      congratulate: this.state.day > 30 ? true : false,
    });
  };
  componentDidMount() {
    console.log("I am componentDidMount and I will be last to run.");
    const API_URL = "https://restcountries.eu/rest/v2/all";

    fetch(API_URL)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        console.log(data);
        this.setState({ data: data });
      })
      .catch((error) => {
        console.log(error);
      });
  }

  componentDidUpdate(prevProps, prevState) {
    console.log(prevProps, prevState);
    if (prevState.day > 30) {
      this.setState({
        congratulate: true,
      });
    }
  }

  renderCountries = () => {
    return this.state.data.map((country) => {
      return (
        <div>
          <div>
            {" "}
            <img src={country.flag} alt={country.name} />{" "}
          </div>
          <div>
            <h1>{country.name}</h1>
            <p>Population: {country.population}</p>
          </div>
        </div>
      );
    });
  };

  render() {
    return (
      <div className="App">
        <h1>React Component Life Cycle</h1>
        <button onClick={this.doChallenge}>Do Challenge</button>
        <p>Challenge: Day {this.state.day}</p>
        {this.state.congratulate && <h2>congratulate</h2>}
      </div>
    );
  }
}

const rootElement = document.getElementById("root");
ReactDOM.render(<App firstName="Derived State" />, rootElement);
