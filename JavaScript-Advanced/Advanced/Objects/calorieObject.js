
function solve(input) {

    let output = [];
    let counter = 2;
    let lastFood = '';
    input.forEach(e => {
        if (counter % 2 == 0) {
            lastFood = e;
        } else {
            let cals = Number(e);
            let food = {};
            food.foodName = lastFood;
            food.calories = cals;

            output.push(food);
        }
        counter++;
    });

   console.log(output);
}
solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);