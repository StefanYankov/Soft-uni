class Kitchen {
    constructor(budget) {
        this.budget = Number(budget);
        this.menu = {};
        this.productsInStock = {}
        this.actionsHistory = []
    }

    loadProducts(products) {

        for (let i = 0; i < products.length; i++) {

            let [product, quantity, productPrice] = products[i].split(' ');
            quantity = Number(quantity);
            productPrice = Number(productPrice);
            // "{productName} {productQuantity} {productPrice}"
            if ((this.budget - productPrice) >= 0) {
                if (this.productsInStock[product]){
                    this.productsInStock[product] += quantity
                } else {
                    this.productsInStock[product] = quantity
                }
                this.budget -= productPrice;
                this.actionsHistory.push( `Successfully loaded ${quantity} ${product}`);
            } else {
                this.actionsHistory.push(`There was not enough money to load ${quantity} ${product}`);
            }
        }
        return this.actionsHistory.join('\n');
    }

    addToMenu(meal, neededProducts = [], price){
        if (!this.menu[meal]){

            this.menu[meal] = {
                products: neededProducts,
                price: Number(price)
            }
            return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals on the menu, other ideas?`;
        } else {
            return `The ${meal} is already in our menu, try something different.`;
        }
    }

    showTheMenu(){
        if (this.menu.length === 0){
            console.log("Our menu is not ready yet, please come later...");
        } else {

            this.menu.array.forEach(element => {
                console.log(`${element.meal} - $ ${element.meal.price}`)
            });
        }

    }
}

let kitchen = new Kitchen(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
//console.log(kitchen.showTheMenu());