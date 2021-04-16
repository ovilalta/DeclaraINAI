<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pgModOtrosGastos.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion.pgModOtrosGastos" %>
<asp:GridView runat="server" ID="grdOtrosGastos" AutoGenerateColumns="false" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
    <Columns>
        <asp:TemplateField HeaderText="Gastos">
            <ItemTemplate>
                <asp:Literal runat="server" ID="ltrTipo" Text='<%#Eval("V_GASTO") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Monto">
            <ItemTemplate>
                <asp:Literal runat="server" ID="moneytxtMonto" Text='<%#Eval("M_GASTO", "{0:C0}") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
