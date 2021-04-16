<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneraDeclaracion.aspx.cs" Inherits="DeclaraINE.Formas.Administrador.GeneraDeclaracion" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: #f8f9fa;">
<head runat="server">
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <title><%: Page.Title %> - <%: Declara_V2.BLLD.clsSistema.V_SISTEMA %></title>
    <!-- CSS here -->
    <meta charset="utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <meta http-equiv="Expires" content="0"/>
    <meta http-equiv="Last-Modified" content="0"/>
    <meta http-equiv="Cache-Control" content="no-cache, mustrevalidate"/>
    <meta http-equiv="Pragma" content="no-cache"/>
    <link rel="shortcut icon" type="image/x-icon" href="img/favicon.png" />
</head>
<body>
    <style>
        .loader {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            opacity: .8;
            background-color: #ffffff;
        }

            .loader img {
                margin: 15% 45%;
                height: 117px;
                display: flex;
            }

        .formError {
            z-index: 999999 !important;
            position: initial !important;
        }

            .formError .formErrorContent {
                background: #ae2174 !important;
                -webkit-box-shadow: 0 0 6px #ae2174 !important;
                border: 0.5px solid #ae2174 !important;
                margin-top: -43px !important;
            }

            .formError .formErrorArrow {
                margin: -2px 0 0 0px !important;
            }

                .formError .formErrorArrow div {
                    background: #ae2174 !important;
                    border: 0.5px solid #ae2174 !important;
                }

        .Login .footer {
            cursor: pointer;
        }

            .Login .footer:hover p {
                font-size: 16px;
                color: #018367;
                font-weight: 600;
            }

        .seach_icon {
            display: none;
        }

        div#sticky-header {
            background: white;
        }

        .container {
            max-width: 460px !important;
            margin: 0 auto !important;
            margin-bottom: 5% !important;
        }
    </style>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            <Scripts>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
                <asp:ScriptReference Name="MsWebFormsControlsResources" />
                <asp:ScriptReference Name="MsWebFormsSiteResorces" />
                <asp:ScriptReference Name="MsWebFormsPoper" />
                <asp:ScriptReference Name="MsWebFormsValidations" />
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

        <link rel="stylesheet" href="../../css/bootstrap.min.css" />
        <link rel="stylesheet" href="../../css/font-awesome.min.css" />
        <link rel="stylesheet" href="../../css/login.css?1" />
        <link rel="stylesheet" href="../../css/style.css?1" />
        <script src="../../Scripts/jquery-3.1.1.min.js"></script>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <link href="../../Content/AlanWebControls.css?1" rel="stylesheet" />
        <script src="../../Scripts/AlanWebControls.js?1"></script>

        <header>
            <div class="header-area ">
                <div id="sticky-header" class="main-header-area">
                    <div class="container-fluid">
                        <div class="header_bottom_border">
                            <div class="row align-items-center">
                                <div class="col-xl-3">
                                    <div class="logo">
                                        <a href="../Index.aspx">
                                            <img src="../../Images/LogoINE.png" width="150" height="60" />
                                            <img src="../../Images/logo-negro.png" width="120" height="60" />
                                        </a>
                                    </div>
                                </div>
                                <div class="col-xl-7 col-lg-7">
                                    <div class="main-menu  d-none d-lg-block">
                                        <nav>
                                            <ul id="navigation">
                                                <%--<li>
                                                        <asp:LinkButton ID="LinkButton11" runat="server" OnClick="btnInicio_Click" CssClass="active" Text="Inicial"></asp:LinkButton></li>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton22" runat="server" OnClick="lkModificacion_Click" CssClass="active" Text="Modificación"></asp:LinkButton></li>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton33" runat="server" OnClick="lkConclusion_Click" CssClass="active" Text="Conclusión"></asp:LinkButton></li>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton44" runat="server" OnClick="lkConflicto_Click" CssClass="active" Text="Intereses"></asp:LinkButton></li>-->
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton200" runat="server" OnClick="lkConflicto_Click" CssClass="active" Text="Fiscal"></asp:LinkButton></li> <!--OEVM acceso para declaración fiscal-->
                                                    <li>
                                                        <asp:LinkButton ID="btnaCerrar" Text="Salir" runat="server" OnClick="btnCerrar_Click"></asp:LinkButton></li>--%>
                                            </ul>
                                        </nav>
                                    </div>
                                </div>

                                <div class="social_wrap d-flex align-items-center justify-content-end">
                                    <div class="social_links d-none d-xl-block">
                                        <%--  <ul>
                                                <li><a href="#"><i class="fa fa-instagram"></i></a></li>
                                                <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                                <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                                <li><a href="#"><i class="fa fa-google-plus"></i></a></li>
                                            </ul>
                                            <p><a href="#"><i class="fa fa-book fa-3" aria-hidden="true"></i>&nbsp;Instructivo de Llenado</a></p>--%>
                                    </div>
                                </div>
                                <div class="seach_icon">
                                    <div class="off">
                                        <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../Images/off.png" ToolTip="Salir" OnClick="btnCerrar_Click" Width="30" Height="30" />--%>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="mobile_menu d-block d-lg-none"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </header>

        <asp:AlanMessageBox ID="MsgBox" runat="server" />
        <div class="row" style="margin:0 !important">
            <div class="col">
                <div class="login-reg-panel">
                    <div class="container">
                        <div class="card"></div>
                        <div class="card row Login">
                            <!--Descarga versión completa-->
                            <div class="input-container">
                                <label for="txtRfc">RFC - Versión Completa</label>
                                <br />
                                <br />
                                <asp:TextBox ID="txtRfc" runat="server"></asp:TextBox>                                
                                <div class="bar">
                                </div>
                            </div>

                            <div class="input-container" align="Center">
                                <label for="txtIdDeclaracion">Id de la Declaración</label>
                                <br />
                                <br />
                                <br />
                                <br />

                                <asp:DropDownList class="btn btn-success dropdown-toggle btn-lg" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" id="txtIdDeclaracion"  runat="server">
                                      
                                      <asp:ListItem  Value=1> Inicial </asp:ListItem>
                                      <asp:ListItem  Value=2> Modificación </asp:ListItem>
                                      <asp:ListItem  Value=3> Conclusión </asp:ListItem>
                               </asp:DropDownList>
                            </div>

                            <div class="button-container" style="margin: 40px 60px 0px;">
                                <asp:Button ID="btnDescargar" runat="server" Text="Descargar" OnClick="btnDescargar_Click" />
                            </div>

                            <%--<div class="button-container" style="margin: 40px 60px 0px;">
                                <asp:Button ID="btnShowDeclaraciones" runat="server" Text="Ver declaraciones" OnClick="btnMostrar_Click" />
                            </div>--%>
                        </div>
                    </div>
                    <!--Descarga versión pública-->
                    <div class="container">
                        <div class="card"></div>
                        <div class="card row Login">
                            <div class="input-container">
                                <label for="txtRfcPub">RFC - Versión Pública</label><br />
                                <asp:TextBox ID="TextRfcPub" runat="server"></asp:TextBox>
                                <div class="bar">
                                </div>
                            </div>

                            <div class="input-container" align="Center">
                                <label for="txtIdDeclaracionPub">Id de la Declaración</label>
                                <br />
                                <br />
                                <br />
                                <br />

                                <asp:DropDownList class="btn btn-success dropdown-toggle btn-lg" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" id="txtIdDeclaracionPub"  runat="server">
                                      
                                      <asp:ListItem  Value=1> Inicial </asp:ListItem>
                                      <asp:ListItem  Value=2> Modificación </asp:ListItem>
                                      <asp:ListItem  Value=3> Conclusión </asp:ListItem>
                               </asp:DropDownList>
                            </div>

                            <div class="button-container" style="margin: 40px 60px 0px;">
                                <asp:Button ID="Button1" runat="server" Text="Descargar" OnClick="btnDescargarPub_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <!--OEVM Meter segunda opción de descarga para versiones públicas 20201005-->
        

        <asp:AlanModalPopUp runat="server" ID="popupErr" HeaderText="ERROR" ModalSize="medium">
            <ContentTemplate>
                <div>
                    <asp:Label runat="server" ID="lblError" Text=""></asp:Label>
                </div>
                <br />
                <div class="right">
                    <asp:Button ID="btnCerrarModal" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarModal_Click" />
                </div>
            </ContentTemplate>
        </asp:AlanModalPopUp>
    </form>


    <link href="../../css/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../../js/jquery.validationEngine-es.js"></script>
    <script src="../../js/jquery.validationEngine.js"></script>


</body>
</html>
