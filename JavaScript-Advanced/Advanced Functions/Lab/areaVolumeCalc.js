function solve(area, vol, input) {
    let parsedInput = JSON.parse(input);

    let result = parsedInput.map(function(onePairInput){
        return{
            area: area.call(onePairInput),
            volume: vol.call(onePairInput)
        };
    });

    return result;
}

console.log(solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`));
    
function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};
