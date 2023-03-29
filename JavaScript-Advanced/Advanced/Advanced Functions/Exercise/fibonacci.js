function getFibonator(){
    let firstN = 0;
    let secondN = 1;
    let result = 0;


    return function fib(){
        result = firstN + secondN;
        firstN = secondN;
        secondN = result;

        return firstN;
    }
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); 