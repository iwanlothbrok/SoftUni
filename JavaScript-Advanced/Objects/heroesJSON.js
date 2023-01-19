
function solve(input) {

    let heroes = [];

    input.forEach(element => {
        let hero = {};
        element = element.split(' / ')
        hero.name = element[0];
        hero.level = Number(element[1]);

        
        hero.items = element[2].split(', ');

        heroes.push(hero);
    });


    console.log(JSON.stringify(heroes));
}
solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']);