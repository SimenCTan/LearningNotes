import React,{Fragment} from "react";

const Skills = ()=>{
    return (
      <React.Fragment>
        <li>HTML</li>
        <li>CSS</li>
        <li>JavaScript</li>
      </React.Fragment>
    );
}

const RequiredSkills = () => {
  return (
    <ul>
      <Skills />
    </ul>
  );
};
const App = () =>{
    return (
      <div>
        <h1>Welcome to 30 Days Of React</h1>
        <RequiredSkills/>
      </div>
    );}
function AppFun() { return <h1>Func to 30 Days Of React</h1>};

export default App
