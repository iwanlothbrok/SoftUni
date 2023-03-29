function solve() {
    const args = {};

    for (let arg of arguments) {
        const type = typeof arg;
        console.log(`${type}: ${arg}`)

        if (args[type] === undefined) {
            args[type] = 0;
        }

        args[type]++;
    }


    Object.entries(args).sort((a,b) => b[1] - a[1]).forEach(e=> console.log(`${e[0]} ${e[1]}`));
}

solve('cat', 42, function () { console.log('Hello world!'); });

// var expectedOutput = [
//     'string: cat',
//     'number: 42',
//     "function: function () { console.log('Hello world!'); }",
//     'string = 1',
//     'number = 1',
//     'function = 1'
// ];