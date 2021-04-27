<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DeclaraINE.Formas.Index" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Src="~/Formas/SioNo.ascx" TagPrefix="uc1" TagName="SioNo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <title><%: Page.Title %> - <%: Declara_V2.BLLD.clsSistema.V_SISTEMA %></title>
    <!-- CSS here -->
    <meta charset="utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <meta name="description" content="Declaracion patrimonial" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Expires" content="0">
    <meta http-equiv="Last-Modified" content="0">
    <meta http-equiv="Cache-Control" content="no-cache, mustrevalidate">
    <meta http-equiv="Pragma" content="no-cache">
    <link rel="shortcut icon" type="image/x-icon" href="img/favicon.png" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/owl.carousel.min.css" />
    <link rel="stylesheet" href="../css/magnific-popup.css" />
    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link rel="stylesheet" href="../css/animate.css" />
    <link rel="stylesheet" href="../css/slicknav.css" />
    <link rel="stylesheet" href="../css/style.css?1" />
    <link rel="stylesheet" href="../css/modal.css?1" />
    <style>
        .ocultarBoton {
            display: none;
        }

        .aspNetDisabled {
            color: darkgrey !important;
        }

            .aspNetDisabled .content p {
                color: darkgrey !important;
            }

            .aspNetDisabled .thumb img {
                filter: grayscale(100%) !important;
            }

        ul#navigation, ul#navigation2,ul#navigation3 {
            text-align: right;
        }

            ul#navigation li, ul#navigation2 li ,ul#navigation3 li {
                margin: 0 20px 0 50px !important;
            }
    </style>
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
    <script async src="https://www.googletagmanager.com/gtag/js?id=G-5WVPWF3WWB"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'G-5WVPWF3WWB');
    </script>
