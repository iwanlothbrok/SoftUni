function solve() {
  let text = document.getElementById('text').value;
  let command = document.getElementById('naming-convention').value;

  let arr = [];
  let output = '';
  text = text.toLowerCase();
  text = text.split(' ');

  text.forEach(t => {
    arr.push(t);
  });

  if (command == 'Camel Case') {
    for (i = 0; i < arr.length; i++) {
      if (i == 0) {
        output += arr[i];
      } else {
        let neededWord = arr[i];
        let result = neededWord.charAt(0).toUpperCase() + neededWord.slice(1);

        output += result;
      }
    }
  } else if (command == 'Pascal Case') {
    for (i = 0; i < arr.length; i++) {

      let neededWord = arr[i];
      let result = neededWord.charAt(0).toUpperCase() + neededWord.slice(1);

      output += result;
    }
  } else {
    output = "Error!";
  }

  let resultElement = document.getElementById('result');

  text = '';
  command = '';
  resultElement.innerHTML = output;
}