function solve() {
    let BASE_URL = 'http://localhost:3030/jsonstore/bus/schedule/';
    let currentStop = 'depot';


    function depart() {
        $('#depart').prop('disabled',true);

        $.get(BASE_URL + currentStop).then((e) => {
            let busName = e.name;
            let nextStop = e.next;

            currentStop = nextStop;
            $('#info').find('span').text('Next stop '+ busName);
            $('#arrive').prop('disabled', false);
        });

    }

    function arrive() {
        $('#arrive').prop('disabled',true);
        $('#depart').prop('disabled', false);

        $.get(BASE_URL + currentStop).then((e) => {
            let busName = e.name;

            $('#info').find('span').text('Arrived at '+ busName);
            $('#depart').prop('disabled', false);
        });
    }

    return {
        depart,
        arrive
    };
}

let result = solve();