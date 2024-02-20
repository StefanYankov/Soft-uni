function solve(input = []) {
  output = {};

  for (let i = 0; i < input.length; i++) {
    let tokens = input[i].split(" : ");
    let productName = tokens[0];
    let productPrice = Number(tokens[1]);
    let letter = productName[0];

    if (!output.hasOwnProperty(letter)) {
      output[letter] = [];
    }

    output[letter].push({
      productName,
      productPrice,
    });
  }

  const sortedKeys = Object.keys(output).sort();

  // Create a new object with sorted keys
  const sortedObject = {};

  // Iterate over sorted keys and assign corresponding values from original object
  sortedKeys.forEach((key) => {
    sortedObject[key] = output[key];
  });

  for (let [key, value] of Object.entries(sortedObject)) {
    console.log(key);
    value.sort((a, b) => {
      const productNameA = a.productName.toLowerCase();
      const productNameB = b.productName.toLowerCase();

      if (productNameA < productNameB) {
        return -1;
      }
      if (productNameA > productNameB) {
        return 1;
      }
      return 0;
    });
    for (let i = 0; i < value.length; i++) {
      console.log(`  ${value[i].productName}: ${value[i].productPrice}`);
    }
  }
}
solve([
  "Appricot : 20.4",
  "Fridge : 1500",
  "TV : 1499",
  "Deodorant : 10",
  "Boiler : 300",
  "Apple : 1.25",
  "Anti-Bug Spray : 15",
  "T-Shirt : 10",
]);
console.log("_______________");
solve([
  "Banana : 2",
  "Rubic's Cube : 5",
  "Raspberry P : 4999",
  "Rolex : 100000",
  "Rollon : 10",
  "Rali Car : 2000000",
  "Pesho : 0.000001",
  "Barrel : 10",
]);
