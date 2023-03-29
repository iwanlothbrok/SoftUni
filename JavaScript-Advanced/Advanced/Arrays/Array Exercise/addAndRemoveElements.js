
function solve(input){

    let ouput = [];
    let counter = 1;
    input.forEach(cmd => {
     if(cmd == 'add'){
        ouput.push(counter);
     }else if(cmd == 'remove'){
        ouput.pop();
     }   

     counter++;
    });    
    if(ouput.length == 0){
        return console.log('Empty');
    }
   console.log(ouput.join('\n'));
}

solve(['remove'
]);