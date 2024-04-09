import { get, post, put, del } from './request.js';

const endPoints = {
    allItems: '/data/cyberpunk?sortBy=_createdOn%20desc',
    item: '/data/cyberpunk',
};

export async function getAllItems() {
    return await get(endPoints.allItems);
}

export async function createItem(data) {
    return await post(endPoints.item, data)
}

export async function getItemById(id) {
    return await get(`${endPoints.item}/${id}`);
}

export async function updateItem(id, data) {
    return await put(`${endPoints.item}/${id}`, data);
}

export async function deleteItemById(id) {
    return await del(`${endPoints.item}/${id}`);
}