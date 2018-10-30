
var mouseX;
var mouseY;

function getCoordenadas() {
    mouseX = event.clientX;
    mouseY = event.clientY;
    //var coords = "X coords: " + x + ", Y coords: " + y;
    //console.log(coords);
}


function iniciar() {
    getItemMenu();
}



function getItemMenu() {

    var itemMenuBackgrounds = document.getElementsByClassName("itemMenuBackGround"); 
    var itemMenus = document.getElementsByClassName("itemMenu");
    var totalItens = itemMenuBackgrounds.length;


    for (i = 0; i < totalItens; i++) {
        addEvento(i);
    }
    
}



function addEvento(index) {
    var itemMenuBackgrounds = document.getElementsByClassName("itemMenuBackGround");
    var itemMenus = document.getElementsByClassName("itemMenu");
    var totalItens = itemMenuBackgrounds.length;


    var item = itemMenus[i];
    var background = itemMenuBackgrounds[i];
    itemMenus[i].addEventListener("mousemove", function () { efeitoHover(background, item) });
    itemMenus[i].addEventListener("mouseout", function () { efeitoOut(background, item) });
}



function efeitoHover(itembgs, items) {
    var width = items.getBoundingClientRect().width;
    var backgroundX = (-width / 2) + (mouseX - width / 2);
    itembgs.style.left = backgroundX + "px";
}



function efeitoOut(itembgs, items) {
    itembgs.style.left = "-200%";
}