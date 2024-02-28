function solution() {
  const microelements = {
    protein: 0,
    carbohydrate: 0,
    fat: 0,
    flavour: 0,
  };

  let recipes = {
    apple: { carbohydrate: 1, flavour: 2 },
    lemonade: { carbohydrate: 10, flavour: 20 },
    burger: { carbohydrate: 5, fat: 7, flavour: 3 },
    eggs: { protein: 5, fat: 1, flavour: 1 },
    turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 },
  };

  return function (input) {
    const inputArray = input.split(" ");
    const command = inputArray[0];
    switch (command) {
      case "restock":
        const element = inputArray[1];
        const elementQuantity = Number(inputArray[2]);
        return restock(element, elementQuantity);
      case "prepare":
        const recipe = inputArray[1];
        const recipeQuantity = inputArray[2];
        return prepare(recipe, recipeQuantity);
      case "report":
        return report();
    }
  };

  function restock(type, quantity) {
    microelements[type] += Number(quantity);
    return "Success";
  }

  function prepare(recipe, quantity) {
    const preparedRecipe = {};
    for (let [key, value] of Object.entries(recipes[recipe])) {
      let neededQuantity = value * quantity;
      debugger;
      if (microelements[key] < neededQuantity) {
        return `Error: not enough ${key} in stock`;
      }
      preparedRecipe[key] = neededQuantity;
    }

    for (const [key, value] of Object.entries(preparedRecipe)) {
      microelements[key] -= value;
    }
    return "Success";
  }

  function report() {
    return `protein=${microelements["protein"]} carbohydrate=${microelements["carbohydrate"]} fat=${microelements["fat"]} flavour=${microelements["flavour"]}`;
  }
}
{
  let manager = solution();
  console.log(manager("restock flavour 50")); // Success
  console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock
  console.log(manager("restock carbohydrate 10"));
  console.log(manager("restock flavour 10"));
  console.log(manager("prepare apple 1"));
  console.log(manager("restock fat 10"));
  console.log(manager("prepare burger 1"));
  console.log(manager("report"));
}

{
  let manager2 = solution();
  console.log(manager2("prepare turkey 1"));
  console.log(manager2("restock protein 10"));
  console.log(manager2("prepare turkey 1"));
  console.log(manager2("restock carbohydrate 10"));
  console.log(manager2("prepare turkey 1"));
  console.log(manager2("restock fat 10"));
  console.log(manager2("prepare turkey 1"));
  console.log(manager2("restock flavour 10"));
  console.log(manager2("prepare turkey 1"));
  console.log(manager2("report"));
}
{
  let manager3 = solution();
  console.log(manager3("prepare turkey 1"));
  console.log(manager3("restock protein 10"));
  console.log(manager3("prepare turkey 1"));
  console.log(manager3("restock carbohydrate 10"));
  console.log(manager3("prepare turkey 1'"));
  console.log(manager3("restock fat 10"));
  console.log(manager3("prepare turkey 1"));
  console.log(manager3("restock flavour 10"));
  console.log(manager3("prepare turkey 1'"));
  console.log(manager3("report")); // , 'protein=0 carbohydrate=0 fat=0 flavour=0'
}
