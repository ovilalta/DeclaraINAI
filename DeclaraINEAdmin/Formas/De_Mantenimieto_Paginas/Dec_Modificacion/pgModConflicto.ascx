<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pgModConflicto.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion.pgModConflicto" %>

<asp:GridView ID="grdRubros" runat="server" OnRowDataBound="grdRubros_RowDataBound" AutoGenerateColumns="false" CssClass="table table-condensed table-striped  alanGrid-theme">
    <Columns>
        <asp:TemplateField HeaderText="En este sentido:">
            <ItemTemplate>
                <asp:Label ID="NID_RUBRO" runat="server" Text='<%# Eval("NID_RUBRO") %>' CssClass="invisible"></asp:Label>
                <asp:Label ID="NID_CONFLICTO" runat="server" Text='<%# Eval("NID_CONFLICTO") %>' CssClass="invisible"></asp:Label>
                <asp:Literal ID="ltrPregunta" runat="server" Text='<%#Eval("V_RUBRO") %>'></asp:Literal><br />              
                <asp:Panel ID="panelConflicto" runat="server"  ClientIDMode="Static" CssClass="right" Visible='<%# Eval("L_ENCABEZADOS") %>'>
                    <asp:GridView ID="grdRespuestas" OnRowDataBound="grdRespuestas_RowDataBound" runat="server" CssClass="  table-striped  alanGrid-theme" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:Label ID="NID_CONFLICTO" runat="server" Text='<%# Eval("NID_CONFLICTO") %>' CssClass="invisible"></asp:Label>
                                    <asp:Label ID="NID_RUBRO" runat="server" Text='<%# Eval("NID_RUBRO") %>' CssClass="invisible"></asp:Label>
                                    <asp:Label ID="NID_ENCABEZADO" runat="server" Text='<%# Eval("NID_ENCABEZADO") %>' CssClass="invisible"></asp:Label>
                                    <asp:Literal ID="ltrNombre" runat="server"></asp:Literal>
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
                            <asp:TemplateField HeaderText="Genera Conflicto">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chDecPublica" runat="server" Text=" " Enabled="false" CssClass="onoff" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Si">
            <ItemTemplate>
                <asp:Button ID="btnSi" runat="server" disabled="disabled"  Text="" CssClass='<%# Eval("L_RESPUESTA") == null ? "btnFalse2" : (!Convert.ToBoolean(Eval("L_RESPUESTA")) ? "btnFalse2" : "btnTrue2") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="No">
            <ItemTemplate>
                <asp:Button ID="btnNo" runat="server"  disabled="disabled" Text="" CssClass='<%# Eval("L_RESPUESTA") == null ? "btnFalse2" : !Convert.ToBoolean(Eval("L_RESPUESTA")) ? "btnTrue2" : "btnFalse2" %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
