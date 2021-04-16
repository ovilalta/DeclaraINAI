<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pass.aspx.cs" Inherits="DeclaraINE.Formas.Pass" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="../Content/login.css" rel="stylesheet" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <title><%: Page.Title %> - <%: Declara_V2.BLLD.clsSistema.V_SISTEMA %></title>
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
                    return false;
                }
            }

            window.onkeydown = function (event) {
                if (event.keyCode == 123) {
                    event.stopPropagation();
                    event.preventDefault();
                    return false;
                } else if ((event.ctrlKey && event.shiftKey && event.keyCode == 73) || (event.ctrlKey && event.shiftKey && event.keyCode == 74) || (event.ctrlKey && event.keyCode == 83) || (event.ctrlKey && event.keyCode == 71)) {
                    return false;
                }
            }

        }

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
        <div id="l">
            <div id="head">
                <img src="../Images/logo-blanco.png" />
                Sistema de Declaración Patrimonial 
            </div>
            <div id="body">
                <asp:Panel ID="pnlRecuperacion" runat="server">
                    <h4>Recuperar contraseña</h4>
                    <p>Escriba su R.F.C. (13 Posiciones)</p>
                    <table>
                        <tr>
                            <td><span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                <asp:TextBox ID="txtRFC" runat="server" placeholder="R.F.C." AutoCompleteType="Disabled" MaxLength="13"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div class="right">
                        <asp:Button ID="btnRecuperaClave" runat="server" Text="Enviar correo de recuperación" CssClass="Image-Email" OnClick="btnRecuperaClave_Click" />
                        <br />
                        <br />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnRegresar_Click" />
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlConfimacion" runat="server" Visible="false">
                    Se envio una LIGA DE RECUPERACIÓN a los correos electrónicos que registró búsquela en su <b class="danger">bandeja de entrada</b> o en la carpeta de <b class="danger">correo no deseado</b> y siga las instrucciones.
                </asp:Panel>

            </div>
            <div id="foot">
                <img src="../Images/LogoINE.png" />
            </div>
        </div>
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
