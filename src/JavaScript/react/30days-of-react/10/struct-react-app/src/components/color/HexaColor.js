import React from "react";
import { hexaColor } from "../../utils/generate-color";

const HexaColor = (props) => {
  return (
    <div style={{ textAlign: "center", border: "2px solid", height: 50 }}>
      {hexaColor()}
    </div>
  );
};

HexaColor.prototype = {};
export default HexaColor;
