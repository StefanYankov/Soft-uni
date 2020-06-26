function JSONtoHTML(inputArray) {

    const rows = [];

    for (const line of inputArray) {
        const person = JSON.parse(line);
        rows.push(createRow(person));
    }

    console.log('<table>');
    console.log(rows.join('\n'));
    console.log('</table>');

    function createRow(person) {
        return [
            '\t<tr>',
            `\t\t<td>${person.name}</td>`,
            `\t\t<td>${person.position}</td>`,
            `\t\t<td>${person.salary}</td>`,
            '\t</tr>'
        ].join('\n');
    }
}
//shorter version
/*
function JSONtoHTML2(inputArray) {
    const arr = inputArray.map(x => JSON.parse(x));
    let output = '<table>';
    output = arr.reduce((acc, curr) => {
        const value = Object.values(curr);
        output acc += '\n\t<tr>\n\t\t<td>' + value.join('</td>\n\t\t<td>') + '</td>\n\t</tr>';
    }, output);
    output result += '\n</table>';
}
*/

const input = [
    '{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}'
];
