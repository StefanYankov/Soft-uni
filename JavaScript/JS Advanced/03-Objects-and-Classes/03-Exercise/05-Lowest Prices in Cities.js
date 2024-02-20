function solve(input = []) {
  const output = {};

  for (let i = 0; i < input.length; i++) {
    let tokens = input[i].split(" | ");
    let town = tokens[0];
    let product = tokens[1];
    let price = Number(tokens[2]);

    if (!output.hasOwnProperty(product)) {
      output[product] = {};
    }

    if (output[product].price > price || output[product].price === undefined) {
      output[product].price = price;
      output[product].town = town;
    }
  }

  for (let [key, value] of Object.entries(output)) {
    console.log(`${key} -> ${value.price} (${value.town})`);
  }
}

solve([
  "Sample Town | Sample Product | 1000",
  "Sample Town | Orange | 2",
  "Sample Town | Peach | 1",
  "Sofia | Orange | 3",
  "Sofia | Peach | 2",
  "New York | Sample Product | 1000.1",
  "New York | Burger | 10",
]);
console.log("_______________");
