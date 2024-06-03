<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionConflicto/_Conflicto.master" AutoEventWireup="true" CodeBehind="Envio.aspx.cs" Inherits="DeclaraINAI.Formas.DeclaracionConflicto.Envio" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Src="~/Formas/SioNo.ascx" TagPrefix="uc1" TagName="SioNo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Enviar la Declaración Patrimonial de Conflicto" EnableViewState="false">
        </asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <asp:AlanQuestionBox runat="server" ID="QstBoxEnviar" OnYes="QstBoxEnviar_Yes" OnNo="QstBoxEnviar_No" />
    <asp:AlanQuestionBox runat="server" ID="QstBoxVistaPDF" OnYes="QstBoxVistaPDF_Yes" OnNo="QstBoxVistaPDF_No" />
    <asp:AlanQuestionBox runat="server" ID="QstBox" OnYes="QstBox_Yes" OnNo="QstBox_No" />
    <div id="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
        <table class="f" style="display: none;">
            <tbody>
                <tr>
                    <th>
                        <l>¿Autoriza hacer pública su declaración patrimonial?</l>

                    </th>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:CheckBox Text=" " runat="server" ID="SiNo" CssClass="onoff" AutoPostBack="true" OnCheckedChanged="SiNo_CheckedChanged" Enabled="false"></asp:CheckBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </tbody>
        </table>
        <div runat="server" id="grd">
            <div>
                <asp:Button ID="btnPrevisualizar" runat="server" CssClass="big" Text="" OnClick="btnPrevisualizar_Click" />
                <div class="a">
                    <label>
                        <asp:Literal ID="lrtAccion" runat="server" Text=""></asp:Literal>
                    </label>
                    <br>
                    <se></se>
                </div>
                <div class="b">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
