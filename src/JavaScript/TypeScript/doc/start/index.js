var UserAccount = /** @class */ (function () {
    function UserAccount(name, id) {
        this.name = name;
        this.id = id;
    }
    return UserAccount;
}());
var user = new UserAccount("Test", 1);
console.log(user);
function getLength(obj) {
    if (typeof (obj) === "string") {
        return obj.length;
    }
    return obj.length;
}
var object = backpack.get();
backpack.add('23');
function logPoint(p) {
    console.log("".concat(p.x, " ").concat(p.y));
}
var point = { x: 12, y: 18 };
logPoint(point);
var point3 = { x: 12, y: 26, z: 89 };
logPoint(point3);
// const color = { hex: "#187ABF" };
// logPoint(color);
var VirtualPoint = /** @class */ (function () {
    function VirtualPoint(x, y) {
        this.x = x;
        this.y = y;
    }
    return VirtualPoint;
}());
var newVPoint = new VirtualPoint(13, 56);
logPoint(newVPoint); // logs "13, 56"
var anys = [];
anys.push(1);
anys.push('11');
anys.map(anys[1]);
var Three = /** @class */ (function () {
    function Three() {
        this.p = "Hello";
    }
    return Three;
}());
var x = { p: 'hi' };
var two = x;
two = new Three();
function start(arg) {
    if (typeof arg === 'string') {
        return commonCase(arg);
    }
    else if (Array.isArray(arg)) {
        return arg.map(commonCase).join(",");
    }
    else if (typeof arg === "function") {
        return commonCase(arg());
    }
    else {
        return commonCase(arg.s);
    }
    function commonCase(s) {
        return s;
    }
}
pad("hi", 10, "left");
// let s = "right";
// pad("hi", 10, s);
var s = "right";
pad("hi", 10, s);
function area(s) {
    if (s.kind === "circle") {
        return Math.PI * s.radius * s.radius;
    }
    else if (s.kind === "square") {
        return s.x * s.x;
    }
    else {
        return (s.x * s.y) / 2;
    }
}
var shape = { kind: "circle", radius: 12 };
var areaShape = area(shape);
console.log(areaShape);
