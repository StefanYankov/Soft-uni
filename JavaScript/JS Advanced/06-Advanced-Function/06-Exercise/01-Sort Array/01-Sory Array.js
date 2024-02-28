function solve(array = [], operation = "") {
  if (operation === "asc") {
    return array.sort((a, b) => a - b);
  }

  if (operation === "desc") {
    return array.sort((a, b) => b - a);
  }
}

console.log(solve([14, 7, 17, 6, 8], "asc"));
console.log("______________");
console.log(solve([10, 9, 8, 7, 6, 5], "desc"));
