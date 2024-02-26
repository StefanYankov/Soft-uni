function solve() {
  const addFurnitureBtn = document.querySelectorAll("button")[0];
  const buyFurnitureBtn = document.querySelectorAll("button")[1];
  const buyTextArea = document.querySelectorAll("textarea")[1];

  const tableBody = document.querySelector("table.table tbody");
  addFurnitureBtn.addEventListener("click", addFurniture);
  buyFurnitureBtn.addEventListener("click", buyFurniture);

  function addFurniture(event) {
    const parentElement = event.currentTarget.parentNode;
    const inputFurnitureJson =
      parentElement.querySelectorAll("textarea")[0].value;

    const furnitureObj = JSON.parse(inputFurnitureJson);

    for (let i = 0; i < furnitureObj.length; i++) {
      const item = furnitureObj[i];
      const newRowElement = document.createElement("tr");
      for (const key in item) {
        const tdElement = document.createElement("td");

        if (key === "img") {
          const imageElement = document.createElement("img");
          imageElement.src = item[key];
          tdElement.appendChild(imageElement);
        } else {
          tdElement.textContent = item[key];
        }

        newRowElement.appendChild(tdElement);
      }
      const markElement = document.createElement("td");
      const inputElement = document.createElement("input");
      inputElement.type = "checkbox";
      markElement.appendChild(inputElement);
      newRowElement.appendChild(markElement);
      tableBody.appendChild(newRowElement);
    }
  }

  function buyFurniture(event) {
    let output = [];
    let selectedRows = document.querySelectorAll(
      "input[type='checkbox']:checked"
    );

    for (let i = 0; i < selectedRows.length; i++) {
      const element = Array.from(
        selectedRows[i].parentElement.parentElement.children
      );
      let name = element[1].innerHTML;
      let price = Number(element[2].innerHTML);
      let decorationFactor = Number(element[3].innerHTML);
      addItem(output, name, price, decorationFactor);
    }
    buyTextArea.value = `Bought furniture: ${output
      .map((x) => x.Name)
      .join(", ")}\nTotal price: ${output.reduce(
      (acc, item) => acc + item.Price,
      0
    )}\nAverage decoration factor: ${
      output.reduce((acc, item) => acc + item.DecorationFactor, 0) /
      output.length
    }`;
    console.log(output);

    function addItem(array, name, price, decorationFactor) {
      array.push({
        Name: name,
        Price: price,
        DecorationFactor: decorationFactor,
      });
    }
  }
}
