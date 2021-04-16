<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/Site.Master" AutoEventWireup="true" CodeBehind="CambioContraseña.aspx.cs" Inherits="DeclaraINEAdmin.Formas.CambioContraseña" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="filtro-header">
        Mantenimiento de contraseñas
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:AlanMessageBox runat="server" ID="MsgBox" />
            <asp:AlanQuestionBox runat="server" ID="QstBox"  OnYes="QstBox_Yes" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <nav class="filtro">
        &nbsp;&nbsp;
                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        RFC o Nombre(s): 
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" />
                    </div>
                </div>
        <div class="center filtro-button">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Image-Search" OnClick="btnBuscar_Click" />
        </div>
    </nav>
    <asp:AlanAlert runat="server" ID="AlertaSuperior" />
    <div class="filtro ">
        <asp:GridView ID="grdUsuario" runat="server" AutoGenerateColumns="false" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
            <Columns>
                <asp:TemplateField HeaderText="RFC">
                    <ItemTemplate>
                        <asp:Literal ID="ltrRFC" runat="server" Text='<%# String.Format("{0}{1}{2}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE")) %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Literal ID="ltrV_NOMBRE" runat="server" Text='<%#Eval("V_NOMBRE")%>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Primer Apellido">
                    <ItemTemplate>
                        <asp:Literal ID="ltrV_PRIMER_A" runat="server" Text='<%#Eval("V_PRIMER_A")%>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Segundo Apellido">
                    <ItemTemplate>
                        <asp:Literal ID="ltrV_SEGUNDO_A" runat="server" Text='<%#Eval("V_SEGUNDO_A")%>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Enviar Correo Electrónico">
                    <ItemTemplate>
                        <asp:Button ID="btnEditarEnviarContraseña" runat="server" Text="Enviar Correo" CommandArgument='<%# String.Format("{0}{1}{2}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE"))  %>' CssClass="Image-Email" OnClick="btnEditarEnviarContraseña_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Restablecer Contraseña">
                    <ItemTemplate>
                        <asp:Button ID="btnEditarRestablecerContraseña" runat="server" Text="Reestablecer" CommandArgument='<%# String.Format("{0}{1}{2}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE"))  %>' OnClick="btnRestablecerContraseña_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Modificar Contraseña">
                    <ItemTemplate>
                        <asp:Button ID="btnCancelar" runat="server" Text="Modificar" CommandArgument='<%# String.Format("{0}{1}{2}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE"))  %>' OnClick="btnCambiarContraseña_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Usuario Activo">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbxActivo" runat="server" Text=" " Enabled="false" CssClass="onoff3" Checked='<%# Convert.ToBoolean(Eval("L_ACTIVO")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Detalle">
                    <ItemTemplate>

                        <asp:Button ID="btnEditarActivarUsuario" runat="server" Text="Detalle" CommandArgument='<%# String.Format("{0}{1}{2}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE"))  %>' CssClass="Image-OpenFolder" OnClick="btnActivarUsuario_Click" />

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <asp:AlanModalPopUp runat="server" ID="mppCambioContraseña" HeaderText="Solicitud de Cambio de Contraseña">
        <ContentTemplate>
            <asp:AlanAlert runat="server" ID="AlertaSuperiorSolicitud" />
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>
                            Nombre 
                            </l>
                        </th>
                        <td>
                            <asp:Literal ID="ltrNombreCompreto" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                            RFC 
                            </l>
                        </th>
                        <td>
                            <asp:Literal ID="ltrRfc" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="center">
                <hr style="width: 75%;">
                <th>Escribe la Nueva contraseña</th>
                <table class="f">
                    <tbody>

                        <tr>
                            <th>
                                <l>
                            Nueva Contraseña 
                                </l>
                            </th>
                            <td>
                                <asp:TextBox ID="txtNueva" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:Button ID="btnGuardarContraseña" runat="server" Text="Guardar" OnClick="btnGuardarContraseña_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
            </div>
            <div class="right">
                <asp:Button ID="btnCerrarContraseña" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarContraseña_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="mppCorreos" HeaderText="Detalles del Acceso">
        <ContentTemplate>
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>
                           Activo
                            </l>
                        </th>
                        <td>
                            <asp:CheckBox ID="cbxlActivo" runat="server" Text=" " Enabled="false" CssClass="onoff3" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                            Fecha de Ingreso al Instituto 
                            </l>
                        </th>
                        <td>
                            <asp:Literal ID="ltrIngresoInstituto" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                            Fecha de Registro
                            </l>
                        </th>
                        <td>
                            <asp:Literal ID="ltrRegistro" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>

            <asp:GridView ID="grdCorreos" runat="server" AutoGenerateColumns="false" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
                <Columns>
                    <asp:TemplateField HeaderText="Correo">
                        <ItemTemplate>
                            <asp:Literal ID="lrtCorreo" runat="server" Text='<%# Eval("V_CORREO")  %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Activo">
                        <ItemTemplate>
                            <asp:CheckBox ID="cbxActivo" runat="server" Text=" " Enabled="false" CssClass="onoff3" Checked='<%# Convert.ToBoolean(Eval("L_ACTIVO")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Confirmado">
                        <ItemTemplate>
                            <asp:CheckBox ID="cbxConfirmado" runat="server" Text=" " Enabled="false" CssClass="onoff3" Checked='<%# Convert.ToBoolean(Eval("L_CONFIRMADO")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnAceptarConfirmar" runat="server" Text="" CommandName="Select" CommandArgument='<%# Eval("V_CORREO")  %>' OnClick="btnAceptarConfirmar_Click" Enabled='<%# !Convert.ToBoolean(Eval("L_CONFIRMADO")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" runat="server" Text="" CommandName="Delete" CommandArgument='<%# Eval("V_CORREO")  %>' OnClick="btnEliminar_Click"  />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            <div class="right">
                <asp:Button ID="btnAgregarCorreo" runat="server" Text="Agregar Correo" OnClick="btnAgregarCorreo_Click" />
                <asp:Button ID="btnReenviarComprobacion" runat="server" Text="Activar Usuario" OnClick="btnReenviarComprobacion_Click" />
                <asp:Button ID="btnDesactivar" runat="server" Text="Desactivar Usuario" CssClass="Image-Shutdown" OnClick="btnDesactivar_Click" />
                <asp:Button ID="btnCerrarConsulta" runat="server" Text="Cerrar" OnClick="btnCerrarConsulta_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="mppNuevoCorreo" HeaderText="Detalles del Acceso">
        <ContentTemplate>
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>
                           Correo Electrónico
                            </l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtNuevoCorreo" runat="server" TextMode="Email"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="right">
                <asp:Button ID="btnGuardarNuevoCorreo" runat="server" Text="Guardar" OnClick="btnGuardarNuevoCorreo_Click" />
                <asp:Button ID="btnCerrarNuevoCorreo" runat="server" Text="Cerrar" OnClick="btnCerrarNuevoCorreo_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

</asp:Content>
