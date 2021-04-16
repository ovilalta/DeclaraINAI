<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recuperacion.aspx.cs" Inherits="DeclaraINE.Formas.Recuperacion" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="../Content/login.css" rel="stylesheet" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <title><%: Page.Title %> - <%: Declara_V2.BLLD.clsSistema.V_SISTEMA %></title>
    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link rel="stylesheet" href="../css/registro.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <script type="text/javascript">

        function cmp() {
            document.oncontextmenu = function () { return false }
            window.location.hash = "no-back-button";
            window.location.hash = "Again-No-back-button"
            window.onhashchange = function () { window.location.hash = "no-back-button"; }

            document.onkeydown = function (event) {
                if (event.keyCode == 123) {
                    event.stopPropagation();
                    event.preventDefault();
                    return false;
                } else if ((event.ctrlKey && event.shiftKey && event.keyCode == 73) || (event.ctrlKey && event.shiftKey && event.keyCode == 74) || (event.ctrlKey && event.keyCode == 83) || (event.ctrlKey && event.keyCode == 71)) {
                    event.stopPropagation();
                    event.preventDefault();
                    return false;
                }
            }

            window.onkeydown = function (event) {
                if (event.keyCode == 123) {
                    event.stopPropagation();
                    event.preventDefault();
                    return false;
                } else if ((event.ctrlKey && event.shiftKey && event.keyCode == 73) || (event.ctrlKey && event.shiftKey && event.keyCode == 74) || (event.ctrlKey && event.keyCode == 83) || (event.ctrlKey && event.keyCode == 71)) {
                    event.stopPropagation();
                    event.preventDefault();
                    return false;
                }
            }
        }

    </script>
    <script async src="https://www.googletagmanager.com/gtag/js?id=G-5WVPWF3WWB"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'G-5WVPWF3WWB');
    </script>
</head>
<body onload="cmp();">
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
        <asp:AlanMessageBox ID="MsgBox" runat="server" />


        <div class="card">
            <div class="row" style="background: url('../Images/ine-acerca-slide.jpg');">
                <div class="register-info-box">
                    <div class="row">
                        <div class=" ">
                            <img src="../Images/INE_Login.png" width="180" height="120">
                            <img src="../Images/OIC.png" width="115" height="52" style="margin-top: -8px">
                        </div>
                    </div>
                    <div class="row">
                        <h2 style="margin: 0px auto;">
                            <asp:Literal runat="server" ID="ltr" Text='<%# Page.Title %>'></asp:Literal></h2>
                    </div>
                </div>
            </div>

            <div class="row">


                <asp:Panel runat="server" ID="pnlMensaje" Visible="false" Style="margin: 15% 15%;">
                    <div style="border: solid 1px #f6f6f6; padding: 144px; margin-top: -150px; box-shadow: 2px 2px 5px #999;">
                        <h3 style="color: black;">Se cambio correctamente su contraseña, utilice su nueva contraseña para entrar al sistema</h3>
                        <br>
                        <asp:Button ID="btnSistema" runat="server" Text="Entrar al Sistema" OnClick="btnSistema_Click" CssClass="Image-Workstation" />
                    </div>
                </asp:Panel>

            </div>
        </div>



        <asp:AlanModalPopUp runat="server" ID="mppCambioClave" HeaderText="Cambio de contraseña ">
            <ContentTemplate>
                <table class="f">
                    <tr>
                        <th>
                            <l>Nueva Contraseña</l>
                        </th>
                        <td>
                            <div class="progress">
                                <asp:TextBox ID="txtNueva" TextMode="Password" runat="server" oncopy="return false;" oncut="return false;" CssClass="n34" ClientIDMode="Static"></asp:TextBox>
                                <div class="po-markup">
                                    <a href="#" class="po-link">
                                        <asp:Image ID="imgIcono" runat="server" ImageUrl="~/Images/icons/ColorX24/Info.png" />
                                    </a>
                                    <div class="po-content hidden">
                                        <div class="po-title center">
                                            La contraseña debe contener 
                                        </div>
                                        <div class="po-body center">
                                            <p>
                                                <small>*Mínimo seis caracteres</small><br />
                                                <small>*Una letra mayúscula</small><br />
                                                <small>*Una letra minúscula</small><br />
                                                <small>*Un número</small><br />
                                                <small>*Opcional: Un carácter especial</small>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="progresstext">
                                <div id="Nivelseguridad" class="progress-bar progress-bar-striped active " aria-valuenow="45" aria-valuemin="0" aria-valuemax="100" style="width: 0%"></div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Confirmar Contraseña</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtConfirmar" runat="server" TextMode="Password" oncopy="return false;" oncut="return false;" CssClass="n34" ClientIDMode="Static"></asp:TextBox>
                            <asp:Label ID="mgsSugerencia" runat="server" ClientIDMode="Static" Width="100%" EnableViewState="false"></asp:Label>
                        </td>
                    </tr>

                    <tr runat="server" id="trCaptcha">
                        <th>
                            <l>Verificación de Seguridad</l>
                        </th>
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

                <h6 style="color: black;"><b style="color: black;">NOTA:</b> El nivel de seguridad de tu contraseña debe ser de seguridad <b>ALTA</b>.</h6>
                <div class="po-title">
                    La contraseña debe contener:
                    <ul>
                        <li>*Mínimo seis caracteres</li>
                        <li>*Una letra mayúscula</li>
                        <li>*Una letra minúscula</li>
                        <li>*Un número</li>
                        <li>*Opcional: Un carácter especial</li>
                    </ul>
                </div>

                <div class="right">
                    <asp:Button ID="btnGuardarClave" runat="server" Text="Guardar" OnClick="btnGuardarClave_Click" />
                </div>
                <asp:Literal ID="ltrAPIGoogle" runat="server" EnableViewState="false"></asp:Literal>
                <asp:Literal ID="ltrScriptGoogle" runat="server" EnableViewState="false"></asp:Literal>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnGuardarClave" />
            </Triggers>
        </asp:AlanModalPopUp>
    </form>

    <script>
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            showMessageBox();
            ValidaSeguridad();
            compkey();
            modalToolTip();
        });
    </script>

</body>
</html>
