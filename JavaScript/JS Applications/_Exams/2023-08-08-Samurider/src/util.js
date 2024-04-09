// keep user data, get them from storage, clear the user data on logout or expired token

export function setUserData(data) {
    localStorage.setItem('user', JSON.stringify(data));
}

export function getUserData() {
    return JSON.parse(localStorage.getItem('user'));
}

export function clearUserData() {
    localStorage.removeItem('user');
}

export function createSubmitHandler(callback) {
    return function (event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        const data = [...formData.entries()].map(([k, v]) => [k, v.trim()]);

        callback(Object.fromEntries(data), event.target);
    };
}

export function updateNav() {
    const userNav = document.querySelector('nav .user');
    const guestNav = document.querySelector('nav .guest');
    const userData = getUserData();

    if (userData) {
        guestNav.style.display = 'none';
        userNav.style.display = 'block';
    }
    else {
        guestNav.style.display = 'block';
        userNav.style.display = 'none';
    }

    // document.querySelector('nav .guest').style.display = userData ? 'none' : 'block';
    // document.querySelector('nav .user').style.display = userData ? 'block' : 'none';
}

export function isOwner(itemOwnerId) {
    return getUserData()?._id === itemOwnerId;
}