//Inicia campo requerido---------------------------------------------------------
$(document).ready(function () {
    req();
    money();
    number1();
    //avoidAutoComplete();
});

function req() {
    $("[requerido]").each(function () {
        var block = $(this);
        block.wrap("<div class='required-field-block'></div>");
        block.parent().append("<div class='required-icon'><div class='required-text'>*</div></div>");
        $('.required-icon').tooltip({
            placement: 'left',
            title: 'Campo Requerido'
        });
    });
}

function CheckReq() {
    var flag = true;
    $("[requerido='" + event.target.id + "']").each(function () {
        if ($(this).val() != null) {
            if ($(this).val().trim().length == 0) {
                flag = false;
                $(this).animate({ borderWidth: "2px" }, 'fast', function () { $(this).css("border-color", '#ff4d4d') });
                var that = this;
                setTimeout(function () {
                    $(that).animate({ borderWidth: "1px" }, 'fast', function () { $(that).removeAttr('style') })
                }, 600);
            }
        }
        else {
            flag = false;
            $(this).animate({ borderWidth: "2px" }, 'fast', function () { $(this).css("border-color", '#ff4d4d') });
            var that = this;
            setTimeout(function () {
                $(that).animate({ borderWidth: "1px" }, 'fast', function () { $(that).removeAttr('style') })
            }, 600);
        }
    });
    return flag;
}


//Termina campo requerido---------------------------------------------------------

function ComprobarVentana() {
    if (window.name == 'DeclaraiJ4iXTUQZKF1tYl9WzMohREM60') {
    }
    else {
        window.location.href = "../Default.aspx";
        window.open('', '_parent', '');
        window.close();
        document.onclick = function () { return false }
        return false;
    }
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
}

function avoidAutoComplete() {
    $('form[autocomplete="off"] input, input[autocomplete="off"]').each(function () {

        var input = this;
        var name = $(input).attr('name');
        var id = $(input).attr('id');

        $(input).removeAttr('name');
        $(input).removeAttr('id');

        setTimeout(function () {
            $(input).attr('name', name);
            $(input).attr('id', id);
        }, 1);
    });
}



//Formato de TextBox--------------------------------------------------------------
function txtFormatPercent(evt) {
    var e = evt || window.event;
    var charCode = e.which || e.keyCode;

    var value = event.target.value;

    if (charCode == 8 || (charCode > 36 && charCode < 41)) {
        //event.target.value = value;
    }
    else {
        if (value.length > 1) {
            value = value.replace("%", "");
            event.target.value = value.concat("%");
        }
        else {
            event.target.value = value;
        }
    }
}

function isIntegerKey(evt) {
    var e = evt || window.event;
    var charCode = e.which || e.keyCode;
    return !isNumberCharCode(charCode, e);
}

function isIntegerPercentKey(evt) {
    var e = evt || window.event;
    var charCode = e.which || e.keyCode;
    if (isNumberCharCode(charCode, e) || isPercentCharCode(charCode, e))
        return true;
    else return false;
}

function isDecimalPercentKey(evt) {
    var e = evt || window.event;
    var charCode = e.which || e.keyCode;
    console.log(charCode);
    console.log(isNumberCharCode(charCode, e));
    console.log(isPercentCharCode(charCode, e));
    console.log(isPeriodCharCode(charCode, e));
    if (isNumberCharCode(charCode, e) || isPercentCharCode(charCode, e) || isPeriodCharCode(charCode, e))
        return true;
    else return false;
}

function isNumberCharCode(charCode, e) {
    if (charCode > 31 && (charCode < 47 || charCode > 57) && (charCode < 95 || charCode > 105) && (charCode < 36 || charCode > 40))
        return false;
    if (e.shiftKey) return false;
    return true;
}

function isPercentCharCode(charCode, e) {
    if (e.shiftKey || charCode == 53)
        return true;
    return false;
}

function isPeriodCharCode(charCode, e) {
    if (charCode != 190)
        return false;
    if (e.shiftKey) return false;
    return true;
}

