<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/Site.Master" AutoEventWireup="true" CodeBehind="Puestos.aspx.cs" Inherits="DeclaraINEAdmin.Formas.Puesto" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="ProyectoConsultaGestion" class="nuevapagina">
        <div class="body-content">
            <div class="filtro-header">
                Catalogo de Puestos
            </div>
            <asp:AlanMessageBox runat="server" ID="MsgBox" />

            <nav class="filtro">  

                        <div class="form-group">
                            <div class="col-md-2 filtro-label">
                             No° PUESTO
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtPuesto" runat="server" CssClass="form-control" />
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="col-md-2 filtro-label">
                             Nivel del puesto
                            </div>
                            <div class="col-md-10">
                                  <asp:TextBox ID="txtNivel" runat="server" CssClass="form-control" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-2 filtro-label">
                             Descripcion de Puesto
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtDPuesto" runat="server" CssClass="form-control" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-2 filtro-label">
                            Activo
                            </div>
                            <div class="col-md-10">
                                <asp:DropDownList ID="dpActivo" runat="server" requerido="btnBuscar">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Desactivado" Value="0"></asp:ListItem>
                                </asp:DropDownList>                             
                            </div>
                        </div>
 
                <div class=" filtro-button">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-default btnImage Image-Search" OnClick="btnBuscar_Click" />                    <asp:Button ID="btnAgregarPuesto" runat="server" ToolTip="Agregar Puesto" Text="Agregar Puesto" OnClick="btnNuevoPuesto_Click" />
  
                </div>
            </nav>

            <div id="DivConsultaPuestos" class="filtro" >
                <asp:GridView ID="grdPuestos" runat="server" AutoGenerateColumns="false" CssClass="f table table-condensed table-striped bordeless table-hover">
                    <Columns>

                        <asp:TemplateField HeaderText="No° PUESTO">
                            <ItemTemplate>
                                <asp:Literal ID="ltrVID_PUESTO" runat="server" Text='<%#Eval("VID_PUESTO")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NIVEL">
                            <ItemTemplate>
                                <asp:Literal ID="ltrVID_NIVEL" runat="server" Text='<%#Eval("VID_NIVEL")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PUESTO">
                            <ItemTemplate>
                                <asp:Literal ID="ltrV_PUESTO" runat="server" Text='<%#Eval("V_PUESTO")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Activo">
                            <ItemTemplate>
                                <asp:Button ID="btnPuestoActivo" runat="server" Text="" CommandArgument='<%# Eval("NID_PUESTO") %>' CssClass='<%# Eval("L_ACTIVO") == null ? "btnFalse2" : (!Convert.ToBoolean(Eval("L_ACTIVO")) ? "btnFalse2" : "btnTrue2") %>' OnClick="btnPuestoActivo_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>



            <asp:AlanModalPopUp runat="server" ID="appPuesto" HeaderText="Agregar nuevo puesto">
                <ContentTemplate>
                    <asp:AlanAlert runat="server" ID="AlertaSuperiorPuesto" />
                    <table class="f">
                        <tbody>
                            <tr>
                                <th>
                                    <l>
                            No° PUESTO 
                            </l>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNPuesto" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <l>
                            NIVEL 
                            </l>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNivelNuevo" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <l>
                            PUESTO 
                            </l>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtVPuesto" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <l>
                            Activo 
                            </l>
                                </th>
                                <td>
                                    <asp:CheckBox ID="chPuestoActivo" runat="server" />

                                </td>
                            </tr>
                        </tbody>
                    </table>

                    <div class="right">
                        <asp:Button ID="btnCerrarPuesto" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarPuesto_Click" />
                        <asp:Button ID="btnGuardarPuesto" runat="server" Text="Guardar" OnClick="btnGuardarPuesto_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
                    </div>
                </ContentTemplate>
            </asp:AlanModalPopUp>




        </div>
    </div>
</asp:Content>
