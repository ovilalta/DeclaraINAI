<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/Site.Master" AutoEventWireup="true" CodeBehind="DeclaracionTestadoConsulta.aspx.cs" Inherits="DeclaraINEAdmin.Formas.DeclaracionTestadoConsulta" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <style>
        .specialTextArea:disabled,
        .specialTextArea {
            background-color: white;
            color: black;
            cursor: text;
        }

            .specialTextArea:disabled::selection,
            .specialTextArea::selection {
                color: orange;
                background-color: black;
                cursor: text;
            }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {

            $('.po-markup > .po-link').popover({
                trigger: 'hover',
                html: true,  // must have if HTML is contained in popover

                // get the title and conent
                title: function () {
                    return $(this).parent().find('.po-title').html();
                },
                content: function () {
                    return $(this).parent().find('.po-body').html();
                },

                container: 'body',
                placement: 'left'

            });
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $('.po-markup > .po-link').popover({
                trigger: 'hover',
                html: true,  // must have if HTML is contained in popover

                // get the title and conent
                title: function () {
                    return $(this).parent().find('.po-title').html();
                },
                content: function () {
                    return $(this).parent().find('.po-body').html();
                },

                container: 'body',
                placement: 'left'

            });
        });

    </script>


    <script type="text/javascript">

        function jsMarcar() {
            var txtarea = document.getElementById("txtE_OBSERVACIONES_MARCADO");
            var start = txtarea.selectionStart;
            var finish = txtarea.selectionEnd;
            var sel = txtarea.value.substring(0, start) + '||';
            sel = sel + txtarea.value.substring(start, finish) + '||';
            sel = sel + txtarea.value.substring(finish, txtarea.value.length);
            txtarea.value = sel;
            return false;
        }

        function jsDesMarcar() {
            var txtarea = document.getElementById("txtE_OBSERVACIONES_MARCADO");
            var cadena = txtarea.value;
            var textoDesmarcado = "";
            var i;
            for (i = 0; i <= cadena.length; i++) {
                if (cadena[i] != "|") {
                    if (cadena[i] != null)
                        textoDesmarcado = textoDesmarcado + cadena[i];
                }

            }
            txtarea.value = textoDesmarcado;
            return false;
        }

        $(document).keydown(function (e) {
            if (e.keyCode == 77 && e.altKey) {
                jsMarcar();
            }
        });

    </script>

  
        <div class="filtro-header">
            Testado de Declaraciones
        </div>

        <asp:UpdatePanel ID="pnlFiltros" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <nav class="filtro">
                    <div class="filtro-checks">
                        <asp:CheckBox ID="cbxFiltroRFC" AutoPostBack="True" Text="RFC" runat="server" CssClass="checkbox-success checkbox-inline " OnCheckedChanged="cbxFiltroRFC_CheckedChanged" />&nbsp;&nbsp;
                            <asp:CheckBox ID="cbxFiltroNombre" AutoPostBack="True" Text="Nombre" runat="server" CssClass="checkbox-success checkbox-inline " OnCheckedChanged="cbxFiltroNombre_CheckedChanged" />&nbsp;&nbsp;
                            <asp:CheckBox ID="cbxFiltroTipoDeclaracion" AutoPostBack="True" Text="Tipo de Declaración" runat="server" CssClass="checkbox-success checkbox-inline " OnCheckedChanged="cbxFiltroTipoDeclaracion_CheckedChanged" />&nbsp;&nbsp;
                            <asp:CheckBox ID="cbxFiltroMes" AutoPostBack="True" Text="Mes" runat="server" CssClass="checkbox-success checkbox-inline" OnCheckedChanged="cbxFiltroMes_CheckedChanged" />&nbsp;&nbsp;
                            <asp:CheckBox ID="cbxFiltroEstadoTestado" AutoPostBack="True" Text="Estado del Testado" runat="server" CssClass="checkbox-success checkbox-inline" Checked="true" OnCheckedChanged="cbxFiltroEstadoTestado_CheckedChanged" />&nbsp;&nbsp;
                            <asp:CheckBox ID="cbxFiltroAutoriza" AutoPostBack="True" Text="Autoriza su publicación" runat="server" CssClass="checkbox-success checkbox-inline" Checked="true" OnCheckedChanged="cbxFiltroAutoriza_CheckedChanged" />&nbsp;&nbsp;
                    </div>

                    <asp:Panel ID="pnlFiltroRFC" runat="server" Visible="false">
                        <div class="form-group">
                            <div class="col-md-2 filtro-label">
                                RFC
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtRFC" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="pnlFiltroNombre" runat="server" Visible="false">
                        <div class="form-group">
                            <div class="col-md-2 filtro-label">
                                Nombre
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </asp:Panel>


                    <asp:Panel ID="pnlFiltroTipo" runat="server" Visible="false">
                        <div class="form-group">
                            <div class="col-md-2 filtro-label">
                                Tipo de Declaración
                            </div>
                            <div class="col-md-10 checkboxlistFiltro">
                                <asp:CheckBoxList ID="cblTipoDeclaracion" runat="server" RepeatDirection="Horizontal" CssClass="form-control"></asp:CheckBoxList>
                            </div>
                        </div>
                    </asp:Panel>


                    <asp:Panel ID="pnlFiltroMes" runat="server" Visible="false">
                        <div class="form-group">
                            <div class="col-md-2 filtro-label">
                                Mes
                            </div>
                            <div class="col-md-10 checkboxlistFiltro">
                                <asp:CheckBoxList ID="cblMes" runat="server" RepeatDirection="Horizontal" CssClass="form-control"></asp:CheckBoxList>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="pnlFiltroEstadoTestado" runat="server">
                        <div class="form-group">
                            <div class="col-md-2 filtro-label">
                                Estado
                            </div>
                            <div class="col-md-10 checkboxlistFiltro">
                                <asp:CheckBoxList ID="cblEstados" runat="server" RepeatDirection="Horizontal" CssClass="form-control"></asp:CheckBoxList>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="pnlFiltroAutorizaPublicar" runat="server">
                        <div class="form-group">
                            <div class="col-md-2 filtro-label">
                                Autoriza Publicar
                            </div>
                            <div class="col-md-10 ">
                                <asp:CheckBox ID="cbxAutorizaPublicar" Checked="true" Text=" " CssClass="onoff" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>

                    <div class="center filtro-button">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Image-Search" OnClick="btnBuscar_Click" />
                    </div>
                </nav>

            </ContentTemplate>
        </asp:UpdatePanel>


        <asp:AlanAlert runat="server" ID="AlertaBusqueda" />

        <asp:UpdatePanel ID="pnlGridResultados" runat="server" UpdateMode="Conditional" class="filtro" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:GridView ID="grid"
                    runat="server"
                    PagerSettings-Position="TopAndBottom"
                    AllowPaging="true"
                    PageSize="25"
                    OnPageIndexChanging="grd_PageIndexChanging"
                    AutoGenerateColumns="false"
                    CssClass="table table-condensed table-striped table-hover alanGrid-theme"
                    OnRowDataBound="grd_RowDataBound"
                    OnRowCommand="grd_RowCommand"
                    OnSelectedIndexChanged="grd_SelectedIndexChanged">
                    <Columns>

                        <asp:TemplateField HeaderText="Año">
                            <ItemTemplate>
                                <asp:Literal ID="Agno" runat="server" Text='<%# Eval("C_EJERCICIO") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="R.F.C.">
                            <ItemTemplate>
                                <asp:Literal ID="RFC" runat="server" Text='<%#  String.Concat(Eval("VID_NOMBRE"),Eval("VID_FECHA"),Eval("VID_HOMOCLAVE")) %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Literal ID="Nombre" runat="server" Text='<%# String.Concat(Eval("V_PRIMER_A"), " ", Eval("V_SEGUNDO_A")," ",Eval("V_NOMBRE")) %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha de Envio">
                            <ItemTemplate>
                                <asp:Literal ID="F_ENVIO" runat="server" Text='<%#  Convert.ToDateTime(Eval("F_ENVIO")).ToString("dd/MMMM/yyyy") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tipo Declaración">
                            <ItemTemplate>
                                <asp:Image ID="NID_TIPO_DECLARACION" runat="server" Height="24px" Width="24px" />
                                <asp:Literal ID="V_TIPO_DECLARACION" runat="server" Text='<%# Eval("V_TIPO_DECLARACION") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Estado Declaración">
                            <ItemTemplate>
                                <asp:Image ID="NID_ESTADO" runat="server" ImageUrl='<%# String.Concat("~/Images/CAT_ESTADO_DECLARACION/",Eval("NID_ESTADO"),".png") %>' />
                                <asp:Literal ID="V_ESTADO" runat="server" Text='<%# Eval("V_ESTADO") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Pública">
                            <ItemTemplate>
                                <asp:CheckBox ID="L_AUTORIZA_PUBLICAR" Checked='<%# Eval("L_AUTORIZA_PUBLICAR") %>' Text=" " CssClass="onoff" runat="server" Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Estado del Testado">
                            <ItemTemplate>
                                <asp:Image ID="NID_ESTADO_TESTADO" runat="server" ImageUrl='<%# String.Concat("~/Images/CAT_ESTADO_TESTADO/",Eval("NID_ESTADO_TESTADO"),".png") %>' />
                                <asp:Literal ID="V_ESTADO_TESTADO" runat="server" Text='<%#  Eval("V_ESTADO_TESTADO") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <div class="po-markup">
                                    <a href="#" class="po-link">
                                        <asp:Image ID="imgIcono" runat="server" ImageUrl="~/Images/icons/ColorX24/Create%20New.png" /></a>
                                    <div class="po-content hidden">
                                        <div class="po-title center">
                                            Vista rápida de las observaciones 
                                        </div>
                                        <div class="po-body center">
                                            <p>
                                                <asp:Literal ID="ltrPop" runat="server"></asp:Literal>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Panel ID="popTestado" runat="server">
                                    <div class="po-markup">
                                        <a href="#" class="po-link">
                                            <asp:Image ID="imgIcon" runat="server" ImageUrl="~/Images/icons/ColorX24/Barcode.png" /></a>
                                        <div class="po-content hidden">
                                            <div class="po-title center">
                                                Vista rápida del testado 
                                            </div>
                                            <div class="po-body center">
                                                <p>
                                                    <asp:Literal ID="ltrPopTestado" runat="server"></asp:Literal>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Acciones" >
                            <ItemTemplate>
                                <asp:Panel ID="pnlTestar" runat="server">
                                            <asp:Button ID="btnEditar" runat="server" ToolTip="Testar" CommandName="Select" CommandArgument='<%# Container.DataItemIndex %>' />&nbsp;&nbsp;&nbsp;
                                             <asp:Button ID="btnAprobarFinalizar" runat="server" CssClass="Image-Approval_3" ToolTip="Finalizar" CommandName="Finaliza" CommandArgument='<%# Container.DataItemIndex %>' />
                                            <asp:Button ID="btnAprobar" runat="server" CssClass="Image-Approval" ToolTip="Aprobar" CommandName="Aprobar" CommandArgument='<%# Container.DataItemIndex %>' />
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Vista Previa">
                            <ItemTemplate>
                                <asp:Button ID="btnPDFGrid" runat="server" CssClass="Image-PDF" ToolTip="Declaración" CommandName="PDF" CommandArgument='<%# Container.DataItemIndex %>' ClientIDMode="AutoID" />
                                <asp:Button ID="btnPDFTestadoGrid" runat="server" CssClass="Image-PDF" ToolTip="Declaración Testada" CommandName="PDFTestado" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>




    <asp:AlanModalPopUp runat="server" ID="mdlTestar">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPDF" />
            <asp:PostBackTrigger ControlID="brnPDFTestado" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="pnlTestar" runat="server">
                <table class="f">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtE_OBSERVACIONES" runat="server" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtE_OBSERVACIONES_MARCADO" Enabled="false" runat="server" TextMode="MultiLine" CssClass="specialTextArea" ClientIDMode="Static"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtV_OBSERVACIONES_TESTADO" runat="server" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:AlanAlert runat="server" ID="lrtDetalle" />
                <div class="right">
                    <asp:Button ID="btnMarcar" runat="server" Text="Marcar" ToolTip="Marcar" OnClientClick="return jsMarcar();" CssClass="Image-Barcode" />
                    <asp:Button ID="btnDesmarcar" runat="server" Text="Quitar Marcas" ToolTip="Quitar Marcas" OnClientClick="return jsDesMarcar();" CssClass="Image-NoBarcode" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ToolTip="Guardar" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnAprobarFinalizar" runat="server" CssClass="Image-Approval_3" Text="Finalizar" ToolTip="Finalizar" OnClick="btnAprobarFinalizar_Click" />
                    <asp:Button ID="btnAprobar" runat="server" CssClass="Image-Approval" Text="Aprobar" ToolTip="Aprobar" OnClick="btnAprobar_Click" />
                    <asp:Button ID="btnPDF" runat="server" CssClass="Image-PDF" ToolTip="Declaración" CommandName="PDF" Text="Declaración" OnClick="btnPDF_Click" />
                    <asp:Button ID="brnPDFTestado" runat="server" CssClass="Image-PDF" ToolTip="Declaración Testada" CommandName="PDFTestado" Text="Declaración Testada" OnClick="brnPDFTestado_Click" />
                </div>
            </asp:Panel>
            <br />
            <div class="right">
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" ToolTip="Cerrar" OnClick="btnCerrar_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>
</asp:Content>
