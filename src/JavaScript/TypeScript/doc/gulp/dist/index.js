"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var greet_1 = require("./greet");
function hello(compiler) {
    console.log("Hello from ".concat(compiler));
}
hello('TypeScript');
console.log((0, greet_1.sayHello)('gulp'));
