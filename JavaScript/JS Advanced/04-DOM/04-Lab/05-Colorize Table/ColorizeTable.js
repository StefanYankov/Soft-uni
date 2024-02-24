function colorize() {
  const tableRows = Array.from(document.querySelectorAll("tr"));

  for (let i = 1; i < tableRows.length; i += 2) {
    let item = tableRows[i];
    item.style.background = "teal";
  }
}
