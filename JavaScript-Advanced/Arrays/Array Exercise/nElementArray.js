
function solve(input, count){

    let ouput = [];
    let counter = 0;
    input.forEach(num => {
        if(counter % count == 0){
            ouput.push(num)}

            counter++;
        });
    
   return ouput;
}

solve(['1', 
'2',
'3', 
'4', 
'5'], 
6);