function solve(input){
 
    let output = [];

    input.sort((a, b) => b - a);
    output = input.slice(0,Math.round(input.length / 2)).reverse();


    console.log(output);
}

 solve([3, 19, 14, 7, 2, 19, 6]);