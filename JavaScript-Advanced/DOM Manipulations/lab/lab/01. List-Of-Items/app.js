function addItem() {
    let itemsElements = document.getElementById("items");
    let newElement = document.getElementById('newItemText');
    let newLiElement = document.createElement('li');

    newLiElement.textContent += newElement.value;

    itemsElements.appendChild(newLiElement);

    newElement.value = '';
}   