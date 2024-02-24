function search() {
  const searcBarInput = document.getElementById("searchText").value;
  const cities = document.querySelectorAll("#towns li");
  let counter = document.getElementById("result");
  let numberCitiesFound = 0;

  for (const city of cities) {
    if (city.innerText.includes(searcBarInput)) {
      numberCitiesFound++;
      city.style.fontWeight = "bold";
      city.style.textDecoration = "underline";
    }
  }

  counter.innerText = `${numberCitiesFound} matches found`;
}
