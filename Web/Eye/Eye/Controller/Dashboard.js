
var firstLoaded = false;

function LoadingAll() {



    var loading = document.createElement("div");
    loading.setAttribute("class", "loading");
    loading.setAttribute("id", "loading");

    document.getElementById("areaInfo").appendChild(loading);

    loading.textContent = "Carregando Informações..."
}

function Loaded() {
    document.getElementById("loading").parentNode.removeChild(document.getElementById("loading")); firstLoaded = false;
    firstLoaded = true;
}


function GetUsuariosWorkspace() {
    if (!firstLoaded) {
        LoadingAll();
    }
    PageMethods.GetUsuariosWorkspace(setCodComputadores, onError);
    setTimeout(GetUsuariosWorkspace, 30000);
}



var computadoresUsuarios = [];


function setCodComputadores(usuarios) {
    computadoresUsuarios = usuarios;
    if (!firstLoaded) {
        getLeitura();
        Loaded();
        return computadoresUsuarios;
    }
}


function onError(result) {
    console.log(result);
}



function getLeitura() {

    for (i = 0; i < computadoresUsuarios.length; i++) {
        //console.log(computadoresUsuarios[i]);

        for (j = 0; j < computadoresUsuarios[i].ComputadoresUsuario.length; j++) {

            //console.log(computadoresUsuarios[i].ComputadoresUsuario[j].CodComputador);


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
                computadorMonitor.User = computadoresUsuarios[i].Nome;
                break;
            }
        }

    }






    if (!document.getElementById("infoGeralComputador" + computadorMonitor.CodComputador)) {
        IniciarMonitor(computadorMonitor, leituraMonitor);
    }
    updateChart(computadorMonitor, leituraMonitor);
}




function IniciarMonitor(computadorMonitor, leituraMonitor) {


    var areaInfo = document.getElementById('areaInfo');

    var infoGeralComputador = document.createElement("div");

    infoGeralComputador.setAttribute("class", "infoGeralComputador");
    infoGeralComputador.setAttribute("id", "infoGeralComputador" + computadorMonitor.CodComputador);


    areaInfo.appendChild(infoGeralComputador);

    var tituloComputador = document.createElement("div");
    tituloComputador.setAttribute("class", "tituloComputador");
    tituloComputador.setAttribute("id", "tituloComputador" + computadorMonitor.CodComputador);

    infoGeralComputador.appendChild(tituloComputador);


    tituloComputador.textContent = computadorMonitor.NomeComputador;

    Desenhar("HD", infoGeralComputador, (computadorMonitor.HdTotal / 1e+9).toFixed(2), (leituraMonitor.HdAtual / 1e+9).toFixed(2), computadorMonitor.CodComputador);
    Desenhar("RAM", infoGeralComputador, (computadorMonitor.RamTotal / 1e+9).toFixed(2), (leituraMonitor.RamAtual / 1e+9).toFixed(2), computadorMonitor.CodComputador);
    //Desenhar("CPU", infoGeralComputador, computadorMonitor.CpuAtual, leituraMonitor.CpuAtual);




    DesenharCPU("CPU", infoGeralComputador, 100, leituraMonitor.CpuAtual.toFixed(2), computadorMonitor.CodComputador);


    var detalhesMonitor = document.createElement("div");
    detalhesMonitor.setAttribute("class", "detalhesMonitor");
    detalhesMonitor.setAttribute("id", "detalhesMonitor" + computadorMonitor.CodComputador);

    infoGeralComputador.appendChild(detalhesMonitor);

    addDetalhe(detalhesMonitor, "Usuário", computadorMonitor.User, computadorMonitor.CodComputador);
    addDetalhe(detalhesMonitor, "Perfil", computadorMonitor.Perfil, computadorMonitor.CodComputador);
    addDetalhe(detalhesMonitor, "Processador", computadorMonitor.Processador, computadorMonitor.CodComputador);
    addDetalhe(detalhesMonitor, "SO", computadorMonitor.SistemaOperacional + " " + computadorMonitor.VersaoSistema + " " + computadorMonitor.VersaoBits + " BITS ", computadorMonitor.CodComputador);


}


function addDetalhe(detalhesMonitor, titulo, info, cod) {
    var campoDetalhe = document.createElement("div");
    campoDetalhe.setAttribute("class", "campoDetalhe");
    campoDetalhe.setAttribute("id", "campoDetalhe" + titulo + cod);

    detalhesMonitor.appendChild(campoDetalhe);

    campoDetalhe.textContent = titulo + ": " + info;
}

var chartsData = [];
var chartsCod = [];
var chartsOptions = [];
var chartsComp = [];

var charts = [];
var lineCharts = [];

