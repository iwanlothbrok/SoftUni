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
        newDivElement.className = 'forecast';

        let firstMainSpan = document.createElement('span');
        let secondMainSpan = document.createElement('span');

        
        switch(currentObj.condition){
            case 'Sunny':
            firstMainSpan.textContent = '☀'
            break; 
            case 'Partly sunny':
            firstMainSpan.textContent = '⛅'
            break; 
            case 'Overcast':
            firstMainSpan.textContent = '☁'
            break; 
            case 'Rain':
            firstMainSpan.textContent = '☂'
            break; 
            case 'Degrees':
            firstMainSpan.textContent = '°'
            break; 
         }
         firstMainSpan.className = 'condition symbol';
         secondMainSpan.className = 'condition';

         mainDivElement.appendChild(newDivElement);
         newDivElement.appendChild(firstMainSpan);
            

         let infoSpansOne =  document.createElement('span');
         infoSpansOne.className = 'forecast-data';
         let infoSpansTwo =  document.createElement('span');
         infoSpansTwo.className = 'forecast-data';
         let infoSpansThree =  document.createElement('span');
         infoSpansThree.className = 'forecast-data';

         infoSpansOne.textContent =locationName;
         infoSpansTwo.textContent = currentObj.low + '°' + '/' + currentObj.high + '°';
         infoSpansThree.textContent = currentObj.condition;
         
         secondMainSpan.appendChild(infoSpansOne);
         secondMainSpan.appendChild(infoSpansTwo);
         secondMainSpan.appendChild(infoSpansThree);

         newDivElement.appendChild(secondMainSpan);

        $('#forecast').show();
    }
}

attachEvents();

