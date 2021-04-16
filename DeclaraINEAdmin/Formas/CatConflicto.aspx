<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/Site.Master" AutoEventWireup="true" CodeBehind="CatConflicto.aspx.cs" Inherits="DeclaraINEAdmin.Formas.CatConflicto" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="body-content">
        <div class="filtro-header">
            Catalogo de Conflicto
        </div>
        <nav class="filtro center">
            <asp:Button ID="btnAgregarRubro" runat="server" Text="Agregar Nuevo Rubro" OnClick="btnAgregarRubro_Click" ClientIDMode="Static" />
        </nav>

        <asp:UpdatePanel ID="pnlGridRubros" runat="server" UpdateMode="Conditional" class="filtro" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:AlanAlert runat="server" ID="AlertaRubros" />
                <asp:GridView ID="gridRubros" runat="server" AutoGenerateColumns="false" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
                    <Columns>
                        <asp:TemplateField HeaderText="Rubro" ItemStyle-Width="67%">
                            <ItemTemplate>
                                <asp:Literal runat="server" ID="ltrRubro" Text='<%#Eval("V_RUBRO") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Año Inicial">
                            <ItemTemplate>
                                <asp:Literal runat="server" ID="ltrFechaInicial" Text='<%#Eval("C_INICIO","{0:yyyy}") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Final">
                            <ItemTemplate>
                                <asp:Literal ID="ltrFechaFinal" runat="server" Text='<%#Eval("C_FIN","{0:yyyy}") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:Button ID="btnEditarRubro" runat="server" OnClick="btnEditarRubro_Click" Text="" CommandArgument='<%#Eval("NID_RUBRO")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Preguntas">
                            <ItemTemplate>
                                <asp:Button ID="btnEditarRubroPregunta" runat="server" OnClick="btnEditarRubroPregunta_Click" Text="" CommandArgument='<%#Eval("NID_RUBRO")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <asp:AlanModalPopUp runat="server" ID="appAgregarRubro">
        <ContentTemplate>
            <asp:AlanAlert runat="server" ID="AlertaRubro" />
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>
                             Rubro
                            </l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtVRubro" runat="server" CssClass=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                             Fecha Inicial
                            </l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtFInicialNewRubro" runat="server" TextMode="Number" MaxLength="4"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                              Fecha Final
                            </l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtFFinalNewRubro" runat="server" TextMode="Number" MaxLength="4"></asp:TextBox>
                        </td>
                    </tr>

                </tbody>
            </table>
            <div class="right">
                <asp:Button ID="btnCerrarAgregarRubro" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarAgregarRubro_Click" />
                <asp:Button ID="btnGuardarRubro" Visible="false" runat="server" Text="Guardar" OnClick="btnGuardarRubro_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
                <asp:Button ID="btnGuardarRubroUpdate" Visible="false" runat="server" Text="Actualizar" OnClick="btnGuardarRubroUpdate_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="appAgregarRubroPregunta">
        <ContentTemplate>
            <asp:AlanAlert runat="server" ID="AlertaRubroPregunta" />
            <div>
                <asp:Label ID="ltrSinOpciones" Visible="false" Text="Sin opciones ingresadas..." runat="server"></asp:Label>
                <asp:GridView Visible="false" ID="gridRubroPregunta" runat="server" OnRowDataBound="gridRubroPregunta_RowDataBound" AutoGenerateColumns="false" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
                    <Columns>
                        <asp:TemplateField HeaderText="Preguntas" ItemStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Literal runat="server" ID="ltrRubro" Text='<%#Eval("V_RUBRO") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Respuestas" ItemStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Literal runat="server" ID="ltrOps" Text='<%#Eval("V_OPCIONES") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Año Inicial">
                            <ItemTemplate>
                                <asp:Literal runat="server" ID="ltrFechaInicial" Text='<%#Eval("C_INICIO","{0:yyyy}") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Final">
                            <ItemTemplate>
                                <asp:Literal ID="ltrFechaFinal" runat="server" Text='<%#Eval("C_FIN","{0:yyyy}") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:Button ID="btnEditarPregunta" runat="server" OnClick="btnEditarPregunta_Click" Text="" CommandArgument='<%#Eval("NID_PREGUNTA")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="right">
                <asp:Button ID="btnCerrarPrgunta" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarPrguntaAgregar_Click" />
                <asp:Button ID="btnAgregarPrgunta" runat="server" Text="Agregar" OnClick="btnAgregarPrgunta_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="appOpcionesPregunta">
        <ContentTemplate>
            <asp:AlanAlert runat="server" ID="AlanAlert1" />
            <asp:Label Text="¿Si cambias de opción, se borran tus opciones ya ingresadas, estas de seguro?" runat="server" />
            <div class="right">
                <asp:Button ID="btnCerrarPregunta" runat="server" ToolTip="" Text="Cancelar" OnClick="btnCerrarPregunta_Click" />
                <asp:Button ID="btnGuardarPregunta" runat="server" Text="Aceptar" OnClick="btnOpcionesPregunta_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>
    <asp:AlanModalPopUp runat="server" ID="appPregunta">
        <ContentTemplate>
            <asp:AlanAlert runat="server" ID="AlertaPregunta" />
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>
                             Pregunta
                            </l>
                        </th>
                        <td>
                            <asp:Label ID="ltrnp" Text="" runat="server" CssClass="invisible"></asp:Label>
                            <asp:TextBox ID="txtPregunta" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="2">
                            <l>¿La pregunta es de opción múltiple?
                            <asp:CheckBox ID="cbPreguntas" runat="server" Text=" " CssClass="onoff" AutoPostBack="true" OnCheckedChanged="cbPreguntas_CheckedChanged" /></l>
                        </th>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel runat="server" ID="pnlPOps" Visible="false" CssClass="left">
                                <br />
                                <asp:GridView ID="grdPreOpciones" runat="server" ShowHeader="false" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Literal ID="txtOpciones" runat="server" Text='<%#Eval("v_respuesta") %>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div class="right">
                                    <asp:Button ID="btnEditarOpcionEditarTMP" Text="Editar opciones" runat="server" OnClick="btnEditarOpcionEditarTMP_Click" />
                                </div>
                                <br />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                             Fecha Inicial
                            </l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtPreguntaFechaInicio" runat="server" TextMode="Number" MaxLength="4" AutoCompleteType="Disabled"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                              Fecha Final
                            </l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtPreguntaFechaFin" runat="server" TextMode="Number" MaxLength="4" AutoCompleteType="Disabled"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="right">
                <asp:Button ID="btnCerrarRubroPregunta" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarRubroPregunta_Click" />
                <asp:Button ID="btnGuardarRubroPregunta" Visible="false" runat="server" Text="Guardar" OnClick="btnGuardarRubroPregunta_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
                <asp:Button ID="btnGuardarRubroPreguntaUpdate" Visible="false" runat="server" Text="Actualizar" OnClick="btnGuardarRubroPreguntaUpdate_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>




    <asp:AlanModalPopUp runat="server" ID="mppRespuestaTMP">
        <ContentTemplate>
            <asp:AlanAlert runat="server" ID="AletaRespuestaTMP" />
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>
                             Opciones
                            </l>
                        </th>
                        <td>
                            <asp:GridView ID="grdPreOpcionesTMP" runat="server" ShowHeader="false" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtOpciones" runat="server" Text='<%#Eval("v_respuesta") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="center">
                <asp:Button ID="btnAgregarOpcionTMP" Text="Agregar opcion" runat="server" OnClick="btnAgregarOpcionTMP_Click" />
            </div>
            <br />
            <div class="right">
                <asp:Button ID="btnCerrarRespuestaTMP" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarRespuestaTMP_Click" />
                <asp:Button ID="btnGuardarRespuestaTMP" runat="server" Text="Guardar" OnClick="btnGuardarRespuestaTMP_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

</asp:Content>
