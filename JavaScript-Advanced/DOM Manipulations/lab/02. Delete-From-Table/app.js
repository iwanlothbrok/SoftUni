function deleteByEmail() {
    let searchedElement = document.getElementsByName("email")[0].value;
    let secondColumnEmails = document.querySelectorAll('#customers tr td:nth-child(2)');

    for (let td of secondColumnEmails) {
        if (td.textContent == searchedElement) {
            let row = td.parentNode;
            row.parentNode.removeChild(row);
            document.getElementById('result').textContent = "Deleted";
            searchedElement.value = '';
            return;
        }
        searchedElement = '';
        document.getElementById('result').textContent = "Not found.";
    }
}