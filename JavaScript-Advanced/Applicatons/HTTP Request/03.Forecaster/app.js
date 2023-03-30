function attachEvents() {
    let BASE_URL = 'http://localhost:3030/jsonstore/forecaster/today/';

    const elements = {
        localInput: document.querySelector('#location'),
        button: document.querySelector('#submit'),
    }

    elements.button.addEventListener('click',getLocationValue);


    function getLocationValue(){
        const location = elements.localInput.value;

        $.get(BASE_URL + location).then((e) => {
            let locationName = e.name;
            let forecast = e.forecast;

            $('#current').find('div .label').text(locationName);

            $.ajax({
                method: "GET",
                url: BASE_URL + location,
                success: setLocation(locationName,forecast)
            });
        });
    }

    function setLocation(locationName, forecast){
        let currentObj = {
            condition: forecast.condition,
             high: forecast.high,
             low: forecast.low
        }

        let mainDivElement = document.getElementById('current');
        let newDivElement = document.createElement('div');

        let firstMainSpan = document.createElement('span');
        let secondMainSpan = document.createElement('span');

        newDivElement.appendChild(secondMainSpan);
        
        switch(currentObj.condition){
            case 'Sunny':
            firstMainSpan.value = '&#x2600;'
            break; 
            case 'Partly sunny':
            firstMainSpan.value = '&#x26C5;'
            break; 
            case 'Overcast':
            firstMainSpan.value = '&#x2601;'
            break; 
            case 'Rain':
            firstMainSpan.value = '&#x2614;'
            break; 
            case 'Degrees':
            firstMainSpan.value = '&#176;'
            break; 
         }
         
         mainDivElement.appendChild(newDivElement);
         newDivElement.appendChild(firstMainSpan);
            
        console.log(forecast);
        $('#forecast').show();

        //$('#current').find('label').text(locationName);
        //$('#upcoming').find('label').text(locationName);
    }
}

attachEvents();