</head>
<%--<body onload="ComprobarVentana()">--%>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            <%--            <Scripts>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
                <asp:ScriptReference Name="MsWebFormsSiteResorces" />
            </Scripts>--%>
        </asp:ScriptManager>
        <div class="main-body">
            <!-- header-start -->
            <header>
                <div class="header-area ">
                    <div id="sticky-header" class="main-header-area">
                        <div class="container-fluid">
                            <div class="header_bottom_border">
                                <div class="row align-items-center">
                                    <div class="col-xl-3">
                                        <div class="logo">
                                            <a href="#">
                                                <img src="../Images/LogoINE.png" width="150" height="60" />
                                                <img src="../Images/logo-negro.png" width="120" height="60" />
                                            </a>
                                        </div>
                                    </div>
                                    <div class="col-xl-8 col-lg-8">
                                        <div class="main-menu  d-none d-lg-block">
                                            <nav>
                                                <ul id="navigation">
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton11" runat="server" OnClick="btnInicio_Click" CssClass="active" Text="Inicial"></asp:LinkButton></li>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton22" runat="server" OnClick="lkModificacion_Click" CssClass="active" Text="Modificación"></asp:LinkButton></li>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton33" runat="server" OnClick="lkConclusion_Click" CssClass="active" Text="Conclusión"></asp:LinkButton></li>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton44" runat="server" OnClick="lkConflicto_Click" CssClass="active" Text="Intereses"></asp:LinkButton></li>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton200" runat="server" OnClick="lkConflicto_Click" CssClass="active" Text="Fiscal"></asp:LinkButton></li>
                                                    <li>
                                                        <asp:LinkButton ID="btnaCerrar" Text="Salir" runat="server" OnClick="btnCerrar_Click"></asp:LinkButton></li>
                                                </ul>
                                                <ul id="navigation2">
                                                    <li>
                                                        <asp:LinkButton ID="btnAdmin2" Text="Declaraciones" runat="server" OnClick="btnAdminVer_Click" Visible="false" ForeColor="SlateBlue"></asp:LinkButton>

                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="btnAdmin3" Text="Correo alterno" runat="server" OnClick="btnAdminVer3_Click" Visible="false" ForeColor="SlateBlue"></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="btnAdmin4" Text="Activación de cuenta" runat="server" OnClick="btnAdminVer4_Click" Visible="false" ForeColor="SlateBlue"></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="btnAdmin5" Text="Generación de reporte" runat="server" OnClick="btnAdminVer5_Click" Visible="false" ForeColor="SlateBlue"></asp:LinkButton>
                                                    </li>
                                                    
                                                </ul>
                                                <ul id="navigation3">                                                   
                                                    <li>
                                                        <asp:LinkButton ID="btnAdmin6" Text="Reporte SIPOT" runat="server" OnClick="btnAdminVer6_Click" Visible="false" ForeColor="SlateBlue"></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="btnAdmin7" Text="Declaraciones Públicas PDF's" runat="server" OnClick="btnAdminVer7_Click" Visible="false" ForeColor="SlateBlue"></asp:LinkButton>
                                                    </li>
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
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../Images/off.png" ToolTip="Salir" OnClick="btnCerrar_Click" Width="30" Height="30" />
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
            <!-- header-end -->
            <!-- Banner -->
            <div class="where_togo_area">
                <div class="container">
                    <div class="row align-items-center">
                        <div class="col-lg-9">
                            <div class="form_area">
                                <h1>Declara INAI</h1>
                                <h3>Sistema de Declaraciones Patrimonial y de Intereses </h3>
                                <hr />
                                <h5>Bienvenido:
                                    <asp:Literal ID="LabNombre" runat="server"></asp:Literal>
                                    &nbsp;
                                    <asp:Literal ID="labFecha" runat="server"></asp:Literal></h5>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <!-- Banner  -->
            <!-- Declaration_area_start  -->
            <div class="popular_destination_area">
                <div class="container">

                    <%-- <div class="row justify-content-left">
                        <div class="col-lg-6">
                            <div class="section_title text-center mb_70">
                                <p>Seleccione una opción del mosaico para iniciar con su declaración</p>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <p><a href="#"><i class="fa fa-book fa-3" aria-hidden="true"></i>Ver Instructivo de Llenado</a></p>
                        </div>
                    </div>--%>
                    <div class="row justify-content-left">
                        <div class="col text-justify">
                            <p>
                                Documentos de Ayuda:
                                 <a href="../Formatos/Presentacion.pdf" target="_blank">&nbsp<i class="fa fa-book fa-3" aria-hidden="true"></i>Guía para la Declaración</a>
                                &nbsp;|&nbsp;
                                  <a href="../Formatos/Cuestionario_Declaracion_Modificacion.pdf" target="_blank">&nbsp<i class="fa fa-book fa-3" aria-hidden="true"></i> Preguntas y Respuestas</a>
                                &nbsp;|&nbsp;                       
                                <a href="../Formatos/Normas_e_Instructivo_para_Llenado_de_Declaraciones.pdf" target="_blank">&nbsp<i class="fa fa-book fa-3" aria-hidden="true"></i>Normas e Instructivo Oficiales</a>
                                &nbsp;|&nbsp;
                                <a href="../pdf1/CatalogoPuestosINAI.pdf" target="_blank">&nbsp<i class="fa fa-book fa-3" aria-hidden="true"></i>Catálogo de Puestos INAI</a>
                                &nbsp;|&nbsp;
                                <a href="../Images/TutorialFiscal/GUIAFISCAL.pdf" target="_blank">&nbsp<i class="fa fa-book fa-3" aria-hidden="true"></i>Tutorial Declaración Fiscal</a>
                            </p>
                            <hr />
                        </div>
                    </div>


                    <div class="row justify-content-left">
                        <div class="col text-justify">
                            <asp:AlanMessageBox runat="server" ID="MsgBox1" />
                            <asp:AlanAlert runat="server" ID="MsgBox" />
                        </div>
                    </div>


                    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <div class="row">
                                <div class="col">
                                    <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si" OnNo="QstBox_No" OnYes="QstBox_Yes" YesCssClass="" NoCssClass="" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                    <div class="row">
                        <div class="col-lg-4 col-md-6">
                            <div class="single_destination">
                                <asp:LinkButton ID="btnInicio" runat="server" OnClick="btnInicio_Click">                      
                                <div class="thumb"><img src="../Images/DeclaraInicio.jpg" />
                                     
                                </div>
                                <div class="content">
                                    <p class="d-flex align-items-center">Declaración Inicial</p>
                                </div>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="single_destination">
                                <asp:LinkButton ID="lkModificacion" runat="server" OnClick="lkModificacion_Click">   
                                <div class="thumb"><img src="../Images/DeclaraModificacion.jpg" />
                                  
                                </div>
                                <div class="content">
                                    <p class="d-flex align-items-center">Declaración de Modificación</p>
                                </div>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="single_destination">
                                <asp:LinkButton ID="lkConclusion" runat="server" OnClick="lkConclusion_Click">
                                    <div class="thumb"><img src="../Images/DeclaraPassword.jpg" />
                                 
                                </div>
                                <div class="content">
                                    <p class="d-flex align-items-center">Declaración de Conclusión</p>
                                </div>
                                </asp:LinkButton>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6">
                            <div class="single_destination">
                                <asp:LinkButton ID="lkConflicto" runat="server" OnClick="lkConflicto_Click">
                                <div class="thumb">
                                    <img src="../Images/DeclaraConclusion.jpg" />
                                </div>
                                <div class="content">
                                    <p class="d-flex align-items-center">
                                       Declaración de Intereses
                                    </p>
                                </div>
                                </asp:LinkButton>
                            </div>
                        </div>

                        <!--OEVM Imagen de acceso para la pantalla de Declaración Fiscal-->
                        <div class="col-lg-4 col-md-6">
                            <div class="single_destination">
                                <asp:LinkButton ID="LkFiscal" runat="server" OnClick="lkFiscal_Click">
                                <div class="thumb">
                                    <img src="../Images/DeclaraFiscal.png" />
                                </div>
                                <div class="content">
                                    <p class="d-flex align-items-center">
                                       Declaración Fiscal
                                    </p>
                                </div>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="single_destination">
                                <asp:LinkButton ID="lkAdmin" runat="server" OnClick="lkAdmin_Click">
                                <div class="thumb"><img src="../Images/administration.jpg" />
                                   
                                </div>
                                <div class="content">
                                    <p class="d-flex align-items-center">
                                        Administración de<br />
                                        la cuenta
                                    </p>
                                </div>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="single_destination">
                                <asp:LinkButton ID="lkConsultaDeclaraciones" runat="server" OnClick="btnConsultaDeclaracion_Click">
                                <div class="thumb"><img src="../Images/DeclaraConsulta.png" />                                   
                                </div>
                                <div class="content">
                                    <p>Consulta de Declaraciones</p>
                                </div>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>



                </div>
            </div>

            <!-- Declaration_area_end  -->

            <hr />
            <footer class="footer">
                <div class="container">
                    <div class="row">
                        <div class="col-xl-4 col-md-6 col-lg-4 ">
                            <div>
                                <h4 style="color: #000">OIC</h4>
                                <p>© Derechos Reservados, Órgano Interno de Control</p>
                            </div>
                        </div>
                        <div class="col-xl-4 col-md-6 col-lg-4 ">
                            <div>
                                <h4 style="color: #000"><i class="fa fa-map-marker" aria-hidden="true"></i>&nbsp;Oficinas Centrales</h4>
                                <p>
                                    Órgano Interno de Control<br />
                                    Insurgentes Sur No. 3211
                                    Col. Insurgentes Cuicuilco, 04530 México, Ciudad de México
                                </p>
                            </div>
                        </div>
                        <div class="col-xl-4 col-md-6 col-lg-4 ">
                            <div>
                                <h4 style="color: #000"><i class="fa fa-phone" aria-hidden="true"></i>&nbsp;Llámanos o escríbenos</h4>
                                <p>
                                    50042400 ext: 3435, 2363, 2461
                                    <br />
                                    CDMX e Interior de la República
                                    <br />
                                    <!--OEVM falta definición del OIC-->
                                    Correos electrónicos:
                                    <br />
                                    alejandro.rodriguez@inai.org.mx
                                    <br />
                                    oscar.vilalta@inai.org.mx
                                    <br />
                                    silvia.gomez@inai.org.mx
                                    <br />

                                </p>
                            </div>
                        </div>

                    </div>
                </div>
            </footer>
            <br />
            <br />
            <br />
            <br />
            <br />
            <!-- Modal -->
            <%--<div class="modal fade custom_search_pop" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="serch_form">
                            <input type="text" placeholder="Search" />
                            <button type="submit">search</button>
                        </div>
                    </div>
                </div>
            </div>--%>
            <script src="../js/jquery-1.12.4.min.js"></script>
            <script src="../js/bootstrap.min.js"></script>
            <script src="../js/owl.carousel.min.js"></script>
            <script src="../js/jquery.slicknav.min.js"></script>
            <script src="../js/main.js"></script>
        </div>

        <div class="container" runat="server" visible="false">

            <span></span>
            <div runat="server" visible="false">
                <asp:LinkButton ID="btnConsultaDeclaracion" runat="server" OnClick="btnConsultaDeclaracion_Click">
                        <img src="../Images/inicio/consulta.png" />
                </asp:LinkButton>
                <p>Consulta de Declaraciones</p>
            </div>


            <div runat="server" visible="false">
                <asp:LinkButton ID="btnPatrimonio" runat="server" OnClick="btnPatrimonio_Click">
                        <img src="../Images/inicio/patrimonio.png" />
                </asp:LinkButton>
                <p>Patrimonio</p>
            </div>

        </div>


        <asp:Panel runat="server" ID="pnlAviso">
            <div class="aviso">
                <div class="modal-content">
                    <script src="../Scripts/Site.js?1"></script>
                    <style type="text/css">
                        body .aviso {
                            text-align: -webkit-center;
                            margin-top: -31px;
                            display: block ruby;
                            text-align: center;
                        }

                        .aviso .titulo {
                            font-size: 16.0pt;
                            color: #808080;
                            text-align: center;
                            padding: 24px;
                        }

                        .aviso .contenido {
                            position: relative;
                            padding: 41px;
                            padding-top: 3px;
                        }

                            .aviso .contenido b {
                                font-size: 12.0pt;
                                font-family: sans-serif;
                                color: #797979;
                            }

                            .aviso .contenido p {
                                margin-bottom: 7.5pt;
                                text-align: justify
                            }

                                .aviso .contenido p span {
                                    margin-bottom: 8.0pt;
                                    text-align: justify;
                                    line-height: 12.0pt;
                                    width: 90%;
                                }

                        .aviso .modal-dialog {
                            width: 90%;
                        }
                    </style>
                    <%--                    <div class="titulo">
                        <b>AVISO  </b>
                    </div>
                    <div class="contenido">
                        <p>
                            <b>Actualmente puede presentar su declaración, la vista previa en PDF de su declaración, se le notificara por correo a la brevedad.</b>
                        </p>
                    </div>--%>
                </div>
            </div>
        </asp:Panel>


    </form>

</body>
</html>
