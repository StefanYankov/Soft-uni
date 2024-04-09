import { clearUserData, getUserData } from '../util.js';
import { notify } from '../views/notify.js';
// boilerplate request functionality

// Base URL for API requests
const host = 'http://localhost:3030';

async function request(method, url, data) {
    const options = {
        method,
        headers: {},
    };

    if (data) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    // Retrieve user data from local storage
    const userData = getUserData();

    // If user data exists, include access token in request headers
    if (userData) {
        options.headers['X-Authorization'] = userData.accessToken;
    }

    try {
        const response = await fetch(host + url, options);

        if (!response.ok) {
            // If response status is 403 (Forbidden), clear user data
            if (response.status == 403) {
                clearUserData();
            }

            // Parse error response
            const err = await response.json();
            throw new Error(err.message);
        }

        // If response status is 204 (No Content), return response
        if (response.status == 204) {
            return response;
        } else {
            // Otherwise, return response data
            return response.json();
        }

    }
    catch (err) {
        // TODO: add custom error handling and visualization based on requirements
        // change notify to alert if notifications are not in requirements
        notify(err.message);
        throw err;
    }
}

export const get = (url) => request('get', url);
export const post = (url, data) => request('post', url, data);
export const put = (url, data) => request('put', url, data);
export const del = (url) => request('delete', url);