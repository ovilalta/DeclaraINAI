<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionConclusion/_Conclusion.master" AutoEventWireup="true" CodeBehind="Desincorpora.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionConclusion.Desincorpora" Culture="es-MX" UICulture="es-MX" %>
<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
     <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Desincorporar Inmuebles, muebles y Vehículos del Patrimonio" EnableViewState="false"></asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <div id="cuerpo">
    </div>
</asp:Content>
