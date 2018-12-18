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
    

    tituloTarefa.textContent = info.Nome;

    var descricaoTarefa = document.createElement("div");
    descricaoTarefa.setAttribute("id", "descricaoTarefa" + info.CodTarefa);
    descricaoTarefa.setAttribute("class", "descricaoTarefa");

    divTarefa.appendChild(descricaoTarefa);


    descricaoTarefa.textContent = info.Descricao;



    var resp = [];

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

    var qtdResponsaveisTarefa = document.createElement("div");
    qtdResponsaveisTarefa.setAttribute("id", "qtdResponsaveisTarefa" + info.CodTarefa);
    qtdResponsaveisTarefa.setAttribute("class", "qtdResponsaveisTarefa");

    divTarefa.appendChild(qtdResponsaveisTarefa);


    qtdResponsaveisTarefa.textContent = resp.length + ((resp.length == 1) ? " Responsável" : " Responsáveis");


    divTarefa.onclick = function () { mostrarDetalhes(info); };

    console.log(info);
}


function mostrarDetalhes(info) {
    detalhes = document.getElementById('infoTarefaDetalhes');

    detalhes.innerHTML = "";

    detalhes.textContent = info.CodTarefa + info.CodWorkspace + info.DataConclusao + info.DataFim + info.DataInicio
        + info.Descricao + info.Nome + info.Porcentagem + info.StatusVida;
}