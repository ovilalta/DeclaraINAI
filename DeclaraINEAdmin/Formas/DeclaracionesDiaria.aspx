<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/Site.Master" AutoEventWireup="true" CodeBehind="DeclaracionesDiaria.aspx.cs" Inherits="DeclaraINEAdmin.Formas.DeclaracionesDiaria" Culture="es-Mx" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


        <div class="filtro-header">
            Consulta de Declaraciones Diarias
        </div>

        <asp:AlanMessageBox runat="server" ID="MsgBox" />

        <asp:UpdatePanel ID="pnlFiltros" runat="server" UpdateMode="Conditional" class="filtro">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnExcel" />
            </Triggers>
            <ContentTemplate>
                <div class="filtro-checks">
                    <asp:CheckBox ID="cbxFiltroFecha" Text="Fecha de Envio" runat="server" CssClass="checkbox-success checkbox-inline" Checked="true" Enabled="false" />&nbsp;&nbsp;
                    <asp:CheckBox ID="cbxFiltroTipoDeclaracion" AutoPostBack="True" Text="Tipo de Declaración" runat="server" CssClass="checkbox-success checkbox-inline " Checked="true" OnCheckedChanged="cbxFiltroTipoDeclaracion_CheckedChanged"  />&nbsp;&nbsp;
                </div>

                <asp:Panel ID="pnlFiltro" runat="server" class="form-group">
                    <div class="col-md-2 filtro-label">
                        Fecha de Envìo
                    </div>
                    <asp:UpdatePanel ID="pnlFecha" runat="server" UpdateMode="Conditional" class="col-md-10">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFInicial" runat="server" CssClass="n3" placeholder="Fecha Inicial" AutoCompleteType="Disabled" />
                            <asp:CalendarExtender runat="server" TargetControlID="txtFInicial" ID="txtFInicialCalendar" />
                            <asp:TextBox ID="txtFFinal" runat="server" CssClass="n3" AutoCompleteType="Disabled" />
                            <asp:CalendarExtender runat="server" TargetControlID="txtFFinal" ID="txtFFinalCalendar" />
                            <asp:Button ID="btnDiaMenos" runat="server" ToolTip="Un dia atras" CssClass="btnImage-Discrete-Notext Image-Left" OnClick="btnDiaMenos_Click" />
                            <asp:Button ID="btnDiaMas" runat="server" ToolTip="Un dia delante" CssClass="btnImage-Discrete-Notext Image-Right" OnClick="btnDiaMas_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>

                  <asp:Panel ID="pnlFiltroTipo" runat="server" >
                        <div class="form-group">
                            <div class="col-md-2 filtro-label">
                                Tipo de Declaración
                            </div>
                            <div class="col-md-10 checkboxlistFiltro">
                                <asp:CheckBoxList ID="cblTipoDeclaracion" runat="server" RepeatDirection="Horizontal" CssClass="form-control"></asp:CheckBoxList>
                            </div>
                        </div>
                    </asp:Panel>

                <div class="center filtro-button">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Image-Search" OnClick="btnBuscar_Click" EnableViewState="false" />
                </div>

                <asp:Panel ID="pnlExcel" runat="server" CssClass="center" >
                    <asp:Button ID="btnExcel" runat="server" Text="Exportar" CssClass="Image-MicrosoftExcel" OnClick="btnExcel_Click" EnableViewState="false" />
                </asp:Panel>

            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="pnlAlerta" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:AlanAlert runat="server" ID="AlertaBusqueda" />
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="pnlGrid" runat="server" UpdateMode="Conditional" class="filtro">
            <ContentTemplate>
                <asp:GridView ID="grdDeclaracionesDiarias" runat="server" AutoGenerateColumns="false" CssClass="table table-condensed table-striped table-hover alanGrid-theme" AllowPaging="true" PageSize="35" OnPageIndexChanging="grdDeclaracionesDiarias_PageIndexChanging" PagerSettings-Position="TopAndBottom">
                    <Columns>

                        <asp:TemplateField HeaderText="Ejercicio">
                            <ItemTemplate>
                                <asp:Literal ID="ltrC_EJERCICIO" runat="server" Text='<%#Eval("C_EJERCICIO")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tipo de Declaración">
                            <ItemTemplate>
                                <asp:Image ID="imgNID_TIPO_DECLARACION" runat="server" />
                                <asp:Literal ID="ltrV_TIPO_DECLARACION" runat="server" Text='<%#Eval("V_TIPO_DECLARACION")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha de Inicio o Conclusión">
                            <ItemTemplate>
                                <asp:Literal ID="ltrF_POSESION" runat="server" Text='<%#Eval("F_POSESION","{0:dd/MM/yyyy}")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha y Hora de Envio">
                            <ItemTemplate>
                                <asp:Literal ID="ltrF_ENVIO" runat="server" Text='<%#Eval("F_ENVIO","{0:dd/MM/yyyy HH:mm:ss}")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:Image ID="imgNID_ESTADO" runat="server" ImageUrl='<%# String.Concat("~/Images/CAT_ESTADO_DECLARACION/",Eval("NID_ESTADO"),".png") %>' />
                                <asp:Literal ID="ltrV_ESTADO" runat="server" Text='<%#Eval("V_ESTADO")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha de Registro">
                            <ItemTemplate>
                                <asp:Literal ID="ltrF_REGISTRO" runat="server" Text='<%#Eval("F_REGISTRO","{0:dd/MM/yyyy}")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Literal ID="ltrNombreCompreto" runat="server" Text='<%# String.Format("{0} {1} {2}", Eval("V_PRIMER_A"), Eval("V_SEGUNDO_A"), Eval("V_NOMBRE")) %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="R.F.C.">
                            <ItemTemplate>
                                <asp:Literal ID="ltrRFC" runat="server" Text='<%# String.Format("{0}{1}{2}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE")) %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Unidad Administrativa">
                            <ItemTemplate>
                                <asp:Literal ID="ltrV_PRIMER_NIVEL" runat="server" Text='<%#Eval("V_PRIMER_NIVEL")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Área de Adscripción">
                            <ItemTemplate>
                                <asp:Literal ID="ltrV_SEGUNDO_NIVEL" runat="server" Text='<%#Eval("V_SEGUNDO_NIVEL")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cargo">
                            <ItemTemplate>
                                <asp:Literal ID="ltrV_PUESTO" runat="server" Text='<%#Eval("V_PUESTO")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nivel">
                            <ItemTemplate>
                                <asp:Literal ID="ltrVID_NIVEL" runat="server" Text='<%#Eval("VID_NIVEL")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Pública">
                            <ItemTemplate>
                                <asp:CheckBox ID="L_AUTORIZA_PUBLICAR" Checked='<%# Eval("L_AUTORIZA_PUBLICAR") %>' Text=" " CssClass="onoff3" runat="server" Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>


</asp:Content>
