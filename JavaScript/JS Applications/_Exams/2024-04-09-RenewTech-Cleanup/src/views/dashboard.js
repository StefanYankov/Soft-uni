import { getAllSolutions } from "../data/data.js";
import { html, render } from "../lib.js";

const dashboardTemplate = (data) => html`
<h2>Solutions</h2>
    ${data.length ? dashboardDataTemplate(data) : html`<h2 id="no-solution">No Solutions Added.</h2>`}
`;

// partial
const dashboardDataTemplate = (data) => html`
<section id="solutions">
  <!-- Display a div with information about every post (if any)-->
  ${data.map(item => cardTemplate(item))}
</section>`;

// card
const cardTemplate = (item) => html`
<div class="solution">
  <img src="${item.imageUrl}" alt="example3" />
      <div class="solution-info">
        <h3 class="type">${item.type}</h3>
        <p class="description">
        ${item.description}
        </p>
        <a class="details-btn" href="/details/${item._id}">Learn More</a>
      </div>
</div>`;

export async function showDashboard(ctx) {
  const data = await getAllSolutions();
  render(dashboardTemplate(data));
}