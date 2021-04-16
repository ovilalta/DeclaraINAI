<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionInicial/_Inicial.master" AutoEventWireup="true" CodeBehind="ExperienciaLaboral.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionInicial.ExperienciaLaboral" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionInicial/ctrlExperienciaLaboral.ascx" TagPrefix="uc1" TagName="ctrlExperienciaLaboral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server"></asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <div id="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
        <div runat="server" id="grd">
            <div>
                <asp:Button ID="btnAgregarExperienciaLaboral" runat="server" ToolTip="" CssClass="big" Text="" OnClick="btnAgregarExperienciaLaboral_Click" />
                <div class="a">
                    <label>
                        Agregar Experiencia Laboral
                    </label>
                    <br>
                    <se>
                        </se>
                </div>
                <div class="b">
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
    <asp:AlanModalPopUp runat="server" ID="mppExperienciaLaboral" HeaderText="Experiencia Laboral">
        <ContentTemplate>
            <uc1:ctrlExperienciaLaboral runat="server" ID="ctrlExperienciaLaboral" />
            <div class="right">
                <asp:Button ID="btnCerrarModal" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarModal_Click" />
                <asp:Button ID="btnGuardarExperienciaLaboral" runat="server" Text="Guardar" OnClick="btnGuardarExperienciaLaboral_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>
    <asp:AlanAlert runat="server" ID="AlertaInferior" />
</asp:Content>
