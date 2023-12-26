import React, { Fragment } from "react";
import Header from "./components/header/Header";
import Main from "./components/main/Main";
import Footer from "./components/footer/Footer";
import { countriesData } from "./data/countries";
import asabenehImage from "./images/asabeneh.jpg";
import { showTime } from "./utils/display-time";

const Skills = () => {
  return (
    <React.Fragment>
      <li>HTML</li>
      <li>CSS</li>
      <li>JavaScript</li>
    </React.Fragment>
  );
};

const RequiredSkills = () => {
  return (
    <ul>
      <Skills />
    </ul>
  );
};

class App extends React.Component {
  state = {
    loggedIn: false,
    techs: ["HTML", "CSS", "JS"],
    message: "Click show time or Greet people to change me",
    country: countriesData[1],
  };
  handleLogin = () => {
    this.setState({
      loggedIn: !this.state.loggedIn,
    });
  };
  handleTime = () => {
    let message = showTime(new Date());
    this.setState({ message });
  };
  greetPeople = () => {
    let message = "Welcome to 30 Days Of React Challenge, 2020";
    this.setState({ message });
  };

  render() {
    const data = {
      welcome: "30 Days Of React",
      title: "Getting Started React",
      subtitle: "JavaScript Library",
      author: {
        firstName: "Asabeneh",
        lastName: "Yetayeh",
      },
      date: new Date(),
    };
    const techs = ["HTML", "CSS", "JavaScript"];
    const user = { ...data.author, image: asabenehImage };
    return (
      <div className="app">
        {this.state.backgroundColor}
        <Header data={data} />
        <Main
          techs={techs}
          handleTime={this.handleTime}
          greetPeople={this.greetPeople}
          loggedIn={this.state.loggedIn}
          handleLogin={this.handleLogin}
          message={this.state.message}
          country={this.state.country}
          user={user}
        />

        <Footer date={new Date()} />
      </div>
    );
  }
}

export default App;
