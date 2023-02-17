function subtract() {
    let firstElement = document.getElementById('firstNumber').value;
    let lastElement = document.getElementById('secondNumber').value;

    let result = document.getElementById('result');
    result.innerHTML += firstElement - lastElement;

}