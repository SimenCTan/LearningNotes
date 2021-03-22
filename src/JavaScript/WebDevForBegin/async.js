function resolveAfter2Seconds(x) {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve(x);
    }, 2000);
  });
}

// async function assigned to a variable
var add1 = async function (x) {
  var a = await resolveAfter2Seconds(20);
  var b = await resolveAfter2Seconds(10);
  return x + a + b;
};

add1(10).then((v) => {
  console.log(v);
});

(async function (x) {
  var a = await resolveAfter2Seconds(20);
  var b = await resolveAfter2Seconds(10);
  return x + (await a) + (await b);
})(10).then((v) => {
  console.log(v);
});
