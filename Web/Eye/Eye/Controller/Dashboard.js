var qtdComputers = 4; //Teste, essa vai ser a qtd de computadores do usuário
var valoresUsada = [];
var valoresLivre = [];

function iniciarDash() {
    for (i = 0; i < qtdComputers; i++) {

        valoresUsada[i] = Math.random() * 10;

        valoresLivre[i] = Math.random() * 10;

        var areaInfo = document.getElementById('areaInfo');

        var infoGeralComputador = document.createElement("div");

        infoGeralComputador.setAttribute("class", "infoGeralComputador");
        infoGeralComputador.setAttribute("id", "infoGeralComputador" + i);


        areaInfo.appendChild(infoGeralComputador);


        var pieChartInfo = document.createElement("div");

        pieChartInfo.setAttribute("class", "donutchart");
        pieChartInfo.setAttribute("id", "donutchart" + i);


        infoGeralComputador.appendChild(pieChartInfo);

    }
}



google.charts.load("current", { packages: ["corechart"] });
google.charts.setOnLoadCallback(drawChart);
function drawChart() {

    var style = getComputedStyle(document.body);
    var darkerBgColor = (style.getPropertyValue('--darker-bg-color'));
    var redColor = (style.getPropertyValue('--red-color'));
    for (i = 0; i < qtdComputers; i++) {
        var data = google.visualization.arrayToDataTable([
            ['', ''],
            ['Usada', valoresUsada[i]],
            ['Livre', valoresLivre[i]]
        ]);

        var options = {
            pieHole: 0.9,
            backgroundColor: { fill: darkerBgColor.replace(/\s/g, '') },
            colors: [redColor.replace(/\s/g, ''), darkerBgColor.replace(/\s/g, '')],
            pieSliceBorderColor: "transparent",
            pieSliceTextStyle: {
                color: 'white',
            },
            legend: 'none'

        };

        var chart = new google.visualization.PieChart(document.getElementById('donutchart' + i));
        chart.draw(data, options);

        animarPie(chart, options, data, i);

    }


}


function updateChart() {

    var style = getComputedStyle(document.body);
    var darkerBgColor = (style.getPropertyValue('--darker-bg-color'));
    var redColor = (style.getPropertyValue('--red-color'));
    for (i = 0; i < qtdComputers; i++) {
        var data = google.visualization.arrayToDataTable([
            ['', ''],
            ['Usada', valoresUsada[i]],
            ['Livre', valoresLivre[i]]
        ]);

        var options = {
            pieHole: 0.9,
            backgroundColor: { fill: darkerBgColor.replace(/\s/g, '') },
            colors: [redColor.replace(/\s/g, ''), darkerBgColor.replace(/\s/g, '')],
            pieSliceBorderColor: "transparent",
            pieSliceTextStyle: {
                color: 'white',
            },
            legend: 'none'

        };

        var chart = new google.visualization.PieChart(document.getElementById('donutchart' + i));
        chart.draw(data, options);
    }
}


function animarPie(chart, options, data, index) {


    var umPorCento = (valoresUsada[index] + valoresLivre[index]) / 100;

    var pctUsada = valoresUsada[index] / umPorCento;
    var pctLivre = valoresLivre[index] / umPorCento;

    // initial value
    var percent = 0;
    // start the animation loop
    var handler = setInterval(function () {
        // values increment
        percent += 1;
        // apply new values
        data.setValue(0, 1, percent);
        data.setValue(1, 1, 100 - percent);
        // update the pie
        chart.draw(data, options);
        // check if we have reached the desired value
        if (percent >= pctUsada) {
            // stop the loop
            clearInterval(handler);
        }
    }, 10);

}



