<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionModificacion/_Modificacion.master" AutoEventWireup="true" CodeBehind="ExperienciaLaboral.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionModificacion.ExperienciaLaboral" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionModificacion/ctrlExperienciaLaboral.ascx" TagPrefix="uc1" TagName="ctrlExperienciaLaboral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
     <asp:AlanQuestionBox runat="server" ID="QstSiguiente" NoText="No" YesText="Si" OnYes="QstSiguiente_Yes" OnNo="QstSiguiente_No" YesCssClass="" NoCssClass="" />

    <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si" OnNo="QstBox_No" OnYes="QstBox_Yes" YesCssClass="" NoCssClass="" />
     <asp:AlanMessageBox runat="server" ID="AlanMessageBox1" />

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
                        Agregar
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
