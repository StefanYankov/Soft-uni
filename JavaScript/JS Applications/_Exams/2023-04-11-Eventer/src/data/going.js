import { get, post, put, del } from './request.js';

const endPoints = {
    goToEvent: '/data/going',
    visitorsByEventId: (eventId) => `/data/going?where=eventId%3D%22${eventId}%22&distinct=_ownerId&count`,
    isGoing: (eventId, userId) => `/data/going?where=eventId%3D%22${eventId}%22%20and%20_ownerId%3D%22${userId}%22&count`,
};

export async function goToEvent(eventId) {
    await post(endPoints.goToEvent, { eventId });
}

export async function getVisitorById(eventId) {
    return get(endPoints.visitorsByEventId(eventId));
}

export async function isGoing(eventId, userId) {
    return get(endPoints.isGoing(eventId, userId));
}