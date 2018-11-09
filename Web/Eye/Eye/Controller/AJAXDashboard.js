function RequestAtualizarMonitores(codComputador) {
    "use strict";
    
    var request = new XMLHttpRequest();

    request.open('POST', '../View/Dashboard.aspx/AtualizarMonitores', true); 


    request.send(codComputador);

    request.addEventListener('readystatechange', function () {


        if (isRequestOk()) {

           //Pega a bosta q eu quero
        }

        function isRequestOk() {
            return request.readyState === 4 && request.status === 200;
        }
    }, false);

}