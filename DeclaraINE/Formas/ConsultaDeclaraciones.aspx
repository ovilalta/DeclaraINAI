<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaDeclaraciones.aspx.cs" Inherits="DeclaraINE.Formas.ConsultaDeclaraciones" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <title><%: Page.Title %> - <%: Declara_V2.BLLD.clsSistema.V_SISTEMA %></title>
</head>
<body onload="ComprobarVentana()">
    <form id="form1" runat="server" autocomplete="off">
        <asp:ScriptManager runat="server" EnablePartialRendering="true">
            <Scripts>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
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
        <%: Scripts.Render("~/bundles/modernizr") %>
        <ul class="nav nav-tabs menu">

            <li runat="server" enableviewstate="false" id="liDatosGenerales" class="active">
                <a href="#menu1" data-toggle="tab">Consulta de Declaraciones
                </a>
            </li>
        </ul>
        <div class="tab-content">
            <div runat="server" enableviewstate="false" class="tab-pane fade level1 active in" id="menu1">
                <ul class="nav nav-tabs ">
                    <li>
                        <asp:LinkButton ID="btnDeclaracionPatrimonial" runat="server" d-t="Declaración Patrimonial" OnClick="btnDeclaracionPatrimonial_Click" EnableViewState="false">
                                <img alt="Inicio" src="../../images/icons/ColorX32/Windows8.png" />
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="btnDeclaracionConflicto" runat="server" d-t="Declaración de Conflicto de Intereses" OnClick="btnDeclaracionConflicto_Click" EnableViewState="false">
                               <img alt="Inicio" src="./../images/icons/ColorX32/Transfer Between Users.png"/>
                        </asp:LinkButton>
                    </li>
                    <li></li>
                    <li>
                        <asp:LinkButton ID="btnDeclaracionAnteriores" runat="server" d-t="Declaraciones Anteriores a 2016" OnClick="btnDeclaracionAnteriores_Click" EnableViewState="false">
                               <img alt="Inicio" src="./../images/icons/ColorX32/Flow Chart.png"/>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <a></a>
                    </li>
                    <li>
                        <asp:LinkButton ID="lkVolver" runat="server" d-t="Volver al menù principal" OnClick="lkVolver_Click" EnableViewState="false">                       
                        <img src="./../images/icons/ColorX32/Circled%20Left.png"/></asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>

        <div class="subtitulo">
            <asp:Literal ID="ltrSubTitulo" runat="server"></asp:Literal>
        </div>

        <div id="cuerpo">

         

           


            <asp:Panel ID="pnlDeclaracionConflicto" runat="server" Visible="false">
                <asp:AlanAlert runat="server" ID="AlanAlert1" />
                <asp:GridView ID="grdDCF" runat="server" AutoGenerateColumns="false" ShowHeader="false" CssClass="table table-condensed table-striped bordeless table-hover">
                    <Columns>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Literal ID="ltrDescripcionCF" runat="server" Text='<%# Eval("C_EJERCICIO") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnGridDeclaraciónConflictoCF" runat="server" Text="Declaración" CommandArgument='<%# Eval("NID_DECLARACION") %>' OnClick="btnGridDeclaraciónConflicto_Click" CssClass="mpdf" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnGridDeclaracionConflictoAcuse" runat="server" Text="Acuse" CommandArgument='<%# Eval("NID_DECLARACION") %>' OnClick="btnGridDeclaracionConflictoAcuse_Click" CssClass="mpdf" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </asp:Panel>


            <asp:Panel ID="pnlDeclaracionAnteriores" runat="server" Visible="false">
                <asp:AlanAlert runat="server" ID="AlanAlert2" />
                <asp:GridView ID="grdDAnt" runat="server" AutoGenerateColumns="false" ShowHeader="false" CssClass="table table-condensed table-striped bordeless table-hover">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Literal ID="ltrDescripcion" runat="server" Text='<%# Eval("V_TIPO_DECLARACION") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Literal ID="ltrEjercicio" runat="server" Text='<%# Eval("C_EJERCICIO") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnGridDeclaracionAnterior" runat="server" Text="Declaración" CommandArgument='<%# Eval("NID_DECLARACION")+ ","+Eval("NID_ESTADO")+ ","+Eval("C_EJERCICIO")+ ","+Eval("NID_ORIGEN") +","+Eval("V_TIPO_DECLARACION")+","+Eval("F_PRESENTACION") %>' OnClick="btnGridDeclaracionAnterior_Click" CssClass="mpdf" />
                               
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnGridDeclaracionConflictoAnterior" runat="server" Visible='<%# (Convert.ToString( Eval("F_PRESENTACION")).Substring(0,1) !="," && Convert.ToString( Eval("NID_ORIGEN"))!="0")%>' Text="Declaración de Conflicto de Intereses" CommandArgument='<%# Eval("NID_DECLARACION")+","+Eval("NID_ESTADO")+","+Eval("F_PRESENTACION")+","+Eval("NID_ORIGEN") %>' OnClick="btnGridDeclaracionConflictoAnterior_Click" CssClass="mpdf" />
                                <%--<asp:Button ID="btnGridDeclaracionConflictoAnterior" runat="server" Visible='<%# (Convert.ToString( Eval("C_EJERCICIO")) =="2016")%>' Text="Declaración de Conflicto de Intereses" CommandArgument='<%# Eval("NID_DECLARACION")+","+Eval("NID_ESTADO") %>' OnClick="btnGridDeclaracionConflictoAnterior_Click" CssClass="mpdf" />--%>
                                
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnGridDeclaraciónAnteriorAcuse" runat="server" Text="Acuse" CommandArgument='<%# Eval("NID_DECLARACION")+ ","+Eval("NID_ESTADO")+ ","+Eval("C_EJERCICIO")+ ","+Eval("NID_ORIGEN") +","+Eval("V_TIPO_DECLARACION")+","+Eval("F_PRESENTACION")  %>' OnClick="btnGridDeclaraciónAnteriorAcuse_Click" CssClass="mpdf" />
                                <%--<asp:Button ID="btnGridDeclaraciónAnteriorAcuse" runat="server" Text="Acuse" CommandArgument='<%# Eval("NID_DECLARACION")+ ","+Eval("NID_ESTADO")+ ","+Eval("C_EJERCICIO")+ ","+Eval("V_TIPO_DECLARACION")  %>' OnClick="btnGridDeclaraciónAnteriorAcuse_Click" CssClass="mpdf" />--%>
                               
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </asp:Panel>

             <asp:Panel ID="pnlDeclaracionPatrimonial" runat="server" Visible="false">
                <asp:AlanAlert runat="server" ID="ADP" />
                <asp:GridView ID="grdDP" runat="server" AutoGenerateColumns="false" ShowHeader="false" CssClass="table table-condensed table-striped bordeless table-hover">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Literal ID="ltrDescripcionDP" runat="server" Text='<%# Eval("V_TIPO_DECLARACION") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Literal ID="ltrEjercicioDP" runat="server" Text='<%# Eval("C_EJERCICIO") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnGridDeclaracionAcuse" runat="server" Text="Acuse" CommandArgument='<%# Eval("NID_DECLARACION")  %>' OnClick="btnGridDeclaracionAcuse_Click" CssClass="mpdf" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnGridDeclaracionConflicto" runat="server"  Text="Declaración de Conflicto de Intereses" CommandArgument='<%# Eval("NID_DECLARACION") %>' OnClick="btnGridDeclaracionConflicto_Click" CssClass="mpdf" />
                                
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                 <asp:Button ID="Button1" runat="server" Text="Declaración" CommandArgument='<%# Eval("NID_DECLARACION")  %>' OnClick="btnGridDeclaracion_Click" CssClass="mpdf" />
                               
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
            </asp:Panel>

        </div>

    </form>
</body>
</html>
