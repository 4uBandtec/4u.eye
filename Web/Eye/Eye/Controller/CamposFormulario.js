function mascaraData(campo) {


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


    if (ano > anoAtual) {
        ano = anoAtual;
        mes = mesAtual;
        dia = diaAtual;
    }
    else if (ano == anoAtual) {
        if (mes > mesAtual) {
            mes = mesAtual;
            dia = diaAtual;
        }
        else if (mes == mesAtual) {
            if (dia > diaAtual) {
                dia = diaAtual;
            }
        }
    }

    var trintaEUm = [1, 3, 5, 7, 8, 10, 12];
    var trinta = [4, 6, 9, 11];
    var bissexto = (ano % 4 == 0) ? true : false;

    if (mes > 12) {
        mes = 12;
    }
    else if (mes == 2 && dia > ((bissexto) ? 28 : 29)) {
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



function getCamposCadastro() {
    telaAtual = "workspace";
    btnNext = document.getElementById("btnNext");
    btnPrevious = document.getElementById("btnPrevious");
    btnCadastrar = document.getElementById("btnCadastrar");

    btnFormNext = document.getElementById("btnFormNext");
    btnFormPrevious = document.getElementById("btnFormPrevious");
    btnFormCadastrar = document.getElementById("btnFormCadastrar");

    camposCadastro = document.getElementsByClassName("campoCadastro");
    totalCamposCadastro = camposCadastro.length;


    showCampoCadastro(campoAtual);

}


var decide = [Math.floor(Math.random() * 2), Math.floor(Math.random() * 4)];

function mudarTexto() {
    var lblTexto = document.getElementById("lblTexto");
    var mensagem = "";
    var info = "";

    if (telaAtual == "workspace") {

        switch (campoAtual) {
            case 0:
                info = decide[0] == 1 ? "Qual seu nome?" : "Como você se chama?";


                if (decide[1] == 0) mensagem = "Oi, tudo bem? ";
                else if (decide[1] == 1) mensagem = "Olá! Seja bem vindo!!! ";
                else if (decide[1] == 2) mensagem = "Oi, você é novo aqui? ";
                else mensagem = "Oi! Pronto pra usar o EYE? ";

                break;

            case 1:
                info = decide[0] == 1 ? "Dê um nome para seu Workspace" : "Qual vai ser o nome do seu novo Workspace?";


                if (decide[1] == 0) mensagem = "Bem vindo " + camposCadastro[0].value + "!!! ";
                else if (decide[1] == 1) mensagem = "Prazer em te conhecer " + camposCadastro[0].value + "! ";
                else if (decide[1] == 2) mensagem = "Olá " + camposCadastro[0].value + "! ";
                else mensagem = "Oi " + camposCadastro[0].value + ", ";

                break;

            case 2:
                info = decide[0] == 1 ? "uma senha para ele" : "a senha do seu novo Workspace";


                if (decide[1] == 0) mensagem = "Agora você tem que decidir ";
                else if (decide[1] == 1) mensagem = "Digite ";
                else if (decide[1] == 2) mensagem = "Você precisa colocar ";
                else mensagem = "Agora defina ";
                break;
            case 3:
                info = "";
                if (decide[1] == 0) mensagem = "Digite ela só mais uma vez ";
                else if (decide[1] == 1) mensagem = "Você ainda lembra da senha? ";
                else if (decide[1] == 2) mensagem = "Precisamos ter certeza de que você vai se lembrar dela ";
                else mensagem = "Coloque sua senha... de novo ";
                break;
            case 4:
                info = "";


                if (decide[1] == 0) mensagem = "Quase lá, só falta colocar seu email";
                else if (decide[1] == 1) mensagem = "Já está acabando, apenas digite seu email";
                else if (decide[1] == 2) mensagem = "Com qual email você quer cadastrar esse Workspace?";
                else mensagem = "Ultima etapa, digite seu email";
                break;
        }
    }


    if (telaAtual == "usuario") {
        const NOME = 0,
            USER_NAME = 1,
            EMAIL = 2,
            DATA_NASCIMENTO = 3,
            SEXO = 4,
            SENHA = 5,
            CONFIRMA_SENHA = 6;



        switch (campoAtual) {
            case NOME:
                info = decide[0] == 1 ? "Qual o nome dele?" : "Como ele se chama?";


                if (decide[1] == 0) mensagem = "Você vai cadastrar um novo usuário? ";
                else if (decide[1] == 1) mensagem = "Oi de novo, deseja cadastrar alguém? ";
                else if (decide[1] == 2) mensagem = "Quer fazer o cadastro de um novo usuário do EYE? ";
                else mensagem = "Olá, tem alguém que você quer cadastrar? ";

                break;

            case USER_NAME:


                if (decide[1] == 0) mensagem = "Ele precisa de um Username para usar o EYE. ";
                else if (decide[1] == 1) mensagem = "Qual vai ser o Username dessa pessoa? ";
                else if (decide[1] == 2) mensagem = "Coloque um Username pra ele, seja criativo!!! ";
                else mensagem = "Decida qual será o Username do novo usuário... e digite ele aí ";

                break;

            case EMAIL:


                if (decide[1] == 0) mensagem = "Vamos precisar de um email pra ele";
                else if (decide[1] == 1) mensagem = "Ele tem algum email? Espero que sim";
                else if (decide[1] == 2) mensagem = "Qual é o email dele? \"Prometo\" que não vou mandar spam";
                else mensagem = "Agora me diga o email dele";

                break;

            case DATA_NASCIMENTO:
                info = decide[0] == 1 ? "Quando ele nasceu? Só por curiosidade mesmo" : "Qual a data de nascimento dele?";

                break;

            case SEXO:
                info = decide[0] == 1 ? "Qual o sexo dele... dela...???" : "Você é capaz de identificar o sexo dessa pessoa?";

                break;

            case SENHA:


                if (decide[1] == 0) mensagem = "Tenho certeza que tudo que essa pessoa precisa é mais uma Senha pra lembrar";
                else if (decide[1] == 1) mensagem = "Dê uma senha, de preferencia uma bem forte, a minha por exemplo é: *********";
                else if (decide[1] == 2) mensagem = "Coloque uma senha, só não esqueça dela... ainda";
                else mensagem = "Na minha opinião essa pessoa merece uma senha, o que você acha?";

                break;

            case CONFIRMA_SENHA:

                if (decide[1] == 0) mensagem = "Você sabe como funciona essa parte... ";
                else if (decide[1] == 1) mensagem = "Qual é a senha mesmo? Eu esqueci, e você? ";
                else if (decide[1] == 2) mensagem = "Lembra que eu falei pra não esquecer? Então...";
                else mensagem = "Estamos quase acabando, agora, com muita calma, concentre-se e digite exatamente a mesma coisa que você acabou de digitar";

                break;


        }
    }

    lblTexto.innerHTML = mensagem + info;
}


function updateProgressBar() {
    var progressBar = document.getElementById('progressBar');
    progressBar.style.width = (100 / totalCamposCadastro) * (campoAtual + 1) + "%";
}

function checaEmail(index) {
    var email = camposCadastro[index].value;
    var arroba = email.indexOf('@');
    var arroba2 = email.lastIndexOf('@');
    var ponto = email.lastIndexOf('.');


    if (arroba <= 0 || ponto <= (arroba + 1) || ponto == (email.length - 1) || arroba2 != arroba) {

        return false;
    }
    return true;
}

var msgErro = false;

function showCampoCadastro(index) {


    var lblMensagem = document.getElementById('lblMensagem');

    if (telaAtual == "workspace") {

        if (msgErro) {
            msgErro = false;
            lblMensagem.innerHTML = "";
        }


        if (lblMensagem.innerHTML.indexOf('Workspace') >= 0) {
            index = 1;
            campoAtual = 1;
            msgErro = true;
        }
        else if (lblMensagem.innerHTML.indexOf('mail') >= 0) {
            index = 4;
            campoAtual = 4;
            msgErro = true;
        }

        updateProgressBar();
        mudarTexto();

        if (index === totalCamposCadastro - 1) {


            if (checaEmail(index)) {
                btnCadastrar.style.opacity = 1;
                btnFormCadastrar.style.opacity = 1;
                btnCadastrar.disabled = false;
            } else {
                btnCadastrar.style.opacity = 0;
                btnFormCadastrar.style.opacity = 0;
                btnCadastrar.disabled = true;
            }

            btnNext.style.opacity = 0;
            btnFormNext.style.opacity = 0;
            btnNext.disabled = true;
        }
        else {

            btnCadastrar.style.opacity = 0;
            btnFormCadastrar.style.opacity = 0;
            btnCadastrar.disabled = true;

            if (!!camposCadastro[index].value) {
                if (campoAtual == 3) {
                    if (camposCadastro[campoAtual].value === camposCadastro[campoAtual - 1].value) {
                        btnNext.style.opacity = 1;
                        btnFormNext.style.opacity = 1;
                        btnNext.disabled = false;
                    }
                    else {
                        btnNext.style.opacity = 0;
                        btnFormNext.style.opacity = 0;
                        btnNext.disabled = true;
                    }
                }
                else {
                    btnNext.style.opacity = 1;
                    btnFormNext.style.opacity = 1;
                    btnNext.disabled = false;
                }
            }
            else {
                btnNext.style.opacity = 0;
                btnFormNext.style.opacity = 0;
                btnNext.disabled = true;
            }

        }

        if (index === 0) {
            btnPrevious.style.opacity = 0;
            btnFormPrevious.style.opacity = 0;
            btnPrevious.disabled = true;
        }
        else {
            btnPrevious.style.opacity = 1;
            btnFormPrevious.style.opacity = 1;
            btnPrevious.disabled = false;
        }


        for (var i = 0; i < totalCamposCadastro; i++) {
            if (i === index) {
                camposCadastro[i].style.opacity = "1";
                camposCadastro[i].style.zIndex = "2";

                camposCadastro[i].focus();
            }
            else {

                camposCadastro[i].style.opacity = "0";
                camposCadastro[i].style.zIndex = "0";

            }


        }
    }

}


function nextCampo() {
    if (telaAtual == "workspace") {
        if (campoAtual < totalCamposCadastro - 1) {

            if (!!camposCadastro[campoAtual].value) {

                showCampoCadastro(++campoAtual);
            }
        }

        else {
            camposCadastro[campoAtual].focus();
        }
    }
    else if (telaAtual == "usuario") {
        if (campoAtual < totalCamposCadastro - 1) {

            if (!!camposCadastro[campoAtual].value) {

                showCampoCadastroUsuario(++campoAtual);
            }
        }

        else {
            camposCadastro[campoAtual].focus();
        }
    }
}


function previousCampo() {
    if (telaAtual == "workspace") {
        if (campoAtual > 0) {
            showCampoCadastro(--campoAtual);
        }
        else {
            camposCadastro[campoAtual].focus();
        }
    }
    else if (telaAtual == "usuario") {
        if (campoAtual > 0) {
            showCampoCadastroUsuario(--campoAtual);
        }
        else {
            camposCadastro[campoAtual].focus();
        }
    }
}

function tabPress(e) {


    if (e.shiftKey && e.keyCode == 9) {
        if (e.preventDefault) e.preventDefault();
        previousCampo();
    }
    else if (e.which == 9 || e.keyCode === 13) {

        if (campoAtual == totalCamposCadastro - 2) {
            if (e.preventDefault) e.preventDefault();
        }

        if (telaAtual == "workspace") {
            if (campoAtual == 3 && camposCadastro[campoAtual].value != camposCadastro[campoAtual - 1].value) {
                showCampoCadastro(campoAtual);
            }
            else {
                if (!msgErro) {
                    nextCampo();
                }
            }

        }
        if (telaAtual == "usuario") {
            if ((campoAtual == 2 && !checaEmail(campoAtual))
                || (campoAtual == 3 && camposCadastro[campoAtual].value.length < 10)) {
                showCampoCadastroUsuario(campoAtual);
            }
            else {
                if (!msgErro) {
                    nextCampo();
                }
            }
        }
    }
}






function keyUp(e) {
    if (e.keyCode !== 13) {
        if (telaAtual == "workspace") {
            showCampoCadastro(campoAtual);
        }
        else if (telaAtual == "usuario") {
            showCampoCadastroUsuario(campoAtual);
        }
    }
}



//--------------------------------------------------CADASTRO DE USUÀRIOS----------------------------------------------------------------






function getCamposCadastroUsuario() {

    telaAtual = "usuario";

    btnNext = document.getElementById("btnNext");
    btnPrevious = document.getElementById("btnPrevious");
    btnCadastrar = document.getElementById("btnCadastrar");

    btnFormNext = document.getElementById("btnFormNext");
    btnFormPrevious = document.getElementById("btnFormPrevious");
    btnFormCadastrar = document.getElementById("btnFormCadastrar");

    camposCadastro = document.getElementsByClassName("campoCadastro");
    totalCamposCadastro = camposCadastro.length;

    showCampoCadastroUsuario(campoAtual);

}



function showCampoCadastroUsuario(index) {


    index = validaMudancaCampo(index);

    for (var i = 0; i < totalCamposCadastro; i++) {
        if (i === index) {
            camposCadastro[i].style.opacity = "1";
            camposCadastro[i].style.zIndex = "2";

            camposCadastro[i].focus();
        }
        else {

            camposCadastro[i].style.opacity = "0";
            camposCadastro[i].style.zIndex = "0";

        }


    }

    if (index == 3) {
        mascaraData(camposCadastro[index]);
    }



    updateProgressBar();
    mudarTexto();
}

function checaConfirmaSenha(index) {
    if (camposCadastro[index].value == camposCadastro[index - 1].value && camposCadastro[index].value != null) {
        return true;
    }
    return false;
}

function validaMudancaCampo(index) {

    var lblMensagem = document.getElementById('lblMensagem');
    if (telaAtual == "usuario") {

        if (msgErro) {
            msgErro = false;
            lblMensagem.style.color = "var(--red-color)";
            lblMensagem.innerHTML = "";
        }

        if (lblMensagem.innerHTML.indexOf('cadastrado') >= 0) {
            index = 0;
            campoAtual = 0;
            lblMensagem.style.color = "var(--purple-color)";
            limpaCampos();
            msgErro = true;
        }

        if (lblMensagem.innerHTML.indexOf('sername') >= 0) {
            index = 1;
            campoAtual = 1;
            msgErro = true;
        }
        else if (lblMensagem.innerHTML.indexOf('mail') >= 0) {
            index = 2;
            campoAtual = 2;
            msgErro = true;
        }
        else if (lblMensagem.innerHTML.indexOf('sexo') >= 0) {
            index = 4;
            campoAtual = 4;
            msgErro = true;
        }



        if (index === totalCamposCadastro - 1) {


            if (checaConfirmaSenha(index)) {
                btnCadastrar.style.opacity = 1;
                btnFormCadastrar.style.opacity = 1;
                btnCadastrar.disabled = false;
            } else {
                btnCadastrar.style.opacity = 0;
                btnFormCadastrar.style.opacity = 0;
                btnCadastrar.disabled = true;
            }

            btnNext.style.opacity = 0;
            btnFormNext.style.opacity = 0;
            btnNext.disabled = true;
        }
        else {

            btnCadastrar.style.opacity = 0;
            btnFormCadastrar.style.opacity = 0;
            btnCadastrar.disabled = true;

            if (!!camposCadastro[index].value) {

                if ((index == 2 && !checaEmail(campoAtual)) // verifica o preenchimento do email
                    || (index == 3 && camposCadastro[index].value.length < 10) // verifica o preenchimento da data
                    || (index == 4 && camposCadastro[index].options[camposCadastro[index].selectedIndex].value == "")
                ) {

                    btnNext.style.opacity = 0;
                    btnFormNext.style.opacity = 0;
                    btnNext.disabled = true;
                }
                else {
                    btnNext.style.opacity = 1;
                    btnFormNext.style.opacity = 1;
                    btnNext.disabled = false;
                }
            }
            else {

                btnNext.style.opacity = 0;
                btnFormNext.style.opacity = 0;
                btnNext.disabled = true;
            }

        }

        if (index === 0) {
            btnPrevious.style.opacity = 0;
            btnFormPrevious.style.opacity = 0;
            btnPrevious.disabled = true;
        }
        else {
            btnPrevious.style.opacity = 1;
            btnFormPrevious.style.opacity = 1;
            btnPrevious.disabled = false;
        }
    }

    return index;
}

function limpaCampos() {
    for (i = 0; i < totalCamposCadastro; i++) {
        camposCadastro[i].value = "";
    }
}