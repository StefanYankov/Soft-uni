class Rat {
    
    unitedRats = [];
    constructor(name){
        this.name = name;
    }

    unite(r){
        if (r instanceof Rat){
            this.unitedRats.push(r);
        }
    }

    getRats(){
        return  this.unitedRats;
    }

    toString(){
        return this.name +  this.unitedRats.map(r => `\n##${r.name}`).join('');
    }
}
let firstRat = new Rat("Peter");
console.log(firstRat.toString()); // Peter
console.log(firstRat.getRats()); // []
firstRat.unite(new Rat("George"));
firstRat.unite(new Rat("Alex"));

console.log(firstRat.toString());

// Peter
// ##George;
// ##Alex;