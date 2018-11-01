
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
        var itemMenuBackgrounds = document.getElementsByClassName("itemMenuBackGround");
        var itemMenus = document.getElementsByClassName("itemMenu");
        var totalItens = itemMenuBackgrounds.length;

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
    var backgroundX = (-width / 2) + (mouseX - width / 2);
    itembgs.style.left = backgroundX + "px";
}

