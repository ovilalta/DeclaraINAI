<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirma.aspx.cs" Inherits="DeclaraINAI.Formas.Confirma" %>


<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="../Content/login.css" rel="stylesheet" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link rel="stylesheet" href="../css/registro.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <script type="text/javascript" src="../js/jquery-1.12.4.min.js"></script>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <script type="text/javascript">
        function cmp() {

            document.oncontextmenu = function () { return false }
            window.location.hash = "no-back-button";
            window.location.hash = "Again-No-back-button"
            window.onhashchange = function () { window.location.hash = "no-back-button"; }
            window.onkeydown = function (event) {
                if (event.keyCode == 123) {
                    event.stopPropagation();
                    event.preventDefault();
                    return false;
                } else if ((event.ctrlKey && event.shiftKey && event.keyCode == 73) || (event.ctrlKey && event.shiftKey && event.keyCode == 74) || (e.ctrlKey && (e.which == 83))) {
                    event.stopPropagation();
                    event.preventDefault();
                    return false;
                }
            }
        }

    </script>
    <title><%: Page.Title %> - <%: Declara_V2.BLLD.clsSistema.V_SISTEMA %></title>
</head>
<body onload="cmp();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            <Scripts>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
                <asp:ScriptReference Name="MsWebFormsControlsResources" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
            </Scripts>

        </asp:ScriptManager>
        <div class="card">
            <div class="row" style="background: url('../Images/inai-acerca-slide.jpg');">
                <div class="register-info-box">
                    <div class="row">
                        <div class=" ">
                            <img src="../Images/INE_Login.png" width="180" height="120">
                            <img src="../Images/OIC.png" width="115" height="52" style="margin-top: -8px">
                        </div>
                    </div>
                    <div class="row">
                        <h2 style="margin: 0px auto;">               
                            <asp:Literal runat="server" ID="ltr" Text='<%# Page.Title %>'></asp:Literal></h2>
                    </div>
                </div>
            </div>
        </div>

        <asp:UpdatePanel runat="server" ID="m" UpdateMode="Always">
            <ContentTemplate>
                <asp:AlanQuestionBox runat="server" ID="QstBox" OnYes="QstBox_Yes" OnNo="QstBox_No"></asp:AlanQuestionBox>
                <asp:AlanMessageBox runat="server" ID="MsgBox" />
            </ContentTemplate>
        </asp:UpdatePanel>


    </form>
</body>
</html>

<script type="text/javascript">
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(
        function () {
            showMessageBox();
            AlertSucccessFading();
        });

</script>
