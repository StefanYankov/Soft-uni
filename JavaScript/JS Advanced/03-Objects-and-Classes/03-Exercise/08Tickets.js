function tickets(tickets = [], criteria) {

    class Ticket {
        constructor(descriptor) {
            const [destination, price, status] = descriptor.split('|');
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    const comparator = {
        destination: (a,b) => a.destination.localeCompare(b.destination),
        price: (a,b) => a - b,
        status: (a,b) => a.status.localeCompare(b.status)
    }

    /*
    function comparator(a, b){
        try {
            return a[criteria].localeCompare(b[criteria]);
        } catch (e) {
            return a[criteria] - b[criteria];
        }
    }
    */

    return tickets.map(t => new Ticket(t)).sort(comparator[criteria]);
}

const input = [
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
];

let sortingCriterion = 'destination';

const input2 = [
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
];

let sortingCriterion2 = 'status';

console.log(tickets(input,sortingCriterion));