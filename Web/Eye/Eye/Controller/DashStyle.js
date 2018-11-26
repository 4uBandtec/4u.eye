
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



    /*
    var html = document.getElementsByTagName('html')[0];
    html.style.setProperty("--bg-color", "rgb(220,220,220)");
    html.style.setProperty("--txt-color", "rgb(20,20,20)");
    html.style.setProperty("--darker-bg-color", "rgb(210,210,210)");
    html.style.setProperty("--lighter-bg-color", "rgb(240,240,240)");
    html.style.setProperty("--to-invisible", "rgba(255,255,255, 0)");
    html.style.setProperty("--black-color-a", "rgba(255,255,255,0.5)");
    */
}



function getItemMenu() {

    var itemMenuBackgrounds = document.getElementsByClassName("itemMenuBackGround");
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
    icon.style.left = (backgroundIconX / 4)*-1 + "px";
    icon.style.top = (backgroundIconY / 4)* -1 + "px";
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
    background.style.background = "radial-gradient(circle, rgba(0,0,0,0.3), " + color + "," + getCor(i+1) + ")";
    
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
    
    
    icon.style.left = -10+"%";
    icon.style.top = 0+"%";
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

