const originalString = `
  <div>
    <p>Hey that's <span>somthing</span></p>
  </div>
`;

const strippedString = originalString.replace(/(<([^>]+)>)/gi, "");

console.log(strippedString);

const test = {
  prop: 42,
  func: function () {
    return this.prop;
  },
};
console.log(test.func());

const Rectangle = class {
  constructor(height, width) {
    this.height = height;
    this.width = width;
  }
  area() {
    return this.height * this.width;
  }
};
console.log(new Rectangle(3, 5).area());

("use strict");
function fun() {
  return this;
}
console.log(fun());
console.log(fun.call(2));
console.log(fun.apply(null));
console.log(fun.call(undefined));
console.log(fun.bind(true)());

// 浏览器中执行
// console.log(this === window);
// let a = 37;
// console.log(window.a);
// this.b = "abc";
// console.log(window.b);
// console.log(b);
function f1() {
  return this;
}
console.log(f1() === globalThis);

function f2() {
  "use strict";
  return this;
}
console.log(f2() === undefined);
class exmaple {
  constructor() {
    const proto = Object.getPrototypeOf(this);
    console.log(Object.getOwnPropertyNames(proto));
  }
  first() {}
  second() {}
  static third() {}
}
// const newExmaple = new exmaple();

// this 在 类 中的表现与在函数中类似，因为类本质上也是函数，但也有一些区别和注意事项。

// 在类的构造函数中，this 是一个常规对象。类中所有非静态的方法都会被添加到 this 的原型中：
class Base {}
class Good extends Base {}
class AlsoGood extends Base {
  constructor() {
    return { a: 5 };
  }
}
class Bad extends Base {
  constructor() {
    super();
  }
}
new Good();
new AlsoGood();
new Bad();

// 在非严格模式下使用 call 和 apply 时，如果用作 this 的值不是对象，则会被尝试转换为对象。null 和 undefined 被转换为全局对象。原始值如 7 或 'foo' 会使用相应构造函数转换为对象。因此 7 会被转换为 new Number(7) 生成的对象，字符串 'foo' 会转换为 new String('foo') 生成的对象。
function add(c, d) {
  return this.a + this.b + c + d;
}
var o = { a: 1, b: 2 };
console.log(add.call(o, 3, 4));
console.log(add.apply(o, [3, 4]));

// ECMAScript 5 引入了 Function.prototype.bind()。调用f.bind(someObject)会创建一个与f具有相同函数体和作用域的函数，但是在这个新函数中，this将永久地被绑定到了bind的第一个参数，无论这个函数是如何被调用的。
function f() {
  return this.a;
}
var g = f.bind({ a: "bingfun" });
console.log(g());
var h = g.bind({ a: "can not bind" });
console.log(h());
var obj = { a: 37, f: f, g: g, h: h };
console.log(obj.a, obj.f(), obj.g(), obj.h());

// 对于在对象原型链上某处定义的方法，同样的概念也适用。如果该方法存在于一个对象的原型链上，那么 this 指向的是调用这个方法的对象，就像该方法就在这个对象上一样。
var latestobj = {
  f: function () {
    return this.a + this.b;
  },
  c: "gogo",
};
var newLatestObj = Object.create(latestobj);
newLatestObj.a = 1;
newLatestObj.b = 2;
console.log(newLatestObj.f());

//再次，相同的概念也适用于当函数在一个 getter 或者 setter 中被调用。用作 getter 或 setter 的函数都会把 this 绑定到设置或获取属性的对象。
function sum() {
  return this.a + this.b + this.c;
}
var o = {
  a: 1,
  b: 2,
  c: 3,
  get average() {
    return (this.a + this.b + this.c) / 3;
  },
};

Object.defineProperty(o, "sum", {
  get: sum,
  enumerable: true,
  configurable: true,
});
console.log(o.average, o.sum);

// 当函数被用作事件处理函数时，它的 this 指向触发事件的元素（一些浏览器在使用非 addEventListener 的函数动态地添加监听函数时不遵守这个约定）。
function bluify(e) {
  console.log(this === e.currentTarget);
  console.log(this === e.Target);
  this.Style.backgroundColor = "#A5D9F3";
}

// 将bluify作为元素的点击监听函数，当元素被点击时，就会变成蓝色
// var elements = document.getElementsByTagName("*");
// for (var i = 0; i < elements.length; i++) {
//   elements[i].addEventListener("click", bluify, false);
// }

let functionName = function factorial(n) {
  if (n <= 2) {
    return 1;
  }
  return factorial(n - 2) + factorial(n - 1);
};
console.log(functionName(10));
console.log(functionName.name);