//Termina formato de TextBox------------------------------------------------------


//Money------------------------------------------------------

function money() {
    $("input[id*='moneytxt']").each(function (event) {
        var elemento = $(this);
        //$(elemento).on('keypress', elemento[0], function (event) {
        //    checkMoney(event);
        //});
        $(elemento).on('keyup', elemento[0], function (event) {
            checkMoney(event);
        });
    });

    $("input[id*='moneytxt']").each(function () {
        var elemento = $(this);
        elemento[0].value = writemoney(elemento[0].value);
        document.getElementById('div' + elemento[0].id).innerText = NumeroALetras(elemento[0].value.replace('$', '').replace(',', '').replace(',', ''));
    });

    document.oncontextmenu = function () { return false }
    window.onkeydown = function (event) {
        if (event.keyCode == 123) {
            return false;
        } else if ((event.ctrlKey && event.shiftKey && event.keyCode == 73) || (event.ctrlKey && event.shiftKey && event.keyCode == 74)) {
            return false;
        }
    }
}

function number1() {
    $("input[id*='numbertxt']").each(function (event) {
        var elemento = $(this);
        //$(elemento).on('keypress', elemento[0], function (event) {
        //    checkNumber(event);
        //});
        $(elemento).on('keyup', elemento[0], function (event) {
            checkNumber(event);
        });
    });

    $("input[id*='numbertxt']").each(function () {
        var elemento = $(this);
        elemento[0].value = writeNumber(elemento[0].value);
    });
}


function writemoney(Num) {
    Num = Num.replace('$', '');
    Num = Num.replace(/,/g, '').replace(/[^0-9\.]/g, '');

    x = Num.split('.');
    x1 = x[0];
    x1 = x1.length <= 9 ? x1 : x1.substring(0, 9);
    x2 = x.length > 1 ? '.' + x[1] : '';
    x2 = x2.length <= 3 ? x2 : x2.substring(0, 3);
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1))
        x1 = x1.replace(rgx, '$1' + ',' + '$2');

    ////////////////////////////////////////////////////////////////
    ///////////Se actualizo para evitar los decimales///////////////
    //return (x1 + x2).length > 0 ? '$' + x1 + x2 : '';
    return (x1 + x2).length > 0 ? '$' + x1 : '';
    ////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////
}

function checkMoney(event) {
    var code = (event.keyCode || event.which);
    var key = event.keyCode || event.charCode;

    if (code == 37 || code == 38 || code == 39 || code == 40) { }
    else {
        var pos = caret(event.target);
        var Num = event.target.value;
        Num += '';
        Num = Num.replace('$', '');
        Num = Num.replace(/,/g, '').replace(/[^0-9\.]/g, '');

        x = Num.split('.');
        x1 = x[0];
        x1 = x1.length <= 9 ? x1 : x1.substring(0, 9);
        x2 = x.length > 1 ? '.' + x[1] : '';
        x2 = x2.length <= 3 ? x2 : x2.substring(0, 3);

        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1))
            x1 = x1.replace(rgx, '$1' + ',' + '$2');

        ////////////////////////////////////////////////////////////////
        ///////////Se actualizo para evitar los decimales///////////////
        //event.target.value = (x1 + x2).length > 0 ? '$' + x1 + x2 : '';
        event.target.value = (x1 + x2).length > 0 ? '$' + x1 : '';
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////


        if (code != 8 && code != 46) if (x1.length == 1 || x1.length == 5 || x1.length == 9) { pos = pos + 1; }
        document.getElementById('div' + event.target.id).innerText = NumeroALetras(event.target.value.replace('$', '').replace(',', '').replace(',', ''));
        event.target.focus();
        event.target.setSelectionRange(pos, pos);
        ////////////////////////////////////////////////////////////////
        ///////////Se actualizo para evitar los decimales///////////////
        if (x.length > 1)
            alert('Los montos no deben llevar decimales');
        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
    }
}

