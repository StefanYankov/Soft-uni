function toggle() {

    //find the reference
    const div = document.querySelector('#extra');
    const button = document.getElementsByClassName('button')[0];
    //const button = document.querySelectorAll('.button')[0];

    //find the property
    if (div.style.display === 'block') {
        // if visible -> hide and change to "More"
        button.textContent = 'More';
        div.style.display = 'none';
        // debug console.log(div.style.display)
    } else {
        // if not visible -> show and change to "Less"
        button.textContent = 'Less';
        div.style.display = 'block';
        // debug console.log(div.style.display)
    }
}