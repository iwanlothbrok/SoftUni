function create(words) {
   let divElementMajor = document.getElementById('content');

   words.forEach(el => {
      let newDivElement = document.createElement('div');
      let newParagraphElement = document.createElement('p');
      newParagraphElement.textContent += el;
      newParagraphElement.style.display = 'none';
      newDivElement.appendChild(newParagraphElement);

      newDivElement.addEventListener('click', () => {
         newParagraphElement.style.display = 'block';
      })

      divElementMajor.appendChild(newDivElement);
   });


}