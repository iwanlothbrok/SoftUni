function deleteByEmail() {
  let emailsElement = document.querySelectorAll('table tbody tr');

  let neededEmail = document.getElementsByName('email')[0].value;

  emailsElement.forEach(element => {

    if (element.inludes(neededEmail)) {
      element.remove()
    }
    console.log(element.textContent);
  });


  console.log(neededEmail);
}