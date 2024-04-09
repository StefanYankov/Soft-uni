import { logout } from '../data/users.js';
import { updateNav } from '../util.js';

export async function showLogout() {
    await logout();
    updateNav();
}