var o = {};
var o = { a: "foo", b: 42, c: {} };
var a = "foo",
  b = 42,
  c = {};
var o = { a: a, b: b, c: c };
var o = {
  property: function ([parameters]) {},
  get property() {},
  set property(value) {},
};

// Shorthand property names
var a = "foo",
  b = 42,
  c = {};
var o = { a, b, c };

// Shorthand method names
var o = {
  property([parameters]) {},
};

// Computed property name
var prop = "foo";
var o = {
  [prop]: "hey",
  ["b" + "ar"]: "there",
};

// object
let objEmpty = {};
let objValue = {
  foo: "bar",
  age: 42,
  baz: { myProp: 12 },
};

console.log(objValue.foo);
console.log(objValue["age"]);
objValue.foo = "abc";
console.log(objValue.foo);

// 属性定义
var a = "foo",
  b = 1,
  c = {};
var objProperty = { a, b, c };
console.log(objProperty.a);

// computor property
let i = 0;
var objComputor = {
  ["foo" + ++i]: i,
  ["foo" + ++i]: i,
  ["foo" + ++i]: i,
};

console.log(objComputor.foo1);
console.log(objComputor.foo2);
console.log(objComputor.foo3);

// clone obj
var cloneObj = { ...objComputor };
var mergedObj = { ...objEmpty, ...objProperty };
