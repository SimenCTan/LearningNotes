// 下面的代码使用类表达式语法创建了一个匿名类，然后赋值给变量 Foo。
let classFoo = class {
  constructor() {}
  bar() {
    return "js class";
  }
};
let instance = new classFoo();
console.log(instance.bar());

// 如果你想在类体内部也能引用这个类本身，那么你就可以使用命名类表达式，并且这个类名只能在类体内部访问。
const nameFoo = class NamedClass {
  constructor() {}
  whoIsThere() {
    return NamedClass.name;
  }
};
console.log(new nameFoo().whoIsThere());
