function ticketDatabase(ticketArray = [], sortType) {

    const database = [];
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    for (let i = 0; i < ticketArray.length; i++) {
        let [tempDestination, tempPrice, tempStatus] = ticketArray[i].split('|');
        tempPrice = Number(tempPrice);
        let tempTicket = new Ticket(tempDestination, tempPrice, tempStatus);
        database.push(tempTicket);
    }

    let sortedDatabase = database.sort((a, b) => {
        if (sortType === 'destination') {
            return a.destination.localeCompare(b.destination);
        } else if (sortType === 'price') {
            return a.price - b.price;
        } else if (sortType === 'status') {
            return a.status.localeCompare(b.status);
        }
    })
    return sortedDatabase;
}

console.log(ticketDatabase(
    ['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'));

console.log(ticketDatabase(
    ['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'status'
));