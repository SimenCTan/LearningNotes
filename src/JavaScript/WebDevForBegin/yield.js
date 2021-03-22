function* countAppleSales() {
  var saleList = [3, 5, 7];
  for (var i = 0; i < saleList.length; i++) {
    yield saleList[i];
  }
}
var appleStore = countAppleSales();
console.log(appleStore.next());
console.log(appleStore.next());
console.log(appleStore.next());
console.log(appleStore.next());

function* g1() {
  yield 2;
  yield 3;
  yield 4;
}
function* g2() {
  yield 1;
  yield* g1();
  yield 5;
}
var iterator = g2();
for (const val of iterator) {
  console.log(val);
}

function* g3() {
  yield* [1, 2];
  yield* "34";
  yield* arguments;
}
var iterator3 = g3(5, 6);
console.log(iterator3.next());
console.log(iterator3.next());
console.log(iterator3.next());
console.log(iterator3.next());
console.log(iterator3.next());
console.log(iterator3.next());
console.log(iterator3.next());
