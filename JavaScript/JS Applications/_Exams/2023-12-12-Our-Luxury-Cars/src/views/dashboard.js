import { getAllCars } from "../data/data.js";
import { html, render } from "../lib.js";

const dashboardTemplate = (data) => html`
<h3 class="heading">Our Cars</h3>
    ${data.length ? dashboardDataTemplate(data) : html`<h3 class="nothing">Nothing to see yet</h3>`}
`;

// partial
const dashboardDataTemplate = (data) => html`
<section id="dashboard">
  <!-- Display a div with information about every post (if any)-->
  ${data.map(item => cardTemplate(item))}
</section>`;

// card
const cardTemplate = (item) => html`
<div class="car">
    <img src="${item.imageUrl}" alt="example1" />
    <h3 class="model">${item.model}</h3>
    <div class="specs">
      <p class="price">Price: €${item.price}</p>
      <p class="weight">Weight: ${item.weight} kg</p>
      <p class="top-speed">Top Speed: ${item.speed} kph</p>
    </div>
    <a class="details-btn" href="/details/${item._id}">More Info</a>
</div>`;

export async function showDashboard(ctx) {
    const data = await getAllCars();
    render(dashboardTemplate(data));
}