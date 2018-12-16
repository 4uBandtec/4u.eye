
var listaCodUsersTarefa = [];
var listaProcTarefa = [];
var listaTempoTarefa = [];


var taVerde = false;

function iniciarPainelTarefas() {

    var AreaCadastroTarefa = document.getElementById("AreaCadastroTarefa");
    var AreaConfig = document.getElementById("AreaConfig");
    var btnFormCadastrarTarefa = document.getElementById("btnFormCadastrarTarefa");

    AreaConfig.style.opacity = 0;
    btnFormCadastrarTarefa.style.opacity = 0;

}


function validaCamposTarefa() {

    var style = getComputedStyle(document.body);
    var greencolor = style.getPropertyValue('--green-color').replace(/\s/g, '');
    var redcolor = style.getPropertyValue('--red-color').replace(/\s/g, '');

    if (taVerde) {
        lblMensagem.style.color = redcolor;
        lblMensagem.textContent = "";
        taVerde = false;
    }

    txtNome = document.getElementById("txtNome");
    txtDescricao = document.getElementById("txtDescricao");
    txtDataInicio = document.getElementById("txtDataInicio");
    txtDataFim = document.getElementById("txtDataFim");

    var AreaCadastroTarefa = document.getElementById("AreaCadastroTarefa");
    var AreaConfig = document.getElementById("AreaConfig");
    var btnFormCadastrarTarefa = document.getElementById("btnFormCadastrarTarefa");


    btnFormCadastrarTarefa.style.opacity = 0;

    if (txtNome.value == "") {
        return [false, "Você esqueceu o nome da tarefa"];
    }
    else if (txtDescricao.value == "") {
        return [false, "Oops, faltou descrever a tarefa"];
    }
    else if (txtDataInicio.value == "") {
        return [false, "Você não me disse quando a tarefa vai começar"];
    }
    else if (txtDataFim.value == "") {
        return [false, "Faltou a data limite pra fializar a tarefa"];
    }
    else if (!fimMaiorQueInicio(txtDataFim.value, txtDataInicio.value)) {
        if (txtDataFim.value.length >= 10 && txtDataInicio.value.length >= 10) {
            lblMensagem.textContent = "Tem algo de errado com as datas, lembre-se de deixar o fim maior que o começo"
        }
        return [false, "Tem algo de errado com as datas, lembre-se de deixar o fim maior que o começo"];
    }
    else {

        lblMensagem.textContent = "";

        AreaConfig.style.opacity = 1;
        btnFormCadastrarTarefa.style.opacity = 0;

        desbloqueiaCamposConfig();

        return [validaCamposConfig(), "Essa tarefa deve estar associada a pelo menos 1 usuário"];
    }
    return [false, "Algo deu errado"];
}

function validaCamposConfig() {
    

    let index = 0
    var allItens = document.querySelectorAll(".conteudoTarefa");

    var btnAdicionar = document.getElementById("btnAdicionar");

    var btnCadastrarTarefa = document.getElementById("btnCadastrarTarefa");

    var tudoPreenchido = true;
    var retorno = false;

    btnAdicionar.disabled = true;
    btnCadastrarTarefa.disabled = true;

    allItens.forEach(item => {
        console.log(item);
        console.log(allItens.length);
        if (item.value == "") {

        }
        else {

            if (item.querySelector(".ddlUsuarios").value != "" && item.querySelector(".ddlProcessos").value != "" && item.querySelector(".txtTempo").value != "") {
                
                listaCodUsersTarefa[index] = item.querySelector(".ddlUsuarios").value;
                listaProcTarefa[index] = item.querySelector(".ddlProcessos").value;
                listaTempoTarefa[index] = item.querySelector(".txtTempo").value;
                index++;
                
                btnCadastrarTarefa.disabled = false;

                var AreaCadastroTarefa = document.getElementById("AreaCadastroTarefa");
                var AreaConfig = document.getElementById("AreaConfig");
                var btnFormCadastrarTarefa = document.getElementById("btnFormCadastrarTarefa");

                btnFormCadastrarTarefa.style.opacity = 1;
                if (tudoPreenchido) {
                    btnAdicionar.style.opacity = 1;
                    btnAdicionar.disabled = false;

                }
                
            }
            else {
                
                tudoPreenchido = false;

                btnAdicionar.disabled = true;
                btnAdicionar.style.opacity = 0;

                if (document.querySelectorAll(".conteudoTarefa").length == 1) {
                    
                }
                
                
            }
            
        }

        
    })
    return tudoPreenchido;
}

