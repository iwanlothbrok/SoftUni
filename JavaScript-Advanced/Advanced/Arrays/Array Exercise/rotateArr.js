function solve(input, rotationCount){

   for(i=0; i < rotationCount; i++){
    let lastElement = input.pop();
    input.unshift(lastElement);
   }

   console.log(input.join(' '));
}

solve(['1', 
'2', 
'3', 
'4'], 
2);