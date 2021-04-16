<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pgModTarjetas.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion.pgModTarjetas" %>
<asp:GridView runat="server" OnRowDataBound="grdTarjetas_RowDataBound" ID="grdTarjetas" AutoGenerateColumns="false" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
    <Columns>
        <asp:TemplateField HeaderText="Institución Financiera">
            <ItemTemplate>
                <asp:Image ID="imgTipo" runat="server" Width="24px" Height="24px" ImageUrl='<%# String.Concat("~/Images/icons/ColorX100/Bank Card Back Side.png") %>' />
                <asp:Literal ID="ltrTipo" runat="server"></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Número de cuenta">
            <ItemTemplate>
                <asp:Label ID="ltrNumero" runat="server" Text='<%#Eval("V_NUMERO_CORTO") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Monto de los pagos">
            <ItemTemplate>
                <asp:Literal ID="moneytxtPagos" runat="server" Text='<%#Eval("M_PAGOS", "{0:C0}") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Titulares">
            <ItemTemplate>
                <asp:Literal ID="ltrTitulares" runat="server"></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
