<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionConclusion/_Conclusion.master" AutoEventWireup="true" CodeBehind="AdeudosModifica.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionConclusion.AdeudosModifica" Culture="es-MX" UICulture="es-MX" %>


<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionConclusion/Adeudo.ascx" TagPrefix="uc1" TagName="Adeudo" %>
<%@ Register Src="~/Formas/SioNo.ascx" TagPrefix="uc1" TagName="SioNo" %>
<%@ Register Src="~/Formas/DeclaracionConclusion/AdeudoModificacion.ascx" TagPrefix="uc2" TagName="AdeudoModificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si" OnNo="QstBox_No" OnYes="QstBox_Yes" YesCssClass="" NoCssClass="" />
    <asp:AlanMessageBox runat="server" ID="MsgBox" />



    <div class="subtitulo">
        <asp:Literal ID="Literal1" runat="server" Text="Actualización de Adeudos" EnableViewState="false"></asp:Literal>
    </div>
    <div id="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperiorMod" />
        <div runat="server" id="grdMod" />
    </div>

    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Alta de Adeudos"></asp:Literal>
    </div>


    <div class="cuerpo">
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

    <asp:AlanModalPopUp runat="server" ID="mppModificaAdeudo" HeaderText="Actualizar Adeudo">
        <ContentTemplate>
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>¿La cuenta sigue activa? 
                         </l>
                        </th>
                        <td>
                            <uc1:SioNo runat="server" ID="cbx" />
                        </td>
                    </tr>
                    <uc2:AdeudoModificacion runat="server" ID="AdeudoModificacion" />
                    <div class="right">
                        <asp:Button ID="btnCerrarMod" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarMod_Click" />
                        <asp:Button ID="btnGuardarMod" runat="server" Text="Guardar" OnClick="btnGuardaMod_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
                    </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>


    <asp:AlanAlert runat="server" ID="AlertaInferior" />

</asp:Content>
