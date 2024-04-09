import { get, post, put, del } from "./request.js"


const endPoints = {
    dashboard: '/data/events?sortBy=_createdOn%20desc',
    events: '/data/events',
    eventById: '/data/events/',
};

export async function getAllEvents() {
    return get(endPoints.dashboard);
}

export async function getEventById(id) {
    return get(endPoints.eventById + id);
}

export async function createEvent(data) {
    return post(endpoints.events, data);
}

export async function updateEvent(id, data) {
    return put(endPoints.eventById + id, data);
}

export async function deleteEvent(id) {
    return del(endPoints.eventById + id);
}