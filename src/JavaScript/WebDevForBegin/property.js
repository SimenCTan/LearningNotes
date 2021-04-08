const person1 = {};
person1["fistname"] = "go";
person1["lastname"] = "you";
console.log(person1.fistname);

const person2 = {
  firstname: "go",
  lastname: "you",
};

console.log(person2.lastname);

var foo = { unique_property1: 1 },
  bar = { unique_property2: 2 },
  object = {};
object[foo] = "value";
console.log(object[bar]);
