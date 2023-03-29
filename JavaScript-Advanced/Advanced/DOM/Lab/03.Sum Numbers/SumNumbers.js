function calc() {
    let firstNumber = Number(document.getElementById('num1').value);
    let secondNumber = Number(document.getElementById('num2').value);
    let result = document.getElementById(`sum`);

    result.value = firstNumber + secondNumber;
}
