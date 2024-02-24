function addItem() {

    // get elements and read properties
    const textInput = document.querySelector('#newItemText');
    const valueInput = document.querySelector('#newItemValue');

    const text = textInput.value;
    const value = valueInput.value;

    //creating a new element and changing its properties
    const option = document.createElement('option');
    option.textContent = text;
    option.value = value;

    //adding the newly created element ot the list
    document.querySelector('#menu').appendChild(option);

    //clearing the fields
    textInput.value = '';
    valueInput.value = '';
}