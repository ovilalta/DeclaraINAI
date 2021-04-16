<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionInicial/_Inicial.master" AutoEventWireup="true" CodeBehind="Adeudos.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionInicial.Adeudos" Culture="es-MX" UICulture="es-MX" %>


<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionInicial/Adeudo.ascx" TagPrefix="uc1" TagName="Adeudo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
          <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si"  OnNo="QstBox_No" OnYes="QstBox_Yes" YesCssClass="" NoCssClass=""  />
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Adeudos"></asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <div id="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
        <div runat="server" id="grd">
            <div>
                <asp:Button ID="btnAgregarAdeudo" runat="server" ToolTip="" CssClass="big" Text="" OnClick="btnAgregarAdeudo_Click" />
                <div class="a">
                    <label>
                        Agregar Adeudo
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
    <asp:AlanModalPopUp runat="server" ID="mppAdeudo" HeaderText="Adeudos">
        <ContentTemplate>
            <uc1:Adeudo runat="server" ID="Adeudo" />
            <div class="right">
                <asp:Button ID="btnCerrarModal" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarModal_Click" />
                <asp:Button ID="btnGuardarAdeudo" runat="server" Text="Guardar" OnClick="btnGuarda_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>
    <asp:AlanAlert runat="server" ID="AlertaInferior" />

</asp:Content>
