
function solve(input) {
let worker = {
    weight: input.weight,
    experience: input.experience,
    levelOfHydrated: input.levelOfHydrated,
    dizziness: input.dizziness
};

if(worker.dizziness == true){
    let neededWater = (worker.weight * 0.1) * worker.experience;

    worker.levelOfHydrated+= neededWater;
    worker.dizziness= false;
}

console.log(worker);
}
solve({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true });