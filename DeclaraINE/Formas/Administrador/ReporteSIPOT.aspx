<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteSIPOT.aspx.cs" Inherits="DeclaraINE.Formas.Administrador.ReporteSIPOT" %>

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
    <link rel="stylesheet" href="../../css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../css/Declaracion.css" />
    <link rel="stylesheet" href="../../css/style.css" />
    <script src="../../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../../Scripts/Site.js"></script>
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

            td {
                color: black;
                font-weight: normal;
                font-size: small;
                padding: 8px;
            }

            th {
                text-align: center;
                font-size: small;
                padding: 8px;
            }
        </style>
        <div class="card">
            <asp:AlanMessageBox runat="server" ID="msgBox" />
            <div class="row register-info-box" style="background: url('../../Images/ine-acerca-slide.jpg');">
                <div>
                    <div class="row align-items-left" style="display: flex;">
                        <div>
                            <img src="../../Images/Declaraine.png" style="height: 32px; margin: 10px 12px 0px;" />
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
                            <a href="#menu1" data-toggle="tab">Reporte SIPOT</a>
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
                                    <asp:LinkButton ID="lkVolver" runat="server" d-t="Volver al menú principal" OnClick="lkVolver_Click" EnableViewState="false" Text="Volver al menù principal">                       
                        <img src="../../images/icons/ColorX32/Circled%20Left.png"/></asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="subtitulo">
                        <asp:Literal ID="ltrSubTituloAdmin" runat="server"></asp:Literal>
                        <label style="float: left;">Fecha de inicio:</label>
                        <br />
                        <asp:TextBox ID="txtFInicio" runat="server" AutoCompleteType="Disabled" MaxLength="10" Date="S"></asp:TextBox>
                        <br />
                        <asp:CalendarExtender runat="server" ID="txtInicio" TargetControlID="txtFInicio" Format="dd/MM/yyyy" />
                        <br />
                        <br />
                        <label style="float: left;">Fecha de fin:</label>
                        <br />
                        <asp:TextBox ID="txtFFin" runat="server" AutoCompleteType="Disabled" MaxLength="10" Date="S"></asp:TextBox>
                        <br />
                        <asp:CalendarExtender runat="server" ID="txtFin" TargetControlID="txtFFin" Format="dd/MM/yyyy" />
                        <br />
                        <br />
                        <asp:Button ID="brnActualizar" runat="server" Text="Generar reporte" OnClick="btnDescargar_Actualizar" CssClass="xls"/>
                        <div class="bar">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
