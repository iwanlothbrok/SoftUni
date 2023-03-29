function lockedProfile() {
    let button = document.querySelector('main').addEventListener('click', onClick);

    function onClick(e) {
        if(e.target.nodeName === 'BUTTON'){
   
            let parent = e.target.parentNode;
            let hiddenField = [...parent.querySelectorAll('div')].filter(e => e.id.includes('HiddenFields'))[0];
            let lock = parent.querySelector("input[type='radio'][value='lock']");
            
            if(lock.checked){
                return;
            }
            
            if (hiddenField.style.display !== 'block') {
                hiddenField.style.display = 'block';
                e.target.textContent = "Hide it"
            } else {
                hiddenField.style.display = 'none';
                e.target.textContent = "More"
            }
        }
    }
}