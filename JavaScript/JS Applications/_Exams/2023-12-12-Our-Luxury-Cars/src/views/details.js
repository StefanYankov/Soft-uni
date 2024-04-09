import { html, page, render } from '../lib.js';
import { isOwner } from '../util.js';
import { getCarById, deleteCar } from '../data/data.js';

const detailsTemplate = (item, hasOwner) => html`
<section id="details">
<div id="details-wrapper">
  <img id="details-img" src="${item.imageUrl}" alt="example1" />
  <p id="details-title">${item.model}</p>
  <div id="info-wrapper">
    <div id="details-description">
      <p class="price">Price: €${item.price}</p>
      <p class="weight">Weight: ${item.weight} kg</p>
      <p class="top-speed">Top Speed: ${item.speed} kph</p>
      <p id="car-description">
        ${item.about}
      </p>
    </div>
    <!--Edit and Delete are only for creator-->
    ${hasOwner ? html`
    <div id="action-buttons">
        <a href="/edit/${item._id}" id="edit-btn">Edit</a>
        <a href="javascript:void(0)" id="delete-btn" @click=${onDelete} data-id=${item._id}>Delete</a>
    </div>
    ` :
        ''}
  </div>
</div>
</section>`;

export async function showDetails(ctx) {
    const id = ctx.params.id;

    const data = await getCarById(id);
    const hasOwner = isOwner(data._ownerId);
    render(detailsTemplate(data, hasOwner));
}

async function onDelete(event) {
    event.preventDefault();
    const choice = confirm('Are you sure?');
    const id = event.target.dataset.id;
    if (!choice) {
        return;
    }
    await deleteCar(id);
    page.redirect('/dashboard');
}