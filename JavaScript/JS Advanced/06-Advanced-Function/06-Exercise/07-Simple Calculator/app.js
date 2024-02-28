function calculator() {
  let firstField = null;
  let secondField = null;
  let result = null;
  return {
    init,
    add,
    subtract,
  };

  function init(f1, f2, fr) {
    debugger;
    firstField = document.querySelector(f1);
    secondField = document.querySelector(f2);
    result = document.querySelector(fr);
  }
  function add() {
    debugger;
    result.value = Number(firstField.value) + Number(secondField.value);
  }
  function subtract() {
    result.value = Number(firstField.value) - Number(secondField.value);
  }
}
