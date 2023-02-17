function colorize() {
    let tablesElements = document.querySelectorAll('table tr');

    let counter = 1;
    tablesElements.forEach(e => {
        if (counter % 2 == 0) {
            e.style.background = 'blue';
        }
        counter++;
    });
}