function writeNumber(Num) {
    Num = Num.replace('$', '');
    Num = Num.replace(/,/g, '').replace(/[^0-9\.]/g, '');

    x = Num.split('.');
    x1 = x[0];
    x1 = x1.length <= 9 ? x1 : x1.substring(0, 9);
    x2 = x.length > 1 ? '.' + x[1] : '';
    x2 = x2.length <= 3 ? x2 : x2.substring(0, 3);
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1))
        x1 = x1.replace(rgx, '$1' + ',' + '$2');

    return (x1 + x2).length > 0 ? x1 + x2 : '';
}

function checkNumber(event) {
    var code = (event.keyCode || event.which);

    if (code == 37 || code == 38 || code == 39 || code == 40) { }
    else {
        var pos = caret(event.target);
        var Num = event.target.value;
        Num += '';
        Num = Num.replace('$', '');
        Num = Num.replace(/,/g, '').replace(/[^0-9\.]/g, '');

        x = Num.split('.');
        x1 = x[0];
        x1 = x1.length <= 9 ? x1 : x1.substring(0, 9);
        x2 = x.length > 1 ? '.' + x[1] : '';
        x2 = x2.length <= 3 ? x2 : x2.substring(0, 3);
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1))
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        event.target.value = (x1 + x2).length > 0 ? x1 + x2 : '';
        if (code != 8 && code != 46) if (x1.length == 1 || x1.length == 5 || x1.length == 9) { pos = pos + 1; }
        event.target.focus();
        event.target.setSelectionRange(pos, pos);
    }
}

function caret(node) {
    if (node.selectionStart) return node.selectionStart;
    else if (!document.selection) return 0;
    //node.focus();
    var c = "\001";
    var sel = document.selection.createRange();
    var txt = sel.text;
    var dul = sel.duplicate();
    var len = 0;
    try { dul.moveToElementText(node); } catch (e) { return 0; }
    sel.text = txt + c;
    len = (dul.text.indexOf(c));
    sel.moveStart('character', -1);
    sel.text = "";
    return len;
}

//Termina Money------------------------------------------------------------------------


//Numero en letras------------------------------------------------------------------------
function Unidades(num) {

    switch (num) {
        case 1: return "UN";
        case 2: return "DOS";
        case 3: return "TRES";
        case 4: return "CUATRO";
        case 5: return "CINCO";
        case 6: return "SEIS";
        case 7: return "SIETE";
        case 8: return "OCHO";
        case 9: return "NUEVE";
    }

    return "";
}

function Decenas(num) {

    decena = Math.floor(num / 10);
    unidad = num - (decena * 10);

    switch (decena) {
        case 1:
            switch (unidad) {
                case 0: return "DIEZ";
                case 1: return "ONCE";
                case 2: return "DOCE";
                case 3: return "TRECE";
                case 4: return "CATORCE";
                case 5: return "QUINCE";
                default: return "DIECI" + Unidades(unidad);
            }
        case 2:
            switch (unidad) {
                case 0: return "VEINTE";
                default: return "VEINTI" + Unidades(unidad);
            }
        case 3: return DecenasY("TREINTA", unidad);
        case 4: return DecenasY("CUARENTA", unidad);
        case 5: return DecenasY("CINCUENTA", unidad);
        case 6: return DecenasY("SESENTA", unidad);
        case 7: return DecenasY("SETENTA", unidad);
        case 8: return DecenasY("OCHENTA", unidad);
        case 9: return DecenasY("NOVENTA", unidad);
        case 0: return Unidades(unidad);
    }
}//Unidades()

function DecenasY(strSin, numUnidades) {
    if (numUnidades > 0)
        return strSin + " Y " + Unidades(numUnidades)

    return strSin;
}//DecenasY()

