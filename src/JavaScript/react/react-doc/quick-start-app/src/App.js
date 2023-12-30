import { useState } from "react";
import logo from "./logo.svg";
import "./App.css";

const products = [
  { title: "Cabbage", isFruit: false, id: 1 },
  { title: "Garlic", isFruit: false, id: 2 },
  { title: "Apple", isFruit: true, id: 3 },
];

const listItems = products.map((product) => (
  <li
    key={product.id}
    style={{ color: product.isFruit ? "magenta" : "darkgreen" }}
  >
    {product.title}
  </li>
));

function MyButton({ count, onClick }) {
  return <button onClick={onClick}>Clicked {count} times</button>;
}

function App() {
  const [count, setCount] = useState(0);
  function handleClick() {
    setCount(count + 1);
  }
  return (
    <div className="App">
      <header className="App-header">
        <ul>{listItems}</ul>
        <MyButton count={count} onClick={handleClick} />
        <MyButton count={count} onClick={handleClick} />
      </header>
    </div>
  );
}

export default App;
