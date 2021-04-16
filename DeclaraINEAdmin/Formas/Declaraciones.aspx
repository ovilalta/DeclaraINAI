<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/Site.Master" AutoEventWireup="true" CodeBehind="Declaraciones.aspx.cs" Inherits="DeclaraINEAdmin.Formas.Declaraciones" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
            <ContentTemplate>
                
                    <div class="filtro-header">
                        Consulta de Declaraciones
                    </div>

                    <nav class="filtro">
                        <div class="filtro-checks">
                            <asp:CheckBox ID="chNRFC" AutoPostBack="True" Text="RFC" runat="server" CssClass="checkbox-success checkbox-inline" Enabled="false" Checked="true" />&nbsp;&nbsp;
                        </div>

                        <asp:Panel ID="pnlchchNRFC" runat="server" Visible="true" class="form-group">
                            <div class="col-md-2 filtro-label">
                                RFC o Nombre
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" />
                            </div>
                        </asp:Panel>

                        <div class="center filtro-button">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Image-Search" OnClick="btnBuscar_Click" />
                            <asp:Button ID="btnNoEncontrado" runat="server" Text="No encontrado" CssClass="Image-DoNotDisturb" OnClick="btnNoEncontrado_Click" />
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Visible="false" />
                        </div>
                    </nav>

                    <asp:AlanAlert runat="server" ID="AlertaBusqueda" />

                    <div class="filtro ">
                        <asp:GridView ID="grdUsuario" runat="server" AutoGenerateColumns="false" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
                            <Columns>
                                <asp:TemplateField HeaderText="RFC">
                                    <ItemTemplate>
                                        <asp:Literal ID="ltrRFC" runat="server" Text='<%# String.Format("{0}{1}{2}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE")) %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:Literal ID="ltrV_NOMBRE" runat="server" Text='<%#Eval("V_NOMBRE")%>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Primer Apellido">
                                    <ItemTemplate>
                                        <asp:Literal ID="ltrV_PRIMER_A" runat="server" Text='<%#Eval("V_PRIMER_A")%>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Segundo Apellido">
                                    <ItemTemplate>
                                        <asp:Literal ID="ltrV_SEGUNDO_A" runat="server" Text='<%#Eval("V_SEGUNDO_A")%>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Declaraciónes">
                                    <ItemTemplate>
                                        <asp:Button ID="btnOpenFolderDeclaraciones" runat="server" CssClass="Image-OpenFolder" CommandArgument='<%# String.Format("{0}{1}{2}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE")) %>' OnClick="btnConsultaDeclaraciones_Click" />

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
         

            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:AlanModalPopUp runat="server" ID="appConsultaDeclaraciones">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnInforme" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView ID="grdDec" runat="server" AutoGenerateColumns="false" CssClass="table table-condensed table-striped table-hover alanGrid-theme" Visible="true" OnRowDataBound="grdDec_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Tipo Declaracion">
                            <ItemTemplate>
                                <asp:Literal ID="ltrV_TIPO_DECLARACION" runat="server" Text='<%#Eval("V_TIPO_DECLARACION")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ejercicio">
                            <ItemTemplate>
                                <asp:Literal ID="ltrC_EJERCICIO" runat="server" Text='<%#Eval("C_EJERCICIO")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:Literal ID="ltrV_ESTADO" runat="server" Text='<%#Eval("V_ESTADO")%>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Declaración">
                            <ItemTemplate>
                               <%-- <asp:Button ID="btnGridDeclaracion" runat="server" Visible='<%# Convert.ToInt32(Eval("NID_ORIGEN")) == 2 %>' CommandArgument='<%# Eval("NID_DECLARACION") %>' OnClick="btnGridDeclaracion_Click" CssClass="Image-PDF" />--%>
                                 <asp:Button ID="btnGridDeclaracion" runat="server"  CommandArgument='<%# Eval("NID_DECLARACION")+ ","+Eval("NID_ESTADO")+ ","+Eval("C_EJERCICIO")+ ","+Eval("NID_ORIGEN") +","+Eval("V_TIPO_DECLARACION")+","+Eval("F_PRESENTACION")%>' OnClick="btnGridDeclaracion_Click" CssClass="Image-PDF" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Declaración de Intereses" ItemStyle-CssClass="center">
                            <ItemTemplate>
                                <%--<asp:Button ID="btnGridDeclaracionConflicto" runat="server" Visible='<%# Convert.ToInt32(Eval("NID_ORIGEN")) == 2 %>' CommandArgument='<%# Eval("NID_DECLARACION") %>' OnClick="btnGridDeclaracionConflicto_Click" CssClass="Image-PDF" />--%>
                                <asp:Button ID="btnGridDeclaracionConflicto" runat="server" Visible='<%# (Convert.ToString( Eval("F_PRESENTACION")).Substring( Convert.ToString( Eval("F_PRESENTACION")).Length-1,1) !="," && Convert.ToString( Eval("NID_ORIGEN"))!="0")%>'  CommandArgument='<%# Eval("NID_DECLARACION")+","+Eval("NID_ORIGEN")+","+Eval("F_PRESENTACION")+","+Eval("NID_ESTADO") %>' OnClick="btnGridDeclaracionConflicto_Click" CssClass="Image-PDF" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Acuse">
                            <ItemTemplate>
                                <%--<asp:Button ID="btnGridDeclaracionAcuse" runat="server" Visible='<%# Convert.ToInt32(Eval("NID_ORIGEN")) == 2 %>' CommandArgument='<%#  Eval("NID_DECLARACION") %>' OnClick="btnGridDeclaracionAcuse_Click" CssClass="Image-PDF" />--%>
                                <asp:Button ID="btnGridDeclaracionAcuse" runat="server" CommandArgument='<%#Eval("NID_DECLARACION") + ","+Eval("NID_ESTADO")+ ","+Eval("C_EJERCICIO")+ ","+Eval("NID_ORIGEN") +","+Eval("V_TIPO_DECLARACION")+","+Eval("F_PRESENTACION")%> ' OnClick="btnGridDeclaracionAcuse_Click" CssClass="Image-PDF" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="right">
                    <asp:Button ID="btnInforme" runat="server" Text="Exportar" OnClick="btnInforme_Click" CssClass="Image-PDF" />
                    <asp:Button ID="btnCerrarConsultaDeclaraciones" runat="server" Text="Cerrar" OnClick="btnConsultaDeclaracionesCerrar_Click" />
                </div>
                <asp:AlanAlert runat="server" ID="AlertaSuperiorEJ" />
            </ContentTemplate>
        </asp:AlanModalPopUp>

        <asp:AlanModalPopUp runat="server" ID="mdlNoEncontado">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnInformeNoEncontrado" />
            </Triggers>
            <ContentTemplate>
                <table class="f">
                    <tr>
                        <td>
                            <l>
                                Primer Apellido
                            </l>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPrimerApellido" runat="server" Requerido="btnInformeNoEncontrado"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <l>
                                Segundo Apellido
                            </l>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSegundoApellido" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <l>
                                Nombre
                            </l>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" AutoPostBack="true" OnTextChanged="txtNombre_TextChanged" Requerido="btnInformeNoEncontrado"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <l>
                                R.F.C.
                            </l>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRFC1" runat="server" CssClass="n3" MaxLength="4" Requerido="btnInformeNoEncontrado"></asp:TextBox>
                            <asp:TextBox ID="txtRFC2" runat="server" CssClass="n3" MaxLength="6" Requerido="btnInformeNoEncontrado"></asp:TextBox>
                            <asp:TextBox ID="txtRFC3" runat="server" CssClass="n3" MaxLength="3" Requerido="btnInformeNoEncontrado" AutoPostBack="true" OnTextChanged="txtRFC3_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <l>
                                C.U.R.P.
                            </l>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCURP" runat="server" Requerido="btnInformeNoEncontrado"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="right">
                    <asp:Button ID="btnInformeNoEncontrado" runat="server" Text="Exportar" CssClass="Image-PDF" OnClick="btnInformeNoEncontrado_Click" ClientIDMode="Static" CommandArgument="NoGrid" />
                    <asp:Button ID="btnCerrarNoEncontrado" runat="server" Text="Cerrar" OnClick="btnCerrarNoEncontrado_Click" />
                </div>
            </ContentTemplate>
        </asp:AlanModalPopUp>
</asp:Content>
