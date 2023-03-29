
function solve(input){
let towns= [];

input.forEach(line => {
    let [townName, population] = line.split(' <-> ');
    population = Number(population);

    let town = {townName,population};

    if(towns.some(e=>e.townName == townName)){
     towns.find(e=>e.townName == townName).population += population;
        
      return;
    };

    towns.push(town);
});
towns.forEach(town => {
  console.log(town.townName  + ' : ' + town.population)
});

}

solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']);