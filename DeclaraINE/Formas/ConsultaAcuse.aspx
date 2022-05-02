<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaAcuse.aspx.cs" Inherits="DeclaraINE.Formas.ConsultaAcuse" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>


<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - <%: Declara_V2.BLLD.clsSistema.V_SISTEMA %></title>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link rel="stylesheet" href="../css/Declaracion.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/Site.js"></script>
</head>
<body onload="ComprobarVentana()">
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

        <style>
            div[id*="grd"] > div .a {
                overflow: hidden;
                height: 100px;
                padding-top: 4px;
                text-align: center;
                width: inherit;
                padding-bottom: 110px;
            }

            div[id*="grd"] > div {
                position: relative;
                display: inline-block;
                margin: 8px;
                border: 1px solid #ddd;
                box-shadow: none;
                padding: 6px;
                float: none;
                text-align: center;
                min-width: 290px;
                height: 130px;
            }
        </style>
        <%--        <asp:AlanQuestionBox runat="server" ID="QstBox" OnYes="QstBox_Yes" OnNo="QstBox_No" />--%>
        <%--        <asp:UpdatePanel ID="pnlAcuse" runat="server" >
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnPrevisualizar" />
                <asp:AsyncPostBackTrigger ControlID="btnPrevisualizarDeclaracion" />
            </Triggers>
            <ContentTemplate>--%>

        <div class="alert alert-primary" role="alert">
            <asp:Literal Text=" " ID="msg" runat="server" ClientIDMode="Static" />
        </div>
        <script>
 
            function MensajeAcuseEnvio(state) {
                debugger
                if (state) {
                    $('#lbMensaje').html("Descargando Acuse de Envío, favor de esperar, al finalizar verifique su descarga");
                } else
                    $('#lbMensaje').html();
                return true;
            }
            function MensajeAcuseEnvio(state) {
                    $('#lbMensaje').html("Descargando Acuse de Envío, favor de esperar, al finalizar verifique su descarga");
            }

            function MensajeDeclaracionPresentada(state) {
                    $('#lbMensaje').html("Descargando Declaracion Presentada, favor de esperar, al finalizar verifique su descarga");
   
            }
            
            function MensajeDeclaracionCodigos(state) {
                $('#lbMensaje').html("Descargando Declaración de Aceptación de que se dio cumplimiento al código de Ética, favor de esperar, al finalizar verifique su descarga");

            }

            function MensajeDeclaracionCodigoConducta(state) {
                $('#lbMensaje').html("Descargando Declaración de Aceptación de que se dio cumplimiento al código de Conducta, favor de esperar, al finalizar verifique su descarga");

            }



        </script>

 
        <div class="card">

            <div class="row register-info-box" style="background: url('../Images/ine-acerca-slide.jpg');">
                <div>
                    <div class="row align-items-left" style="display: flex;">
                        <div>
                            <img src="../Images/Declaraine.png" style="height: 32px; margin: 10px 12px 0px;" />
                        </div>
                        <div style="width: 100%;">
                            <h3 style="margin: 7px; font-size: 22px; float: right;">
                                <asp:Label ID="lblIdentificacion" runat="server" Text=" " Font-Size="Small"></asp:Label>
                                <asp:Label ID="lblEjercicio" runat="server" Font-Size="Small" Text=" "></asp:Label>
                            </h3>
                        </div>
                    </div>
                    <div style="height: 60px;">
                        <h2 style="margin-top: 0px; margin-bottom: 0px; margin-left: 15px;">Sistema de Declaración Patrimonial</h2>
                    </div>
                    <ul class="nav nav-tabs menu2020">
                        <li runat="server" enableviewstate="false" id="liDatosGenerales" class="active">
                            <a href="#menu1" data-toggle="tab">Consulta Declaración</a>
                        </li>
                    </ul>
                </div>

            </div>

            <div class="row">
                <div class="col">

                    <div class="tab-content">
                        <div runat="server" enableviewstate="false" class="tab-pane fade level1 active in" id="menu1">
                            <ul class="nav nav-tabs ">
                                <li>
                                    <asp:LinkButton ID="lkVolver" runat="server" d-t="Volver al menù principal" OnClick="lkVolver_Click" EnableViewState="false" Text="Volver al menù principal">                       
                        <img src="./../images/icons/ColorX32/Circled%20Left.png"/></asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                    </div>

                    <div class="subtitulo">
                        <asp:Literal ID="ltrSubTitulo" runat="server"></asp:Literal>
                    </div>
                    <div id="cuerpo">
                        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
                        <div runat="server" id="grd">
                            <div>
                                <asp:Button ID="btnAcuseEnvio" runat="server" CssClass="big" Text="" OnClick="btnAcuseEnvio_Click" OnClientClick="return MensajeAcuseEnvio(true)" />
                                <div class="a">
                                    <label>
                                        Descargar Acuse de Envío
                                    </label>
                                </div>
                            </div>
                            <div>
                                <asp:Button ID="btnAcuseDeclaracion" runat="server" CssClass="big" Text="" OnClick="btnAcuseDeclaracion_Click" OnClientClick="return MensajeDeclaracionPresentada(true)" />
                                <div class="a">
                                    <label>
                                        Descargar Declaracion Presentada
                                    </label>
                                </div>
                            </div>
                            <div style="width: 290px;" runat="server" id="pnlAcuseEtica">
                                <asp:Button ID="btnAcuseEtica" runat="server" CssClass="big" Text="" OnClick="btnAcuseEtica_Click" OnClientClick="return MensajeDeclaracionCodigos(true)" />
                                <div class="a">
                                    <label style="padding: 0px 13px  6px 0px;">
                                        Descarga tu Declaración de Aceptación de que se dió cumplimiento al código de Ética.
                                    </label>
                                </div>
                            </div>
                            <div style="width: 290px;" runat="server" id="pnlAcuseConducta">
                                <asp:Button ID="btnAcuseConducta" runat="server" CssClass="big" Text="" OnClick="btnAcuseConducta_Click" OnClientClick="return MensajeDeclaracionCodigoConducta(true)" />
                                <div class="a">
                                    <label style="padding: 0px 13px  6px 0px;">
                                        Descarga tu Declaración de Aceptación de que se dió cumplimiento al código de Conducta.
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div class="alert alert-primary" role="alert" style="text-align: center; ">
                            <asp:Label ID="lbMensaje" runat="server" Style="font-weight: bold;" />
                        </div>


                    </div>
                </div>
            </div>
        </div>
        <%--            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress AssociatedUpdatePanelID="pnlAcuse" runat="server" >
            <ProgressTemplate>
                <div style="position: fixed; left: 0px; top: 0px; width: 100%; height: 100%; z-index: 9999; opacity: .8; background-color: #ffffff;">
                    <img src="../Images/pageLoader.gif" style="margin: auto; height: 45%; display: flex;" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
    </form>

</body>
</html>
