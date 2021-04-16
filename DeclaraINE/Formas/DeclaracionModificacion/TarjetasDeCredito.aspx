<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionModificacion/_Modificacion.master" AutoEventWireup="true" CodeBehind="TarjetasDeCredito.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionModificacion.TarjetasDeCredito" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Tarjetas de Crédito" EnableViewState="false"></asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
      <asp:AlanQuestionBox runat="server" ID="Qst" OnYes="Qst_Yes" OnNo="Qst_No"  />
    <div id="cuerpo">

        <asp:AlanAlert runat="server" ID="AlertaSuperior" />

        <%--<asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si" OnNo="QstBox_No" OnYes="QstBox_Yes" YesCssClass="" NoCssClass=""  />--%>

        <div runat="server" id="grd">
            <div>
                <asp:Button ID="btnAgregarTarjeta" runat="server" CssClass="big" Text="" OnClick="btnAgregarTarjeta_Click" />
                <div class="a">
                    <label>
                        Agregar Tarjeta de Crédito
                    </label>
                    <br>
                    <se></se>
                </div>
                <div class="b">
                </div>
            </div>
        </div>
    </div>

    <asp:AlanModalPopUp runat="server" ID="mppTarjeta" HeaderText="Tarjeta de Crédito">
        <ContentTemplate>
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>Institución Finaciera</l>
                        </th>

                        <td>
                            <asp:DropDownList runat="server" requerido="btnGuardar" ID="cmbInstitución"></asp:DropDownList>
                        </td>

                    </tr>
                    <tr>
                        <th>
                            <l>  Número de Cuenta  </l>
                        </th>

                        <td>
                            <asp:TextBox ID="txtE_CUENTA" runat="server" requerido="btnGuardar" MaxLength="16"></asp:TextBox>

                        </td>

                    </tr>
                    <tr>
                        <th>
                            <l>Monto de los pagos <br /> al 31 de diciembre de <asp:Literal ID="C_EJERCICIO" runat="server"></asp:Literal></l>
                        </th>
                        <td>
                            <asp:TextBox ID="moneytxtM_Pagos" requerido="btnGuardar" runat="server" ClientIDMode="Static" AutoCompleteType="None" MaxLength="19"></asp:TextBox>
                            <div id="divmoneytxtM_Pagos"></div>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Saldo a Cargo <br /> al 31 de diciembre de <asp:Literal ID="C_EJERCICIO2" runat="server"></asp:Literal>
                            </l>
                        </th>
                        <td>
                            <asp:TextBox ID="moneytxtM_Gasto" requerido="btnGuardar" runat="server" ClientIDMode="Static" AutoCompleteType="None" MaxLength="19"></asp:TextBox>
                            <div id="divmoneytxtM_Gasto"></div>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Titular(es) de la cuenta</l>
                        </th>
                        <td>

                            <asp:CheckBoxList ID="cblTitulares" runat="server"></asp:CheckBoxList>

                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <div class="right">
                <asp:Button ID="btnCerrarModal" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarModal_Click" />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuarda_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>
    <br />
    <br />
    <br />

</asp:Content>
