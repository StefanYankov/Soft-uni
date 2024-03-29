function systemComponentsDatabase(inputArray = []) {
    const database = {};

    // Take input data and fill the catalog
    for (const line of inputArray) {
        const [systemName, componentName, subcomponentName] = line.split(' | ');

        if (database.hasOwnProperty(systemName) === false) {
            database[systemName] = {};
        }

        if (database[systemName].hasOwnProperty(componentName) === false) {
            database[systemName][componentName] = [];
        }
        
        database[systemName][componentName].push(subcomponentName);
    }

    // Sorting by first and second criteria
    const sortedByFirstAndSecondCriteria = Object.entries(database).sort((a, b) => {
        return Object.keys(b[1]).length - Object.keys(a[1]).length || a[0].localeCompare(b[0]);
    });

    // Sorting by third criteria and printing the result
    for (const [system, component] of sortedByFirstAndSecondCriteria) {
        console.log(system);

        const sortedByThirdCriteria = Object.entries(component).sort((a, b) => b[1].length - a[1].length);

        for (const [name, subComponent] of sortedByThirdCriteria) {
            console.log('|||' + name);

            subComponent.forEach(sub => {
                console.log('||||||' + sub);
            })
        }
    }
}

const input = [
    'SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security'
];

systemComponentsDatabase(input);
