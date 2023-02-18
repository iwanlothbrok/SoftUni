function addItem() {
    let newTextInput = document.getElementById('newItemText');
    let newValueInput = document.getElementById('newItemValue');

    let optionElement = document.createElement('option');
    optionElement.textContent = newTextInput.value;
    optionElement.value = newValueInput.value;


    let menuElement = document.getElementById('menu');
    menuElement.appendChild(optionElement);

    newTextInput.value = '';
    newValueInput.value = '';
}