<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionModificacion/_Modificacion.master" AutoEventWireup="true" CodeBehind="Adeudos.aspx.cs" Inherits="DeclaraINAI.Formas.DeclaracionModificacion.Adeudos" Culture="es-MX" UICulture="es-MX" %>
<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionModificacion/Adeudo.ascx" TagPrefix="uc1" TagName="Adeudo" %>
<%@ Register Src="~/Formas/DeclaracionModificacion/ctrlDesincorpora.ascx" TagPrefix="ascx" TagName="ctrlDesincorpora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
          <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si"  OnNo="QstBox_No" OnYes="QstBox_Yes" YesCssClass="" NoCssClass=""  />
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="13. Adeudos/Pasivos (entre el 1 de enero y el 31 de diciembre del año inmediato anterior) <br/><h6>Todos los datos de los adeudos/pasivos a nombre de la pareja, dependientes económicos y/o terceros o que sean copropiedad con el declarante no serán públicos </br> Adeudos del declarante, pareja y/o dependientes económicos"></asp:Literal>
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

     <asp:AlanModalPopUp runat="server" ID="mppBaja">
        <ContentTemplate>
            <ascx:ctrlDesincorpora runat="server" ID="ctrlDesincorpora1" />
            <div class="right">
                <br />
                
                
                <asp:Button ID="btnCerrarBaja" runat="server"  Text="Cerrar" OnClick="btnCerrarBaja_Click"  />
                <asp:Button ID="btnGuardarBaja" runat="server" Text="Guardar" OnClick="btnGuardarBaja_Click" />
                 <asp:Button ID="btnEliminarBaja" runat="server" Text="Eliminar"  OnClick="btnEliminarBaja_Click" />
                 <br />
                 <br />
                 <br />
                 <br />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

</asp:Content>
