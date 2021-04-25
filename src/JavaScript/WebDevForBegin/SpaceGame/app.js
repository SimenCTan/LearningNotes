class EventEmitter {
  constructor() {
    this.listeners = {};
  }
  //when a message is received, let the listener to handle its payload
  on(message, listeners) {
    if (!this.listeners[message]) {
      this.listeners[message] = [];
    }
    this.listeners[message].push(listeners);
  }
  //when a message is sent, send it to a listener with some payload
  emit(message, payload = null) {
    if (this.listeners[message]) {
      this.listeners[message].forEach((element) => {
        element(message, payload);
      });
    }
  }
}

// To use the above code we can create a very small implementation:
//set up a message structure
const Messages = {
  HERO_MOVE_LEFT: "HERO_MOVE_LEFT",
};
//invoke the eventEmitter you set up above
const eventEmitter = new EventEmitter();
//set up a hero
const hero = createHero(0, 0);
//let the eventEmitter know to watch for messages pertaining to the hero moving left, and act on it
eventEmitter.on(Messages.HERO_MOVE_LEFT, () => {
  hero.moveTo(5, 0);
});
//set up the window to listen for the keyup event, specifically if the left arrow is hit, emit a message to move the hero left
window.addEventListener("Keyup", (evt) => {
  if (evt.key === "ArrowLeft") {
    eventEmitter.emit(Messages.HERO_MOVE_LEFT);
  }
});

// set up the class game object
class GameObject {
  constructor(x, y, type) {
    this.x = x;
    this.y = y;
    this.type = type;
  }
}

// this class will extend the game object inherent class properties
class Movable extends GameObject {
  constructor(x, y, type) {
    super(x, y, type);
  }

  // this movable object can be move on the screen
  moveto(x, y) {
    this.x = x;
    this.y = y;
  }
}

//this is a specific class that extends the Movable class, so it can take advantage of all the properties that it inherits
class Hero extends Movable {
  constructor(x, y) {
    super(x, y, "Hero");
  }
}

//this class, on the other hand, only inherits the GameObject properties
class Tree extends GameObject {
  constructor(x, y) {
    super(x, y, "Tree");
  }
}

// a hero can move
var hero = new Hero();
hero.moveto(5, 5);

// but a tree can not move
const tree = new Tree();
