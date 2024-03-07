function personAndTeacher() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }
    }

    return {
        Person,
        Teacher
    };
}

let { Person, Teacher } = personAndTeacher();

let person = new Person('Niki', 'niki@test.com');
let teacher = new Teacher('Lili', 'lili@test.com', 'math');

console.log(person);
console.log(teacher);
console.log("____________");
console.log(person instanceof Person);
console.log(teacher instanceof Person);
console.log(teacher instanceof Teacher);