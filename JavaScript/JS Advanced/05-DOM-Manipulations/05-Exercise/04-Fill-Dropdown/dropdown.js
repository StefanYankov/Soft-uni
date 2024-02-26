function addItem() {
  const selectMenu = document.getElementById("menu");
  const optionText = document.getElementById("newItemText");
  const optionValue = document.getElementById("newItemValue");

  const optionElement = document.createElement("option");

  let tempOptionText = optionText.value;
  let tempOptioNValue = optionValue.value;
  optionElement.text = tempOptionText;
  optionElement.value = tempOptioNValue;

  selectMenu.add(optionElement);
  debugger;

  optionText.value = "";
  optionValue.value = "";
}
