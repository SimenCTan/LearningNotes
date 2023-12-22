class Person {
  constructor(firstName, lastName = "li", age) {
    // console.log(this);
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.skills = [];
  }

  getFullName() {
    const fullName = this.firstName + this.lastName;
    return fullName;
  }

  static favoriteSkill() {
    const skills = ["HTML", "CSS", "JS", "React", "Python", "Node"];
    const index = Math.floor(Math.random() * skills.length);
    return skills[index];
  }

  get getAge() {
    return this.age;
  }

  get getSkills() {
    return this.skills;
  }

  set setSkill(skill) {
    this.skills.push(skill);
  }
}

class Student extends Person {
  constructor(firstName, lastName, age, gender) {
    super(firstName, lastName, age);
    this.gender = gender;
  }

  saySomething() {
    console.log("I am a child of the person class");
  }

  getFullName(){
    return `${this.firstName} ${this.lastName} ${this.gender}`
}
}

const person = new Person("wang", "hou", 21);
console.log(person);
console.log(person.getFullName());
console.log(person.getAge);
person.setSkill = "HTML";
console.log(person.skills);
console.log(Person.favoriteSkill());

const student = new Student('wang','huo',21,'male');
student.skills='VUE';
console.log(student.getFullName());
console.log(student.skills);
