function search() {
   let townsElement = document.querySelectorAll('ul li');
   let searchWord = document.getElementById('searchText').value;
   let result = document.getElementById('result');

   result.textContent = ' ';

   let arr = [];

   if (searchWord.length <= 0) {
      return;
   }
   townsElement.forEach(element => {
      let neededElement = element.textContent.substring(0, searchWord.length);

      if (searchWord.toLowerCase() == neededElement.toLowerCase()) {
         arr.push(neededElement);
      }
   });

   console.log(arr);


   if (arr.length > 0) {
      result.innerHTML += `${arr.length} matches found.`
   }

   searchWord.value = ' ';

}
