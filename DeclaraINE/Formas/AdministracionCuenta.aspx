<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministracionCuenta.aspx.cs" Inherits="DeclaraINE.Formas.AdministracionCuenta" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - DeclaraINAI</title>
    <asp:PlaceHolder runat="server"></asp:PlaceHolder>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <script src="../../Scripts/AlanWebControls.js"></script>
    <script src="../../Scripts/Site.js"></script>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link rel="stylesheet" href="../css/Declaracion.css" />
    <link rel="stylesheet" href="../css/style.css" />

    <style type="text/css">
        .panel.panel-default {
            background-color: azure;
        }

        #foot #identificacion {
            text-align: left;
        }

        .LT .active {
            border-color: #f9f9f9 !important;
            background: #f9f9f9 !important;
        }
    </style>
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
</head>
<body>

    <form id="form1" runat="server" autocomplete="off">
        <asp:ScriptManager runat="server" EnablePartialRendering="true">
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
        <%: Scripts.Render("~/bundles/modernizr") %>
        <%: Scripts.Render("~/bundles/ine") %>

        <div class="card">

            <div class="row register-info-box" style="background: url('../Images/ine-acerca-slide.jpg');">
                <div>
                    <div class="row align-items-left" style="display: flex;">
                        <div>
                            <img src="../Images/Declaraine.png" style="height: 32px; margin: 10px 12px 0px;" />
                        </div>
                        <div style="width: 100%;">
                        </div>
                    </div>
                    <div style="height: 60px;">
                        <h2 style="margin-top: 0px; margin-bottom: 0px; margin-left: 15px;">Sistema de Declaración Patrimonial</h2>
                    </div>
                    <ul class="nav nav-tabs menu2020 LT">
                        <li>
                            <asp:LinkButton ID="btnContraseña" runat="server" d-t="Cambiar Contraseña" OnClick="btnContraseña_Click" EnableViewState="false">
                                <img alt="Inicio" src="../images/icons/ColorX32/Add Key.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="btnCorreo" runat="server" d-t="Correo electrónico" OnClick="btnCorreo_Click" EnableViewState="false">
                               <img alt="Inicio" src="../images/icons/ColorX32/Email.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkVolver" runat="server" d-t="Volver al menù principal" OnClick="lkVolver_Click" EnableViewState="false">                       
                        <img src="../images/icons/ColorX32/Circled%20Left.png"></asp:LinkButton>
                        </li>
                    </ul>
                </div>

            </div>


            <%--            <div class="row" style="background: url(https://www.ine.mx/wp-content/uploads/2017/03/ine-acerca-slide.jpg);">
                <div class="register-info-box">
                    <div class="row" style="display: flex">
                        <h2 style="margin: 14px; font-size: 26px;">DeclaraINE |</h2>
                        <h3 style="margin-top: 17px; font-size: 22px;">Administración de cuenta</h3>
                    </div>
                </div>
            </div>--%>
            <div class="row">
                <div class="col">


                    <div class="tab-content">
                        <div runat="server" enableviewstate="false" class="tab-pane fade level1 active in" id="menu1">
                        </div>
                    </div>

                    <div class="subtitulo">
                        <asp:Literal ID="ltrSubTitulo" runat="server"></asp:Literal>
                    </div>

                    <div id="cuerpo">
                        <table class="f ">
                            <tbody>
                                <tr>
                                    <th>
                                        <l>Responsiva de uso de medios (Solo para las declaraciones iniciales)</l>
                                    </th>
                                    <td>
                                        <asp:Button ID="btnDescargarRespon" runat="server" Text="Descargar" OnClick="btnDescargarRespon_Click" CssClass="mpdf" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>

                        <asp:Panel ID="pnlContraseña" runat="server" Visible="false">
                            <asp:AlanAlert runat="server" ID="AlertaSuperiorPass" />
                            <table class="f">
                                <tbody>
                                    <tr>
                                        <th>
                                            <l>Contraseña Anterior</l>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtContraseñaAnterior" runat="server" TextMode="Password" requerido="btnGuardarDatos" MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <l>Nueva Contraseña</l>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtContraseñaA" runat="server" requerido="btnGuardarDatos" MaxLength="15"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <l>Confirmar Contraseña</l>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtContraseñaB" runat="server" requerido="btnGuardarDatos" MaxLength="15"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="right">
                                <asp:Button ID="btnGuardarContraseña" runat="server" ToolTip="Cerrar" Text="Guardar" OnClientClick="return CheckReq();" ClientIDMode="Static" OnClick="btnGuardarContraseña_Click" />
                            </div>
                        </asp:Panel>

                        <asp:UpdatePanel ID="pnlCorreo" runat="server" Visible="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:AlanAlert runat="server" ID="AlertaSuperior" />
                                <table class="f">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:CheckBoxList CssClass="table table-striped table-hover" ID="chbCorreos" runat="server" RepeatDirection="Vertical"></asp:CheckBoxList>
                                                <asp:GridView ID="grdCorreos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Correo Electrónico">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltrDescripcion" runat="server" Text='<%# Eval("V_CORREO") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Principal">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnCorreoPrincipal" runat="server" Text="" CommandArgument='<%# Eval("V_CORREO") %>' CssClass='<%# Eval("L_PRINCIPAL") == null ? "btnFalse2" : (!Convert.ToBoolean(Eval("L_PRINCIPAL")) ? "btnFalse2" : "btnTrue2") %>' OnClick="btnCorreoPrincipal_Click" Enabled='<%#  Eval("L_PRINCIPAL") == null ? true : !Convert.ToBoolean(Eval("L_PRINCIPAL")) %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Activo">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnCorreoActivo" runat="server" Text="" CommandArgument='<%# Eval("V_CORREO") %>' CssClass='<%# Eval("L_ACTIVO") == null ? "btnFalse2" : (!Convert.ToBoolean(Eval("L_ACTIVO")) ? "btnFalse2" : "btnTrue2") %>' OnClick="btnCorreoActivo_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Confirmado">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnCorreoConfirmado" runat="server" Text="" CommandArgument='<%# Eval("V_CORREO") %>' CssClass='<%# Eval("L_CONFIRMADO") == null ? "btnFalse2" : (!Convert.ToBoolean(Eval("L_CONFIRMADO")) ? "btnFalse2" : "btnTrue2") %>' OnClick="btnCorreoConfirmado_Click" Enabled='<%#  Eval("L_CONFIRMADO") == null ? true : !Convert.ToBoolean(Eval("L_CONFIRMADO")) %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>

                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div class="right">
                                    <asp:Button ID="btnAgregarNCorreo" runat="server" Text="Agregar Correo " OnClick="btnAgregarNCorreo_Click" />
                                </div>
                            </ContentTemplate>

                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnGuardarNCorreo" />

                            </Triggers>
                        </asp:UpdatePanel>

                    </div>

                    <asp:AlanModalPopUp runat="server" ID="mppNCorreo">
                        <ContentTemplate>
                            <asp:AlanAlert runat="server" ID="AlertaCorreo" />
                            <table class="f">
                                <tbody>
                                    <tr>
                                        <th>
                                            <l>Nuevo correo</l>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNuevoCorreo" runat="server" TextMode="Email" requerido="btnGuardarNCorreo" MaxLength="100"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <l>Confirma correo</l>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtConfirmaCorreo" runat="server" TextMode="Email" requerido="btnGuardarNCorreo" MaxLength="100"></asp:TextBox>
                                        </td>
                                    </tr>
                            </table>
                            <div class="right">
                                <asp:Button ID="btnCerrarNCorreo" runat="server" ToolTip="Cerrar" Text="Cerrar" OnClick="btnCerrarNCorreo_Click" />
                                <asp:Button ID="btnGuardarNCorreo" runat="server" ToolTip="Cerrar" Text="Guardar" OnClientClick="return CheckReq();" ClientIDMode="Static" OnClick="btnGuardarNCorreo_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:AlanModalPopUp>

                    <asp:AlanModalPopUp runat="server" ID="mppDeshabilitarCorreo">
                        <ContentTemplate>
                            <asp:Literal ID="ltrConfTexto" runat="server"></asp:Literal>
                            <b>
                                <asp:Literal ID="ltrConfCorreo" runat="server"></asp:Literal></b>
                            <div class="right">
                                <asp:Button ID="btnCerrarConfirmacion" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarConfirmacion_Click" />
                                <asp:Button ID="btnGuardarConfirmarDeshabilitar" runat="server" Text="Confirmar" OnClick="btnGuardarConfirmarDeshabilitar_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:AlanModalPopUp>

                    <%--        <asp:AlanModalPopUp runat="server" ID="mppConfirmarCorreo">
            <ContentTemplate>
                Escribe el código de confirmación para ativar tu correo: 
                <b>
                    <asp:TextBox ID="txtCode" runat="server" TextMode="number" requerido="btnGuardarNCorreo" MaxLength="6"></asp:TextBox>
                    <div class="right">
                        <asp:Button ID="btnCancelarConfirmarCorreo" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCancelarConfirmarCorreo_Click" />
                        <asp:Button ID="btnGuardarConfirmarCorreo" runat="server" Text="Confirmar" OnClick="btnGuardarConfirmarCorreo_Click" />
                    </div>
            </ContentTemplate>
        </asp:AlanModalPopUp>--%>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
