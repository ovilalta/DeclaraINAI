<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaCatalogoPuestos.aspx.cs" Inherits="DeclaraINAI.Formas.Administrador.ConsultaCatalogoPuestos" %>

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
        <div class="card">
            <asp:AlanMessageBox runat="server" ID="msgBox" />
            <div class="row register-info-box" style="background: url('../Images/inai-acerca-slide.jpg');">
                <div>
                    <div class="row align-items-left" style="display: flex;">
                        <div>
                            <img src="../Images/Declarainai.png" style="height: 32px; margin: 10px 12px 0px;" />
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
                            <a href="#menu1" data-toggle="tab">Consulta Catálogo de Puestos</a>
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
                        <%-- Combo para mostrar las Unidades Administrativas --%>
                        <div class="container">
                            <div class="row justify-content-center">
                                <div class="col-md-12 ">
                                    <div class="form-group">
                                        <asp:DropDownList ID="cmbVID_PRIMER_NIVEL" runat="server" OnSelectedIndexChanged="txtVID_PRIMER_NIVEL_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <br />
                        <br />
                        <asp:Button ID="btnDescargar" runat="server" Text="Mostrar Puestos" OnClick="btnDescargar_Click" CssClass="Search" />
                        <%--<asp:Button ID="btnAgregarPuesto" runat="server" Text="Agregar Puestos" OnClick="btnDescargar_Click" CssClass="upload" />--%>
                        <asp:Button ID="btnOpenModal" runat="server" Text="Agregar Puesto" CssClass="upload" OnClientClick="$('#myModal').modal('show'); return false;" />
                        <%--<asp:Button ID="btnOpenModal" runat="server" Text="Agregar Puesto" CssClass="upload" OnClientClick="loadDropdown(); return false;" />--%>


                    </div>

                    <!-- Modal -->
                    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Agregar Nuevo Puesto</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <asp:TextBox ID="txtVidPuesto" runat="server" CssClass="form-control" Placeholder="Clave de Puesto"></asp:TextBox>
                                    <asp:TextBox ID="txtVidNivel" runat="server" CssClass="form-control" Placeholder="Nivel de Puesto"></asp:TextBox>
                                    <asp:TextBox ID="txtVPuesto" runat="server" CssClass="form-control" Placeholder="Descripción del Puesto"></asp:TextBox>
                                    <div class="form-group">
                                        <label>Estado:</label><br />
                                        <asp:RadioButton ID="rbActivo" runat="server" GroupName="Estado" Text="Declaración Completa" CssClass="form-check-input" />
                                        <asp:RadioButton ID="rbInactivo" runat="server" GroupName="Estado" Text="Declaración Parcial" CssClass="form-check-input" />
                                    </div>
                                    <%--<div class="form-group">
                                        <label>Unidad Administrativa:</label>
                                        <asp:DropDownList ID="CatalogoUas" runat="server" OnSelectedIndexChanged="txtVID_PRIMER_NIVEL_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                    </div>--%>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnSave" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- Fin de la modal --%>
                    <div id="cuerpo" style="padding: 10px 20px 20px 20px;">
                        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:GridView ID="grdDP" runat="server" AutoGenerateColumns="false" CssClass="table table-condensed table-striped bordeless table-hover" OnRowDataBound="grdDP_RowDataBound" OnSelectedIndexChanged="grdDP_SelectedIndexChanged">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id Puesto" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrIdPuesto" runat="server" Text='<%# Eval("NID_PUESTO") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Clave de Puesto">
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrClavePuesto" runat="server" Text='<%# Eval("VID_PUESTO") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nivel del Puesto">
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrNivelPuesto" runat="server" Text='<%# Eval("VID_NIVEL") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Descripción del Puesto">
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrDescPuesto" runat="server" Text='<%# Eval("V_PUESTO") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre UA">
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrNombreUA" runat="server" Text='<%# Eval("NOMBRE_UA") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Dec Completa">
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltrObligado" runat="server" Text='<%# Eval("L_OBLIGADO") %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>

<%--<script type="text/javascript">
    function loadDropdown() {
        $.ajax({
            type: "POST",
            url: "ConsultaCatalogoPuestos.aspx/LoadDropdown",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            xhrFields: {
                withCredentials: true
            },
            success: function (response) {
                var ddl = $("#<%= CatalogoUas.ClientID %>");
                ddl.empty();
                $.each(response.d, function () {
                    ddl.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
                // Abrir la modal después de cargar el dropdown
                $('#myModal').modal('show');
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
</script>--%>




