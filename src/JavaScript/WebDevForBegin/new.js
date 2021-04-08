function car(make, model, year) {
  this.make = make;
  this.model = model;
  this.year = year;
}

const car1 = new car("changan", "sb", 1999);
console.log(car1.year);

const car2 = new car("fute", "sky", 2020);
car.prototype.color = "original color";
console.log(car1.__proto__.color);
car1.color = "black";
console.log(car1.__proto__.color);
console.log(car1.color);
