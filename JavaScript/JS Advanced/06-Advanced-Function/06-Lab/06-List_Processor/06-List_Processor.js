function solve() {
  let collection = [];

  function add(string) {
    collection.push(string);
  }

  function remove(string) {
    let index = collection.indexOf(string);
    while (index !== -1) {
      collection.splice(index, 1);
      index = collection.indexOf(string);
    }
  }

  function print() {
    console.log(collection.join(","));
  }

  return function (commands) {
    commands.forEach((command) => {
      let [action, value] = command.split(" ");
      if (action === "add") {
        add(value);
      } else if (action === "remove") {
        remove(value);
      } else if (action === "print") {
        print();
      }
    });
  };
}

solve(["add hello", "add again", "remove hello", "add again", "print"]);
console.log("______________________");
solve(["add pesho", "add george", "add peter", "remove peter", "print"]);
