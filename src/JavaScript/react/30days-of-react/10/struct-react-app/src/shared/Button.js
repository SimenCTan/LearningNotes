import React from "react";

const Button = ({ text, onClick, style }) => (
  <button onClick={onClick} style={style}>
    {text}
  </button>
);
export default Button;
