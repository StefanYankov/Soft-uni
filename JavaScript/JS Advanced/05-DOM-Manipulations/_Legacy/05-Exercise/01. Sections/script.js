function create(words) {
   const content = document.getElementById('content');

   words.forEach(element => {
      const divElement = document.createElement('div');
      const paragraphElement = document.createElement('p');

      paragraphElement.textContent = element;
      paragraphElement.style.display = 'none';
      divElement.appendChild(paragraphElement);

      divElement.addEventListener('click', (e) => {
         e.target.children[0].style.display = 'block';
      });

      content.appendChild(divElement);
   });
}