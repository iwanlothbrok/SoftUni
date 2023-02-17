function toggle() {
    let button = document.getElementsByClassName("button")[0];
    let neededDiv = document.getElementById('extra');
    
    if(button.textContent == 'More'){
        neededDiv.style.display = "block"
        button.textContent = 'Less';
    }else{
        neededDiv.style.display = "none"

        button.textContent = 'More';
    }
}