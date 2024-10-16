<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionModificacion/_Modificacion.master" AutoEventWireup="true" CodeBehind="OtrosGastos.aspx.cs" Inherits="DeclaraINAI.Formas.DeclaracionModificacion.OtrosGastos" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionModificacion/ctrlGastos.ascx" TagPrefix="uc1" TagName="ctrlGastos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Otros Gastos" EnableViewState="false"></asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <div id="cuerpo">
        <asp:AlanAlert runat="server" ID="Alertota" />
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
        <uc1:ctrlGastos runat="server" ID="ctrlGastos" />
  <%--      <table class="table-striped table-condensed borderless" style="width: 100%;">
              <tr>
                <td style="width:50%;">
                    <asp:TextBox Text="Depositos a Cuentas Bancarias" runat="server" Enabled="false" EnableViewState="false"></asp:TextBox>
                </td>
                 <td>
                     <asp:TextBox ID="moneytxtCuentas" runat="server" Enabled="false" ClientIDMode="Static"></asp:TextBox>
                     <div id="divmoneytxtCuentas"></div>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:TextBox Text="Pagos de Adeudos" runat="server" Enabled="false" EnableViewState="false"></asp:TextBox>
                </td>
                 <td>
                     <asp:TextBox ID="moneytxtAdeudos" runat="server" Enabled="false" ClientIDMode="Static"></asp:TextBox>
                     <div id="divmoneytxtAdeudos"></div>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:TextBox Text="Pagos a Tarjetas de Crédito" runat="server" Enabled="false" EnableViewState="false"></asp:TextBox>
                </td>
                 <td>
                     <asp:TextBox ID="moneytxtTarjetas" runat="server" Enabled="false" ClientIDMode="Static"></asp:TextBox>
                     <div id="divmoneytxtTarjetas"></div>
                </td>
            </tr>
                <tr>
                <td>
                    <asp:TextBox Text="Impuestos y Retenciones" runat="server" Enabled="false" EnableViewState="false"></asp:TextBox>
                </td>
                 <td>
                     <asp:TextBox ID="moneytxtImpuestos" runat="server" Enabled="false" ClientIDMode="Static"></asp:TextBox>
                     <div id="divmoneytxtImpuestos"></div>
                </td>
            </tr>

         
        </table>--%>
        <div class="right">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" Visible="false" />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" Visible="false" />
        </div>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
