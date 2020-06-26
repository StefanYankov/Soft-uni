function createArticle() {

	const titleInput = document.getElementById('createTitle');
	const contentInput = document.getElementById('createContent');

	//checking if the input fields are empty
	if (titleInput.value === '' || contentInput.value === '') {
		return;
	}

	const articles = document.getElementById('articles');
	const article = document.createElement('article');
	const heading = document.createElement('h3');
	const paragraph = document.createElement('p');

	heading.innerText = titleInput.value;
	paragraph.innerText = contentInput.value;

	article.appendChild(heading);
	article.appendChild(paragraph);
	articles.appendChild(article);

	// clearing up the input text
	titleInput.value = '';
	contentInput.value = '';
}