
function solution(a) {
    var num = a;

    return function add(b) {
        return num + b;
    }
}


let add5 = solution(5);
console.log(add5(2)); //7
console.log(add5(3)); //8
