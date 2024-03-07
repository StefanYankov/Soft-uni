function createPerson(firstName, lastName) {
    const person = {
        firstName,
        lastName,
    };

    Object.defineProperty(person, 'fullName', {
        enumerable: true,
        configurable: true,
        get() {
            return `${person.firstName} ${person.lastName}`;
        },
        set(value) {
            let tokens = value.split(' ');
            person.firstName = tokens[0];
            person.lastName = tokens[1];
        }
    });

    return person;
};
{
    let person = createPerson("Peter", "Ivanov");
    console.log(person.fullName); //Peter Ivanov
    person.firstName = "George";
    console.log(person.fullName); //George Ivanov
    person.lastName = "Peterson";
    console.log(person.fullName); //George Peterson
    person.fullName = "Nikola Tesla";
    console.log(person.firstName); //Nikola
    console.log(person.lastName); //Tesla
}
console.log("_________________");
{
    let person = createPerson("Albert", "Simpson");
    console.log(person.fullName); //Albert Simpson
    person.firstName = "Simon";
    console.log(person.fullName); //Simon Simpson
    person.fullName = "Peter";
    console.log(person.firstName);  // Simon
    console.log(person.lastName);  // Simpson}
}
