import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom";
import axios from "axios";

const Country = ({ country: { name, flag, population, currency } }) => {
  return (
    <div className="country">
      <div className="country_flag">
        <img src={flag} alt={name} />
      </div>
      <h3 className="country_name">{name.toUpperCase()}</h3>
      <div class="country_text">
        <p>
          <span>Population: </span>
          {population}
        </p>
        <p>
          <span>Currency: </span>
          {currency}
        </p>
      </div>
    </div>
  );
};

const App = (props) => {
  const [data, setData] = useState([]);
  const fetchCountryData = async () => {
     const url = "https://restcountries.eu/rest/v2/all";
     try {
       const response = await axios.get(url);
       const data = await response.data;
       this.setState({
         data,
       });
     } catch (error) {
       console.log(error);
     }
   };
  useEffect(() => {
    fetchCountryData();
  }, []);

  return (
    <div className="App">
      <h1>Fetching Data Using Hook</h1>
      <h1>Calling API</h1>
      <div>
        <p>There are {data.length} countries in the api</p>
        <div className="countries-wrapper">
          {data.map((country) => (
            <Country country={country} />
          ))}
        </div>
      </div>
    </div>
  );
};

const rootElement = document.getElementById("root");
ReactDOM.render(<App />, rootElement);
