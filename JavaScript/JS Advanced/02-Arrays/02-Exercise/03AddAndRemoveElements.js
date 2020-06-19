function addAndRemoveElements(inputArray = []) {

    const tempArray = [];
    for (let i = 0; i < inputArray.length; i++) {
        let currentElement = inputArray[i];
        switch (currentElement) {
            case 'add':
                tempArray.push(i + 1);
                break;
            case 'remove':
                tempArray.pop();
                break;
        }

    }
    if(tempArray.length > 0){
        console.log(tempArray.join('\n'));
    }
    else {
        console.log('Empty');
    }
}

const input = ['add', 'add', 'add', 'add'];
const input2 = ['add', 'add', 'remove', 'add', 'add'];
const input3 = ['remove', 'remove', 'remove'];

addAndRemoveElements(input2);