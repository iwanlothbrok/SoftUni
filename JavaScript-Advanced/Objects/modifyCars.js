
function solve(input) {
    let car = {
        model: input.model
    };

    if (input.power <= 100) {
        let engine = {
            power: 90,
            volume: 1800,
        };
        car.engine = engine;
    } else if (input.power > 100 && input.power <= 160) {
        let engine = {
            power: 120,
            volume: 2400,
        };
        car.engine = engine;
    } else {
        let engine = {
            power: 200,
            volume: 3500,
        };
        car.engine = engine;
    }

    let carriage = {
        type: input.carriage,
        color: input.color
    };

    car.carriage = carriage;

    while (input.wheelsize % 2 != 1) {
        input.wheelsize -= 1;
    }

    let wheels = [];
    for (i = 0; i < 4; i++) {
        wheels.push(input.wheelsize);
    }

    car.wheels = wheels;


    return car;
}

solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
});