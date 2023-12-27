// index.js
import React, { Component } from "react";
import ReactDOM from "react-dom";
import Header from "./components/Header";
import axios from "axios";

class App extends Component {
  constructor(props) {
    super();
    this.state = {
      data: [],
    };
  }

  componentDidMount() {
    const API_URL = "https://restcountries.eu/rest/v2/all";
    axios
      .get(API_URL)
      .then((response) => {
        this.setState({ data: response.data });
      })
      .catch((error) => {
        console.log(error);
      });
  }

  renderCountries = () => {
    return this.state.data.map((country) => {
      const languageOrLanguages =
        country.languages.length > 1 ? "Langauges" : "Language";
      const formatLanguages = country.languages
        .map(({ name }) => name)
        .join(", ");
      return (
        <div>
          <div>
            {" "}
            <img src={country.flag} alt={country.name} />{" "}
          </div>
          <div>
            <h1>{country.name}</h1>
            <p>Capital: {country.capital}</p>
            <p>
              {languageOrLanguages}: {formatLanguages}
            </p>
            <p>Population: {country.population}</p>
          </div>
        </div>
      );
    });
  };

  render() {
    return (
      <div className="App">
        <Header />
        <h1>Fetching Data Using Axios</h1>
        <div>
          <p>There are {this.state.data.length} countries in the api</p>
          <div className="countries-wrapper">{this.renderCountries()}</div>
        </div>
      </div>
    );
  }
}

const rootElement = document.getElementById("root");
ReactDOM.render(<App firstName="Derived State" />, rootElement);
