
var listaCodUsersTarefa = [];
var listaProcTarefa = [];
var listaTempoTarefa = [];


function iniciarPainelTarefas() {

    var AreaCadastroTarefa = document.getElementById("AreaCadastroTarefa");
    var AreaConfig = document.getElementById("AreaConfig");
    var btnFormCadastrarTarefa = document.getElementById("btnFormCadastrarTarefa");

    AreaConfig.style.opacity = 0;
    btnFormCadastrarTarefa.style.opacity = 0;

}


function validaCamposTarefa() {
    txtNome = document.getElementById("txtNome");
    txtDescricao = document.getElementById("txtDescricao");
    txtDataInicio = document.getElementById("txtDataInicio");
    txtDataFim = document.getElementById("txtDataFim");

    var AreaCadastroTarefa = document.getElementById("AreaCadastroTarefa");
    var AreaConfig = document.getElementById("AreaConfig");
    var btnFormCadastrarTarefa = document.getElementById("btnFormCadastrarTarefa");


    btnFormCadastrarTarefa.style.opacity = 0;

    if (txtNome.value == "") {
        return [false, "Digita o nome aí"];
    }
    else if (txtDescricao.value == "") {
        return [false, "Digita o txtDescricao aí"];
    }
    else if (txtDataInicio.value == "") {
        return [false, "Digita o txtDataInicio aí"];
    }
    else if (txtDataFim.value == "") {
        return [false, "Digita o txtDataFim aí"];
    }
    else if (!fimMaiorQueInicio(txtDataFim.value, txtDataInicio.value)) {
        return [false, "O fim deve ser maior"];
    }
    else {



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

            }
            else {

                btnAdicionar.disabled = true;
                btnCadastrarTarefa.disabled = true;

                if (document.querySelectorAll(".conteudoTarefa").length == 1) {

                    return false;
                }
                else {
                    return [true, false];
                    //item.remove();
                }
            }
        }

        btnAdicionar.disabled = false;
        btnCadastrarTarefa.disabled = false;

        var AreaCadastroTarefa = document.getElementById("AreaCadastroTarefa");
        var AreaConfig = document.getElementById("AreaConfig");
        var btnFormCadastrarTarefa = document.getElementById("btnFormCadastrarTarefa");

        btnFormCadastrarTarefa.style.opacity = 1;

        return [true, true];

    })

    return false;
}

function desbloqueiaCamposConfig() {
    var allItens = document.querySelectorAll(".conteudoTarefa");
    allItens.forEach(item => {
        item.querySelector(".ddlUsuarios").disabled = false;
        item.querySelector(".ddlProcessos").disabled = false;
        item.querySelector(".txtTempo").disabled = false;

    });
}


function cadastrarClick() {
    if (validaCamposTarefa()[0]) {
        PageMethods.CadastraTarefa(listaCodUsersTarefa, listaProcTarefa, listaTempoTarefa, onSuccess, onError);

        return true
    }
    else {
        lblMensagem.textContent = validaCamposTarefa()[1];
        return false
    }
}

function AdicionarPainel() {
    //ARRUMAR
    //TIRAR BTNS DA TELA
    //ARUMAR CADASTRAR
    if (!validaCamposConfig()[1]) {
        const pnlConfiguracao = document.getElementById("pnlConfiguracao")


        const listaDeUsers = pnlConfiguracao.querySelectorAll(".conteudoTarefa")
        const ultimoUser = listaDeUsers[listaDeUsers.length - 1]
        const ultimaPosicaoOcupada = parseInt(listaDeUsers.length - 1)
        let novoUser = ultimoUser.cloneNode(true)
        novoUser.id = ("conteudo" + (ultimaPosicaoOcupada + 1))


        pnlConfiguracao.appendChild(novoUser)
    }

}
function onSuccess(sucesso) {

    lblMensagem.textContent = "Cradastado";
    console.log(sucesso);
};
function onError(erro) { console.log("DEU ERROOOOOOOOOO ONKNKSA KBAD J<B JDMB " + erro) };




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
