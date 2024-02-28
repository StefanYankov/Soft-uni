function solve() {
  const input = {
    name: document.getElementById('task'),
    description: document.getElementById('description'),
    date: document.getElementById('date'),
  };

  // get the second div where we will need to append the data
  const [_, openSection, progressSection, finishedSection] = Array.from(document.querySelectorAll('section')).map((e) => e.children[1]);
  document.getElementById('add').addEventListener('click', addTask);

  function addTask(event) {
    // to stop the form's submit default behaviour 
    event.preventDefault();

    // create elements
    const articleElement = document.createElement('article');
    articleElement.appendChild(createElement('h3', input.name.value));
    articleElement.appendChild(createElement('p', `Description: ${input.description.value}`));
    articleElement.appendChild(createElement('p', `Due Date: ${input.date.value}`));
    const divElement = createElement('div', '', 'flex');

    // create the buttons
    const startButton = createElement('button', 'Start', 'green');
    const deleteButton = createElement('button', 'Delete', 'red');
    const finishButton = createElement('button', 'Finish', 'orange');

    divElement.appendChild(startButton);
    divElement.appendChild(deleteButton);

    articleElement.appendChild(divElement);

    // apend to Open section
    openSection.appendChild(articleElement);

    // clear form input
    Object.values(input).forEach(i => i.value = '');

    // add button functionality for start, finish and delete task
    startButton.addEventListener('click', onStart);
    deleteButton.addEventListener('click', onDelete);
    finishButton.addEventListener('click', onFinish);

    function onStart() {
      startButton.remove();
      divElement.appendChild(finishButton);
      progressSection.appendChild(articleElement);
    }

    function onDelete() {
      articleElement.remove();
    }

    function onFinish() {
      divElement.remove();
      finishedSection.appendChild(articleElement);
    }
  }

  /**
   * Creates a new DOM element with optional content and class name.
   * @param {string} type - The type of the DOM element to create (e.g., 'div', 'article', 'span', 'p').
   * @param {string} [content] - Optional. The text content to set for the created element.
   * @param {string} [className] - Optional. The class name to set for the created element.
   * @returns {HTMLElement} The newly created DOM element.
   */
  function createElement(type, content, className) {
    const element = document.createElement(type);
    element.textContent = content;
    if (className) {
      element.className = className;
    }
    return element;
  }
}
