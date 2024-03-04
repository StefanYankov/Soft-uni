function validate() {
    const username = document.getElementById('username');
    const email = document.getElementById('email');
    const password = document.getElementById('password');
    const confirmPassword = document.getElementById('confirm-password');
    const companyNumber = document.getElementById('companyNumber');
    const company = document.getElementById('company');
    const errFields = [];

    company.addEventListener('change', handleCompanyChange);



    document.getElementById('submit')
        .addEventListener('click', validateFields)

    function isCorrectUserName(username) {
        let userNamePattern = /^[a-zA-Z0-9]{3,20}$/gm;
        return userNamePattern.test(username);
    }

    function isCorrectEmail(email) {
        const emailPattern = /^\w+@\w*\.+/;
        return emailPattern.test(email);
    }

    function isCorrectPassword(password) {
        let regExp = /^\w{5,15}$/;
        return regExp.test(password) && password.localeCompare(confirmPassword.value) === 0;
    }

    function isCorrectCompanyInfo(companyNumber) {
        let regExp = /^[0-9]{4}$/;
        return regExp.test(companyNumber);
    }

    function handleCompanyChange() {
        if (company.checked) {
            document.getElementById('companyInfo').style.display = 'block';
        } else {
            document.getElementById('companyInfo').style.display = 'none';
        }
    }

    function validateFields(event) {
        event.preventDefault();

        if (!isCorrectUserName(username.value)) {
            errFields.push(username);
        }

        if (!isCorrectEmail(email.value)) {
            errFields.push(email);
        }

        if (!isCorrectPassword(password.value) || password.value !== confirmPassword.value) {
            errFields.push(password);
            errFields.push(confirmPassword);
        }

        if (company.checked) {
            if (!isCorrectCompanyInfo(companyNumber.value)) {
                errFields.push(companyNumber);
            }
        }

        errFields.forEach(field => field.style.borderColor = 'red');

        document.getElementById('valid').style.display =
            errFields.length ? 'none' : 'block';
    }
}