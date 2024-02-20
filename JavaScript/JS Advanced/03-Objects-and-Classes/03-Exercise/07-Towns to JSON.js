function solve(input = []) {
  const output = [];

  // similar to stringsplitoptions.RemoveEmptyEntries()
  const headers = input[0]
    .split("|")
    .filter((x) => x.trim() !== "")
    .map((x) => x.trim());

  for (let i = 1; i < input.length; i++) {
    let tokens = input[i]
      .split("|")
      .filter((x) => x.trim() !== "")
      .map((x) => x.trim());

    const tempObj = {};

    tempObj[headers[0]] = tokens[0];
    for (let i = 1; i < 3; i++) {
      tempObj[headers[i]] = Number(Number(tokens[i]).toFixed(2));
    }

    output.push(tempObj);
  }
  return JSON.stringify(output);
}

console.log(
  solve([
    "| Town | Latitude | Longitude |",
    "| Sofia | 42.696552 | 23.32601 |",
    "| Beijing | 39.913818 | 116.363625 |",
  ])
);

console.log("_______________");
solve([
  "| Town | Latitude | Longitude |",
  "| Veliko Turnovo | 43.0757 | 25.6172 |",
  "| Monatevideo | 34.50 | 56.11 |",
]);
