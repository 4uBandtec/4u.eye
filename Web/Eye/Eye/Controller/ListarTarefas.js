
function classificando() {
    if (document.getElementById("lblNomeProcesso").textContent == "") {
        document.getElementById("classific").style.display = "none";
    }
}

function listar() {
    PageMethods.ListarTarefas(listarTarefas, onError);

}

function listarTarefas(lista) {
    
    for (i = 0; !!lista[i]; i++) {
        inserirTarefa(lista[i]);
    }
}

function onError(erro) {
    console.log(erro);
}

function inserirTarefa(info) {
    var lt = document.getElementById("listaDeTarefas");

    var divTarefa = document.createElement("div");
    divTarefa.setAttribute("id", "Tarefa" + info.CodTarefa);
    divTarefa.setAttribute("class", "infoTarefa");

    lt.appendChild(divTarefa);


    var tituloTarefa = document.createElement("div");
    tituloTarefa.setAttribute("id", "tituloTarefa" + info.CodTarefa);
    tituloTarefa.setAttribute("class", "tituloTarefa");

    divTarefa.appendChild(tituloTarefa);
    

    tituloTarefa.textContent = (info.Nome + " - " + ((info.StatusVida == 1) ? "Ativa" : "Finalizada"));

    var descricaoTarefa = document.createElement("div");
    descricaoTarefa.setAttribute("id", "descricaoTarefa" + info.CodTarefa);
    descricaoTarefa.setAttribute("class", "descricaoTarefa");

    divTarefa.appendChild(descricaoTarefa);


    descricaoTarefa.textContent = info.Descricao;



    var resp = [];
    var proc = [];

    for (k = 0; !!(info.ProcessoTarefa[k]); k++) {
        var duplicado = false;
        for (j = 0; j < resp.length; j++) {
            if (info.ProcessoTarefa[k].NomeUsuario == resp[j]) {
                duplicado = true;
            }
        }

        if (duplicado == false) {
            resp.push(info.ProcessoTarefa[k].NomeUsuario);
        }
    }

    for (k = 0; !!(info.ProcessoTarefa[k]); k++) {
        var duplicado = false;
        for (j = 0; j < resp.length; j++) {
            if (info.ProcessoTarefa[k].NomeProcesso == proc[j]) {
                duplicado = true;
            }
        }

        if (duplicado == false) {
            proc.push(info.ProcessoTarefa[k].NomeProcesso);
        }
    }

    var qtdResponsaveisTarefa = document.createElement("div");
    qtdResponsaveisTarefa.setAttribute("id", "qtdResponsaveisTarefa" + info.CodTarefa);
    qtdResponsaveisTarefa.setAttribute("class", "qtdResponsaveisTarefa");

    divTarefa.appendChild(qtdResponsaveisTarefa);


    qtdResponsaveisTarefa.textContent = resp.length + ((resp.length == 1) ? " Responsável" : " Responsáveis");



    var qtdProcessosTarefa = document.createElement("div");
    qtdProcessosTarefa.setAttribute("id", "qtdProcessosTarefa" + info.CodTarefa);
    qtdProcessosTarefa.setAttribute("class", "qtdResponsaveisTarefa");

    divTarefa.appendChild(qtdProcessosTarefa);


    qtdProcessosTarefa.textContent = proc.length + ((proc.length == 1) ? " Processo" : " Processos");


    


    var progressoTarefa = document.createElement("div");
    progressoTarefa.setAttribute("id", "progressoTarefa" + info.CodTarefa);
    progressoTarefa.setAttribute("class", "progressoTarefa");

    divTarefa.appendChild(progressoTarefa);



    var trackProgressoTarefa = document.createElement("div");
    trackProgressoTarefa.setAttribute("id", "trackProgressoTarefa" + info.CodTarefa);
    trackProgressoTarefa.setAttribute("class", "trackProgressoTarefa");

    progressoTarefa.appendChild(trackProgressoTarefa);


    var barProgressoTarefa = document.createElement("div");
    barProgressoTarefa.setAttribute("id", "barProgressoTarefa" + info.CodTarefa);
    barProgressoTarefa.setAttribute("class", "barProgressoTarefa");

    trackProgressoTarefa.appendChild(barProgressoTarefa);

    barProgressoTarefa.style.width = info.Porcentagem + "%";


    var pctProgressoTarefa = document.createElement("div");
    pctProgressoTarefa.setAttribute("id", "pctProgressoTarefa" + info.CodTarefa);
    pctProgressoTarefa.setAttribute("class", "pctProgressoTarefa");

    progressoTarefa.appendChild(pctProgressoTarefa);

    pctProgressoTarefa.textContent = info.Porcentagem + "%";
    

   


    divTarefa.onclick = function () { mostrarDetalhes(info); };

    console.log(info);
}


function mostrarDetalhes(info) {
    detalhes = document.getElementById('descTarefaDetalhes');
    nomeTarefaDetalhes = document.getElementById('nomeTarefaDetalhes');
    descTarefaDetalhes = document.getElementById('descTarefaDetalhes');
    dataInicioTarefaDetalhes = document.getElementById('dataInicioTarefaDetalhes');
    dataFimTarefaDetalhes = document.getElementById('dataFimTarefaDetalhes');
    dataFinalizadaTarefaDetalhes = document.getElementById('dataFinalizadaTarefaDetalhes');
    progressoTarefaDetalhes = document.getElementById('progressoTarefaDetalhes');
    trackProgressoTarefaDetalhes = document.getElementById('trackProgressoTarefaDetalhes');
    barProgressoTarefaDetalhes = document.getElementById('barProgressoTarefaDetalhes');
    pctProgressoTarefaDetalhes = document.getElementById('pctProgressoTarefaDetalhes');
    areaUsersTarefaDetalhes = document.getElementById('areaUsersTarefaDetalhes');
    

    nomeTarefaDetalhes.textContent = info.Nome;
    descTarefaDetalhes.textContent = info.Descricao;
    dataInicioTarefaDetalhes.textContent = "Inicio: "+info.DataInicio;
    dataFimTarefaDetalhes.textContent = "Prazo: " + info.DataFim;
    dataFinalizadaTarefaDetalhes.textContent = "Conclusão: " + ((info.DataConclusao != 0) ? info.DataConclusao : "Não Concluida");
    pctProgressoTarefaDetalhes.textContent = info.Porcentagem + "%";
    barProgressoTarefaDetalhes.style.width = info.Porcentagem + "%";



    //detalhes.textContent = info.CodTarefa + info.CodWorkspace + info.DataConclusao + info.DataFim + info.DataInicio
    //    + info.Descricao + info.Nome + info.Porcentagem + info.StatusVida;
}