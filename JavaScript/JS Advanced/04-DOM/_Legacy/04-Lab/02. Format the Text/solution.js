function solve() {
  const input = document.querySelector('#input')
  const sentences = input.innerText.split('.');
  let outputDiv = document.querySelector('#output');

  let currParagraph = document.createElement('p');

  for (let i = 0; i < sentences.length; i++) {
    currParagraph.innerText += sentences[i] + '.';

    if (i % 3) {
      outputDiv.appendChild(currParagraph);
      currParagraph = document.createElement('p');
    }
  }

  if (sentences.length <= 3) {
    outputDiv.appendChild(currParagraph);
  }
}