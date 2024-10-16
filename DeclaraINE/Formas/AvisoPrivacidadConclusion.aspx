<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvisoPrivacidadConclusion.aspx.cs" Inherits="DeclaraINAI.Formas.AvisoPrivacidadConclusion" %>

<%@ Register Src="~/Formas/AvisoPrivacidad.ascx" TagPrefix="uc1" TagName="AvisoPrivacidad" %>
<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Src="~/Formas/SioNo.ascx" TagPrefix="uc1" TagName="SioNo" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%: Page.Title %> - <%: Declara_V2.BLLD.clsSistema.V_SISTEMA %></title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link rel="stylesheet" href="../css/registro.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <script type="text/javascript" src="../js/jquery-1.12.4.min.js"></script>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body onload="ComprobarVentana()">
    <form id="form1" runat="server" class="modal-panel">
        <asp:UpdatePanel ID="pnlAviso" runat="server" UpdateMode="Always">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAceptar" />
            </Triggers>
            <ContentTemplate>
                <div class="card">
                    <div class="row" style="background: url(../Images/inai-acerca-slide.jpg);">
                        <div class="register-info-box">
                            <div class="row">
                                <div class=" " style="margin: -12px;">
                                    <img src="../Images/INE_Login.png" width="180" height="120">
                                    <img src="../Images/OIC.png" width="115" height="52" style="margin-top: -8px">
                                </div>
                            </div>
                            <div class="row">
                                <h2 style="margin: 0px auto;">AVISO DE PRIVACIDAD INTEGRAL</h2>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:ScriptManager runat="server"></asp:ScriptManager>
                            <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si" OnNo="QstBox_No" OnYes="QstBox_Yes" YesCssClass="" NoCssClass="" />
                            <asp:AlanMessageBox runat="server" ID="MsgBox" />

                            <uc1:AvisoPrivacidad runat="server" ID="AvisoPrivacidad" />
                            <div class="right button-container">
                                <asp:Button ID="btnAceptar" runat="server" Text="He leído y acepto los términos" OnClick="btnAceptar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress AssociatedUpdatePanelID="pnlAviso" runat="server" EnableViewState="false">
            <ProgressTemplate>
                <div style="position: fixed; left: 0px; top: 0px; width: 100%; height: 100%; z-index: 9999; opacity: .8; background-color: #ffffff;">
                    <img src="../Images/pageLoader.gif" style="margin: 15% 45%; height: 117px; display: flex;" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
