var firstname = "you";
let lastname = "her";
const PI = 3.14;
console.log(firstname + lastname);

const arr = [
  "test",
  20,
  { country: "China", city: "ShenZhen" },
  { skills: ["HTML", "JS", "VUE"] },
];

console.log(arr);

const eightXvalues = Array(8).fill("X");
console.log(eightXvalues);

const firstList = [1, 2, 3];
const secondList = [4, 5, 6];
const thirdList = firstList.concat(secondList);
console.log(thirdList);

console.log(thirdList.indexOf(3))

const numbers = [1, 2, 3, 4, 5];
// console.log(numbers.slice());
// console.log(numbers.slice(0));
// console.log(numbers.slice(1,4));
console.log(numbers.splice(3, 3, 7, 8, 9));
console.log(numbers);

const addarr = ["item1", "item2", "item3"];
addarr.push("new item");
console.log(addarr);
addarr.pop();
console.log(addarr);
addarr.shift();
console.log(addarr);
addarr.unshift("unshift");
console.log(addarr);
