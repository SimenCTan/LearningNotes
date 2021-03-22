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
