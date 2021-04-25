//create a constant gameObject
const gameObject = {
  x: 0,
  y: 0,
  type: "",
};

//...and a constant movable
const movable = {
  moveTo(x, y) {
    this.x = x;
    this.y = y;
  },
};

//then the constant movableObject is composed of the gameObject and movable constants
const movableObject = { ...gameObject, ...movable };

//then create a function to create a new Hero who inherits the movableObject properties
function createHero(x, y) {
  return {
    ...movableObject,
    x,
    y,
    type: "Hero",
  };
}

//...and a static object that inherits only the gameObject properties
function createStatic(x, y, type) {
  return {
    ...gameObject,
    x,
    y,
    type,
  };
}
//create the hero and move it
const hero = createHero(10, 10);
hero.moveTo(5, 5);
//and create a static tree which only stands around
const tree = createStatic(0, 0, "Tree");
