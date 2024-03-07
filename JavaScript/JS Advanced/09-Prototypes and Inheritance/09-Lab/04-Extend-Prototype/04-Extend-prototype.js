function extendPrototype(classToExtend) {
    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    };
}

// test input

class Mammal {
    constructor(name) {
        this.name = name;
    }

    toString() {
        return `My name is ${this.name}.`;
    }
}

extendPrototype(Mammal);

const mammal = new Mammal('Serafim');
console.log(mammal.toSpeciesString());