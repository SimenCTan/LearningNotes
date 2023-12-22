for (var i = 0; i < 7; i++) {
  console.log(i);
}

let sum = 0;
for (let i = 0; i < 101; i++) {
  sum += i;
}

console.log(sum);
let count = 5;
while (count > 0) {
  console.log(count);
  count--;
}

do {
  console.log(count);
  count++;
} while (count < 11);

const countries = ["Finland", "Sweden", "Norway", "Denmark", "Iceland"];
for (const country in countries) {
  console.log(country);
}
for (const country of countries) {
  console.log(country);
}
countries.forEach((country, i) => {
  console.log(i, country.toLowerCase());
});
