<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaApartadosDeclaracion.aspx.cs" Inherits="DeclaraINAI.Formas.Administrador.ConsultaApartadosDeclaracion" %>

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
            .header-center {
                text-align: center !important;
            }

            .header-left {
                text-align: left !important;
            }

            .header-right {
                text-align: right !important;
            }
        </style>
        <div class="card">
            <asp:AlanMessageBox runat="server" ID="msgBox" />
            <div class="row register-info-box" style="background: url('../../Images/inai-acerca-slide.jpg');">
                <div>
                    <div class="row align-items-left" style="display: flex;">
                        <div>
                            <img src="../../Images/Declarainai.png" style="height: 32px; margin: 10px 12px 0px;" />
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
                            <a href="#menu1" data-toggle="tab">Visualizar secciones declaración</a>
                        </li>
                    </ul>
                </div>

            </div>

            <div class="row ">
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
                            <asp:TextBox ID="txtRFC" runat="server" Placeholder="Ingrese el RFC para realizar la búsqueda"></asp:TextBox> 
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnAgregar_Click" />                        
                        <asp:Panel ID="pnlSecciones" runat="server" Visible="false">
                            <div class="row">
                                Secciones de la Declaración de: 
       
                                <asp:Label ID="lblNombre" runat="server"></asp:Label>
                            </div>
                        </asp:Panel>
                        <br />


                        <asp:GridView ID="gvSeccionesData" runat="server"
                            AutoGenerateColumns="False"
                            AutoGenerateEditButton="true" OnRowEditing="gvSeccionesData_RowEditing"
                            OnRowUpdating="gvSeccionesData_RowUpdating" OnRowCancelingEdit="gvSeccionesData_RowCancelingEdit"
                            DataKeyNames="VID_NOMBRE,VID_FECHA,VID_HOMOCLAVE,NID_DECLARACION, NID_APARTADO">
                            <Columns>
                                <asp:BoundField DataField="NID_APARTADO" HeaderText=" Sección " />

                                <asp:TemplateField HeaderText=" Estatus Sección ">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkActivoEdit" runat="server" Checked='<%# Bind("L_ESTADO") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkActivo" runat="server" Enabled="false" Checked='<%# Eval("L_ESTADO") %>' />
                                    </ItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkActivo" runat="server" Enabled="false"
                                            Checked='<%# Eval("L_ESTADO") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Campo1" HeaderText="Campo1" Visible="false" />
                                <asp:BoundField DataField="Campo2" HeaderText="Campo2" Visible="false" />
                                <asp:BoundField DataField="Campo3" HeaderText="Campo3" Visible="false" />
                                <asp:BoundField DataField="Campo4" HeaderText="Campo4" Visible="false" />
                            </Columns>
                        </asp:GridView>

                    </div>

                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

                    <br />
                    <br />

                </div>
            </div>
        </div>

    </form>
    <script type="text/javascript"> 
        $(window).ready(function () {
            $(".loader").fadeOut("slow");
        });
    </script>
</body>
</html>
