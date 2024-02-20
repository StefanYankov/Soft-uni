function solve(input = []) {
  const calorieObject = {};

  for (let i = 0; i < input.length; i += 2) {
    calorieObject[input[i]] = Number(input[i + 1]);
  }

  console.log(calorieObject);
}
solve(["Yoghurt", "48", "Rise", "138", "Apple", "52"]);
console.log("_______________");
solve(["Potato", "93", "Skyr", "63", "Cucumber", "18", "Milk", "42"]);
