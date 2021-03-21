let myTrueBool = true;
let myFalseBool = false;

if (myTrueBool) {
  console.log("print true");
} else {
  console.log("print false");
}

let currentMoney;
let laptopPrice;
let laptopDiscountPrice = laptopPrice - laptopPrice * 0.2;
if (currentMoney >= laptopPrice || currentMoney >= laptopDiscountPrice) {
  console.log("Getting a new laptop");
} else {
  console.log("can not afford a new laptop, yet!");
}

let firstNumber = 20;
let secondNumber = 10;
let biggestNumber = firstNumber > secondNumber ? firstNumber : secondNumber;

const status = 2000;
let isEqual = status === 2000 ? console.log("ok") : console.log("error");
