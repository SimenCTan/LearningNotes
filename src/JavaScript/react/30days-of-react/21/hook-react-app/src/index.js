import React, { useState } from "react";
import ReactDOM from "react-dom";

const App =()=>{
  const [count,setCount]=useState(0);
  return (
    <div>
      <h3>{count}</h3>
      <button onClick={() => setCount(count + 1)}>Add one</button>
      <button onClick={() => setCount(count - 1)}>Minus One</button>
    </div>
  );
}

const rootElement = document.getElementById("root");
ReactDOM.render(<App/>,rootElement);
