function solution() {
    let word = '';

    return {
        append: w => (word += w),
        removeStart: n => (word = word.slice(n)),
        removeEnd: n => (word = word.slice(0, -n)),
        print: () => console.log(word)
    };

}

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();