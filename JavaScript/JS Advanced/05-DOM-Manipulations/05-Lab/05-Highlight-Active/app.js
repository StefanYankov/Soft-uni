function focused() {
  const divElement = document.querySelectorAll("div div input");

  for (let i = 0; i < divElement.length; i++) {
    divElement[i].addEventListener("focus", addFocus);
    divElement[i].addEventListener("blur", blur);
  }

  function addFocus(event) {
    let parent = event.target.parentNode;
    parent.classList.add("focused");
  }

  function blur(event) {
    let parent = event.target.parentNode;
    parent.classList.remove("focused");
  }
}
