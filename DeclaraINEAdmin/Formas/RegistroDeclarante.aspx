<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/Site.Master" AutoEventWireup="true" CodeBehind="RegistroDeclarante.aspx.cs" Inherits="DeclaraINEAdmin.Formas.RegistroDeclarante" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <%-- <div class="body-content">--%>
        <div class="modal-dialog total-width">
            <div class="modal-content">
                <div class="modal-header default info">
                    <h3 class="modal-title">Registro del Declarante  </h3>
                </div>
                <div class="modal-body">
                    <asp:AlanMessageBox runat="server" ID="MsgBox" />

                    <div class="input-group forma-group">
                        <label for="disabledTextInput" class="input-group-addon forma-etiqueta">Nombre(s) </label>
                        <asp:TextBox ID="txtNombre" runat="server" AutoCompleteType="Disabled" requerido="btnAceptar"></asp:TextBox>
                    </div>
                    <div class="input-group forma-group">
                        <label for="disabledTextInput" class="input-group-addon forma-etiqueta">Primer Apellido</label>
                        <asp:TextBox ID="txtPrimerApellido" runat="server" AutoCompleteType="Disabled" requerido="btnAceptar"></asp:TextBox>
                    </div>
                    <div class="input-group forma-group">
                        <label for="disabledTextInput" class="input-group-addon forma-etiqueta">Segundo Apellido </label>
                        <asp:TextBox ID="txtSegundoApellido" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>

                    <div class="input-group forma-group">
                        <label for="disabledTextInput" class="input-group-addon forma-etiqueta"> Fecha de Nacimiento</label>
                            <asp:TextBox ID="txtFecha" runat="server" AutoCompleteType="Disabled" MaxLength="10" Date="S" requerido="btnAceptar"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="txtFecha_C" TargetControlID="txtFecha" Format="dd/MM/yyyy" />
                    </div>
                    <div class="input-group forma-group">
                        <label for="disabledTextInput" class="input-group-addon forma-etiqueta">R.F.C.</label>
                        <asp:TextBox ID="txtVID_NOMBRE" runat="server" AutoCompleteType="Disabled" MaxLength="4" placeholder="XXXX" requerido="btnAceptar" CssClass="n4"></asp:TextBox>
                        <asp:TextBox ID="txtVID_FECHA" runat="server" AutoCompleteType="Disabled" MaxLength="6" placeholder="000000" requerido="btnAceptar" TextMode="Number" CssClass="n3"></asp:TextBox>
                        <asp:TextBox ID="txtVID_HOMOCLAVE" runat="server" AutoCompleteType="Disabled" MaxLength="3" placeholder="XX0" CssClass="n4"></asp:TextBox>

                    </div>
                    <div class="input-group forma-group">
                        <label for="disabledTextInput" class="input-group-addon forma-etiqueta">Correo Electrónico</label>
                        <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" requerido="btnAceptar"></asp:TextBox>

                    </div>
                    <div class="input-group forma-group">
                        <label for="disabledTextInput" class="input-group-addon forma-etiqueta">Fecha de Ingreso al Instituto</label>
                        <asp:TextBox ID="txtFIngreso" runat="server" AutoCompleteType="Disabled" Date="S" requerido="btnAceptar"></asp:TextBox>
                        <asp:CalendarExtender runat="server" ID="txtFIngreso_C" TargetControlID="txtFIngreso" Format="dd/MM/yyyy" />

                    </div>
          <%--          <div class="input-group forma-group">
                        <label for="disabledTextInput" class="input-group-addon forma-etiqueta">Contraseña</label>
                        <asp:TextBox ID="txtPassword" runat="server" AutoCompleteType="Disabled" TextMode="Password" requerido="btnAceptar"></asp:TextBox>

                    </div>
              --%>
                    <div class="input-group forma-group">
                        <label class="input-group-addon forma-etiqueta">Contraseña</label>
                        <span class="form-control"><b>La Contraseña será igual al R.F.C. Capturado</b></span>
                        <%--<asp:TextBox ID="txtPasswordConfirma" runat="server" AutoCompleteType="Disabled" TextMode="Password" requerido="btnAceptar"></asp:TextBox>--%>
                    </div>


                    <div class="right">
                        <asp:Button ID="btnAceptar" runat="server" Text="Guardar Declarante" OnClick="btnAceptar_Click" EnableViewState="false" ClientIDMode="Static" OnClientClick="return CheckReq();" />
                    </div>

                </div>
            </div>
        </div>
</asp:Content>
