class Company {
    departments;
    constructor() {
        this.departments = {}
    }

    addEmployee(name, salary, position, department) {
        if (!name || !salary || !position || !department || name === "" || salary === "" || position === "" || department === "") {
            throw new Error("Invalid input!");
        }

        if (salary < 0) {
            throw new Error("Invalid input!");
        }


        if (!this.departments.hasOwnProperty(department)) {
            this.departments[department] = [];
        }

        this.departments[department].push({ name, salary, position });
        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        const department = Object.entries(this.departments)
            .sort((a, b) => this.getAverageSalary(b) - this.getAverageSalary(a))[0];

        const averageSalary = this.getAverageSalary(department[1]).toFixed(2);

        const employeesInfo = department[1]
            .sort((a, b) => {
                let result = b.salary - a.salary;
                return result === 0 ? a.name.localeCompare(b.name) : result;
            })
            .map(e => `${e.name} ${e.salary} ${e.position}`)
            .join("\n");

        return `Best Department is: ${department[0]}
Average salary: ${averageSalary}
${employeesInfo}`;
    }

    getAverageSalary(employees) {
        if (employees.length <= 0) {
            return 0;
        }
        return employees.reduce((acc, e) => acc + e.salary, 0) / employees.length;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
