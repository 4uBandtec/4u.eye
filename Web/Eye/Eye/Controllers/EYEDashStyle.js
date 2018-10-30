
var x;
var y;

function getCoordenadas() {
    x = event.clientX;
    y = event.clientY;
    //var coords = "X coords: " + x + ", Y coords: " + y;
    //console.log(coords);
}

function iniciar() {
    getItemMenu();
}

function getItemMenu() {

    var itemMenuBackgrounds = document.getElementsByClassName("itemMenuBackGround");
    var itemMenus = document.getElementsByClassName("itemMenu");

    for (var i = 0; i < itemMenus.length; ++i) {
        var item = itemMenus[i];
        var itembg = itemMenuBackgrounds[i];

        itemMenus[i].addEventListener("mousemove", function () { efeitoHover(itembg, item) });
        itemMenus[i].addEventListener("mouseout", function () { efeitoOut(itembg, item) });
        
    }
    
}



function efeitoHover(itembgs, items) {
    var width = items.getBoundingClientRect().width;
    var backgroundX = (-width / 2) + (x - width / 2);
    itembgs.style.left = backgroundX + "px";
}

function efeitoOut(itembgs, items) {
    itembgs.style.left = "-200%";
}