<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DeclaraINEAdmin.Formas.Login" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/login.css" rel="stylesheet" />
    <link href="../Content/AlanWebControls.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/AlanWebControls.js"></script>
    <script src="../Scripts/Site.js"></script>
    <link href="../Content/Site.css" rel="stylesheet" />


    <link href="../Content/Iconsx24.css" rel="stylesheet" />

    <script src="../Scripts/ModalTooltip.js"></script>
    <script src="../Scripts/Login.js"></script>


    <title></title>
</head>
<body onload="ComprobarVentana()">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            <Scripts>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
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
                <img src="../Images/logo-blanco.png" /><asp:Label ID="NombreSistema" runat="server"></asp:Label>
            </div>
            <div id="body">
                <table>
                    <tr>
                        <td><span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <asp:TextBox ID="txtUsuario" runat="server" placeholder="  Usuario" AutoCompleteType="Disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <asp:TextBox ID="txtContraseña" runat="server" placeholder="  Contraseña" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <div class="right">
                    <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" EnableViewState="false" CssClass="Image-Lock" />
                    <br />
                </div>
                <br />
                <br />
            </div>
            <div id="foot">
                <img src="../Images/LogoINE.png" />
            </div>
        </div>

        <asp:AlanModalPopUp runat="server" ID="mppCambioClave" HeaderText="Cambie su contraseña por una de seguridad: ALTA">
            <ContentTemplate>
                <table class="f">
                    <tr>
                        <th>
                            <l>Contraseña actual</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtContrasenAnterior" runat="server" AutoCompleteType="Disabled" oncopy="return false;" oncut="return false;" TextMode="Password" CssClass="n34"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Nueva Contraseña</l>
                        </th>
                        <td>
                            <div class="progress">
                                <asp:TextBox ID="txtNueva" TextMode="Password" runat="server" AutoCompleteType="Disabled" oncopy="return false;" oncut="return false;" CssClass="n34"></asp:TextBox>
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
                            <asp:TextBox ID="txtConfirmar" runat="server" TextMode="Password" AutoCompleteType="Disabled" oncopy="return false;" oncut="return false;" CssClass="n34" ClientIDMode="Static"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div id="mgsSugerencia"></div>
                <asp:AlanAlert runat="server" ID="AlertaSuperior" />
                <div class="right">
                    <asp:Button ID="btnCerrarClave" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarClave_Click" />
                    <asp:Button ID="btnGuardarClave" runat="server" Text="Guardar" OnClick="btnGuardarClave_Click" OnClientClick="return ValidaSeguridad();" ClientIDMode="Static" />
                </div>
            </ContentTemplate>
        </asp:AlanModalPopUp>
    </form>
</body>
</html>

<script type="text/javascript">
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(
        function () {
            showMessageBox();
            AlertSucccessFading();
            ValidaSeguridad();
            compkey();
            modalToolTip();
        });

</script>