function Centenas(num) {

    centenas = Math.floor(num / 100);
    decenas = num - (centenas * 100);

    switch (centenas) {
        case 1:
            if (decenas > 0)
                return "CIENTO " + Decenas(decenas);
            return "CIEN";
        case 2: return "DOSCIENTOS " + Decenas(decenas);
        case 3: return "TRESCIENTOS " + Decenas(decenas);
        case 4: return "CUATROCIENTOS " + Decenas(decenas);
        case 5: return "QUINIENTOS " + Decenas(decenas);
        case 6: return "SEISCIENTOS " + Decenas(decenas);
        case 7: return "SETECIENTOS " + Decenas(decenas);
        case 8: return "OCHOCIENTOS " + Decenas(decenas);
        case 9: return "NOVECIENTOS " + Decenas(decenas);
    }

    return Decenas(decenas);
}//Centenas()

function Seccion(num, divisor, strSingular, strPlural) {
    cientos = Math.floor(num / divisor)
    resto = num - (cientos * divisor)

    letras = "";

    if (cientos > 0)
        if (cientos > 1)
            letras = Centenas(cientos) + " " + strPlural;
        else
            letras = strSingular;

    if (resto > 0)
        letras += "";

    return letras;
}//Seccion()

function Miles(num) {
    divisor = 1000;
    cientos = Math.floor(num / divisor)
    resto = num - (cientos * divisor)

    strMiles = Seccion(num, divisor, "UN MIL", "MIL");
    strCentenas = Centenas(resto);

    if (strMiles == "")
        return strCentenas;

    return strMiles + " " + strCentenas;

    //return Seccion(num, divisor, "UN MIL", "MIL") + " " + Centenas(resto);
}//Miles()

function Millones(num) {
    divisor = 1000000;
    cientos = Math.floor(num / divisor)
    resto = num - (cientos * divisor)

    strMillones = Seccion(num, divisor, "UN MILLON", "MILLONES");
    strMiles = Miles(resto);

    if (strMillones == "")
        return strMiles;

    return strMillones + " " + strMiles;

    //return Seccion(num, divisor, "UN MILLON", "MILLONES") + " " + Miles(resto);
}//Millones()

function NumeroALetras(num) {
    var data = {
        numero: num,
        enteros: Math.floor(num),
        centavos: (((Math.round(num * 100)) - (Math.floor(num) * 100))),
        letrasCentavos: "",
        letrasMonedaPlural: "PESOS",
        letrasMonedaSingular: "PESO"
    };

    if (data.centavos > 0) {
        data.letrasCentavos = "CON " + data.centavos + "/100";
    }

    if (data.enteros == 0) {
        return "CERO " + data.letrasMonedaPlural + " " + data.letrasCentavos;
        //alert("Numero: " + "CERO " + data.letrasMonedaPlural + " " + data.letrasCentavos);
    }
    if (data.enteros == 1) {
        return Millones(data.enteros) + " " + data.letrasMonedaSingular + " " + data.letrasCentavos;
        //alert("Numero: " +  Millones(data.enteros) + " " + data.letrasMonedaSingular + " " + data.letrasCentavos);
    }
    else {
        return Millones(data.enteros) + " " + data.letrasMonedaPlural + " " + data.letrasCentavos;
        //alert("Numero: " +  Millones(data.enteros) + " " + data.letrasMonedaPlural + " " + data.letrasCentavos);
    }

}//NumeroALetras()
//Termina numero en letras------------------------------------------------------------------------

function OnItemSelected_FillDiv(event) {
    var selInd = $find(event._id)._selectIndex;
    if (selInd != -1) {
        $find(event._id).get_element().value = $find(event._id).get_completionList().childNodes[selInd]._value;
        console.log("div" + event._id);
        document.getElementById("div" + event._id).innerHTML = "&nbsp;&nbsp;" + $find(event._id).get_completionList().childNodes[selInd].firstChild.nodeValue;
    }
}

function OnClientPopulated_Text(sender, eventArgs) {
    var autoList = $find(sender._id).get_completionList();
    for (i = 0; i < autoList.childNodes.length; i++) {
        var value = autoList.childNodes[i]._value;
        var text = autoList.childNodes[i].firstChild.nodeValue;
        autoList.childNodes[i]._value = value;
        autoList.childNodes[i].innerHTML = value + ' - ' + text;
    }
}