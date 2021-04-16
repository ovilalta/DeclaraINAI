<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/Site.Master" AutoEventWireup="true" CodeBehind="Areas.aspx.cs" Inherits="DeclaraINEAdmin.Formas.Areas" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="body-content">
        <div class="filtro-header">
            Unidad Administrativa y Áreas de Adscripción 
        </div>
        <asp:AlanMessageBox runat="server" ID="MsgBox" />
        <nav class="filtro">
            <asp:CheckBox ID="chNUnidad" AutoPostBack="True" Text="N° Unidad" runat="server" />&nbsp;&nbsp;
            <asp:CheckBox ID="chNomUNIDAD" AutoPostBack="True" Text="Nombre de Unidad" runat="server" />&nbsp;&nbsp;
            <asp:CheckBox ID="chFINICIAL" AutoPostBack="True" Text="Año Inicial" runat="server" />&nbsp;&nbsp;
            <asp:CheckBox ID="chFFINAL" AutoPostBack="True" Text="Año Final" runat="server" />
            <asp:AlanAlert runat="server" ID="AlertaBusqueda" />
            <asp:Panel ID="pnlchNUnidad" runat="server" Visible="false">
                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        N° Unidad
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtPD" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlchNomUNIDAD" runat="server" Visible="false">
                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        Nombre de Unidad 
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtPDescription" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlchFINICIAL" runat="server" Visible="false">
                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        Año Inicial
                    </div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="dpAnioIP" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlchFFINAL" runat="server" Visible="false">
                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        Año Final
                    </div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="dpAnioFP" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlSN" runat="server" Visible="false">
                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        Nombre de Área
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtSDescription" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        Año Inicial
                    </div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="dpAnioIS" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        Año Final
                    </div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="dpAnioFS" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </asp:Panel>
            <div class="filtro-button">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-default btnImage Image-Search" OnClick="btnBuscar_Click" />
                <asp:Button ID="btnAgregarUA" Visible="false" runat="server" Text="Agregar Nueva Área" OnClick="btnAgregarUA_Click" ClientIDMode="Static" />
            </div>
        </nav>
        <div class="filtro">
            <asp:GridView ID="grdPrimerNivel" runat="server" AutoGenerateColumns="false" CssClass="f table table-condensed table-striped bordeless table-hover" Visible="true">
                <Columns>
                    <asp:TemplateField HeaderText="N° Unidad">
                        <ItemTemplate>
                            <asp:Literal ID="ltrPVID_PRIMER_NIVEL" runat="server" Text='<%#Eval("VID_PRIMER_NIVEL")%>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre de Unidad">
                        <ItemTemplate>
                            <asp:Literal ID="ltrPV_PRIMER_NIVEL" runat="server" Text='<%#Eval("V_PRIMER_NIVEL")%>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Inicio">
                        <ItemTemplate>
                            <asp:Literal ID="ltrPC_INICIOL" runat="server" Text='<%#Eval("C_INICIO")%>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Fin">
                        <ItemTemplate>
                            <asp:Literal ID="ltrPC_FIN" runat="server" Text='<%#Eval("C_FIN")%>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Editar Unidad Administrativa">
                        <ItemTemplate>
                            <asp:Button ID="btnEditarPN" runat="server" Text="" CommandArgument='<%# Eval("VID_PRIMER_NIVEL")  %>' OnClick="btnEditarPN_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Áreas de Adscripción">
                        <ItemTemplate>
                            <asp:Button ID="btnBuscarAA" runat="server" Text="" CommandArgument='<%# Eval("VID_PRIMER_NIVEL")  %>' OnClick="btnBuscarAA_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <asp:AlanModalPopUp runat="server" ID="appAgregarUA">
        <ContentTemplate>
            <asp:AlanAlert runat="server" ID="AlertaSuperiorUA" />
            <table class="f">
                <tbody>

                    <tr>
                        <th>
                            <l>
                             Numero Unidad
                            </l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtUANumero" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                             Nombre de Unidad de Administrativa
                            </l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtUANombre" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                            Año de Inicio 
                            </l>
                        </th>
                        <td>
                            <asp:DropDownList ID="dpAnioIPE" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                            Año de Fin 
                            </l>
                        </th>
                        <td>
                            <asp:DropDownList ID="dpAnioIFE" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                </tbody>
            </table>

            <div class="right">
                <asp:Button ID="btnCerrarAgregarUA" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarAgregarUA_Click" />
                <asp:Button ID="btnGuardarUA" Visible="false" runat="server" Text="Guardar" OnClick="btnGuardarUA_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
                <asp:Button ID="btnGuardarUA_Update" Visible="false" runat="server" Text="Guardar" OnClick="btnGuardarUA_Update_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="appAgregarAA">

        <ContentTemplate>
            <asp:AlanAlert runat="server" ID="AlertaSuperiorAA" />

            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>
                           N°  Unidad de Administrativa
                            </l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtAAUNumeroUA" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                             Unidad de Administrativa
                            </l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtAAUNombreUA" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                             Nombre del Área de Adscripción  
                            </l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtAANombre" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                            Año de Inicio 
                            </l>
                        </th>
                        <td>
                            <asp:DropDownList ID="txtAAInicio" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                            Año de Fin 
                            </l>
                        </th>
                        <td>
                            <asp:DropDownList ID="txtAAFin" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                </tbody>
            </table>

            <div class="right">
                <asp:Button ID="btnCerrarAgregarAA" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarAgregarAA_Click" />
                <asp:Button ID="btnGuardarAA" runat="server" Visible="false" Text="Guardar" OnClick="btnGuardarAA_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
                <asp:Button ID="btnGuardarAA_Update" runat="server" Visible="false" Text="Guardar" OnClick="btnGuardarAA_Update_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />

            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="appConsultaAA">
        <ContentTemplate>
            <asp:AlanAlert runat="server" ID="AlertaSuperiorConsultaAA" />
            <asp:Panel ID="grdAApnl" runat="server" Visible="false">
                <table class="f">
                    <tbody>
                        <tr>
                            <td>

                                <asp:GridView ID="grdAA" runat="server" AutoGenerateColumns="false" CssClass="f table table-condensed table-striped bordeless table-hover" Visible="true">
                                    <Columns>
                                        <%--                                       <asp:TemplateField HeaderText="Numero de Área de Adscripción">
                                            <ItemTemplate>
                                                <asp:Literal ID="ltrSVID_SEGUNDO_NIVEL" runat="server" Text='<%#Eval("VID_SEGUNDO_NIVEL")%>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Nombre de Área de Adscripción">
                                            <ItemTemplate>
                                                <asp:Literal ID="ltrSV_SEGUNDO_NIVEL" runat="server" Text='<%#Eval("V_SEGUNDO_NIVEL")%>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha Inicio">
                                            <ItemTemplate>
                                                <asp:Literal ID="ltrSC_INICIO" runat="server" Text='<%#Eval("C_INICIO")%>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha Fin">
                                            <ItemTemplate>
                                                <asp:Literal ID="ltrSC_FIN" runat="server" Text='<%#Eval("C_FIN")%>'></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Editar">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditarSN" runat="server" Text="" CommandArgument='<%# Eval("VID_SEGUNDO_NIVEL")  %>' OnClick="btnEditarSN_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                </table>
            </asp:Panel>
            <div class="right">
                <asp:Button ID="btnCerrarConsultaAA" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarConsultaAA_Click" />
                <asp:Button ID="btnAgregarAA" runat="server" Text="Agregar Nueva Área" OnClick="btnAgregarAA_Click" ClientIDMode="Static" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

</asp:Content>
