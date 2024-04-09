import { html, page, render } from '../lib.js';
import { createSubmitHandler } from '../util.js';
import { getSolutionById, updateSolution } from '../data/data.js'

const editTemplate = (item, onEdit) => html`
<section id="edit">
    <div class="form">
      <img class="border" src="./images/border.png" alt="" />
      <h2>Edit Solution</h2>
      <form class="edit-form" @submit=${onEdit} data-id=${item._id}>
        <input type="text" name="type" id="type" placeholder="Solution Type" .value=${item.type} />
        <input type="text" name="image-url" id="image-url" placeholder="Image URL" .value=${item.imageUrl} />
        <textarea id="description" name="description" placeholder="Description" rows="2" cols="10" .value=${item.description} ></textarea>
        <textarea id="more-info" name="more-info" placeholder="more Info" rows="2" cols="10" .value=${item.learnMore} ></textarea>
        <button type="submit">Edit</button>
      </form>
    </div>
</section>`;

export async function showEdit(ctx) {
    const id = ctx.params.id;
    const handler = createSubmitHandler(onEdit);
    const data = await getSolutionById(id);
    render(editTemplate(data, handler));
}

async function onEdit(data, form) {
    const id = form.dataset.id;

    const { type, description } = data;
    const imageUrl = data['image-url'];
    const learnMore = data['more-info'];
    if (!type || !imageUrl || !description || !learnMore) {
        return alert('All fields are required!');
    }

    await updateSolution(id, type, imageUrl, description, learnMore);
    page.redirect(`/details/${id}`);
}