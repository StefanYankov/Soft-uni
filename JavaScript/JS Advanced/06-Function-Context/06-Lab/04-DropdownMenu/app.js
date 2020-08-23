function solve() {

    const optionsButton = document.getElementById('dropdown');
    const dropdownMenu = document.getElementById('dropdown-ul');
    const box = document.getElementById('box');

    optionsButton.addEventListener('click', showOptions);
    dropdownMenu.addEventListener('click', changeColor);

    function showOptions() {
        
        if (dropdownMenu.style.display === 'block') {
            dropdownMenu.style.display = 'none';
            box.style.backgroundColor = 'black';
            box.style.color = 'white';
        } else {
            dropdownMenu.style.display = 'block';
        }
    }

    function changeColor(e) {
        const color = e.target.textContent;
        box.style.backgroundColor = color;
        box.style.color = 'black';
    }
}