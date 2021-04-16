<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="dumm.Menu" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

 



    <script src="../Scripts/jquery-3.1.1.js"></script>
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/AlanWebControls.js"></script>
    <link href="../Content/Icons.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Content/AlanWebControls.css" rel="stylesheet" />
<%--     <link href="../Content/login.css" rel="stylesheet" />--%>


    <script>
        $(document).ready(function () {
            $('.dropdown-submenu a.test').on("click", function (e) {
                $(this).next('ul').toggle();
                e.stopPropagation();
                e.preventDefault();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:AlanTabsMenu runat="server" ID="menu11" CssClass="menu" LeveOneCssClass="level1"> </asp:AlanTabsMenu>
            <asp:Button ID="btnActivar" runat="server" Text="Button" OnClick="btnActivar_Click" />
             <asp:Button ID="Button1" runat="server" Text="Button"  OnClick="Button1_Click"/>
            <asp:Button ID="Button2" runat="server" Text="Button" />
        </div>
    </form>
</body>
</html>
