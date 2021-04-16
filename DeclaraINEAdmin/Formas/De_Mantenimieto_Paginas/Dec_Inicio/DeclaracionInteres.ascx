<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeclaracionInteres.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Inicio.DeclaracionInteres" %>
<asp:GridView ID="grdConflicto" runat="server" OnRowDataBound="grdConflicto_RowDataBound" AutoGenerateColumns="false" CssClass="table table-condensed table-striped  alanGrid-theme">
    <Columns>
        <asp:TemplateField HeaderText="En este sentido">
            <ItemTemplate>
                <asp:Label ID="NID_RUBRO" runat="server" Text='<%#Eval("NID_RUBRO") %>' CssClass="invisible"></asp:Label>
                <asp:Label ID="NID_CONFLICTO" runat="server" Text='<%#Eval("NID_CONFLICTO") %>' CssClass="invisible"></asp:Label>
                <asp:Literal ID="ltrPregunta" runat="server" Text='<%#Eval("V_RUBRO") %>'></asp:Literal><br />       
                <asp:Panel ID="pnlConflicto" runat="server" CssClass="right" Visible='<%#Eval("L_ENCABEZADOS") %>' ClientIDMode="Static">
                    <asp:GridView runat="server" ID="grdRespuesta" OnRowDataBound="grdRespuesta_RowDataBound" CssClass="table table-condensed table-striped  alanGrid-theme" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:Label ID="NID_CONFLICTO" runat="server" Text='<%# Eval("NID_CONFLICTO") %>' CssClass="invisible"></asp:Label>
                                    <asp:Label ID="NID_RUBRO" runat="server" Text='<%# Eval("NID_RUBRO") %>' CssClass="invisible"></asp:Label>
                                    <asp:Label ID="NID_ENCABEZADO" runat="server" Text='<%# Eval("NID_ENCABEZADO") %>' CssClass="invisible"></asp:Label>
                                    <asp:Literal runat="server" ID="ltrNombre"></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parentesco">
                                <ItemTemplate>
                                    <asp:Literal ID="ltrParentesco" runat="server"></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre de la entidad, empresa o asociación">
                                <ItemTemplate>
                                    <asp:Literal ID="ltrEntidad" runat="server"></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Si">
            <ItemTemplate>
                <asp:Button ID="btnSi" runat="server" disabled="disabled" Text="" CssClass='<%# Eval("L_RESPUESTA") == null ? "btnFalse2" : (!Convert.ToBoolean(Eval("L_RESPUESTA")) ? "btnFalse2" : "btnTrue2") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="No">
            <ItemTemplate>
                <asp:Button ID="btnNo" runat="server" disabled="disabled" Text="" CssClass='<%# Eval("L_RESPUESTA") == null ? "btnFalse2" : !Convert.ToBoolean(Eval("L_RESPUESTA")) ? "btnTrue2" : "btnFalse2" %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>


</asp:GridView>
