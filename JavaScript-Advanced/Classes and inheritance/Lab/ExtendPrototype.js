function Person(firstN, lastN) {
    this.firstN = firstN;
    this.lastN = lastN;
}

function extendProrotype(classToExtend) {

    classToExtend.prototype.species = "Human";
    classToExtend.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;

    }
}


extendProrotype(Person);

let person = new Person(`iwo`, `iwanow`);

console.log(person.toSpeciesString());

