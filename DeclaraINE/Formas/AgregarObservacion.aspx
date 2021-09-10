<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarObservacion.aspx.cs" Inherits="DeclaraINE.Formas.AgregarObservacion" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>DeclaraINAI</title>
    <asp:PlaceHolder runat="server"></asp:PlaceHolder>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-eOJMYsd53ii+scO/bJGFsiCZc+5NDVN2yr8+0RDqr0Ql0h+rP48ckxlpbzKgwra6" crossorigin="anonymous">
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <script src="../Scripts/AlanWebControls.js"></script>
    <script src="../Scripts/Site.js"></script>
    <script src="../Scripts/jquery-3.1.1.js"></script>
    <%--<webopt:BundleReference runat="server" Path="~/Content/css" />--%>

    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link rel="stylesheet" href="../css/Declaracion.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/AlanWebControls.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <%--<link href="/../../Content/login.css" rel="stylesheet" />--%>
    <script src="../Scripts/Site.js"></script>

    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link rel="stylesheet" href="../css/registro.css" />
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
</head>

<body>




    <%-- Codigo encabezado donde aparece la imagen de DeclaraINAI --%>
    <div class="row register-info-box" style="background: url('../../Images/ine-acerca-slide.jpg');">
        <%--<div>--%>
        <div class="row align-items-left" style="display: flex;">
            <div>
                <img src="../../Images/Declaraine.png" style="height: 80px; margin: 10px 4px 10px 40px;" />
            </div>
            <div style="width: 100%;">
            </div>
        </div>
        <%--</div>--%>
    </div>




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
        <asp:AlanMessageBox runat="server" ID="msgBox" />
        <div class="container">


            <br />



            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>Aclaraciones/Observaciones</l>
                        </th>
                        <td>

                            <asp:TextBox ID="txtObservaciones" runat="server" onkeyDown="nombrecampo('txtObservaciones',this,'4000')"
                                onkeyup="nombrecampo('txtObservaciones',this,'4000')" MaxLength="4000" TextMode="MultiLine" Width="100%"></asp:TextBox>

                        </td>
                    </tr>

                </tbody>


            </table>

                <tr>
                    <td>
                        <asp:FileUpload ID="SubirArchivoAclara" runat="server" Width="400px" Height="50px" accept=".pdf, .doc, .docx"
                            onchange="previewPDF()" />
                    </td>
                    <td  >
                        <i id="IconoPDF" runat="server" >
                        <img  src="../Images/icons/ColorX24/PDF.png"  />Archivo Cargado</i>
                    </td>

                </tr>
            </div>


            <div class="row">
                <div class="col-md-3">
                </div>
                <div class="col-md-6" align="center">
                    <asp:Button Text="Guardar" ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" CssClass="save" Width="150" />
                    <asp:Button Text="Regresar" ID="btnAtras" runat="server" OnClick="btnAtras_Click" CssClass="Image-Restart" Width="150" />
                </div>
                <div class="col-md-3">
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-4" align="center">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#009933" Font-Size="X-Large"></asp:Label>
                </div>
                <div class="col-md-4">
                </div>
            </div>


        </div>


    </form>





</body>
</html>
