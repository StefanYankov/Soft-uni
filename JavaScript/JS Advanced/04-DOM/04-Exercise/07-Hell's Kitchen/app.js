function solve() {
  document.querySelector("#btnSend").addEventListener("click", onClick);

  function onClick() {
    const textArea = document.querySelector("#inputs textarea").value;
    const input = JSON.parse(textArea);

    const restaurants = {};

    for (let i = 0; i < input.length; i++) {
      let line = input[i].split(" - ");
      let restaurantName = line[0];
      let employees = line[1].split(", ");

      if (!restaurants.hasOwnProperty(restaurantName)) {
        restaurants[restaurantName] = {};
      }

      for (let j = 0; j < employees.length; j++) {
        let employee = employees[j].split(" ");
        let employeeName = employee[0];
        let existingEmployees = restaurants[restaurantName];

        if (!existingEmployees.hasOwnProperty(employeeName)) {
          let employeeSalary = Number(employee[1]);
          existingEmployees[employeeName] = employeeSalary;
        }
      }
    }

    const bestRestaurant = {
      name: "",
      averageSalary: -1,
      bestSalary: 0,
      employees: {},
    };

    for (const kvp in restaurants) {
      const name = kvp;
      const employees = restaurants[kvp];
      const employeesCount = Object.keys(employees).length;
      const averageSalary =
        Object.values(employees).reduce((acc, salary) => acc + salary, 0) /
        employeesCount;
      if (averageSalary > bestRestaurant["averageSalary"]) {
        bestRestaurant["name"] = name;
        bestRestaurant["averageSalary"] = averageSalary;
        bestRestaurant["bestSalary"] = Math.max(...Object.values(employees));
        bestRestaurant["employees"] = employees;
      }
    }

    const bestRestaurantTag = document.querySelector("#bestRestaurant p");
    bestRestaurantTag.textContent =
      `Name: ${bestRestaurant.name} ` +
      `Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} ` +
      `Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

    const bestRestaurantWorkersTag = document.querySelector("#workers p");

    let employeeArray = Object.entries(bestRestaurant["employees"]).map(
      ([name, salary]) => ({ name, salary })
    );
    let sortedEmployee = employeeArray.sort((a, b) => a.salary + b.salary);
    bestRestaurantWorkersTag.textContent = sortedEmployee
      .map((x) => `Name: ${x.name} With Salary: ${x.salary}`)
      .join(" ");
  }
}
