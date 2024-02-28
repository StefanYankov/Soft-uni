function solve(...params) {
  const output = {};

  for (const element of params) {
    let type = typeof element;
    console.log(`${type}: ${element}`);
    if (!output.hasOwnProperty(type)) {
      output[type] = 0;
    }
    output[type] += 1;
  }
  const sortedOutput = Object.entries(output).sort((a, b) => b[1] - a[1]);

  for (const [key, value] of sortedOutput) {
    debugger;
    console.log(`${key} - ${value}`);
  }
}

solve("cat", 42, function () {
  console.log("Hello world!");
});
