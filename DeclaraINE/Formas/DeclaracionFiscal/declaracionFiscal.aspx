<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="declaracionFiscal.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionFiscal.WebForm1" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - DeclaraINAI</title>
    <asp:PlaceHolder runat="server"></asp:PlaceHolder>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-eOJMYsd53ii+scO/bJGFsiCZc+5NDVN2yr8+0RDqr0Ql0h+rP48ckxlpbzKgwra6" crossorigin="anonymous">
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <script src="../../Scripts/AlanWebControls.js"></script>
    <script src="../../Scripts/Site.js"></script>
    <script src="../Scripts/jquery-3.1.1.js"></script>
    <%--<webopt:BundleReference runat="server" Path="~/Content/css" />--%>

    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link rel="stylesheet" href="../css/Declaracion.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/AlanWebControls.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Content/login.css" rel="stylesheet" />
    <script src="../Scripts/Site.js"></script>

    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link rel="stylesheet" href="../css/registro.css" />
    <link rel="stylesheet" href="../css/style.css" />

    <style type="text/css">
        .panel.panel-default {
            background-color: azure;
        }

        #foot #identificacion {
            text-align: left;
        }

        .LT .active {
            border-color: #f9f9f9 !important;
            background: #f9f9f9 !important;
        }
    </style>
</head>

<body>
    <%-- Codigo encabezado donde aparece la imagen de DeclaraINAI --%>
    <div class="row register-info-box" style="background: url('../../Images/ine-acerca-slide.jpg');">
                <%--<div>--%>
                    <div class="row align-items-left" style="display: flex;">
                        <div>
                            <img src="../../Images/Declaraine.png" style="height: 80px; margin: 10px 4px 10px 40px;" />
                        </div>
                        <div style="width: 100%;">
                        </div>
                    </div>
                <%--</div>--%>
     </div>


    

        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="true">
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
            
            <div class ="container">
                <div class="row">
                    <div class="col-md-4" >  </div>        
                
                    <div class="col-md-4" align="center">
                        <h3 >Acuse de la Declaración Fiscal</h3>
                    </div>
                    <div class="col-md-4">     </div>
                </div>    
                <br />
                <%-- Boton tutorial --%>
                <div class="row">
                    <div class="col-md-4">                
                    </div>
                    <div class="col-md-4" align="center">
                        <asp:Button runat="server" Text="Tutorial Declaración Fiscal" ID="button3" OnClick="btnVerTutorial_Click" CssClass="Image-FAQ" />
                    </div>
                    <div class="col-md-4">                
                    </div>
                 </div>
                <br />
                <br />
                <br />

                
                
                <%-- Boton carga archivo pdf --%>
                <div class="row">
                    <div class="col-md-4">                
                    </div>
                    <div class="col-md-4" align="center">
                       
                            <asp:FileUpload  ID="FileUpload1" runat="server" Width="400px" Height="80px" />
                            
                        
                    </div>
                    <div class="col-md-4">                
                    </div>
               </div>
                <br />
                    <%-- Botones de cargar y cancelar --%>
                 <div class="row">                    
                    <div class="col-md-3">                            
                    </div>                    
                    <div class="col-md-6" align="center">
                        <asp:Button Text="Guardar" ID="Button1" runat="server" OnClick="Button1_Click" CssClass="Image-SaveArchive" width="210" />
                        <asp:Button Text="Regresar a tu declaración" ID="btnAtras" runat="server" OnClick="btnAtras_Click" CssClass="Image-Restart" width="210" />
                    </div>                    
                    <div class="col-md-3">                        
                    </div>                    
                 </div>
                <br />
                <br />
                <div class="row">
                    <div class="col-md-4">                        
                    </div>
                    <div class="col-md-4" align="center">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#009933" Font-Size="X-Large" ></asp:Label>
                    </div>
                    <div class="col-md-4">                        
                    </div>
                 </div>

                <asp:AlanModalPopUp runat="server" ID="mdlTutorial" HeaderText="Tutorial de la Declaración Fiscal" ModalSize="medium">

                <ContentTemplate>
                    <div id="myCarousel" class="carousel slide" data-ride="false">
                        <ol class="carousel-indicators">
                            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                            <li data-target="#myCarousel" data-slide-to="1"></li>
                            <li data-target="#myCarousel" data-slide-to="2"></li>
                            <li data-target="#myCarousel" data-slide-to="3"></li>
                            <li data-target="#myCarousel" data-slide-to="4"></li>
                        </ol>

                        <div class="carousel-inner">
                            <div class="item active">
                                <img src="../../Images/TutorialFiscal/01.png" />
                            </div>


                            <div class="item">
                                <img src="../../Images/TutorialFiscal/02.png" />
                            </div>

                            <div class="item">
                                <img src="../../Images/TutorialFiscal/03.png" />
                            </div>

                            <div class="item">
                                <img src="../../Images/TutorialFiscal/04.png" />
                            </div>

                            <div class="item">
                                <img src="../../Images/TutorialFiscal/05.png" />
                            </div>
                        </div>

                        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#myCarousel" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                    <div class="center total-width">
                        <asp:Button ID="btnCerrarModal" runat="server" Text="Cerrar el Tutorial de la Declaración Fiscal" OnClick="btnCerrarModal_Click" />
                    </div>
                </ContentTemplate>
            </asp:AlanModalPopUp>

          </div>

                
    </form>               
                 
                 

    

</body>
</html>