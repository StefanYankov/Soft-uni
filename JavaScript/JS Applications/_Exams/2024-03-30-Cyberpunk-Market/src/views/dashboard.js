import { getAllItems } from "../data/data.js";
import { html, render } from "../lib.js";

const dashboardTemplate = (data) => html`
<h3 class="heading">Market</h3>
${data.length ? dashboardDataTemplate(data) : html`<h3 class="empty">No Items Yet</h3>`}`;

// partial
const dashboardDataTemplate = (data) => html`
<section id="dashboard">
  <!-- Display a div with information about every post (if any)-->
${data.map(item => cardTemplate(item))}
</section>`;

// card
const cardTemplate = (item) => html`
<div class="item">
    <img src="${item.imageUrl}" alt="example1" />
    <h3 class="model">${item.item}</h3>
    <div class="item-info">
      <p class="price">Price: €${item.price}</p>
      <p class="availability">
        ${item.availability}
      </p>
      <p class="type">Type: ${item.type}</p>
    </div>
    <a class="details-btn" href="/details/${item._id}">Uncover More</a>
</div>`;

export async function showDashboard(ctx) {
    const data = await getAllItems();
    render(dashboardTemplate(data));
}