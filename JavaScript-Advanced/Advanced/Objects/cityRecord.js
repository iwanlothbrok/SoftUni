
function solve(name, population, treasury) {

  let output = { name, population, treasury };

  output.population = Number(output.population);
  output.treasury = Number(output.treasury);

  return output;
}
solve('Tortuga', 7000, 15000);