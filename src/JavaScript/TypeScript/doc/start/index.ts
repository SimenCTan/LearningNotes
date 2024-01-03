interface User {
    name: string;
    id:number
}

class UserAccount {
    name: string;
    id: number;
    constructor(name: string, id: number) {
        this.name = name;
        this.id = id;
    }
}

const user: User = new UserAccount("Test", 1);
console.log(user);

type MyBool = true | false;
type WindowStates = "open" | "closed" | "minimized";
type PositiveOddNumbersUnderTen = 1 | 3 | 5 | 7 | 9;

function getLength(obj: string | string[]) {
    if (typeof (obj) === "string") {
        return obj.length;
    }
    return obj.length;
}

type StringArray = Array<string>;
type NumberArray = Array<number>;
type ObjectWithNameArray = Array<{ name: string }>;


interface Backpack<Type> {
    add: (obj: Type) => void;
    get: () => Type;
}

declare const backpack: Backpack<string>;
const object = backpack.get();
backpack.add('23');

interface Point {
    x: number;
    y: number;
}

function logPoint(p: Point) {
    console.log(`${p.x} ${p.y}`);
}

const point = { x: 12, y: 18 }
logPoint(point);

const point3 = { x: 12, y: 26, z: 89 };
logPoint(point3);

// const color = { hex: "#187ABF" };
// logPoint(color);

class VirtualPoint {
    x: number;
    y: number;

    constructor(x: number, y: number) {
        this.x = x;
        this.y = y;
    }
}

const newVPoint = new VirtualPoint(13, 56);
logPoint(newVPoint); // logs "13, 56"

const anys = [];
anys.push(1);
anys.push('11');
anys.map(anys[1]);

type One = { p: string };

interface Two {
    p:string
}

class Three {
    p = "Hello";
}

let x: One = { p: 'hi' };
let two: Two = x;
two = new Three();

function start(arg: string | string[] | (() => string) | { s: string }): string {

    if (typeof arg === 'string') {
        return commonCase(arg);
    } else if (Array.isArray(arg)) {
        return arg.map(commonCase).join(",");
    } else if (typeof arg === "function") {
        return commonCase(arg());
    } else {
        return commonCase(arg.s);
    }

    function commonCase(s: string): string {
        return s;
    }
}

type Combined = { a: number } & { b: string };
type Conflicting = { a: number } & { a: string };

declare function pad(s: string, n: number, direction: "left" | "right"): string;
pad("hi", 10, "left");

// let s = "right";
// pad("hi", 10, s);

let s: "left" | "right" = "right";
pad("hi", 10, s);


type Shape =
    | { kind: "circle"; radius: number }
    | { kind: "square"; x: number }
    | { kind: "triangle"; x: number; y: number };

function area(s: Shape):number {
    if (s.kind === "circle") {
        return Math.PI * s.radius * s.radius;
    } else if (s.kind === "square") {
        return s.x * s.x;
    } else {
        return (s.x * s.y) / 2;
    }
}

let shape: Shape = { kind: "circle", radius: 12 };
let areaShape = area(shape);
console.log(areaShape);
