<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="DeclaraINE.Formas.Registro" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/SioNo.ascx" TagPrefix="uc1" TagName="SioNo" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../Scripts/jquery-3.1.1.js"></script>
    <%--<webopt:BundleReference runat="server" Path="~/Content/css" />--%>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/AlanWebControls.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />

    <link href="../Content/login.css" rel="stylesheet" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <script src="../Scripts/Site.js"></script>

    <%--<link rel="stylesheet" href="../css/bootstrap.min.css" />--%>
    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link rel="stylesheet" href="../css/registro.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <script async src="https://www.googletagmanager.com/gtag/js?id=G-5WVPWF3WWB"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'G-5WVPWF3WWB');
    </script>
    <title><%: Page.Title %> - <%: Declara_V2.BLLD.clsSistema.V_SISTEMA %></title>
</head>
<body onload="ComprobarVentana()" style="background-size: 3840px 2160px;">
    <%--<body style="background-size: 3840px 2160px;">--%>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="true">
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


        <div class="card">
            <div class="row" style="background: url(../Images/ine-acerca-slide.jpg);">
                <div class="register-info-box">
                    <div class="row">
                        <div class=" ">
                            <img src="../Images/INE_Login.png" width="180" height="120">
                            <img src="../Images/OIC.png" width="115" height="52" style="margin-top: -8px">
                        </div>
                    </div>
                    <div class="row">
                        <h2 style="margin-top: 0px; margin-bottom: 0px;">Sistema de Declaración Patrimonial </h2>
                        <h3 style="margin-top: 0px; margin-bottom: 0px;">Registro</h3>
                    </div>
                </div>
            </div>
        </div>
        <div class="card">
            <div class="col">



                <asp:AlanMessageBox runat="server" ID="msgBox" />
                <asp:AlanQuestionBox runat="server" ID="qstBoxConfirmaCorreo" OnYes="qstBoxConfirmaCorreo_Yes" OnNo="qstBoxConfirmaCorreo_No"></asp:AlanQuestionBox>
                <asp:AlanQuestionBox runat="server" ID="qstBoxConfirmaSinCorre" OnYes="qstBoxConfirmaSinCorre_Yes" OnNo="qstBoxConfirmaSinCorre_No"></asp:AlanQuestionBox>
                <asp:AlanQuestionBox runat="server" ID="qstHomo" OnYes="qstHomo_Yes" OnNo="qstHomo_No"></asp:AlanQuestionBox>
                <asp:AlanQuestionBox runat="server" ID="qstConfirmaDatos" OnYes="qstConfirmaDatos_Yes" OnNo="qstConfirmaDatos_No"></asp:AlanQuestionBox>
                <asp:AlanQuestionBox runat="server" ID="qstRegistroExitoso" OnYes="qstRegistroExitoso_Yes" OnNo="qstRegistroExitoso_Yes"></asp:AlanQuestionBox>
                <div id="cuerpo">
                    <asp:AlanAlert runat="server" ID="msgx"></asp:AlanAlert>
                    <div runat="server" id="Correo">
                        <asp:AlanAlert runat="server" ID="alertPuesto"></asp:AlanAlert>
                        <table class="f" style="background-image: linear-gradient(white,white)">
                            <tr runat="server" visible="false" id="trNivel0">
                                <th>
                                    <l> Clave de Puesto</l>
                                </th>
                                <td>
                                    <ajaxToolkit:ComboBox ID="cmbVID_CLAVEPUESTO" runat="server"
                                        AutoPostBack="true"
                                        DropDownStyle="DropDownList"
                                        AutoCompleteMode="SuggestAppend"
                                        CaseSensitive="False"
                                        Width="100%"
                                        OnSelectedIndexChanged="cmbVID_CLAVEPUESTO_SelectedIndexChanged"
                                        ItemInsertLocation="Append">
                                    </ajaxToolkit:ComboBox>
                                </td>
                            </tr>
                            <tr runat="server" visible="false" id="trNivel">
                                <th>
                                    <l>Clave de Nivel</l>
                                </th>
                                <td>
                                    <asp:DropDownList ID="cmbVID_NIVEL" runat="server" AutoPostBack="true" requerido="btnAceptarCorreo" OnSelectedIndexChanged="cmbVID_NIVEL_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr runat="server" visible="false" id="trPuesto">
                                <th>
                                    <l>Denominación del Puesto</l>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtV_DENOMINACION_PUESTO" runat="server" Enabled="false" requerido="btnSiguienteERROR"></asp:TextBox>
                                </td>
                            </tr>

                            <tr runat="server" visible="false">
                                <th>
                                    <l>¿Participa en la administración u operación de los recursos materiales, humanos y/o financieros?</l>
                                </th>
                                <td>
                                    <uc1:SioNo runat="server" ID="SioNo1" />
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <th>
                                    <l>¿Interviene en la adjudicación de pedidos o contratos?</l>
                                </th>
                                <td>
                                    <uc1:SioNo runat="server" ID="SioNo2" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <l><asp:Literal ID="ltrPreCorreo" runat="server" Text="Correo electrónico institucional"></asp:Literal></l>
                                </th>
                                <td>
                                    <div style="width: 50%;">
                                        <asp:TextBox ID="txtPrevCorreo" runat="server" AutoCompleteType="Disabled" requerido="btnAceptarCorreo" CssClass="n2" Width="420px"></asp:TextBox><span style="padding-top: 7px; position: fixed;">
                                            <asp:Label Text="@inai.org.mx" ID="lblCorreoINE" runat="server" />
                                        </span>
                                    </div>
                                </td>
                                <th runat="server" id="pretag" style="background-color: #ffffff;"></th>
                            </tr>
                            <tr>
                                <td colspan="2" class="center">
                                    <br />
                                    <asp:Button ID="btnAceptarCorreo" runat="server" Text="Aceptar" OnClick="btnAceptarCorreo_Click" EnableViewState="false" ClientIDMode="Static" OnClientClick="return CheckReq();" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;                                    
                                    <asp:Button ID="btnRegresarPantallaLogin" runat="server" Text="Regresar" OnClick="btnRegresarPantallaLogin_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnVerTutorial" runat="server" Text="Ver Tutorial" CssClass="Image-Assistant" OnClick="btnVerTutorial_Click" EnableViewState="false" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancelarCorreo" runat="server" Text="No cuento con correo electrónico institucional" OnClick="btnSinCorreo_Click" />

                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:UpdatePanel ID="Forma" runat="server" Visible="false" UpdateMode="Always">
                        <ContentTemplate>
                            <table class="f" style="background-image: linear-gradient(white,white)">
                                <tbody>
                                <!--<tr>
                                        <th>
                                            <l>¿Ingresaste al INAI en el año 2020? (NO APLICA para demociones, <br />promociones y/o cambios de área de adscripción)</l>
                                        </th>
                                        <td>
                                            <asp:RadioButtonList ID="listNvoIng" runat="server">
                                                <asp:ListItem Value="True" Selected="True">Sí</asp:ListItem>
                                                <asp:ListItem Value="False">No</asp:ListItem>
                                            </asp:RadioButtonList>

                                        </td>
                                    </tr>-->
                                    <tr>
                                        <th>
                                            <l>Nombre(s)</l>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtNombre" runat="server" AutoCompleteType="Disabled" requerido="btnAceptar"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <l>Primer Apellido</l>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPrimerApellido" runat="server" AutoCompleteType="Disabled" requerido="btnAceptar"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <l>Segundo Apellido</l>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtSegundoApellido" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>

                                        <th>
                                            <l>Fecha de Nacimiento</l>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtFecha" runat="server" AutoCompleteType="Disabled" MaxLength="10" Date="S" requerido="btnAceptar"></asp:TextBox>
                                            <asp:CalendarExtender runat="server" ID="txtFecha_C" TargetControlID="txtFecha" Format="dd/MM/yyyy" />


                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <l>R.F.C.</l>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtVID_NOMBRE" runat="server" AutoCompleteType="Disabled" MaxLength="4" placeholder="XXXX" requerido="btnAceptar" CssClass="n4"></asp:TextBox>
                                            <asp:TextBox ID="txtVID_FECHA" runat="server" AutoCompleteType="Disabled" MaxLength="6" placeholder="000000" requerido="btnAceptar" CssClass="n3"></asp:TextBox>
                                            <!--TextMode="Number" esto le quité OEVM-->
                                            <asp:TextBox ID="txtVID_HOMOCLAVE" runat="server" AutoCompleteType="Disabled" MaxLength="3" placeholder="XX0" CssClass="n4"></asp:TextBox>
                                            <asp:ImageButton ID="btnCalcularHomo" runat="server" OnClick="btnCalcularHomo_Click" ImageUrl="~/Images/icons/ColorX32/Calculator.png" ToolTip="Calcular Homoclave" Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <l>Correo Electrónico</l>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtCorreo" runat="server" AutoCompleteType="Disabled" TextMode="Email" requerido="btnAceptar" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <l>Fecha de Ingreso al Instituto</l>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtFIngreso" runat="server" autocomplete="off" Date="S" requerido="btnAceptar" Style="width: 75% !important;"></asp:TextBox>
                                            <asp:CalendarExtender runat="server" ID="txtFIngreso_C" TargetControlID="txtFIngreso" Format="dd/MM/yyyy" />
                                            <asp:TextBox ID="dum" runat="server" BorderColor="Transparent" ReadOnly="true" BackColor="Transparent" Height="0px" Width="0%" CssClass="n0"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <l>Bajo protesta de decir verdad, ¿estuviste obligado a presentar la <br />declaración fiscal anual correspondiente al año anterior? </l>
                                        </th>
                                        <td>
                                            <asp:RadioButtonList ID="listOblDec" runat="server">
                                                <asp:ListItem Value="True">Sí</asp:ListItem>
                                                <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>

                                        </td>
                                    </tr>
                                    <tr>
                                    <tr>
                                        <th>
                                            <l>Contraseña</l>
                                        </th>
                                        <td>
                                            <div style="width: 50%;">
                                                <div class="progress">
                                                    <asp:TextBox ID="txtNueva" runat="server" TextMode="Password" oncopy="return false;" oncut="return false;" Style="width: 93% !important;" ClientIDMode="Static" requerido="btnAceptar"></asp:TextBox>
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
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <l>Confirmar Contraseña</l>
                                        </th>
                                        <td>
                                            <div style="width: 50%;">
                                                <asp:TextBox ID="txtConfirmar" runat="server" TextMode="Password" oncopy="return false;" oncut="return false;" Style="width: 93% !important;" ClientIDMode="Static" requerido="btnAceptar"></asp:TextBox>
                                                <div class="po-markup">
                                                    <a href="#" class="po-link">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/icons/ColorX24/Info.png" />
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
                                            <asp:Label ID="mgsSugerencia" runat="server" ClientIDMode="Static" Style="display: inline-block; width: 100%; text-align: left; font-size: 12px;" EnableViewState="false"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="right">
                                            <br />
                                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" EnableViewState="false" ClientIDMode="Static" OnClientClick="return CheckReq();" />
                                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" EnableViewState="false" />
                                            <asp:Button ID="btnVerTutorial2" runat="server" Text="Ver Tutorial" CssClass="Image-Assistant" OnClick="btnVerTutorial_Click" EnableViewState="false" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnAceptar" />
                            <asp:PostBackTrigger ControlID="btnCancelar" />
                            <asp:PostBackTrigger ControlID="btnCalcularHomo" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <asp:AlanModalPopUp runat="server" ID="mdlTutorial" HeaderText="Tutorial de Registro" ModalSize="medium">

            <ContentTemplate>
                <div id="myCarousel" class="carousel slide" data-ride="false">
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                        <li data-target="#myCarousel" data-slide-to="3"></li>
                        <li data-target="#myCarousel" data-slide-to="4"></li>
                    </ol>

                    <div class="carousel-inner">
                        <div class="item active">
                            <img src="../Images/TutorialRegistro/01.PNG" />
                        </div>


                        <div class="item">
                            <img src="../Images/TutorialRegistro/02.PNG" />
                        </div>

                        <div class="item">
                            <img src="../Images/TutorialRegistro/03.PNG" />
                        </div>

                        <div class="item">
                            <img src="../Images/TutorialRegistro/04.PNG" />
                        </div>

                        <div class="item">
                            <img src="../Images/TutorialRegistro/05.PNG" />
                        </div>
                    </div>

                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#myCarousel" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
                <div class="center total-width">
                    <asp:Button ID="btnCerrarModal" runat="server" Text="Cerrar el Tutorial de Registro" OnClick="btnCerrarModal_Click" />
                </div>
            </ContentTemplate>
        </asp:AlanModalPopUp>
    </form>
</body>
</html>

<script type="text/javascript">
    //$(document).ready(function () {
    //    req();
    //});

    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(
        function () {
            req();
            showMessageBox();
            AlertSucccessFading();
            avoidCharacters();
        });

</script>
