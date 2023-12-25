import React from "react";
import ReactDOM from "react-dom/client";
import asabenehImage from "./images/asabeneh.jpg";

const Numbers = ({ numbers }) => {
  const list = numbers.map((num) => <li key={num}>{num}</li>);
  return list;
};

const skills = [
  ["HTML", 10],
  ["CSS", 7],
  ["JavaScript", 9],
  ["React", 8],
];
// Skill Component
const Skill = ({skill:[tech,level]})=>(
  <li>
    {tech} {level}
  </li>
  );
// Skills Component
const Skills = ({skills}) => {
  const skillsList = skills.map((skill) => <Skill skill={skill} />);
  console.log(skillsList);
  return <ul>{skillsList}</ul>;
}


const countries = [
  { name: "Finland", city: "Helsinki" },
  { name: "Sweden", city: "Stockholm" },
  { name: "Denmark", city: "Copenhagen" },
  { name: "Norway", city: "Oslo" },
  { name: "Iceland", city: "Reykjavík" },
];

// Country component
const Country = ({ country: { name, city } }) => {
  return (
    <div>
      <h1>{name}</h1>
      <small>{city}</small>
    </div>
  );
};

// countries component
const Countries = ({ countries }) => {
  const countryList = countries.map((country) => <Country country={country} />);
  return <div>{countryList}</div>;
};

const App = () => {
  const numbers = [1, 2, 3, 4];
  return (
    <div className="container">
      <div>
        <h1>Countries List</h1>
        <Countries countries={countries} />
      </div>
      <div>
        <h1>Skills Level</h1>
        <Skills skills={skills} />
      </div>
      <div>
        <h1>Numbers List</h1>
        <ul>
          {" "}
          <Numbers numbers={numbers} />
        </ul>
      </div>
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