function Desenhar(componente, infoGeralComputador, total, atual, cod) {



    var style = getComputedStyle(document.body);
    var darkerBgColor = (style.getPropertyValue('--darker-bg-color')).replace(/\s/g, '');
    var angulo = 0,
        cor = (style.getPropertyValue('--blue-color')).replace(/\s/g, '');
    var cor2 = (style.getPropertyValue('--purple-color')).replace(/\s/g, '');


    if (componente == "RAM") {
        cor = (style.getPropertyValue('--pink-color')).replace(/\s/g, '');
    }



    var localChart = document.createElement("div");
    localChart.setAttribute("class", "localChart");
    localChart.setAttribute("id", "localChart" + componente + cod);

    infoGeralComputador.appendChild(localChart);

    var pieChartInfo = document.createElement("canvas");

    pieChartInfo.setAttribute("class", "donutchart" + componente);
    pieChartInfo.setAttribute("id", "donutchart" + componente + cod);

    localChart.appendChild(pieChartInfo);

    var labelChart = document.createElement("div");

    labelChart.setAttribute("class", "labelsChart");
    labelChart.setAttribute("id", "donutchart" + componente + cod);

    localChart.appendChild(labelChart);

    var tituloLabel = document.createElement("div");

    tituloLabel.setAttribute("class", "tituloLabel");
    tituloLabel.setAttribute("id", "tituloLabel" + componente + cod);
    tituloLabel.style.backgroundColor = cor;

    labelChart.appendChild(tituloLabel);

    tituloLabel.textContent = componente;

    var atualLabel = document.createElement("div");

    atualLabel.setAttribute("class", "conteudoLabel");
    atualLabel.setAttribute("id", "conteudoLabelAtual" + componente + cod);

    labelChart.appendChild(atualLabel);

    atualLabel.textContent = "Usado: ";



    var atualValor = document.createElement("div");

    atualValor.setAttribute("class", "conteudoLabel");
    atualValor.setAttribute("id", "conteudoAtual" + componente + cod);

    labelChart.appendChild(atualValor);

    atualValor.textContent = atual + " GB";




    var totalLabel = document.createElement("div");

    totalLabel.setAttribute("class", "conteudoLabel");
    totalLabel.setAttribute("id", "conteudoLabelTotal" + componente + cod);

    labelChart.appendChild(totalLabel);

    totalLabel.textContent = "De: ";



    var totalValor = document.createElement("div");

    totalValor.setAttribute("class", "conteudoLabel");
    totalValor.setAttribute("id", "conteudoTotal" + componente + cod);

    labelChart.appendChild(totalValor);

    totalValor.textContent = total + " GB";










    var c = document.getElementById("donutchart" + componente + cod);
    var ctx = c.getContext("2d");



    var rect = c.getBoundingClientRect();

    console.log(rect.x, rect.width, rect.x - rect.width);

    var gradientStroke = ctx.createLinearGradient(0, 0, window.innerWidth, window.innerHeight);

    gradientStroke.addColorStop(0, cor);
    gradientStroke.addColorStop(0.1, cor2);
    gradientStroke.addColorStop(0.2, cor);


    data = {
        datasets: [{
            data: [atual, total - atual],
            backgroundColor: [gradientStroke, darkerBgColor],
            hoverBackgroundColor: [cor, "#000"]
        }],

        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: [
            componente + ' Usado',
            componente + ' Livre'
        ]

    };




    var options = {
        elements: {
            arc: {
                borderWidth: 0
            }
        },
        legend: {
            display: false
        },
        tooltips: {
            enabled: false
        },
        segmentShowStroke: false,
        cutoutPercentage: 90,
        animationSteps: 100,
        animationEasing: "easeOutBounce",
        animateRotate: true,
        responsive: true,
        maintainAspectRatio: true,
        animateScale: false,


    };

    chartsComp.push(componente);
    chartsCod.push(cod);
    chartsData.push(data);
    chartsOptions.push(options);

    charts.push(new Chart(ctx, {
        type: 'doughnut',
        data: data,
        options: options
    }));




    //console.log(total, total - atual, atual);

}



function updateChart(computadorMonitor, leituraMonitor) {
    var infoGeralComputador = document.getElementById("infoGeralComputador" + computadorMonitor.CodComputador);

    console.log(leituraMonitor.RamAtual);

    Atualizar("HD", infoGeralComputador, (computadorMonitor.HdTotal / 1e+9).toFixed(2), (leituraMonitor.HdAtual / 1e+9).toFixed(2), computadorMonitor.CodComputador);
    Atualizar("RAM", infoGeralComputador, (computadorMonitor.RamTotal / 1e+9).toFixed(2), (leituraMonitor.RamAtual / 1e+9).toFixed(2), computadorMonitor.CodComputador);
    AtualizarCPU("CPU", infoGeralComputador, leituraMonitor.CpuAtual.toFixed(2), computadorMonitor.CodComputador)

}


