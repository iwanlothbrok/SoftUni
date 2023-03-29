
function solve(input){
    
    input.sort(); 
    let counter = 1;
    input.forEach(outputName => {
        console.log(`${counter}.${outputName}`);
        counter++;
    });
 }

 solve(["John", "Bob", "Christina", "Ema"]);