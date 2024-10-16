<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DeclaraINE.Formas.Login" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: #f8f9fa;">
<head runat="server">
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <title><%: Page.Title %> - <%: Declara_V2.BLLD.clsSistema.V_SISTEMA %></title>
    <!-- CSS here -->
    <meta charset="utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <meta http-equiv="Expires" content="0">
    <meta http-equiv="Last-Modified" content="0">
    <meta http-equiv="Cache-Control" content="no-cache, mustrevalidate">
    <meta http-equiv="Pragma" content="no-cache">
    <link rel="shortcut icon" type="image/x-icon" href="img/favicon.png" />
    <script src="../def.js?1"></script>
    <!--<script type="text/javascript">
        var _smartsupp = _smartsupp || {};
        _smartsupp.key = '36fe62cea33d3cbc39674295b89808a4ec11a4fc';
        window.smartsupp || (function (d) {
            var s, c, o = smartsupp = function () { o._.push(arguments) }; o._ = [];
            s = d.getElementsByTagName('script')[0]; c = d.createElement('script');
            c.type = 'text/javascript'; c.charset = 'utf-8'; c.async = true;
            c.src = 'https://www.smartsuppchat.com/loader.js?'; s.parentNode.insertBefore(c, s);
        })(document);
    </script>-->
    <script async src="https://www.googletagmanager.com/gtag/js?id=G-5WVPWF3WWB"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'G-5WVPWF3WWB');
    </script>
