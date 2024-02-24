function solve() {
  const validCases = ["Camel Case", "Pascal Case"];
  let inputText = document.getElementById("text").value;
  let namingConvention = document.getElementById("naming-convention").value;
  let output = document.getElementById("result");

  if (!validCases.includes(namingConvention)) {
    output.innerText = "Error!";
    return;
  }

  let outputText = inputText.toLowerCase().split(" ");
  if (namingConvention === validCases[1]) {
    outputText[0] =
      outputText[0].charAt(0).toUpperCase() + outputText[0].slice(1);
  }

  for (let i = 1; i < outputText.length; i++) {
    outputText[i] =
      outputText[i].charAt(0).toUpperCase() + outputText[i].slice(1);
  }

  output.innerText = outputText.join("");
}
