function toggle() {
  const button = document.querySelector("span.button");
  const extraText = document.getElementById("extra");

  if (button.innerHTML === "More") {
    extraText.style.display = "block";
    button.innerHTML = "Less";
  } else if (button.innerHTML === "Less") {
    extraText.style.display = "none";
    button.innerHTML = "More";
  }
}
