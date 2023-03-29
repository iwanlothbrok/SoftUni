function solve(input){
 
    let output = [];
    
    for (let index = 0; index < input.length; index++){
       if(input[index] < 0){
          output.unshift(input[index]);
       }else{
        output.push(input[index]);
       }}

       console.log(output.join('\n'));
 }
  solve([-1,3, -2, 0]);