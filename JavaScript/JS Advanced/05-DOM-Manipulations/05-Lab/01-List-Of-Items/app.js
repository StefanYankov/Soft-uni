function addItem() {
  const input = document.getElementById("newItemText");

  if (input.value.length === 0) {
    return;
  }

  const list = document.getElementById("items");
  const listItemElement = document.createElement("li");
  listItemElement.textContent = input.value;

  list.appendChild(listItemElement);
  input.value = "";
}