function desbloqueiaCamposConfig() {
    var allItens = document.querySelectorAll(".conteudoTarefa");
    allItens.forEach(item => {
        item.querySelector(".ddlUsuarios").disabled = false;
        item.querySelector(".ddlProcessos").disabled = false;
        item.querySelector(".txtTempo").disabled = false;

    });
}

function bloqueiaCamposConfig() {
    var allItens = document.querySelectorAll(".conteudoTarefa");
    allItens.forEach(item => {
        item.querySelector(".ddlUsuarios").disabled = true;
        item.querySelector(".ddlProcessos").disabled = true;
        item.querySelector(".txtTempo").disabled = true;

    });
}


function cadastrarClick() {

	var txtNome = document.getElementById('txtNome').value;
    var txtDescricao = document.getElementById('txtDescricao').value;
    var txtDataInicio = document.getElementById('txtDataInicio').value;
    var txtDataFim = document.getElementById('txtDataFim').value;
    var lblMensagem = document.getElementById('lblMensagem').textContent;
    var notificacaoEquipe = document.getElementById('cbNotificacao').checked;
    var notificacaoUsuario = document.getElementById('cbNotificacaoUser').checked;

    console.log(txtNome, txtDescricao, txtDataInicio, txtDataFim, lblMensagem, notificacaoEquipe, notificacaoUsuario);

    PageMethods.CadastraTarefa(txtNome, txtDescricao, txtDataInicio, txtDataFim, lblMensagem, listaCodUsersTarefa, listaProcTarefa, listaTempoTarefa, notificacaoEquipe, notificacaoUsuario, onSuccess, onError);
    
}

function AdicionarPainel() {
    if (validaCamposConfig()) {
        const pnlConfiguracao = document.getElementById("pnlConfiguracao")


        const listaDeUsers = pnlConfiguracao.querySelectorAll(".conteudoTarefa")
        const ultimoUser = listaDeUsers[listaDeUsers.length - 1]
        const ultimaPosicaoOcupada = parseInt(listaDeUsers.length - 1)
        let novoUser = ultimoUser.cloneNode(true)
        novoUser.id = ("conteudo" + (ultimaPosicaoOcupada + 1))


        pnlConfiguracao.appendChild(novoUser)
        novoUser.querySelector(".txtTempo").value = "";
        validaCamposTarefa();
    }

}
function onSuccess(sucesso) {

    var style = getComputedStyle(document.body);
    var greencolor = style.getPropertyValue('--green-color').replace(/\s/g, '');
    var redcolor = style.getPropertyValue('--red-color').replace(/\s/g, '');

    taVerde = true;
    lblMensagem.style.color = greencolor;
    lblMensagem.textContent = "Agora seu time tem mais uma tarefa pra fazer!!!";
    console.log(sucesso + greencolor);

    resetaCampos();
};
function onError(erro) { console.log("Ops, deu algo errado " + erro) };



function resetaCampos() {

    txtNome = document.getElementById("txtNome");
    txtDescricao = document.getElementById("txtDescricao");
    txtDataInicio = document.getElementById("txtDataInicio");
    txtDataFim = document.getElementById("txtDataFim");

    txtNome.value = "";
    txtDescricao.value = "";
    txtDataInicio.value = "";
    txtDataFim.value = "";

    resetaConfig();

    validaCamposConfig();
    bloqueiaCamposConfig();

    document.getElementById("AreaConfig").style.opacity = 0;
    document.getElementById("btnFormCadastrarTarefa").style.opacity = 0;

}





