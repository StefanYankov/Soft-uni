function lockedProfile() {
  const profiles = document.querySelectorAll("div.profile");

  for (let i = 0; i < profiles.length; i++) {
    const profileDiv = profiles[i];
    const buttonDiv = profileDiv.querySelector("button");
    buttonDiv.addEventListener("click", showMore);
  }

  function showMore(event) {
    const parentElement = event.currentTarget.parentElement;
    const radioElement = parentElement.querySelector(
      'input[type="radio"]:checked'
    );
    const hiddenFields = parentElement.querySelector("div");

    debugger;

    if (radioElement.value === "unlock") {
      if (event.currentTarget.textContent === "Show more") {
        event.currentTarget.textContent = "Hide it";
        hiddenFields.style.display = "block";
      } else {
        event.currentTarget.textContent = "Show more";

        hiddenFields.style.display = "none";
      }
    }
  }
}
