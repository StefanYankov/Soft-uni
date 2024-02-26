function solve() {
  let points = 0;
  let currSection = 0;
  let question = document.getElementsByTagName("section");
  let correctAnswers = [
    "onclick",
    "JSON.stringify()",
    "A programming API for HTML and XML documents",
  ];

  Array.from(document.querySelectorAll(".answer-text")).map((x) =>
    x.addEventListener("click", (answer) => {
      if (correctAnswers.includes(x.textContent)) {
        points++;
      }
      question[currSection].style.display = "none";
      currSection++;

      if (currSection !== 3) {
        question[currSection].style.display = "block";
      } else {
        printResult(points);
      }
    })
  );

  function printResult(points) {
    document.querySelector("#results").style.display = "block";
    let text = `You have ${points} right answers`;
    if (points === 3) {
      text = "You are recognized as top JavaScript fan!";
    }
    document.querySelector("#results > li > h1").textContent = text;
  }
}