</head>
<body onload="ValidaNavegador();" onselect="return false;" ondragstart="return false;">
    <style>
        .loader {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            opacity: .8;
            background-color: #ffffff;
        }

            .loader img {
                margin: 15% 45%;
                height: 117px;
                display: flex;
            }

        .formError {
            z-index: 999999 !important;
            position: initial !important;
        }

            .formError .formErrorContent {
                background: #ae2174 !important;
                -webkit-box-shadow: 0 0 6px #ae2174 !important;
                border: 0.5px solid #ae2174 !important;
                margin-top: -43px !important;
            }

            .formError .formErrorArrow {
                margin: -2px 0 0 0px !important;
            }

                .formError .formErrorArrow div {
                    background: #ae2174 !important;
                    border: 0.5px solid #ae2174 !important;
                }

        .Login .footer {
            cursor: pointer;
        }

            .Login .footer:hover p {
                font-size: 16px;
                color: #018367;
                font-weight: 600;
            }
    </style>
    <div class="loader" align="center" valign="center">
        <img src="../Images/pageLoader.gif" />
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            <Scripts>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
                <asp:ScriptReference Name="MsWebFormsControlsResources" />
                <asp:ScriptReference Name="MsWebFormsSiteResorces" />
                <asp:ScriptReference Name="MsWebFormsPoper" />
                <asp:ScriptReference Name="MsWebFormsValidations" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
            </Scripts>
        </asp:ScriptManager>

        <link rel="stylesheet" href="../css/bootstrap.min.css" />
        <link rel="stylesheet" href="../css/font-awesome.min.css" />
        <link rel="stylesheet" href="../css/login.css?1" />
        <link rel="stylesheet" href="../css/style.css?1" />
        <script src="../Scripts/jquery-3.1.1.min.js"></script>
        <script src="../Scripts/bootstrap.min.js"></script>
        <link href="../Content/AlanWebControls.css?1" rel="stylesheet" />
        <script src="../Scripts/AlanWebControls.js?1"></script>

        <asp:UpdatePanel ID="pnlLogin" runat="server" UpdateMode="Always">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnEntrar" />
                <asp:AsyncPostBackTrigger ControlID="btnRecuperaClave" />
            </Triggers>
            <ContentTemplate>
                <asp:AlanMessageBox ID="MsgBox" runat="server" />
                <div class="row" style="margin: 10px;">
                    <div class="col">
                        <div class="login-reg-panel">
                            <div class="container">
                                <div class="card"></div>
                                <div class="card row Login">
                                    <h1 class="title" style="padding: 10px 55px 10px 30px;">¿Trabajas actualmente en el INAI o eres Reingreso? Inicia sesión con el usuario y contraseña que registraste</h1>

                                    <div class="input-container">
                                        <asp:TextBox ID="txtUsuario" runat="server" AutoCompleteType="Disabled" xrequired="required" CssClass="validate[required]"></asp:TextBox>
                                        <label for="txtUser">Usuario <small style="font-size:65%; color:red">(RFC con Homoclave o Correo Institucional)</small></label>
                                        <div class="bar">
                                        </div>
                                    </div>
                                    <div class="input-container">
                                        <asp:TextBox ID="txtContraseña" runat="server" AutoCompleteType="Disabled" TextMode="Password" xrequired="required" CssClass="validate[required]"></asp:TextBox>
                                        <label for="txtPwd">Contraseña</label>
                                        <div class="bar">
                                        </div>
                                    </div>
                                    <div class="input-container">

                                        <table style="position: absolute; margin: 0px 20px auto;">
                                            <tr runat="server" id="trCaptcha">
                                                <td colspan="2">
                                                    <div id="dvCaptcha">
                                                    </div>
                                                    <br />
                                                    <asp:TextBox ID="txtCaptcha" runat="server" Style="display: none" ClientIDMode="Static" />
                                                    <asp:RequiredFieldValidator ID="rfvCaptcha" ErrorMessage="Por favor haz click en ''No soy un robot''" ClientIDMode="Static" ControlToValidate="txtCaptcha"
                                                        runat="server" ForeColor="Red" Display="Dynamic" />
                                                    <br />
                                                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="button-container" style="margin: 40px 60px 0px;">
                                        <asp:Button ID="btnEntrar" ClientIDMode="Static" OnClientClick="return ValidatebtnEntrar();" runat="server" Text="Entrar" OnClick="btnEntrar_Click" EnableViewState="false" type="button" />
                                    </div>
                                    <div class="footer">
                                        <p>
                                            ¿Olvidó su contraseña?
                                    <%--<asp:LinkButton ID="btnOlvido" runat="server" OnClick="btnOlvido_Click">¿Olvidó su Contraseña?</asp:LinkButton>--%>
                                        </p>
                                        
                                        <br />
                                            <a  href="../pdf1/GuiaRecuperarContrasena.pdf" target="_blank"><p>&nbsp<i class="fa fa-book fa-3" aria-hidden="true"></i>Guía para recuperar contraseña</p></a>
                                        
                                    </div>

                                </div>
                                <div class="card alt row">
                                    <div class="toggle"></div>
                                    <h1 class="title">Recuperar contraseña<div class="close"></div>
                                        <h1></h1>
                                        <h1 class="title">Escriba su R.F.C. (13 Posiciones) </h1>
                                        <div class="input-container">
                                            <asp:TextBox ID="txtRFC" runat="server" AutoCompleteType="Disabled" ClientIDMode="Static" MaxLength="13"></asp:TextBox>
                                            <label for="txtName">
                                            RFC</label>
                                            <div class="bar">
                                            </div>
                                        </div>
                                        <div class="button-container">
                                            <%--<button><span>Enviar correo de recuperación</span></button>--%>
                                            <asp:Button ID="btnRecuperaClave" runat="server" ClientIDMode="Static" OnClick="btnRecuperaClave_Click" OnClientClick="return btnRecuperaClabe();" Text="Enviar correo de recuperación" />
                                            
                                        </div>
                                        
                                    </h1>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col">
                        <div>
                            <a href="#"></a>
                        </div>
                        <div class="register-info-box">
                            <div class="row">
                                <div class="col">
                                    <img src="../Images/INE_Login.png" width="180" height="120">
                                    <img src="../Images/OIC.png" width="180" height="120" style="margin-top: -8px">
                                    <h3>Sistema de Declaraciones Patrimonial y de Intereses </h3>
                                    <br>
                                    <br>
                                    <img src="../Images/Declaraine.png" width="400" height="65">
                                    <br>
                                    <br>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <h2>¿Es la primera vez que trabajas en el INAI? </h2>
                                    <br>
                                    <br>
                                    <br>
                                    <p style="font-size: 22px;">
                                        <asp:LinkButton Style="color: #f9f9ff;" ID="btnRegistro" runat="server" OnClick="btnRegistro_Click">Regístrate aquí</asp:LinkButton>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col" style="/* text-decoration: none; *//* border: solid 1px #ed008c; *//* padding: 10px; *//* background-color: #ffffff; *//* box-shadow: 0px 0px 1px #ed008c, -1px 4px 14px #ed008c; *//* font-family: Arial,sans-serif; */margin: 7px -15px; color: beige;">

                                    <div class="modal-body" style="text-align: justify;">
                                        <!-- <h5 class="modal-title" style="">AVISO IMPORTANTE</h5>
                                        En este link puedes obtener el formato de Acta de Entrega-recepción a que se refiere el ACUERDO GENERAL OIC-INE/03/2020 QUE ESTABLECE LA OPCIÓN EMERGENTE EN LOS ACTOS DE ENTREGA-RECEPCIÓN.-->
                                        <br>
                                        <!--
                                        <div style="text-align: center; padding: 20px 0px;">
                                            <a href="https://declaraine-pdn.ine.mx/Formato-Acta-Entrega-Recepcion.docx" target="_blank" style="text-decoration: none; color: #ed008c; padding: 10px; background-color: #ffffff; font-family: Arial,sans-serif;">Formato de Acta de Entrega-Recepción</a>
                                        </div>-->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Literal ID="ltrAPIGoogle" runat="server" EnableViewState="false"></asp:Literal>
                    <asp:Literal ID="ltrScriptGoogle" runat="server" EnableViewState="false"></asp:Literal>
                    <script type="text/javascript"> 
                        $(window).ready(function () {
                            $(".loader").fadeOut("slow");
                            showOlvidoPass();
                        });
                    </script>
                    <script type="text/javascript">
                        jQuery(document).ready(function () {
                            jQuery("#form1").validationEngine();
                        });

                        //$("#btnEntrar").click(function () {
                        //    if ($("#form1").validationEngine('validate') == false)
                        //        return false;
                        //    else
                        //        return true;
                        //});

                        //$("#btnRecuperaClave").click(function () {
                        //    if ($("#form1").validationEngine('validate') == false)
                        //        return false;
                        //    else
                        //        return true;
                        //});

                        $('.footer').on('click', function () {
                            $('.container').stop().addClass('active');
                            $('#txtRFC').addClass('validate[required]');
                            $('#txtRFC').val('');

                            $('#txtUsuario').removeClass('validate[required]');
                            $('#txtContraseña').removeClass('validate[required]');
                        });

                        $('.close').on('click', function () {
                            $('.container').stop().removeClass('active');
                            $('#txtRFC').removeClass('validate[required]');

                            $('#txtUsuario').addClass('validate[required]');
                            $('#txtContraseña').addClass('validate[required]');

                            $('#txtUsuario').val('');
                            $('#txtContraseña').val('');
                        });


                    </script>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress AssociatedUpdatePanelID="pnlLogin" runat="server" EnableViewState="false">
            <ProgressTemplate>
                <div style="position: fixed; left: 0px; top: 0px; width: 100%; height: 100%; z-index: 9999; opacity: .8; background-color: #ffffff;">
                    <img src="../Images/pageLoader.gif" style="margin: 15% 45%; height: 117px; display: flex;" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>


    </form>
    <div style="position: absolute; width: 100%;">
        <footer class="footer" style="text-align: left; background: inherit;">
            <div class="container" style="width: 100%; margin: 0% 0% 0% 20%;">
                <div class="row" style="margin-right: 0px; margin-left: 0px;">
                    <div class="col-xl-4 col-md-6 col-lg-4 ">
                        <div>
                            <h4 style="color: #000">OIC</h4>
                            <p>© Derechos Reservados, Órgano Interno de Control</p>
                            <br />
                            <br />
                            <br />
                            <br />
                            <p style="color:dimgray;">V.2024-05-30-1330</p>
                        </div>
                    </div>
                    <div class="col-xl-4 col-md-6 col-lg-4 ">
                        <div>
                            <h4 style="color: #000"><i class="fa fa-map-marker" aria-hidden="true"></i>&nbsp;Oficinas Centrales</h4>
                            <p>
                                Órgano Interno de Control<br />
                                Insurgentes Sur No. 3211
                                    Col. Insurgentes Cuicuilco, 04530 México, Ciudad de México
                            </p>
                        </div>
                    </div>
                    <div class="col-xl-4 col-md-6 col-lg-4 ">
                        <div>
                            <h4 style="color: #000"><i class="fa fa-phone" aria-hidden="true"></i>&nbsp;Llámanos o escríbenos</h4>
                            <p>
                                Número de conmutador: 50042400
                                <br />
                                Extensiones: 3435, 2363<br />
                                CDMX e Interior de la República
                                <br />
                                Correos electrónicos:<br />
                                carla.cordero@inai.org.mx<br />
                                oscar.vilalta@inai.org.mx<br />                                
                                <br />
                            </p>
                        </div>
                    </div>

                </div>
            </div>
        </footer>
    </div>
    <%--    <div class="modal fade" id="mdEtica" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" style="color: black;">Aviso Importante</h5>
                </div>
                <div class="modal-body" style="text-align: justify;">
                    Con fundamento en el artículo 29 de la Ley General de Responsabilidades Administrativas, las declaraciones patrimoniales y de intereses serán públicas salvo los rubros cuya publicidad pueda afectar la vida privada o los datos personales protegidos por la Constitución.

                        <hr />

                    En este link puedes obtener el formato de Acta de Entrega-recepción a que se refiere el ACUERDO GENERAL OIC-INE/03/2020 QUE ESTABLECE LA OPCIÓN EMERGENTE EN LOS ACTOS DE ENTREGA-RECEPCIÓN.


                        <br />

                    <div style="text-align: center; padding: 20px 0px;">
                        <a href="https://declaraine-pdn.ine.mx/Formato-Acta-Entrega-Recepcion.docx" target="_blank" style="text-decoration: none; color: #000; border: solid 1px #cac5c5; padding: 10px; background-color: #ffffff; box-shadow: 0px 3px 15px #e0e0e0, -5px -5px 26px #fff; font-family: Arial,sans-serif;">Formato de Acta de Entrega-Recepción</a>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal" onclick=" return CerrarModal();">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

    <link href="../css/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../js/jquery.validationEngine-es.js"></script>
    <script src="../js/jquery.validationEngine.js"></script>

    <script>
        function CerrarModal() {
            $('#mdEtica').modal('toggle');
        }

        function ValidatebtnEntrar() {
            if ($("#form1").validationEngine('validate') == false)
                return false;
            else
                return true;
        };

        function btnRecuperaClabe() {
            if ($("#form1").validationEngine('validate') == false)
                return false;
            else
                return true;
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            showMessageBox();
            AlertSucccessFading();
            req();
            ValidaSeguridad();
            compkey();
            showOlvidoPass();
            avoidCharacters();
        });
    </script>
</body>
</html>


