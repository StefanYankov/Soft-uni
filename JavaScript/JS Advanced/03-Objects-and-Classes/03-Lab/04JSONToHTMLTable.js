function JSONToHTMLTable(inputString) {
    let output = '<table>\n';

    const arr = JSON.parse(inputString);
    const titleSet = new Set(arr.map(i => Object.keys(i)).flat());
    const titleArray = Array.from(titleSet);

    output += '<tr><th>' + titleArray.join('</th><th>') + '</th></tr>';

    output = arr.reduce((acc, currItem) => {
        let innerResult = titleArray.reduce((titleAcc, currTitle) => {
            let value = currItem[currTitle];
            value = value === undefined ? '' :
                value.toString()
                    .replace(/&/g, "&amp;")
                    .replace(/</g, '&lt;')
                    .replace(/>/g, "&gt;")
                    .replace(/"/g, "&quot;")
                    .replace(/'/g, "&#39;");

            return titleAcc + '<td>' + value + '</td>';
        }, '');

        if (innerResult === '') {
            return acc;
        }

        return acc + '\n<tr>' + innerResult + '</tr>';
    }, output);

    output = output + '\n</table>';
    return output;
}

const input = ['[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]'];
const input2 = ['[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"},{"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]'];

JSONToHTMLTable(input);
