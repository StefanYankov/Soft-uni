function solve() {

   document.querySelector('#searchBtn').addEventListener('click', onSearch);

   let input = document.querySelector('#searchField');
   function onSearch(e) {

      const table = Array.from(document.querySelectorAll('tbody > tr'));

      table.forEach(row => {
         let modInput = (input.value).trim().toLocaleLowerCase();
         if (row.textContent.trim().toLocaleLowerCase().includes(modInput)) {
            row.classList.add('select')
         } else {
            row.classList.remove('select')
         }
      })
      input.value = '';
   }
}