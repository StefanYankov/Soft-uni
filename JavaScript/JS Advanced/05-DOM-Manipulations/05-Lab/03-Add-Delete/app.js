function addItem() {
  /**
   * Input element for the new item text.
   * @type {HTMLInputElement}
   */
  const input = document.getElementById("newItemText");

  if (input.value.length === 0) {
    return;
  }
  /**
   * List element to which the new item will be added.
   * @type {HTMLUListElement}
   */

  const list = document.getElementById("items");

  /**
   * New list item element to be created.
   * @type {HTMLLIElement}
   */
  const listItemElement = document.createElement("li");
  listItemElement.textContent = input.value;

  /**
   * Delete button element.
   * @type {HTMLAnchorElement}
   */
  const deleteBtn = document.createElement("a");
  deleteBtn.textContent = "[Delete]";
  deleteBtn.href = "#"; // if no href button will be disabled;
  deleteBtn.addEventListener("click", onDelete);
  listItemElement.appendChild(deleteBtn);

  list.appendChild(listItemElement);
  input.value = "";

  /**
   * Function to handle the delete button click event.
   * @param {MouseEvent} event - The event object.
   */

  function onDelete(event) {
    const deleteBtn = event.target;
    const liElement = deleteBtn.parentElement;
    liElement.remove();
  }
}
