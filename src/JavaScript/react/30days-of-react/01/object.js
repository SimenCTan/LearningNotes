const person = {
  firstName: "Asabeneh",
  lastName: "Yetayeh",
  age: 250,
  country: "Finland",
  city: "Helsinki",
  skills: [
    "HTML",
    "CSS",
    "JavaScript",
    "React",
    "Node",
    "MongoDB",
    "Python",
    "D3.js",
  ],
  getFullName: function () {
    return `${this.firstName}${this.lastName}`;
  },
  getPersonInfo: function () {
    return `${this.firstName} ${this.lastName} country is ${this.country} and city is ${this.city} my phone is ${this["phone number"]}`;
  },
  "phone number": "+3584545454545",
};

// accessing values using .
console.log(person.firstName);
console.log(person.lastName);
console.log(person.age);
console.log(person.location);

// value can be accessed using square bracket and key name
console.log(person["firstName"]);
console.log(person["lastName"]);
console.log(person["age"]);
console.log(person["age"]);
console.log(person["location"]);

// for instance to access the phone number we only use the square bracket method
console.log(person["phone number"]);

const copyPerson = Object.assign({}, person);
console.log(copyPerson);
const keys = Object.keys(copyPerson);
console.log(keys);
const values = Object.values(copyPerson);
console.log(values);
const entries = Object.entries(copyPerson);
console.log(entries);
console.log(copyPerson.hasOwnProperty("name"));
console.log(copyPerson.hasOwnProperty("score"));
