import * as React from "react";
import "./Hello.css";

export interface Props {
  name: string;
  enthusiasmLevel?: number;
}

export default function Hello({ name, enthusiasmLevel }: Props) {
  const numEnthusiasmLevel = enthusiasmLevel ?? 1;
  if (numEnthusiasmLevel <= 0) {
    throw new Error("You could be a little more enthusiastic. :D");
  }
  return (
    <div className="hello">
      <div className="greeting">
        Hello {name + getExclamationMarks(numEnthusiasmLevel)}
      </div>
    </div>
  );
}

// helpers

function getExclamationMarks(numChars: number) {
  return Array(numChars + 1).join("!");
}
