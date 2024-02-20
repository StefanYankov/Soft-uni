function solve(input = []) {
  const output = [];

  for (let i = 0; i < input.length; i++) {
    let tokens = input[i].split(" / ");
    let name = tokens[0];
    let level = Number(tokens[1]);
    let items = tokens[2] ? tokens[2].split(", ") : [];

    let temp = {
      name,
      level,
      items,
    };
    output.push(temp);
  }

  return JSON.stringify(output);
}

console.log(
  solve([
    "Isacc / 25 / Apple, GravityGun",
    "Derek / 12 / BarrelVest, DestructionSword",
    "Hes / 1 / Desolator, Sentinel, Antara",
  ])
);
console.log("_______________");
console.log(solve(["Jake / 1000 / Gauss, HolidayGrenade"]));
console.log("_______________");
console.log(solve(["Jake / 1000 /"]));
