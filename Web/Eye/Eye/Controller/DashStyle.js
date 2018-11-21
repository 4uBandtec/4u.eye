
var mouseX;
var mouseY;

function getCoordenadas() {
    mouseX = event.clientX;
    mouseY = event.clientY;
    
}


function iniciarEstilo() {
    getItemMenu();
    /*
    var html = document.getElementsByTagName('html')[0];
    html.style.setProperty("--bg-color", "rgb(" + Math.random() * 250 + "," + Math.random() * 250 + "," + Math.random() * 250 + ")");
    html.style.setProperty("--txt-color", "rgb(" + Math.random() * 250 + "," + Math.random() * 250 + "," + Math.random() * 250 + ")");
    html.style.setProperty("--pink-color", "rgb(" + (Math.random() * 250).toFixed(0) + "," + (Math.random() * 250).toFixed(0) + "," + (Math.random() * 250).toFixed(0) + ")");
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

var telaAtual = "";

