import { get, post, put, del } from './request.js';

const endPoints = {
    allMotorcycles: '/data/motorcycles?sortBy=_createdOn%20desc',
    motorcycle: '/data/motorcycles'
};

export async function getAllMotorcycles() {
    return await get(endPoints.allMotorcycles);
}

export async function createMotorcycle(data) {
    return await post(endPoints.motorcycle, data);
}

export async function getMotorcycleById(id) {
    return await get(`${endPoints.motorcycle}/${id}`);
}

export async function updateMotorcycle(id, data) {
    return await put(`${endPoints.motorcycle}/${id}`, data);
}

export async function deleteMotorcycle(id) {
    return await del(`${endPoints.motorcycle}/${id}`);
}

export async function searchByQuery(query) {
    return await get(`/data/motorcycles?where=model%20LIKE%20%22${query}%22`);
}