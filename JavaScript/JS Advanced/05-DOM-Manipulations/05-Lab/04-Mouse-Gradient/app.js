function attachGradientEvents() {
  let gradient = document.getElementById("gradient");
  const divResultElement = document.getElementById("result");

  gradient.addEventListener("mousemove", gradientMove);
  gradient.addEventListener("mouseout", gradientOut);

  /**
   * Function to handle the mousemove event on the gradient element.
   * @param {MouseEvent} event - The event object.
   */
  function gradientMove(event) {
    /**
     * Width of the gradient box.
     * @type {number}
     */
    const gradientBoxWidth = event.target.clientWidth;

    /**
     * Position of the mouse relative to the gradient box.
     * @type {number}
     */
    const positionOfTheMouse = event.offsetX / (gradientBoxWidth - 1); // -1 due to the border being part of the clientWidth

    /**
     * Percentage value based on the position of the mouse.
     * @type {number}
     */
    const percentage = Math.trunc(positionOfTheMouse * 100);
    divResultElement.textContent = `${percentage}%`;
  }

  /**
   * Function to handle the mouseout event on the gradient element.
   * @param {MouseEvent} event - The event object.
   */
  function gradientOut(event) {
    divResultElement.textContent = "";
  }
}
