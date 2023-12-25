import React from "react";
import ReactDOM from "react-dom/client";

const getUserInfo = (firstName, lastName, country) => {
  return `${firstName} ${lastName}. Lives in ${country}.`;
};

// calling a functons
getUserInfo("Asabeneh", "Yeteyeh", "Finland");


// Function to display time in Mon date, year format eg Oct 4, 2020
const showDate = (time) => {
  const months = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
  ];

  const month = months[time.getMonth()].slice(0, 3);
  const year = time.getFullYear();
  const date = time.getDate();
  return ` ${month} ${date}, ${year}`;
};


// simple component
const ClickButton = (props) => (
  <button onClick={props.onClick}>{props.text}</button>
);

// User component, component should start with an uppercase
const User = (props) => {
  return (
    <div>
      <h1>
        {props.firstName}
        {props.lastName}
      </h1>
      <small>{props.country}</small>
    </div>
  );
};
const Age = (props) => <div>The person is {props.age} years old.</div>;
const Weight = (props) => (
  <p>The weight of the object on earth is {props.weight} N.</p>
);
const Status = (props) => {
  // ternary operator to check the status of the person
  let status = props.status ? "Old enough to drive" : "Too young for driving";
  return <p>{status}</p>;
};
// const Skills = (props) =>{
//   const skillsList = props.skills.map((skill)=> <li>{skill}</li>);
//   return <ul>skillsList</ul>;
// }

// Skills Component
const Skills = (props) => {
  // modifying the skills array
  const skillList = props.skills.map((skill) => <li>{skill}</li>);
  return <ul>{skillList}</ul>;
};
// Header Component
// JSX element, header
// const welcome = 'Welcome to 30 Days Of React'
// const title = 'Getting Started React'
// const subtitle = 'JavaScript Library'
// const author = {
//   firstName: 'Asabeneh',
//   lastName: 'Yetayeh',
// }
// const date = 'Oct 2, 2020'
const Header = (props) => {
  console.log(props);
  return (
    <header>
      <div className="header-wrapper">
        <h1>{props.welcome}</h1>
        <h2>{props.title}</h2>
        <h3>{props.subtitle}</h3>
        <p>
          {props.firstName} {props.lastName}
        </p>
        <small>{props.date}</small>
      </div>
    </header>
  );
};

const App = () => {
  const welcome = "Welcome to 30 Days Of React";
  const title = "Getting Started React";
  const subtitle = "JavaScript Library";
  const firstName = "Asabeneh";
  const lastName = "Yetayeh";
  const date = "Oct 4, 2020";
  let currentYear = 2020;
  let birthYear = 1820;
  const age = currentYear - birthYear;
  const gravity = 9.81;
  const mass = 75;
  const skills = ["HTML", "CSS", "JavaScript"];
  let status = age >= 18;
  const sayHi=()=>{
    alert('Hi');
  };
 const handleTime = () => {
   alert(showDate(new Date()));
 };
 const greetPeople = () => {
   alert("Welcome to 30 Days Of React Challenge, 2020");
 };
  return (
    <div className="app">
      <Header
        welcome={welcome}
        title={title}
        subtitle={subtitle}
        firstName={firstName}
        lastName={lastName}
        date={date}
      />
      <Age age={age} />
      <Weight weight={gravity * mass} />
      <Status status={status} />
      <Skills skills={skills} />
      <ClickButton text="show time" onClick={handleTime} />
      <ClickButton text="Greet People" onClick={greetPeople} />
    </div>
  );
};

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    {/* <User firstName = 'Asabeneh' lastName='Yetayeh' country = 'Finland' /> */}
    {<App />}
  </React.StrictMode>
);
