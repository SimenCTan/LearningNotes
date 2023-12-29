import React, { useState, useRef } from "react";
import ReactDOM from "react-dom";

const App = () => {
  const [count, setCount] = useState(0);
  const ref = useRef(null);
  const h3Ref = useRef(null);
  const onClick = () => {
    let value = ref.current.value;
    console.log(h3Ref.current.textContent);
    h3Ref.current.style.backgroundColor = "#61dbfb";
    h3Ref.current.style.padding = "50px";
    h3Ref.current.style.textAlign = "center";
    alert(value);
    ref.current.focus();
  };
  return (
    <div>
      <h3 ref={h3Ref}>How to use data from uncontrolled input using useRef</h3>
      <input type="text" ref={ref} />
      <br />
      <button onClick={onClick}>Add one</button>
      <button onClick={() => setCount(count - 1)}>Minus One</button>
    </div>
  );
};

const rootElement = document.getElementById("root");
ReactDOM.render(<App />, rootElement);
