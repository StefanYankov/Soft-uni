function validate() {
  const input = document.getElementById("email");
  const regex =
    /^[a-z]+([-+.'][a-z]+)*@[a-z]+([-.][a-z]+)*\.[a-z]+([-.][a-z]+)*$/;
  input.addEventListener("change", emailCheck);

  function emailCheck(event) {
    if (regex.test(event.target.value)) {
      event.target.classList.remove("error");
      return;
    }
    event.target.className = "error";
  }
}