function Atualizar(componente, infoGeralComputador, total, atual, cod) {
    var style = getComputedStyle(document.body);
    var darkerBgColor = (style.getPropertyValue('--darker-bg-color')).replace(/\s/g, '');

    document.getElementById("conteudoTotal" + componente + cod).textContent = total + " GB";

    document.getElementById("conteudoAtual" + componente + cod).textContent = atual + " GB";




    for (i = 0; i < charts.length; i++) {

        if (chartsCod[i] == cod && chartsComp[i] == componente) {

            var chart = charts[i];

            chart.data.datasets[0].data = [atual, total - atual];



            chart.update();

        }

    }


}



function DesenharCPU(componente, infoGeralComputador, total, atual, cod) {



    var style = getComputedStyle(document.body);
    var darkerBgColor = (style.getPropertyValue('--darker-bg-color')).replace(/\s/g, '');
    var angulo = 0,
        cor = (style.getPropertyValue('--red-color')).replace(/\s/g, '');
    var cor2 = (style.getPropertyValue('--pink-color')).replace(/\s/g, '');


    var areaCPU = document.createElement("div");
    areaCPU.setAttribute("class", "areaCPU");
    areaCPU.setAttribute("id", "areaCPU" + componente + cod);

    infoGeralComputador.appendChild(areaCPU);




    var graficoCpu = document.createElement("div");
    graficoCpu.setAttribute("class", "graficoCpu");
    graficoCpu.setAttribute("id", "graficoCpu" + componente + cod);

    areaCPU.appendChild(graficoCpu);

    var lineChartInfo = document.createElement("canvas");

    lineChartInfo.setAttribute("class", "lineChart" + componente);
    lineChartInfo.setAttribute("id", "lineChart" + componente + cod);

    graficoCpu.appendChild(lineChartInfo);


    var labelCpu = document.createElement("div");
    labelCpu.setAttribute("class", "labelCpu");
    labelCpu.setAttribute("id", "labelCpu" + componente + cod);

    areaCPU.appendChild(labelCpu);

    labelCpu.textContent = "CPU " + atual + " %";




    var c = document.getElementById("lineChart" + componente + cod);
    var ctx = c.getContext("2d");


    var rect = c.getBoundingClientRect();

    console.log(rect.x, rect.width, rect.x - rect.width);

    var gradientStroke = ctx.createLinearGradient(0, 0, window.innerWidth, window.innerHeight);

    gradientStroke.addColorStop(0, cor);
    gradientStroke.addColorStop(0.2, cor2);
    gradientStroke.addColorStop(0.4, cor);



    data = {

        datasets: [{
            data: [],
            backgroundColor: gradientStroke,
            hoverBackgroundColor: [cor, "#000"],
            fill: true,
            borderColor: "rgba(230,230,230,1)",
            borderWidth: 2,
            pointRadius: 10,
            pointHoverRadius: 12,
            showLine: true
        }],

        labels: []

    };




    var options = {
        legend: {
            display: false
        },
        scales: {
            xAxes: [{
                fontColor: cor,
                display: false,
                ticks: {
                    stepSize: 1,
                    fontColor: cor2,
                    beginAtZero: true,
                }
            }],
            yAxes: [{
                scaleLabel: {
                    stepSize: 1,
                    max: 100,
                    min: 0,
                    fontColor: cor,
                    display: false
                },
                ticks: {
                    fontColor: cor2,
                    beginAtZero: true
                }
            }]
        },
        animationSteps: 100,
        animationEasing: "easeOutBounce",
        responsive: true,
        maintainAspectRatio: false,
        animateScale: false,
        scaleOverride: false,
        scaleSteps: 1,
        scaleStartValue: 0,
        scaleEndValue: 100


    };

    chartsComp.push(componente);
    chartsCod.push(cod);
    chartsData.push(data);
    chartsOptions.push(options);

    charts.push(new Chart(ctx, {
        type: 'line',
        data: data,
        options: options
    }));




}



function AtualizarCPU(componente, infoGeralComputador, atual, cod) {
    var style = getComputedStyle(document.body);



    for (i = 0; i < charts.length; i++) {

        if (chartsCod[i] == cod && chartsComp[i] == componente) {

            var chart = charts[i];

            chart.data.labels.push("CPU");
            chart.data.datasets[0].data.push(atual)

            if (chart.data.labels.length > 6) {
                chart.data.labels.shift()
                chart.data.datasets[0].data.shift()
            }

            chart.update();

        }

    }
}



function breakSession() {
    PageMethods.BreakSession(function () { window.location = "Login.aspx" }, onError);
}


