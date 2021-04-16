$(document).ready(function () {
    ValidaSeguridad();
    compkey();
    avoidCharacters();
});

function avoidCharacters() {
    jQuery("[id*='txt']").keypress(function (tecla) {
        if ((tecla.charCode != 60) && (tecla.charCode != 62) && (tecla.charCode != 39))
            $(this).each(function () {
                char = $(this)[0].value.substring($(this)[0].value.length - 1);
                if (char.charCodeAt() == 45 && char.charCodeAt() == tecla.charCode)
                    document.getElementById($(this)[0].id).value = $(this)[0].value.substring(0, $(this)[0].value.length - 1);
                else
                    document.getElementById($(this)[0].id).value = $(this)[0].value;
            });
        else
            return false;
    });
}

function ValidaSeguridad() {
    $('#txtNueva').each(function () {
        $(this).keyup(function (e) {
            var MyAltRxE = new RegExp("^(?=.{6,})((?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*\\W)).*$", "g");
            var AltRxE = new RegExp("^(?=.{6,})((?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])).*$", "g");
            var mdRxE = new RegExp("^((?=.{6,})(?=.*[A-Z])(?=.*[a-z]))|((?=.{6,})(?=.*[a-z])(?=.*[0-9]))|((?=.{6,})(?=.*[A-Z])(?=.*[0-9])).*$", "g");
            var dbilRxE = new RegExp("(?=.{1,}).*", "g");

            if (false == dbilRxE.test($(this).val())) {
                MdStatus($(this).val(), 0);
            } else if (MyAltRxE.test($(this).val())) {
                MdStatus($(this).val(), 4);
            } else if (AltRxE.test($(this).val())) {
                MdStatus($(this).val(), 3);
            } else if (mdRxE.test($(this).val())) {
                MdStatus($(this).val(), 2);
            } else
                MdStatus($(this).val(), 1);

            compkey();
            return true;
        });
    });

    $('#txtConfirmar').each(function () {
        $(this).keyup(function (e) {
            compkey();
            return true;
        });
    });
};

function MdStatus(name, data) {
    var prog = '#Nivelseguridad';
    var text = '#mgsSugerencia';

    switch (data) {
        case 0:
            $(prog).width('0%');
            $(prog).attr('value', '0');
            $(prog).css("&nbsp; background-color", "#9E9E9E");
            break;
        case 1:
            $(prog).width('33%');
            $(prog).attr('value', '25');
            $(prog).css("background-color", "#eb1616");
            $(prog).html('&nbsp; Seguridad de la contraseña: Baja');
            break;
        case 2:
            $(prog).width('50%');
            $(prog).attr('value', '50');
            $(prog).css("background-color", "#FF9800");
            $(prog).html('&nbsp; Seguridad de la contraseña: Media');
            break;
        case 3:
            $(prog).width('78%');
            $(prog).attr('value', '78');
            $(prog).css("background-color", "#8BC34A");
            $(prog).html('&nbsp; Seguridad de la contraseña: Alta');
            break;
        case 4:
            $(prog).width('100%');
            $(prog).attr('value', '100');
            $(prog).css("background-color", "#07890c");
            $(prog).html('&nbsp; Seguridad de la contraseña: Muy Alta');
            break;
    }
};


function compkey() {
    if ($('#txtConfirmar').val() == $('#txtNueva').val() && $('#txtConfirmar').val() != "") {
        $('#mgsSugerencia').hide();
    } else {
        $('#mgsSugerencia').html('La nueva contraseña y la confirmación no coinciden');
        $('#mgsSugerencia').show();
    }
    if ($('#txtConfirmar').val() == "") {
        $('#mgsSugerencia').hide();
    }

    if ($('#txtConfirmar').val() == $('#txtNueva').val() && parseInt($('#Nivelseguridad').attr('value')) >= 78) {
        statusSave(true);
    } else {
        statusSave(false);
    }
};

function statusSave(a) {
    if (a) {
        $("#btnGuardarClave").attr('disabled', false);
    } else {
        $("#btnGuardarClave").attr('disabled', true);
    }
};