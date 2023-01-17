function solve(input){
 
    let last = Number(input.pop());
    
    input = input.reverse();

    let first = Number(input.pop());

    console.log(first + last);
 }
 
 solve(['20', '30', '40']);