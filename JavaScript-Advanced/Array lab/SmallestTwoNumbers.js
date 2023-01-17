function solve(input){
 
    let output = [];

    input.sort((a, b) => a-b);
    output = input.slice(0,2);

    console.log(output.join(' '))
 }

 solve([3, 0, 10, 4, 7, 3]);