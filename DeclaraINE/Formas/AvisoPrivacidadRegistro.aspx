<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvisoPrivacidadRegistro.aspx.cs" Inherits="DeclaraINAI.Formas.AvisoPrivacidadRegistro" %>

<%@ Register Src="~/Formas/AvisoPrivacidad.ascx" TagPrefix="uc1" TagName="AvisoPrivacidad" %>

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
       <!-- <script type="text/javascript">
        var _smartsupp = _smartsupp || {};
        _smartsupp.key = '36fe62cea33d3cbc39674295b89808a4ec11a4fc';
        window.smartsupp || (function (d) {
            var s, c, o = smartsupp = function () { o._.push(arguments) }; o._ = [];
            s = d.getElementsByTagName('script')[0]; c = d.createElement('script');
            c.type = 'text/javascript'; c.charset = 'utf-8'; c.async = true;
            c.src = 'https://www.smartsuppchat.com/loader.js?'; s.parentNode.insertBefore(c, s);
        })(document);
    </script>-->
        <!--<script type="text/javascript">
            var _smartsupp = _smartsupp || {};
            _smartsupp.key = '36fe62cea33d3cbc39674295b89808a4ec11a4fc';
            window.smartsupp || (function (d) {
                var s, c, o = smartsupp = function () { o._.push(arguments) }; o._ = [];
                s = d.getElementsByTagName('script')[0]; c = d.createElement('script');
                c.type = 'text/javascript'; c.charset = 'utf-8'; c.async = true;
                c.src = 'https://www.smartsuppchat.com/loader.js?'; s.parentNode.insertBefore(c, s);
            })(document);
    </script>-->
</head>
<body>
    <form id="form1" runat="server" class="modal-panel">
        <asp:ScriptManager runat="server" />
        <asp:UpdatePanel ID="pnlAviso" runat="server" UpdateMode="Always">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAceptar" />
            </Triggers>
            <ContentTemplate>
                <div class="card">
                    <div class="row" style="background: url(../Images/inai-acerca-slide.jpg);">
                        <div class="register-info-box">
                            <div class="row">
                                <div class=" ">
                                    <img src="../Images/INE_Login.png" width="180" height="120">
                                    <img src="../Images/OIC.png" width="115" height="52" style="margin-top: -8px">
                                </div>
                            </div>
                            <div class="row">
                                <h1 style="margin: 0px auto;">Protección de Datos Personales</h1>
                            </div>
                            <div class="row">
                                <h2 style="margin: 0px auto;">Aviso de Privacidad Integral</h2>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <uc1:AvisoPrivacidad runat="server" ID="AvisoPrivacidad" />
                            <div class="right button-container">
                                <asp:Button ID="btnAceptar" runat="server" Text="He leido y acepto los términos" OnClick="btnAceptar_Click" />
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
