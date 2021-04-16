<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionConclusion/_Conclusion.master" AutoEventWireup="true" CodeBehind="ImpuestosYRetenciones.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionConclusion.ImpuestosYRetenciones" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionConclusion/ctrlGastos.ascx" TagPrefix="uc1" TagName="ctrlGastos" %>

<asp:Content ID="moneytxt" ContentPlaceHolderID="ChildContent2" runat="server">
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Impuestos y Retenciones" EnableViewState="false"></asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <div id="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
        <uc1:ctrlGastos runat="server" id="ctrlGastos1" />
        <div class="right">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnAgregar" runat="server" Text="Nuevo" OnClick="btnAgregar_Click" />
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
