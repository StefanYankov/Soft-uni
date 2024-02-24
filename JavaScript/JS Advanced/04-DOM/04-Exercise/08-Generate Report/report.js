function generateReport() {
  const outputElement = document.querySelector("#output");
  const result = [];
  const checks = Array.from(document.querySelectorAll("thead tr th input"));
  const tableRows = Array.from(document.querySelectorAll("tbody tr"));

  for (let rowIndex = 0; rowIndex < tableRows.length; rowIndex++) {
    const row = tableRows[rowIndex];
    const current = {};

    for (let cellIndex = 0; cellIndex < row.cells.length; cellIndex++) {
      const cell = row.cells[cellIndex];

      if (checks[cellIndex].checked) {
        current[checks[cellIndex].name] = cell.textContent;
      }
    }
    result.push(current);
  }

  outputElement.value = JSON.stringify(result);
}
