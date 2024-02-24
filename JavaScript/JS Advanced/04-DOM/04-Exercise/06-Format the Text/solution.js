function solve() {
  const textArea = document.getElementById("input").value;
  const output = document.getElementById("output");
  const splittedText = textArea.split(".").filter((x) => x.length > 0);

  for (let i = 0; i < splittedText.length; i += 3) {
    let arr = [];
    for (let j = 0; j < 3; j++) {
      if (splittedText[i + j]) {
        arr.push(splittedText[i + j]);
      }
    }
    let paragraph = `${arr.join(". ")}.`;
    output.innerHTML += `<p>${paragraph}</p>`;
  }
}
