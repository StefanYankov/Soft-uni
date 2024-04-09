import { html, page, render } from '../lib.js';
import { createSubmitHandler } from '../util.js';
import { getCarById, updateCar } from '../data/data.js'

const editTemplate = (item, onEdit) => html`
<section id="edit">
    <div class="form form-auto">
      <h2>Edit Your Car</h2>
      <form class="edit-form" @submit=${onEdit} data-id=${item._id} >
        <input type="text" name="model" id="model" placeholder="Model" .value=${item.model} />
        <input type="text" name="imageUrl" id="car-image" placeholder="Your Car Image URL" .value=${item.imageUrl} />
        <input type="text" name="price" id="price" placeholder="Price in Euro" .value=${item.price} />
        <input type="number" name="weight" id="weight" placeholder="Weight in Kg" .value=${item.weight} />
        <input type="text" name="speed" id="speed" placeholder="Top Speed in Kmh" .value=${item.speed}  />
        <textarea id="about" name="about" placeholder="More About The Car" rows="10" cols="50" .value=${item.about}  ></textarea>
        <button type="submit">Edit</button>
      </form>
    </div>
</section>`;

export async function showEdit(ctx) {
    const id = ctx.params.id;
    const handler = createSubmitHandler(onEdit);
    const data = await getCarById(id);
    render(editTemplate(data, handler));
}

async function onEdit(data, form) {
    const id = form.dataset.id;

    const { model, imageUrl, price, weight, speed, about } = data;

    if (!model || !imageUrl || !price || !weight || !speed || !about) {
        return alert('All fields are required!');
    }

    await updateCar(id, data);
    page.redirect(`/details/${id}`);
}