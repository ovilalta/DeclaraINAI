<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BienesOtrosBienes.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Inicio.BienesOtrosBienes" %>
<asp:GridView ID="grdBienes" OnRowDataBound="grdBienes_RowDataBound" CssClass="table table-condensed table-striped table-hover alanGrid-theme" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:TemplateField HeaderText="Tipo de bien">
            <ItemTemplate>
                <asp:Image ID="imgTipo" Width="24px" Height="24px" ImageUrl='<%# string.Concat("~/Images/CAT_TIPO_MUEBLE/", Eval("NID_TIPO") , ".png")%>' runat="server" />
                <asp:Literal ID="ltrTipo" runat="server" Text='<%#Eval("V_TIPO")%>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Descripción">
            <ItemTemplate>
                <asp:Literal ID="ltrMarca" runat="server" Text='<%#Eval("E_ESPECIFICACION")%>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Valor de adquisición">
            <ItemTemplate>
                <asp:Literal ID="moneytxtValor" runat="server" Text='<%#Eval("M_VALOR","{0:C0}")%>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha de adquisición">
            <ItemTemplate>
                <asp:Literal ID="ltrFecha" runat="server" Text='<%#Eval("F_ADQUISICION","{0:dd/MM/yyyy}")%> '></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Titulares">
            <ItemTemplate>
                <asp:Literal ID="ltrTitulares" runat="server" ></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>