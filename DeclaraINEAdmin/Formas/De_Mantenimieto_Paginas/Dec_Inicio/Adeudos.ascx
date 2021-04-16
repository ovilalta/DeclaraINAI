<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Adeudos.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Inicio.Adeudos" %>
<asp:GridView ID="grdAdeudos" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdAdeudos_RowDataBound" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
    <Columns>
        <asp:TemplateField HeaderText="Tipo de Adeudo">
            <ItemTemplate>
                <asp:Image ID="idTipo" runat="server" Width="24px" Height="24px" ImageUrl='<%# string.Concat("~/Images/CAT_TIPO_ADEUDO/", Eval("NID_TIPO_ADEUDO") , ".png")%>' />
                <asp:Literal ID="ltrTipo" runat="server" Text='<%#Eval("V_TIPO_ADEUDO")%>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Pais">
            <ItemTemplate>
                <asp:Literal ID="ltrPais" runat="server" Text='<%#Eval("V_PAIS") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Entidad">
            <ItemTemplate>
                <asp:Literal ID="ltrEntidad" runat="server" Text='<%#Eval("V_ENTIDAD_FEDERATIVA") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Institución">
            <ItemTemplate>
                <asp:Literal ID="ltrInstitucion" runat="server" Text='<%#Eval("V_INSTITUCION") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Saldo">
            <ItemTemplate>
                <asp:Literal ID="moneytxtValor" runat="server" Text='<%#Eval("M_SALDO","{0:C0}")%>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Numero de cuenta">
            <ItemTemplate>
                <asp:Literal ID="ltrNumeroCuenta" runat="server" Text='<%#Eval("E_CUENTA") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha de apertura">
            <ItemTemplate>
                <asp:Literal ID="ltrFecha" runat="server" Text='<%#Eval("F_ADEUDO","{0:dd/MM/yyyy}")%> '></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Titulares">
            <ItemTemplate>
                <asp:Literal ID="ltrTitulares" runat="server"></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>
