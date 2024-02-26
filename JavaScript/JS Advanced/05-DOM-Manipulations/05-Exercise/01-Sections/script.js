/**
 * Creates div elements with paragraphs inside them and adds click event listeners
 * to toggle the display of the paragraph when the div is clicked.
 * @param {string[]} words - An array of words to be displayed as paragraphs.
 */
function create(words) {
  const mainDiv = document.getElementById("content");
  for (let i = 0; i < words.length; i++) {
    /**
     * The div element containing the paragraph.
     * @type {HTMLDivElement}
     */
    const innerDiv = document.createElement("div");

    /**
     * The paragraph element containing the word.
     * @type {HTMLParagraphElement}
     */
    const paragraph = document.createElement("p");
    paragraph.style.display = "none";
    paragraph.textContent = words[i];

    innerDiv.appendChild(paragraph);
    mainDiv.appendChild(innerDiv);
    innerDiv.addEventListener("click", displayParagraph);
  }

  /**
   * Toggles the display of the paragraph when the div is clicked.
   * @param {MouseEvent} event - The click event.
   */

  function displayParagraph(event) {
    const paragraph = event.currentTarget.querySelector("p");
    paragraph.style.display = "block";
    debugger;
  }
}
