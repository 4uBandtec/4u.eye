
var mouseX;
var mouseY;

function getCoordenadas() {
    mouseX = event.clientX;
    mouseY = event.clientY;

}


function iniciarEstilo() {
    buscarTema();
    getItemMenu();
}


function mudarTema() {
    PageMethods.BuscaTema(aplicarMudança, onError);
}

function buscarTema() {
    PageMethods.BuscaTema(inserirTema, onError);
}

function aplicarMudança(temaAtual) {
    novoTema = temaAtual == 0 ? 1 : 0;

    inserirTema(novoTema);
    PageMethods.TrocaTema(novoTema, console.log(novoTema), console.log("erro"));
}

function inserirTema(novoTema) {
    
    var html = document.getElementsByTagName('html')[0];
    var icones = document.getElementsByClassName("itemIcon");
    if (novoTema == 0) {
        html.style.setProperty("--bg-color", "rgb(200,200,200)");
        html.style.setProperty("--txt-color", "rgb(23,23,23)");
        html.style.setProperty("--darker-bg-color", "rgb(189,189,189)");
        html.style.setProperty("--lighter-bg-color", "rgb(217,217,217)");
        html.style.setProperty("--to-invisible", "rgba(255,255,255, 0)");
        html.style.setProperty("--black-color-a", "rgba(255,255,255,0.5)");
        html.style.setProperty("--green-color", "rgb(97,255,51)");
        html.style.setProperty("--blue-color", "rgb(22,135,153)");
        html.style.setProperty("--red-color", "rgb(127,2,49)");
        html.style.setProperty("--yellow-color", "rgb(96, 92, 35)");
        html.style.setProperty("--purple-color", "rgba(85,49,224)");
        html.style.setProperty("--pink-color", "rgba(205,37,229)");
        html.style.setProperty("--orange-color", "rgba(213,75,41)");
        html.style.setProperty("--red-color-a", "rgba(127,2,49,0.5)");
        html.style.setProperty("--blue-color-a", "rgba(22,135,153,0.5)");
        html.style.setProperty("--purple-color-a", "rgba(85,49,224,0.5)");
        html.style.setProperty("--black-color-a9", "rgba(220,220,220, 0.9)");
        html.style.setProperty("--black-color", "rgba(220,220,220)");
        for (i = 0; i < icones.length; i++) {
            icones[i].style.filter = "invert(100%)";
        }
        document.getElementById("switch-tema").checked = true;
    }
    else {
        html.style.setProperty("--bg-color", "rgb(26,26,26)");
        html.style.setProperty("--txt-color", "rgb(200,200,200)");
        html.style.setProperty("--darker-bg-color", "rgb(16,16,16)");
        html.style.setProperty("--lighter-bg-color", "rgb(50,50,50)");
        html.style.setProperty("--to-invisible", "rgba(50,50,50,0)");
        html.style.setProperty("--black-color-a", "rgba(0,0,0,0.3)");
        html.style.setProperty("--green-color", "rgb(0, 198, 19)");
        html.style.setProperty("--blue-color", "rgb(0, 185, 226)");
        html.style.setProperty("--red-color", "rgb(226,26,47)");
        html.style.setProperty("--yellow-color", "rgb(246, 255, 0)");
        html.style.setProperty("--purple-color", "rgba(86,13,196)");
        html.style.setProperty("--pink-color", "rgba(150,20,110)");
        html.style.setProperty("--orange-color", "rgba(255, 136, 0)");
        html.style.setProperty("--red-color-a", "rgba(226,26,47,0.5)");
        html.style.setProperty("--blue-color-a", "rgba(0, 185, 226, 0.5)");
        html.style.setProperty("--purple-color-a", "rgba(86,13,196,0.5)");
        html.style.setProperty("--black-color-a9", "rgba(0,0,0,0.9)");
        html.style.setProperty("--black-color", "rgba(0,0,0)");
        for (i = 0; i < icones.length; i++) {
            icones[i].style.filter = "invert(0%)";
        }
        document.getElementById("switch-tema").checked = false;
    }

}


