function solve() {
  const hero = {
    mage(name) {
      const mageObject = {
        name: name,
        health: 100,
        mana: 100,

        cast(spell) {
          this.mana = this.mana - 1;
          console.log(`${this.name} cast ${spell}`);
        },
      };
      return mageObject;
    },

    fighter(name) {
      const fighterObject = {
        name: name,
        health: 100,
        stamina: 100,

        fight() {
          this.stamina = this.stamina - 1;
          console.log(`${name} slashes at the foe!`);
        },
      };
      return fighterObject;
    },
  };

  return hero;
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball");
scorcher.cast("thunder");
scorcher.cast("light");

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight();

console.log(scorcher2.stamina);
console.log(scorcher.mana);
