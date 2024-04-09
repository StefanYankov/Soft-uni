import { searchByQuery } from '../data/data.js';
import { html, render } from '../lib.js';
import { createSubmitHandler } from '../util.js';

const searchTemplate = (onSearch, result) => html`
<section id="search">
<div class="form">
  <h4>Search</h4>
  <form class="search-form" @submit=${onSearch} >
    <input type="text" name="search" id="search-input" />
    <button class="button-list">Search</button>
  </form>
</div>
<div class="search-result">
${result ? showResultTemplate(result) : ""}

    </div>
</section>`;

const showResultTemplate = (result) => html`
    <div class="search-result">

    ${result.length ? result.map(x => html`
    <div class="car">
        <img src="${x.imageUrl}" alt="example1" />
        <h3 class="model">${x.model}</h3>
        <a class="details-btn" href="/details/${x._id}">More Info</a>
      </div>`)
    : html`
    <h2 class="no-avaliable">No result.</h2>
    `}
    </div>`;


export function showSearch() {
  const handler = createSubmitHandler(onSearch);
  render(searchTemplate(handler));
}

async function onSearch(data, form) {
  const { search } = data;
  if (!search) {
    return alert('no query');
  }
  const result = await searchByQuery(search);
  const handler = createSubmitHandler(onSearch);
  render(searchTemplate(handler, result));
}