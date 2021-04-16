﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionConclusion/_Conclusion.master" AutoEventWireup="true" CodeBehind="Adeudos.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionConclusion.Adeudos" Culture="es-MX" UICulture="es-MX" %>


<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionConclusion/Adeudo.ascx" TagPrefix="uc1" TagName="Adeudo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
          <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si"  OnNo="QstBox_No" OnYes="QstBox_Yes" YesCssClass="" NoCssClass=""  />
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="14. Adeudos/Pasivos (situación actual)<br/><h6>Todos los datos de los adeudos/pasivos a nombre de la pareja, dependientes económicos y/o terceros o que sean copropiedad con el declarante no serán públicos<br/>Adeudos del declarante, pareja y/o dependientes económicos"></asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <div id="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
        <div runat="server" id="grd">
            <div>
                <asp:Button ID="btnAgregarAdeudo" runat="server" ToolTip="" CssClass="big" Text="" OnClick="btnAgregarAdeudo_Click" />
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