function getItemMenu() {

    var menu = document.getElementById("sideMenu");
    var itemMenuBackgrounds = menu.getElementsByClassName("itemMenuBackGround");
    var totalItens = itemMenuBackgrounds.length;


    for (i = 0; i < totalItens; i++) {
        addEvento(i);
        addEstilo(i);
    }

}



function addEvento(i) {
    var itemMenuBackgrounds = document.getElementsByClassName("itemMenuBackGround");
    var itemMenus = document.getElementsByClassName("itemMenu");
    var itemIcons = document.getElementsByClassName("itemIcon");
    var totalItens = itemMenuBackgrounds.length;


    var item = itemMenus[i];
    var background = itemMenuBackgrounds[i];
    var icon = itemIcons[i];
    itemMenus[i].addEventListener("mousemove", function () { efeitoHoverIcon(background, item, icon) });
    itemMenus[i].addEventListener("mouseout", function () { efeitoOutIcon(background, item, icon) });

}



function efeitoHover(itembgs, items, icon) {

    var width = items.getBoundingClientRect().width;
    var itemX = items.getBoundingClientRect().x;
    var backgroundX = (mouseX - itemX) - ((width));

    itembgs.style.left = backgroundX + "px";
}

function efeitoHoverIcon(itembgs, items, icon) {
    var width = items.getBoundingClientRect().width;
    var itemX = items.getBoundingClientRect().x;
    var backgroundX = (mouseX - itemX) - ((width));


    var widthIcon = icon.getBoundingClientRect().width;
    var iconX = icon.getBoundingClientRect().x;
    var backgroundIconX = (mouseX - iconX) - ((widthIcon));

    var heightIcon = icon.getBoundingClientRect().height;
    var iconY = icon.getBoundingClientRect().y;
    var backgroundIconY = (mouseY - iconY) - ((heightIcon));

    itembgs.style.left = backgroundX + "px";
    icon.style.left = (backgroundIconX / 4) + "px";
    icon.style.top = (backgroundIconY / 4) * -1 + "px";
}

function addEstilo(i) {
    var itemMenuBackgrounds = document.getElementsByClassName("itemMenuBackGround");
    var itemMenus = document.getElementsByClassName("itemMenu");
    var itemIcons = document.getElementsByClassName("itemIcon");
    var totalItens = itemMenuBackgrounds.length;


    var item = itemMenus[i];
    var background = itemMenuBackgrounds[i];
    var icon = itemIcons[i];

    var color = getCor(i);
    item.style.borderColor = color;
    background.style.background = "radial-gradient(circle, rgba(0,0,0,0.3), " + color + "," + getCor(i + 1) + ")";

}

function getCor(i) {
    if (i > 6) i -= 7;
    if (i < 0) i = 6;

    var style = getComputedStyle(document.body);

    switch (i) {
        case 0:
            return (style.getPropertyValue('--pink-color')).replace(/\s/g, '');
        case 1:
            return (style.getPropertyValue('--purple-color')).replace(/\s/g, '');
        case 2:
            return (style.getPropertyValue('--blue-color')).replace(/\s/g, '');
        case 3:
            return (style.getPropertyValue('--green-color')).replace(/\s/g, '');
        case 4:
            return (style.getPropertyValue('--yellow-color')).replace(/\s/g, '');
        case 5:
            return (style.getPropertyValue('--orange-color')).replace(/\s/g, '');
        case 6:
            return (style.getPropertyValue('--red-color')).replace(/\s/g, '');

    }
}

function efeitoOutIcon(itembgs, items, icon) {


    icon.style.left = -10 + "%";
    icon.style.top = 0 + "%";
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

function onError(e) {
    console.log(e);
}

var btnCadastrar = null, btnNext = null, btnPrevious = null;

var btnFormCadastrar = null, btnFormNext = null, btnFormPrevious = null;

var camposCadastro = null;
var totalCamposCadastro = 0;

var campoAtual = 0;

var telaAtual = "";



function displayPopup() {
    document.getElementById("blockArea").style.display = "block";
    document.getElementById("popup").style.display = "block";
}

function hidePopup() {
    document.getElementById("blockArea").style.display = "none";
    document.getElementById("popup").style.display = "none";
}