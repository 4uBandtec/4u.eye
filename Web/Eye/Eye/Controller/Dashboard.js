


function updateChart() {

}


function animarPie(chart, options, data, index, total, atual) {


    var umPorCento = (total) / 100;


    // initial value
    var percent = 0;
    // start the animation loop
    var handler = setInterval(function () {
        // values increment
        percent += umPorCento;
        // apply new values
        data.setValue(0, 1, percent);
        data.setValue(1, 1, total - percent);
        // update the pie
        chart.draw(data, options);
        // check if we have reached the desired value
        if (percent >= atual) {
            // stop the loop
            clearInterval(handler);
        }
    }, 10);
}





function GetUsuariosWorkspace() {
    PageMethods.GetUsuariosWorkspace(setCodComputadores, onError);
}



var computadoresUsuarios = [];


function setCodComputadores(usuarios) {
    computadoresUsuarios = usuarios;
    setTimeout(getLeitura(), 1000);
    return computadoresUsuarios;
}


function onError(result) {
    console.log(result);
}



function getLeitura() {

    for (i = 0; i < computadoresUsuarios.length; i++) {
        console.log(computadoresUsuarios[i]);

        for (j = 0; j < computadoresUsuarios[i].ComputadoresUsuario.length; j++) {

            console.log(computadoresUsuarios[i].ComputadoresUsuario[j].CodComputador);


            PageMethods.AtualizarComputadores(computadoresUsuarios[i].ComputadoresUsuario[j].CodComputador, AtualizarDashboard, onError);
        }

    }

    setTimeout(getLeitura, 5000);
}


function AtualizarDashboard(leituraAtual) {
    if (!!leituraAtual) {

        SetDadosMonitor(leituraAtual);

    }
    else {
        console.log("Não existe nenhuma leitura desse computador, certifique-se se a aplicação local está rodando nele")

    }


}


function SetDadosMonitor(leituraMonitor) {

    var computadorMonitor;

    for (i = 0; i < computadoresUsuarios.length; i++) {

        for (j = 0; j < computadoresUsuarios[i].ComputadoresUsuario.length; j++) {

            if (computadoresUsuarios[i].ComputadoresUsuario[j].CodComputador == leituraMonitor.CodComputador) {
                computadorMonitor = computadoresUsuarios[i].ComputadoresUsuario[j];
                break;
            }
        }
    }

    if (!document.getElementById("infoGeralComputador" + computadorMonitor.CodComputador)) {
        IniciarMonitor(computadorMonitor, leituraMonitor);
    }
}




google.charts.load("current", { packages: ["corechart"] });

function IniciarMonitor(computadorMonitor, leituraMonitor) {



    var areaInfo = document.getElementById('areaInfo');

    var infoGeralComputador = document.createElement("div");

    infoGeralComputador.setAttribute("class", "infoGeralComputador");
    infoGeralComputador.setAttribute("id", "infoGeralComputador" + computadorMonitor.CodComputador);


    areaInfo.appendChild(infoGeralComputador);


    Desenhar("HD", infoGeralComputador, computadorMonitor.HDTotal, leituraMonitor.HDAtual, computadorMonitor.CodComputador);
    Desenhar("RAM", infoGeralComputador, computadorMonitor.RAMTotal, leituraMonitor.RAMAtual, computadorMonitor.CodComputador);
    //Desenhar("CPU", infoGeralComputador, computadorMonitor.CPUAtual, leituraMonitor.CPUAtual);
}


function Desenhar(componente, infoGeralComputador, total, atual, cod) {

    


    var pieChartInfo = document.createElement("div");

    pieChartInfo.setAttribute("class", "donutchart" + componente);
    pieChartInfo.setAttribute("id", "donutchart" + componente + cod);


    infoGeralComputador.appendChild(pieChartInfo);



    var style = getComputedStyle(document.body);
    var darkerBgColor = (style.getPropertyValue('--darker-bg-color'));
    var angulo = 0,
        cor = style.getPropertyValue('--red-color');

    if (componente == "RAM") {
        angulo = 180;
        cor = style.getPropertyValue('--purple-color');
    }

    var data = google.visualization.arrayToDataTable([
        ['', ''],
        [componente + ' Usado', total],
        [componente + ' Livre', atual]
    ]);



    var options = {
        pieHole: 0.9,
        backgroundColor: { fill: darkerBgColor.replace(/\s/g, '') },
        colors: [cor.replace(/\s/g, ''), darkerBgColor.replace(/\s/g, '')],
        pieSliceBorderColor: "transparent",
        pieSliceTextStyle: {
            color: 'white',
        },
        legend: 'none',
        pieStartAngle: angulo
    };

    var chart = new google.visualization.PieChart(document.getElementById('donutchart' + componente + cod));
    chart.draw(data, options);

    animarPie(chart, options, data, cod, total, atual);


}    
