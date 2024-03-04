function validate() {
    const inputElement = document.getElementById('email');
    inputElement.addEventListener('change', onChange);
    const pattern = /^\S+@\S+\.\S+$/gm;

    function onChange(event) {
        let email = event.target.value;

        if (pattern.test(email)) {
            event.target.classList.remove('error');
        } else {
            event.target.classList.add('error');
        }
    }
}