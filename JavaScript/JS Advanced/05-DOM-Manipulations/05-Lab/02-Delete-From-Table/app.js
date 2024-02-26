function deleteByEmail() {
  const input = document.querySelector('[name="email"]').value;
  const result = document.getElementById("result");

  const tableRows = document.querySelectorAll("tbody tr");

  let isDeleted = false;

  for (let rowIndex = 0; rowIndex < tableRows.length; rowIndex++) {
    const row = tableRows[rowIndex];
    const cell = row.cells[1].textContent;

    if (cell === input) {
      row.remove();
      isDeleted = true;

      input.value = "";
    }
  }

  if (isDeleted) {
    result.textContent = "Deleted.";
  } else {
    result.textContent = "Not found.";
  }
}
