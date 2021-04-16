function ValidaNavegador() {

    document.oncontextmenu = function () { return false }
    window.location.hash = "no-back-button";
    window.location.hash = "Again-No-back-button"
    window.onhashchange = function () { window.location.hash = "no-back-button"; }
    document.onkeydown = function (event) {
        if (event.keyCode == 123) {
            return false;
        } else if ((event.ctrlKey && event.shiftKey && event.keyCode == 73) || (event.ctrlKey && event.shiftKey && event.keyCode == 74) || (event.ctrlKey && event.keyCode == 83) || (event.ctrlKey && event.keyCode == 71)) {
            return false;
        }
    }

    window.onkeydown = function (event) {
        if (event.keyCode == 123) {
            return false;
        } else if ((event.ctrlKey && event.shiftKey && event.keyCode == 73) || (event.ctrlKey && event.shiftKey && event.keyCode == 74) || (event.ctrlKey && event.keyCode == 83) || (event.ctrlKey && event.keyCode == 71)) {
            return false;
        }
    }

    var agt = navigator.userAgent;
    var wb = ["Chrome/", "Safari/", "OPR/", "Firefox/", "Edge/"];
    var bj = -1;
    for (i = 0; i < wb.length; i++) {
        if (agt.search(wb[i]) > 0) bj = 1;
    }
    if (bj == -1) window.location.href = "../NavegadorIncorrecto.aspx";
    else Abrir_Login();
}


function Abrir_Login() {
}