import { showCreate } from './data/create.js';
import { showEdit } from './data/edit.js';
import { page } from './lib.js'
import { updateNav } from './util.js';
import { showDashboard } from './views/dashboard.js';
import { showDetails } from './views/details.js';
import { showHomeView } from './views/home.js';
import { showLogin } from './views/login.js';
import { logoutView } from './views/logout.js';
import { showRegister } from './views/register.js';
import { showSearch } from './views/search.js';

updateNav();

page('/', showHomeView);
page('/login', showLogin);
page('/register', showRegister);
page('/logout', logoutView);
page('/dashboard', showDashboard);
page('/create', showCreate);
page('/details/:id', showDetails);
page('/edit/:id', showEdit);
page('/search', showSearch);

page.start();