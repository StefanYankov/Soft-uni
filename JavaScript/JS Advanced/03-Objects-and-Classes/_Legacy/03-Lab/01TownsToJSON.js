function townsToJSON(inputArray = []) {

    const output = [];

    for (let i = 1; i < inputArray.length; i++) {

        let line = inputArray[i].split('|').map(x => x.trim());
        let filteredLine = [];
        for (let j = 0; j < line.length; j++) {
            if (line[j].length > 0) {
                filteredLine.push(line[j]);
            }
        }
        let town = filteredLine[0];
        let latitude = Number(Number(filteredLine[1]).toFixed(2));
        let longtitude = Number(Number(filteredLine[2]).toFixed(2));

        const tempObject = { Town: town, Latitude: latitude, Longitude: longtitude };

        output.push(tempObject);

    }
    return JSON.stringify(output);
}

const input = [
    '| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'];

const input2 = [
    '| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |'];

townsToJSON(input);
