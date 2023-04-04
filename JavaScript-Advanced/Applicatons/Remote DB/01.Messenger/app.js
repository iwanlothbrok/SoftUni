let elements = {
    messages: document.getElementById('messages'),
    refreshBtn: document.getElementById('refresh'),
    sendBtn: document.getElementById('submit'),
    BASE_URL: 'http://localhost:3030/jsonstore/messenger'
};


function attachEvents() {
   // const BASE_URL = 'http://localhost:3030/jsonstore/messenger';

    elements.sendBtn.addEventListener('click', sendMessagesValues)
    elements.refreshBtn.addEventListener('click',getMessagesValue());    
}

function sendMessagesValues(){
    let author =  document.querySelector('label[for="author"]').nextSibling;
    let content = document.querySelector('label[for="content"]').nextSibling;
    const textAreaElement = document.getElementById('messages');

    let data = { 
        author: author.value,
        content: content.value
    }; 

    $.post(elements.BASE_URL,JSON.stringify(data)).then(success);

    function success(data){
        textAreaElement.append(`${data.author}: ${data.content}\n`);
        author.value = '';
        content.value = '';
    }
}

function getMessagesValue(){
    const BASE_URL = 'http://localhost:3030/jsonstore/messenger';
    let textAreaElement = document.getElementById('messages');

    $.get(BASE_URL).then((e) => {
        const mess = Object.values(e);

        
        mess.forEach(el => {
            textAreaElement.append(`${el.author}: ${el.content}\n`);
        });
        // for (let el of mess)
        // $.textAreaElement.append($("<li>").text(
        //     el.author + ": " +
        //     el.content
        // ));
        // $.ajax({
        //     method: "GET",
        //     url: BASE_URL,
        //     success:textAreaElement += mess.map(m => `${m.author}: ${m.content}`).join(`\n`)
        // });
    });
}


attachEvents();