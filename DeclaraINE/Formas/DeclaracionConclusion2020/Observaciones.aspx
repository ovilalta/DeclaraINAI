<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionInicial/_Inicial.master" AutoEventWireup="true" CodeBehind="Observaciones.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionInicial.Observaciones" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <style type="text/css">
     </style>
    <script type="text/javascript">
        function nombrecampo(nombre, area, maximo) {
            NombreTXT = nombre;
            limite = maximo;
            numeroDeC = area.value.length;

            if (numeroDeC > limite) {
                area.value = area.value.substring(0, limite);
            }
            else {
                if (NombreTXT == "txtObservaciones") {
                    $('#<%=txtcuenta.ClientID%>').val(Text = "Número de caractéres capturados:" + numeroDeC);
                }
            }
        }
    </script>


    <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si" OnNo="QstBox_No" OnYes="QstBox_Yes"  YesCssClass="" NoCssClass="" />

    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Observaciones y Aclaraciones"></asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <asp:AlanAlert runat="server" ID="AlertaSuperior" />
    <div id="cuerpo">
        <asp:TextBox ID="txtcuenta" Text="Número de caractéres capturados: 0" runat="server" BackColor="#EEEEEE" ReadOnly="True"></asp:TextBox>
        <asp:TextBox ID="TextBox1" Text="Número máximo de caracteres permitidos: 1000" runat="server" BackColor="#EEEEEE" ReadOnly="True"></asp:TextBox>
        <asp:TextBox ID="txtObservaciones" runat="server" onkeyDown="nombrecampo('txtObservaciones',this,'1000')"
            onkeyup="nombrecampo('txtObservaciones',this,'1000')" MaxLength="1000" TextMode="MultiLine" Width="100%"></asp:TextBox>

    </div>

</asp:Content>
