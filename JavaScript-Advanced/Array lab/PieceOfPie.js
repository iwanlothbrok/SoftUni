function solve(input, firstElement, lastElement){
 
    let output = [];
    let isFound = false;
    input.forEach(elm => {
        if(elm == lastElement){
            isFound = false;
            output.push(elm);}
        if(elm == firstElement || isFound == true){
                isFound = true;
                output.push(elm);
            }
    })
console.log(output.join(', \n'))
}

solve(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie');