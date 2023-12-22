const countries = ["Finland", "Sweden", undefined, "Norway"];
const [fin, swe, ice = "Iceland", nor, den = "Denmark"] = countries;
console.log(fin, swe, ice, nor, den); // Finland, Sweden, Iceland, Norway, Denmark
const [finskip, , sweskip, icskip] = countries;
console.log(finskip, sweskip, icskip);
const nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
const [num1, num2, num3, ...rest] = nums;
console.log(num1, rest);

const fullStack = [
  ["HTML", "CSS", "JS", "React"],
  ["Node", "Express", "MongoDB"],
];

for (const [first, second, third, fourth] of fullStack) {
  console.log(first, second, third, fourth);
}

const [x, y] = [2, (value) => value ** 2];

const rectangle = {
  width: 20,
  height: 10,
};

const { width: w, height: h } = rectangle;
console.log(w, h);

const props = {
  user: {
    firstName: "Asabeneh",
    lastName: "Yetayeh",
    age: 250,
  },
  post: {
    title: "Destructuring and Spread",
    subtitle: "ES6",
    year: 2020,
  },
  skills: ["JS", "React", "Redux", "Node", "Python"],
};

const { user, post, skills } = props;
const { firstName, lastName, age } = user;
const { title, subtitle, year } = post;
const [skillOne, skillTwo, skillThree, skillFour, skillFive] = skills;

const languages = [
  { lang: "English", count: 91 },
  { lang: "French", count: 45 },
  { lang: "Arabic", count: 25 },
  { lang: "Spanish", count: 24 },
  { lang: "Russian", count: 9 },
  { lang: "Portuguese", count: 9 },
  { lang: "Dutch", count: 8 },
  { lang: "German", count: 7 },
  { lang: "Chinese", count: 5 },
  { lang: "Swahili", count: 4 },
  { lang: "Serbian", count: 4 },
];

for (const { lang, count } of languages) {
  console.log(`The ${lang} is spoken in ${count} countries.`);
}

const evens = [0, 2, 4, 6, 8, 10];
const evenNumbers = [...evens];

const odds = [1, 3, 5, 7, 9];
const oddNumbers = [...odds];

const wholeNumbers = [...evens, ...odds];

console.log(evenNumbers);
console.log(oddNumbers);
console.log(wholeNumbers);
