import { getSolutionById, deleteSolution, likeSolutionById, getAllLikesBySolutionId, getAllLikesBySolutionIdAndUserId } from '../data/data.js';
import { html, page, render } from '../lib.js';
import { getUserData, isOwner } from '../util.js';

const detailsTemplate = (item, hasOwner, hasUser, onLike, solutionLikes, isAlreadyLikedByUser) => html`
<section id="details">
    <div id="details-wrapper">
      <img id="details-img" src="${item.imageUrl}" alt="example1" />
      <div>
        <p id="details-type">${item.type}</p>
        <div id="info-wrapper">
          <div id="details-description">
            <p id="description">
            ${item.description}
            </p>
            <p id="more-info">
            ${item.learnMore}
            </p>
          </div>
        </div>
        <h3>Like Solution:<span id="like">${solutionLikes}</span></h3>

        <!--Edit and Delete are only for creator-->
        ${hasUser ? html`
        <div id="action-buttons">
            ${hasOwner ? html`
                <a href="/edit/${item._id}" id="edit-btn">Edit</a>
                <a href="javascript:void(0)" id="delete-btn" @click=${onDelete} data-id=${item._id}>Delete</a>
            ` : html`
                <!--Bonus - Only for logged-in users ( not authors )-->
                ${!isAlreadyLikedByUser ? html`
                <a href="javascript:void(0)" id="like-btn" @click=${onLike}>Like</a>` :
                null
            }
            `}
            </div>
        ` : null}
      </div>
    </div>
</section>`;

export async function showDetails(ctx) {
    const id = ctx.params.id;

    const data = await getSolutionById(id);
    const user = getUserData();

    const solutionLikes = await getAllLikesBySolutionId(id);

    let isAlreadyLikedByUser = false;

    if (user) {
        isAlreadyLikedByUser = await getAllLikesBySolutionIdAndUserId(id, user._id);
    }

    const hasUser = !!user;
    const hasOwner = isOwner(data._ownerId);
    render(detailsTemplate(data, hasOwner, hasUser, onLike, solutionLikes, isAlreadyLikedByUser));

    async function onLike() {
        try {
            await likeSolutionById({ solutionId: data._id });
            page.redirect('/details/' + id);
        } catch (err) {
            console.log(err.message);
        }
    }
}

async function onDelete(event) {
    event.preventDefault();
    const choice = confirm('Are you sure?');
    const id = event.target.dataset.id;
    if (!choice) {
        return;
    }
    await deleteSolution(id);
    page.redirect('/dashboard');
}
