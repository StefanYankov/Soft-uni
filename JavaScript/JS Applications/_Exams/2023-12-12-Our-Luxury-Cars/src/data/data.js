import { get, post, put, del } from './request.js';

const endPoints = {
    allCars: '/data/cars?sortBy=_createdOn%20desc',
    car: '/data/cars'
};

export async function getAllCars() {
    return await get(endPoints.allCars);
}

export async function createCar(data) {
    return await post(endPoints.car, data);
}

export async function getCarById(id) {
    return await get(`${endPoints.car}/${id}`);
}

export async function updateCar(id, data) {
    return await put(`${endPoints.car}/${id}`, data);
}

export async function deleteCar(id) {
    return await del(`${endPoints.car}/${id}`);
}

export async function searchByQuery(query) {
    return await get(`/data/cars?where=model%20LIKE%20%22${query}%22`);
}