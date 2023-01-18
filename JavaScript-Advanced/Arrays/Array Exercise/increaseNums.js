function solve(input, rotationCount){

    let output = [];
    let max = Number.MIN_SAFE_INTEGER;

    input.forEach(elm => {
    if(elm >= max){
        max = elm;
      output.push(elm);  
    }
   });
 
    return output;
 }
 
solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]);