import { get, post, put, del } from './request.js';

const endPoints = {
    allSolutions: '/data/solutions?sortBy=_createdOn%20desc',
    solution: '/data/solutions'
};

export async function getAllSolutions() {
    return await get(endPoints.allSolutions);
}

export async function createSolution(type, imageUrl, description, learnMore) {
    const data = { type, imageUrl, description, learnMore };
    return await post(endPoints.solution, data);
}

export async function getSolutionById(id) {
    return await get(`${endPoints.solution}/${id}`);
}

export async function updateSolution(id, type, imageUrl, description, learnMore) {
    const data = { type, imageUrl, description, learnMore };
    return await put(`${endPoints.solution}/${id}`, data);
}

export async function deleteSolution(id) {
    return await del(`${endPoints.solution}/${id}`);
}

export async function likeSolutionById(data) {
    return await post('/data/likes', data);
}

export async function getAllLikesBySolutionId(solutionId) {
    return await get(`/data/likes?where=solutionId%3D%22${solutionId}%22&distinct=_ownerId&count`);
}

export async function getAllLikesBySolutionIdAndUserId(solutionId, userId) {
    return await get(`/data/likes?where=solutionId%3D%22${solutionId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}