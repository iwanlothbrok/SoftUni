 
function getInfo() {
    let stopId = document.getElementById('stopId').value;
    let BASE_URL = 'http://localhost:3030/jsonstore/bus/businfo/';

    if (Number(stopId) != 1287 &&
            Number(stopId) != 1327 &&
            Number(stopId) != 1308 &&
            Number(stopId) != 2334) {

        $('#stopName').text('Error');
    }
    else {

        $.ajax({
            method: "GET",
            url: BASE_URL + Number(stopId),
            success: renderBusSchedule
        });


        function renderBusSchedule(data) {
            $('#stopName').text(data.name);
            console.log(data.name);
            console.log(data.buses);

            $('#buses').empty();
            for (let bus of Object.keys(data.buses)) {
                let busInfo = `Bus ${bus} arrives in ${data.buses[bus]} minutes`;
                $('<li>').text(busInfo).appendTo($('#buses'));
            }
        }
    }
}