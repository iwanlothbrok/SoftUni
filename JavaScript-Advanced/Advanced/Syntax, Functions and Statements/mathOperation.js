let totalSum = 0;

function sum(firstNumber,secondNumber){
    for (let index = firstNumber; index <= secondNumber; index++) {
    totalSum += index;
    }
    return totalSum;
}

console.log(sum(-8,20));