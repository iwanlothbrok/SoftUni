function focused() {
    let allDivsElements = document.querySelectorAll("div div input");


    allDivsElements.forEach(element => {
        element.addEventListener('focus', focusOn);
    });

    allDivsElements.forEach(element => {
        element.addEventListener('blur', removeFocused);
    });


    function focusOn(e) {
        e.target.parentNode.classList.add('focused');
    }


    function removeFocused(e) {
        e.target.parentNode.classList.removeFocused('focused');
    }
}