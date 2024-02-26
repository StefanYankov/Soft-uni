function solve() {
  const products = document.querySelectorAll("button.add-product");
  const output = document.getElementsByTagName("textarea")[0];
  const checkoutBtn = document.querySelector("button.checkout");

  const bougthProducts = {};

  for (let i = 0; i < products.length; i++) {
    const product = products[i];
    product.addEventListener("click", addItemToBasket);
  }

  checkoutBtn.addEventListener("click", checkout);
  checkoutBtn.addEventListener("click", disableAllButtons);

  function addItemToBasket(event) {
    const productDiv = event.target.parentNode.parentNode;
    const title = productDiv.querySelector(".product-title").textContent;
    const price = productDiv.querySelector(".product-line-price").textContent;

    bougthProducts[title] = Number(price);

    output.textContent += `Added ${title} for ${price} to the cart.\n`;
    // Disable the button
    event.target.disabled = true;
  }

  function checkout(event) {
    const boughtProductsList = Object.keys(bougthProducts).join(", ");
    const totalPrice = Object.values(bougthProducts).reduce(
      (acc, curr) => acc + curr,
      0
    );
    output.textContent += `You bought ${boughtProductsList} for ${totalPrice.toFixed(
      2
    )}.`;

    event.target.disabled = true;
  }

  function disableAllButtons() {
    const buttons = document.querySelectorAll("button");
    buttons.forEach((button) => {
      button.disabled = true;
    });
  }
}
