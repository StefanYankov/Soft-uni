function toStringExtension() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }

        toString() {
            return `Person (name: ${this.name}, email: ${this.email})`;
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            return `Student (name: ${this.name}, email: ${this.email}, course: ${this.course})`;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            return `Teacher (name: ${this.name}, email: ${this.email}, subject: ${this.subject})`;
        }
    }

    return {
        Person,
        Teacher,
        Student
    }
}

const { Person, Student, Teacher } = toStringExtension();

const person = new Person("Serafim Gerasimoff", "serafim@gerasimoff.com");
console.log(person.toString()); // Output: Person (name: John Doe, email: john@example.com)

const student = new Student("Dala Vera", "dala@vera.com", "Mathematics");
console.log(student.toString()); // Output: Student (name: Jane Smith, email: jane@example.com, course: Math)

const teacher = new Teacher("Kaka Penka", "kaka@penka.com", "History");
console.log(teacher.toString()); // Output: Teacher (name: Bob Johns