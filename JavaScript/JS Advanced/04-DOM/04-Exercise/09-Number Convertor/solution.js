function solve() {
  // add missing elements to html on load
  // create the elements
  const firstOptionElement = document.createElement("option");
  firstOptionElement.value = "binary";
  firstOptionElement.innerHTML = "Binary";
  const secondOptionElement = document.createElement("option");
  secondOptionElement.value = "hexadecimal";
  secondOptionElement.innerHTML = "Hexadecimal";
  // add them to the HTML
  const menuToElement = document.getElementById("selectMenuTo");
  menuToElement.appendChild(firstOptionElement);
  menuToElement.appendChild(secondOptionElement);

  // get the reference of the button that will trigger the actual conversion
  const button = document.getElementsByTagName("button")[0];

  // add a function that will triger the conversion on click
  button.addEventListener("click", function () {
    const inputNumber = document.getElementById("input");
    const outputNumber = document.getElementById("result");

    if (menuToElement.value === "binary") {
      outputNumber.value = Number(inputNumber.value).toString(2); // toString method can directly convert to binary
    } else if (menuToElement.value === "hexadecimal") {
      outputNumber.value = Number(inputNumber.value).toString(16).toUpperCase(); // toString method can directly convert to hexadecimal
    }
  });
}