function resetaConfig() {


    let index = 0
    var allItens = document.querySelectorAll(".conteudoTarefa");

    
    allItens.forEach(item => {

        item.querySelector(".ddlUsuarios").value = "";
        item.querySelector(".ddlProcessos").value = "";
        item.querySelector(".txtTempo").value = "";


        if (allItens[0] != item) {
            item.remove();
        }
    });
}








function mascaraData(txtCampo) {
    campo = document.getElementById(txtCampo);

    var position = 2;
    var texto = campo.value;
    if (campo.value.length >= position) {

        if (campo.value.indexOf('/') != position) {
            texto = campo.value;
            var barra = "/";
            var output = [texto.slice(0, position), barra, texto.slice(position)].join('');
            campo.value = output;
        }
    }

    var position2 = 5;
    if (campo.value.length >= position2) {

        if (campo.value.lastIndexOf('/') != position2) {
            texto = campo.value;
            var barra = "/";
            var output = [texto.slice(0, position2), barra, texto.slice(position2)].join('');
            campo.value = output;
        }
    }

    if (campo.value.length > 10) {

        var barra = "/";
        var output = [texto.slice(0, 10)].join('');
        campo.value = output;
    }

    if (campo.value.length == 10) {
        var dia = [campo.value.slice(0, 2)].join('');
        var mes = [campo.value.slice(3, 5)].join('');
        var ano = [campo.value.slice(6, 10)].join('');

        campo.value = validaData(dia, mes, ano);
    }


}



function validaData(dia, mes, ano) {


    var data = new Date();
    var mesAtual = data.getUTCMonth() + 1;
    var diaAtual = data.getUTCDate();
    var anoAtual = data.getUTCFullYear();

    ano = Number(ano);
    mes = Number(mes);
    dia = Number(dia);

    ano = Number.isInteger(ano) ? ano : anoAtual;
    mes = Number.isInteger(mes) ? mes : mesAtual;
    dia = Number.isInteger(dia) ? dia : diaAtual;

    if (mes < 1) mes = 1;
    if (dia < 1) dia = 1;
    if (ano < 1) ano = 1;


    var trintaEUm = [1, 3, 5, 7, 8, 10, 12];
    var trinta = [4, 6, 9, 11];
    var bissexto = (ano % 4 == 0) ? true : false;

    if (mes > 12) {
        mes = 12;
    }

    if (mes == 2 && dia > ((bissexto) ? 28 : 29)) {
        dia = bissexto ? 28 : 29;
    }
    else {
        for (i = 0; i < trinta.length; i++) {
            if (trinta[i] == mes) {
                dia = (dia > 30) ? 30 : dia;
            }
        }
        for (i = 0; i < trintaEUm.length; i++) {
            if (trintaEUm[i] == mes) {
                dia = (dia > 31) ? 31 : dia;
            }
        }
    }

    dia = String(dia).length < 2 ? "0" + String(dia) : dia;
    mes = String(mes).length < 2 ? "0" + String(mes) : mes;
    ano = String(ano).length < 2 ? "0" + String(ano) : ano;

    if (Number(ano) < Number(anoAtual) - 120) {
        ano = anoAtual - 120;
    }

    return (dia + "/" + mes + "/" + ano)
}

function fimMaiorQueInicio(fim, inicio) {
    if (fim.length == 10 && inicio.length == 10) {
        var diaFim = [fim.slice(0, 2)].join('');
        var mesFim = [fim.slice(3, 5)].join('');
        var anoFim = [fim.slice(6, 10)].join('');


        var diaInicio = [inicio.slice(0, 2)].join('');
        var mesInicio = [inicio.slice(3, 5)].join('');
        var anoInicio = [inicio.slice(6, 10)].join('');

        if (anoFim < anoInicio) {
            return false;
        }
        else if (anoFim == anoInicio) {
            if (mesFim < mesInicio) {
                return false;
            }

            else if (mesFim == mesInicio && diaFim < diaInicio) {
                return false;
            }
            return true;
        }

        return true;
    }
    else {
        return false;
    }
}
