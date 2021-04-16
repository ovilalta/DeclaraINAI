<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Inversiones.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Inicio.Inversiones" %>
<asp:GridView ID="grdInvesiones" runat="server" OnRowDataBound="grdInvesiones_RowDataBound" AutoGenerateColumns="false" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
    <Columns>
        <asp:TemplateField HeaderText="Tipo de Inversion">
            <ItemTemplate>
                <asp:Image ID="idTipo" runat="server" Width="24px" Height="24px" ImageUrl='<%# string.Concat("~/Images/CAT_TIPO_INVERSION/", Eval("NID_TIPO_INVERSION") , ".png")%>' />
                <asp:Literal ID="ltrTipo" runat="server" Text='<%#Eval("V_TIPO_INVERSION")%>'></asp:Literal>
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
        <asp:TemplateField HeaderText="Institucion">
            <ItemTemplate>
                <asp:Literal ID="ltrInstitucion" runat="server"></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Saldo">
            <ItemTemplate>
                <asp:Literal ID="moneytxtValor" runat="server" Text='<%#Eval("M_SALDO","{0:C0}")%>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Numero de cuenta">
            <ItemTemplate>
                <asp:Literal ID="ltrNumeroCuenta" runat="server" Text='<%#Eval("V_CUENTA_CORTO") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha de apertura">
            <ItemTemplate>
                <asp:Literal ID="ltrFecha" runat="server" Text='<%#Eval("F_APERTURA","{0:dd/MM/yyyy}")%> '></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Titulares">
            <ItemTemplate>
                <asp:Literal ID="ltrTitulares" runat="server" ></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
