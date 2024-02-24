function solve() {

    const expression = document.getElementById('expressionOutput');
    const result = document.getElementById('resultOutput');

    const clearButton = document.querySelector('.clear');
    clearButton.addEventListener('click', () => {
        memory.firstOperand = '';
        memory.secondOperand = '';
        memory.operator = '';
        expression.textContent = '';
        result.textContent = '';
    })

    const memory = {
        firstOperand: '',
        secondOperand: '',
        operator: '',
    };

    const operations = {
        '+': () => Number(memory.firstOperand) + Number(memory.secondOperand),
        '-': () => Number(memory.firstOperand) - Number(memory.secondOperand),
        '*': () => Number(memory.firstOperand) * Number(memory.secondOperand),
        '/': () => Number(memory.firstOperand) / Number(memory.secondOperand),
        '=': true,
    };
    
    const [...buttons] = document.querySelector('.keys').querySelectorAll('button');
    buttons.forEach(b => b.addEventListener('click', onClick));

    function onClick(e) {
        const value = e.target.value;

        if (operations.hasOwnProperty(value)) {

            if (value === '=') {

                if (memory.firstOperand === '' || memory.secondOperand === '') {
                    result.textContent = 'NaN';
                } else {
                    result.textContent = operations[memory.operator]();
                }
            } else {
                memory.operator = value;
            }
        } else {

            if (memory.operator === '') {
                memory.firstOperand += value;
            } else {
                memory.secondOperand += value;
            }
        }

        expression.textContent =
         `${memory.firstOperand} ${memory.operator} ${memory.secondOperand}`;
    }
}