function addItem() {
    let newTextElement = document.getElementById('newItemText');
    let itemsElement = document.querySelector('#items');
    let newLiElement = document.createElement('li');

    newLiElement.textContent += newTextElement.value;

    itemsElement.appendChild(newLiElement);

    newTextElement.value = ' ';
}