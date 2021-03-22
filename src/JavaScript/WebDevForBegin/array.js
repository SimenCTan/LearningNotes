var fruits = ["Apple", "Banana"];
console.log(fruits.length);
var first = fruits[0];
console.log(fruits[fruits.length - 1]);
fruits.forEach(function (item, index, array) {
  console.log(item, index);
});

var newLength = fruits.push("Orange");
console.log(fruits.pop());
console.log(fruits.shift());
console.log(fruits.unshift("Strawberry"));
console.log(fruits.indexOf("Banana"));

// 通过索引删除某个元素
var removeItem = fruits.splice(fruits.indexOf("Banana"), 1);

var vegetables = ["Cabbage", "Turnip", "Radish", "Carrot"];
console.log(vegetables);

var pos = 1,
  n = 2;
var removedItems = vegetables.splice(pos, n);

// 复制一个数组
var shallowCopy = fruits.slice();

// JavaScript 数组的 length 属性和其数字下标之间有着紧密的联系。
var newFruits = [];
newFruits.push("apple", "banana", "orange");
newFruits[5] = "mango";
console.log(Object.keys(newFruits));
newFruits.length = 20;
console.log(Object.keys(newFruits));
newFruits.length = 2;
console.log(Object.keys(newFruits));

// regex
var regexMatch = /d(b+)(d)/i;
var myArray = regexMatch.exec("cdbBdbsbz");
myArray.forEach(function (item, index, array) {
  console.log(item, index);
});

function isLetter(character) {
  return character >= "a" && character <= "Z";
}
if (myArray.every(isLetter)) {
  console.log("The string '" + str + "' contains only letters");
}

// 下面这个例子创建了一个长度为 0 的数组 msgArray，然后给 msgArray[0] 和 msgArray[99] 赋值，从而导致数组长度变为了 100。
var msgArray = [];
msgArray[0] = "apple";
msgArray[99] = "go";
if (msgArray.length === 100) {
  console.log("The array length is 100");
}

//用数组将一组值以表格形式显示
var values = [];
for (var x = 0; x < 10; x++) {
  values.push([2 ** x, 2 * x ** 2]);
}
console.table(values);
