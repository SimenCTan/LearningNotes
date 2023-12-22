function square(number) {
  return number * number;
}
console.log(square(10));

const areaOfCircle = (radius) => {
  let area = Math.PI * radius * radius;
  return area;
};

console.log(areaOfCircle(10));

const sumAllNums = (...args) => {
  let sum = 0;
  for (let item of args) {
    sum += item;
  }
  return sum;
};
console.log(sumAllNums(1, 2, 3, 4, 5));

const anonymousFun = function () {
  console.log(
    "I am an anonymous function and my value is stored in anonymousFun"
  );
};

const squareNum = (function (num) {
  return num * num;
})(10);
console.log(squareNum);

const callback = function (n) {
  return n ** 2;
};

function cube(callback, n) {
  return callback(n) * n;
}

console.log(cube(callback, 10));

const numbers = [1, 2, 3, 4];
const sumArray = (arr) => {
  let sum = 0;
  arr.forEach(function (element) {
    sum += element;
  });
  return sum;
};
console.log(sumArray(numbers));

setInterval(console.log("Say hi interval"), 2000);

function sayHello() {
  console.log("Hello");
}
setInterval(sayHello, 2000);
setTimeout(sayHello,1000);

const testcountries = ['Finland', 'Estonia', 'Sweden', 'Norway', 'Iceland']
const countriesWithLand = testcountries.filter(
  (country) => !country.includes('land')
)
console.log(countriesWithLand) // ["Estonia", "Sweden", "Norway"]

const countriesLength = testcountries.map((country) => country.length);
console.log(countriesLength);

const newCountries = [];
testcountries.forEach((country) => newCountries.push(country));
console.log(newCountries);

var allCountries = newCountries.reduce((acc,cuu)=>`${acc} ${cuu}`);
console.log(allCountries);


const testnumbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
const someAreEvens = testnumbers.some((n) => n % 2 === 0);
const someAreOdds = testnumbers.some((n) => n % 2 !== 0);
console.log(someAreEvens) // true
console.log(someAreOdds) // true
