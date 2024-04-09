import { html, page, render } from '../lib.js';
import { createSubmitHandler } from '../util.js';
import { createSolution } from '../data/data.js'

const createTemplate = (onCreate) => html`
<section id="create">
    <div class="form">
      <img class="border" src="./images/border.png" alt="" />
      <h2>Add Solution</h2>
      <form class="create-form" @submit=${onCreate}>
        <input type="text" name="type" id="type" placeholder="Solution Type" />
        <input type="text" name="image-url" id="image-url" placeholder="Image URL" />
        <textarea id="description" name="description" placeholder="Description" rows="2" cols="10"></textarea>
        <textarea id="more-info" name="more-info" placeholder="more Info" rows="2" cols="10"></textarea>
        <button type="submit">Add Solution</button>
      </form>
    </div>
</section>`;

export function showCreate(ctx) {
    render(createTemplate(createSubmitHandler(onCreate)));
}

async function onCreate(data, form) {

    const { type, description } = data;
    const imageUrl = data['image-url'];
    const learnMore = data['more-info'];
    if (!type || !imageUrl || !description || !learnMore) {
        return alert('All fields are required!');
    }

    await createSolution(type, imageUrl, description, learnMore);
    page.redirect('/dashboard');
}