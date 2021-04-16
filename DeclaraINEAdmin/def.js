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
    if (bj == -1) window.location.href = "NavegadorIncorrecto.aspx";
    else Abrir_Login();
}


function Abrir_Login() {
    document.oncontextmenu = function () { return false }
    var winName = "DeclaraiJ4iXTUQZKF1tYl9WzMohREM60";
    var h = screen.availHeight - 66;
    var w = screen.availWidth - 13;
    var windowprops = "top=0, " +
        "screenX=0, " +
        "screenY=0, " +
        "left=0, " +
        "top=0, " +
        "toolbar=no, " +
        "location=no, " +
        "status=yes, " +
        "menubar=no, " +
        "scrollbars=yes, " +
        "resizable=yes, " +
        "titlebar=no, " +
        "directories=no, " +
        "personalbar=no, " +
        "minimizable=yes, " +
        "width=" + w + "," +
        "height=" + h;
    var ventana = window.open('Formas/login.aspx', winName, windowprops);

    if (ventana.closed) {
        window.location = 'Start.aspx';
    }
    else {
        window.open('', '_parent', '');
        window.close();
        window.location = 'Start.aspx';
    }
}