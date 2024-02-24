function solve() {

  let quizz = document.getElementById('quizzie');
  let sections = document.getElementsByTagName('section');
  let result = document.querySelector('.results-inner h1');

  let correctAnswers = ["onclick", "JSON.stringify()", "A programming API for HTML and XML documents"];
  let userAnswers = 0;
  let index = 0;

  let handler = (e) => {

    if (e.target.className === 'answer-text') {
      sections[index].style.display = "none";

      let isAnswerCorrect = correctAnswers.includes(e.target.innerHTML);
      if (isAnswerCorrect) {
        userAnswers++;
      }

      index++;
      if (index < correctAnswers.length) {
        sections[index].style.display = "block";

      }

      if (index === correctAnswers.length) {

        quizz.removeEventListener('click', handler);

        document.querySelector('#results').style.display = 'block';
        if (userAnswers === correctAnswers.length) {
          result.innerHTML = "You are recognized as top JavaScript fan!";
        } else {
          result.innerHTML = `You have ${userAnswers} right answers`;
        }
      }
    }
  };

  quizz.addEventListener('click', handler);
}