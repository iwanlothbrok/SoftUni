
const elements = {
    BASE_URL: 'http://localhost:3030/jsonstore/phonebook',
    loadBtn: document.getElementById('btnLoad'),
    createBtn: document.getElementById('btnCreate'),
    phonebookElement: document.getElementById('phonebook')
}

function attachEvents() {
    elements.createBtn.addEventListener('click', createPhoneNumber);
    elements.loadBtn.addEventListener('click', getPhoneNumbers)
}

function getPhoneNumbers() {
    $.get(elements.BASE_URL).then((e) => {
        const mess = Object.values(e);


        mess.forEach(el => {
            // create a new list item and append it to the phonebook element
            const li = document.createElement('li');
            li.textContent = `${el.person}: ${el.phone}`;
            elements.phonebookElement.appendChild(li);

            // create a new button and append it to the list item
            const btn = document.createElement('button');
            btn.textContent = 'Delete';
            li.appendChild(btn);

            // attach a click event listener to the button
            btn.addEventListener('click', () => {
                // remove the list item when the button is clicked
                li.parentNode.removeChild(li);
            });
        });
    });
}

function createPhoneNumber() {
    let person = document.getElementById('person').value;
    let phone = document.getElementById('phone').value;

    let data = {
        person: person,
        phone: phone
    }

    $.post(elements.BASE_URL, JSON.stringify(data)).then(success);



    function success(data) {
        let newLiElement = document.createAttribute('li');

        newLiElement.innerHTML = (`${data.person}: ${data.phone}\n`);
        let person = document.getElementById('person').value = '';
        let phone = document.getElementById('phone').value = '';

        getPhoneNumbers();
        elements.phonebookElement.appendChild(newLiElement);
    }
}

attachEvents();