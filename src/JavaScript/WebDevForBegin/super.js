class Polygon {
  constructor(height, width) {
    this.name = "Rectangle";
    this.height = height;
    this.width = width;
  }
  sayName() {
    console.log("Hi,I am a", this.name + ".");
  }
  get area() {
    return this.height * this.width;
  }
  set area(value) {
    this._area = value;
  }
  static logNbSides() {
    return "I have 4 sides";
  }
}

class Square extends Polygon {
  constructor(length) {
    super(length, length);
    this.name = "Square";
  }
  static logDescription() {
    return super.logNbSides();
  }
}

// 调用父类上的静态方法
console.log(Square.logDescription());
console.log(Square.logNbSides());

var obj1 = {
  method1() {
    console.log("method 1");
  },
};

var obj2 = {
  method2() {
    super.method1();
  },
};

Object.setPrototypeOf(obj2, obj1);
obj2.method2();
