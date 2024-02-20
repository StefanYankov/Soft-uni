function solve(array) {
  const numbers = [];
  for (const element of array) {
    if (typeof element == "number") {
      numbers.push(element);
    } else if (numbers.length >= 2) {
      calculate(numbers, element);
    } else {
      console.log("Error: not enough operands!");
      return;
    }
  }

  if (numbers.length > 1) {
    console.log("Error: too many operands!");
    return;
  } else {
    console.log(numbers.toString());
  }

  function calculate(numbers, operator) {
    if (numbers.length < 2) {
      console.log("Error: not enough operands!");
      return;
    } else {
      let operand2 = numbers.pop();
      let operand1 = numbers.pop();

      let result = 0;
      if (operator == "+") {
        result = operand1 + operand2;
      } else if (operator == "-") {
        result = operand1 - operand2;
      } else if (operator == "*") {
        result = operand1 * operand2;
      } else if (operator == "/") {
        result = operand1 / operand2;
      }
      numbers.push(result);
    }
  }
}

solve([3, 4, "+"]);
console.log("______________");
solve([5, 3, 4, "*", "-"]);
console.log("______________");
solve([7, 33, 8, "-"]);
console.log("______________");
solve([15, "/"]);
