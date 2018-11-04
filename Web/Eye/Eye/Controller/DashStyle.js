
var mouseX;
var mouseY;

function getCoordenadas() {
    mouseX = event.clientX;
    mouseY = event.clientY;
    //var coords = "X coords: " + x + ", Y coords: " + y;
    //console.log(coords);
}


function iniciarEstilo() {
    getItemMenu();
    /*
    var html = document.getElementsByTagName('html')[0];
    html.style.setProperty("--bg-color", "rgb(" + Math.random() * 250 + "," + Math.random() * 250 + "," + Math.random() * 250 + ")");
    html.style.setProperty("--txt-color", "rgb(" + Math.random() * 250 + "," + Math.random() * 250 + "," + Math.random() * 250 + ")");
    html.style.setProperty("--red-color", "rgb(" + (Math.random() * 250).toFixed(0) + "," + (Math.random() * 250).toFixed(0) + "," + (Math.random() * 250).toFixed(0) + ")");
    html.style.setProperty("--purple-color", "rgb(" + Math.random() * 250 + "," + Math.random() * 250 + "," + Math.random() * 250 + ")");
    html.style.setProperty("--darker-bg-color", "rgb(" + (Math.random() * 250).toFixed(0) + "," + (Math.random() * 250).toFixed(0) + "," + (Math.random() * 200).toFixed(0) + ")");
    html.style.setProperty("--lighter-bg-color", "rgb(" + Math.random() * 250 + "," + Math.random() * 250 + "," + Math.random() * 250 + ")");
    html.style.setProperty("--red-color-a", "rgb(" + Math.random() * 250 + "," + Math.random() * 250 + "," + Math.random() * 250 + "," + Math.random() + ")");
    html.style.setProperty("--purple-color-a", "rgb(" + Math.random() * 250 + "," + Math.random() * 250 + "," + Math.random() * 250 + "," + Math.random() + ")");
    html.style.setProperty("--to-invisible", "rgb(" + Math.random() * 250 + "," + Math.random() * 250 + "," + Math.random() * 250 + ", 0)");
    html.style.setProperty("--black-color-a", "rgb(" + Math.random() * 250 + "," + Math.random() * 250 + "," + Math.random() * 250 + "," + Math.random()/2 + ")");
    */
}



function getItemMenu() {

    var itemMenuBackgrounds = document.getElementsByClassName("itemMenuBackGround");
    var totalItens = itemMenuBackgrounds.length;


    for (i = 0; i < totalItens; i++) {
        addEvento(i);
    }

}



function addEvento(i) {
    var itemMenuBackgrounds = document.getElementsByClassName("itemMenuBackGround");
    var itemMenus = document.getElementsByClassName("itemMenu");
    var totalItens = itemMenuBackgrounds.length;


    var item = itemMenus[i];
    var background = itemMenuBackgrounds[i];
    itemMenus[i].addEventListener("mousemove", function () { efeitoHover(background, item) });
}



function efeitoHover(itembgs, items) {

    var width = items.getBoundingClientRect().width;
    var itemX = items.getBoundingClientRect().x;
    var backgroundX = (mouseX - itemX) - ((width));

    itembgs.style.left = backgroundX + "px";
}

function startaHover(itembg, item) {
    var itembgs = document.getElementById(itembg);
    var items = document.getElementById(item);

    efeitoHover(itembgs, items);

}

function radial(id) {

    getCoordenadas();

    var item = document.getElementById(id);

    var width = item.getBoundingClientRect().width;
    var height = item.getBoundingClientRect().height;

    var backgroundX = (mouseX - width / 2);

    var backgroundY = (mouseY - height / 2);

    item.style.left = backgroundX + "px";
    item.style.top = backgroundY + "px";
}


var btnCadastrar = null, btnNext = null, btnPrevious = null;

var btnFormCadastrar = null, btnFormNext = null, btnFormPrevious = null;

var camposCadastro = null;
var totalCamposCadastro = 0;

var campoAtual = 0;

function getCamposCadastro() {
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


            if (decide[1] == 0) mensagem = "Bem vindo " + camposCadastro[0].value+"!!! ";
            else if (decide[1] == 1) mensagem = "Prazer em te conhecer " + camposCadastro[0].value+"! ";
            else if (decide[1] == 2) mensagem = "Olá " + camposCadastro[0].value+"! ";
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

    lblTexto.innerHTML = mensagem+info;
}


function updateProgressBar() {
    var progressBar = document.getElementById('progressBar');
    progressBar.style.width = (100 / totalCamposCadastro) * (campoAtual+1)+"%";
}

function checaEmail() {

    var email = camposCadastro[totalCamposCadastro - 1].value;
    var arroba = email.indexOf('@');
    var arroba2 = email.lastIndexOf('@');
    var ponto = email.lastIndexOf('.');
    

    if (arroba <= 0 || ponto <= (arroba + 1) || ponto == (email.length - 1) || arroba2 != arroba) {
        
        return false;
    }
    return true;
}

function showCampoCadastro(index) {
    updateProgressBar();
    mudarTexto();

    if (index === totalCamposCadastro - 1) {


        if (checaEmail()) {
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


function nextCampo() {
    if (campoAtual < totalCamposCadastro - 1) {

        if (!!camposCadastro[campoAtual].value) {
            
            showCampoCadastro(++campoAtual);
        }
    }

    else {
        camposCadastro[campoAtual].focus();
    }
}


function previousCampo() {
    if (campoAtual > 0) {
        showCampoCadastro(--campoAtual);
    }
    else {
        camposCadastro[campoAtual].focus();
    }
}

function tabPress(e) {


    if (e.shiftKey && e.keyCode == 9) {
        if (e.preventDefault) e.preventDefault();
        previousCampo();
    }
    else if (e.which == 9) {

        if (campoAtual == totalCamposCadastro - 2) {
            if (e.preventDefault) e.preventDefault();
        }
        if (campoAtual == 3 && camposCadastro[campoAtual].value != camposCadastro[campoAtual - 1].value) {
            showCampoCadastro(campoAtual);
        }
        else {
            nextCampo();
        }
    }



}

function keyUp() {
    showCampoCadastro(campoAtual);
}