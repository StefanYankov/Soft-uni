function solve() {
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  function onClick() {
    const searcBarInput = document.getElementById("searchField").value;
    const tableRows = document.querySelectorAll("tbody tr");

    for (let i = 0; i < tableRows.length; i++) {
      const element = tableRows[i];
      if (element.innerText.includes(searcBarInput)) {
        element.classList.add("select");
      } else {
        element.classList.remove("select");
      }
    }
    searcBarInput.value = "";
  }
}
