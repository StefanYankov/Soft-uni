import { clearUserData, setUserData } from '../util.js';
import { page } from '../lib.js';
import { get, post, put, del } from './request.js';

// TODO: adapt user profile to exam requriements (identity, extra properties, etc.)

const endPoints = {
    login: '/users/login',
    register: '/users/register',
    logout: '/users/logout',
}

export async function login(email, password) {
    const result = await post(endPoints.login, { email, password });

    setUserData(result);
    page.redirect('/');

}

export async function register(email, password) {
    const result = await post(endPoints.register, { email, password });

    setUserData(result);
    page.redirect('/');

}

export async function logout() {
    // Send logout request and clear user data
    const promise = get(endPoints.logout);
    clearUserData();

    await promise;
    page.redirect('/');
}