function ticketManager(input = [], sortCriteria = "") {
    const output = []
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    for (const element of input) {
        let tokens = element.split('|');
        let tempDestination = tokens[0];
        let tempPrice = Number(tokens[1]);
        let tempStatus = tokens[2];

        let ticket = new Ticket(tempDestination, tempPrice, tempStatus);

        output.push(ticket);
    }

    switch (sortCriteria) {
        case "destination":
            output.sort((a, b) => a.destination.localeCompare(b.destination));
            break;
        case "price":
            output.sort((a, b) => a.price - b.price);
            break;
        case "status":
            output.sort((a, b) => a.status.localeCompare(b.status));
            break;

    }

    return output;
}

console.log(
    ticketManager(
        [
            'Philadelphia|94.20|available',
            'New York City|95.99|available',
            'New York City|95.99|sold',
            'Boston|126.20|departed'
        ],
        'destination'
    )
);
console.log("__________________________");

console.log(
    ticketManager(
        [
            'Philadelphia|94.20|available',
            'New York City|95.99|available',
            'New York City|95.99|sold',
            'Boston|126.20|departed'
        ],
        'status'
    )
);