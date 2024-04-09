import { html, render } from '../lib.js';
import { getAllEvents } from '../data/events.js'

const dashboardTemplate = (events) => html`
<h2>Current Events</h2>
<section id="dashboard">
  <!-- Display a div with information about every post (if any)-->
    ${events.length ? events.map(eventTemplate) : html`<h4>No Events yet.</h4>`}
</section >`;

// partial template
const eventTemplate = (event) => html`
<div class="event">
    <img src="${event.imageUrl}" alt="example1" />
    <p class="title">${event.name}</p>
    <p class="date">${event.date}</p>
    <a class="details-btn" href="/dashboard/${event._id}">Details</a>
</div > `;

export async function showDashboard(ctx) {
    const events = await getAllEvents();
    render(dashboardTemplate(events));
}