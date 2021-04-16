<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="DeclaraINEAdmin.Start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">


            function Abrir_Login() {
                document.oncontextmenu = function () { return false }
                var winName = "111";
                //var h = screen.availHeight - 66;
                //var w = screen.availWidth - 13;
                var windowprops = "top=0, " +
                    "screenX=0, " +
                    "screenY=0, " +
                    "left=0, " +
                    "top=0, " +
                    "toolbar=no, " +
                    "location=no, " +
                    "status=yes, " +
                    "menubar=no, " +
                    "scrollbars=yes, " +
                    "resizable=yes, " +
                    "titlebar=no, " +
                    "directories=no, " +
                    "personalbar=no, " +
                    "minimizable=yes, " +
                    "width=0," +
                    "height=0;";
                var ventana = window.open('Default.aspx', winName, windowprops);

                if (ventana.closed) {
                }
                else {
                    window.open('', '_parent', '');
                    window.close();
                }
            }
    </script>

</head>
<body onload="Abrir_Login();" onselect="return false;" ondragstart="return false;">
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="a" OnClientClick="Abrir_Login();" runat="server">LinkButton</asp:LinkButton>
        </div>
    </form>
</body>
</html>


































































