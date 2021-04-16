<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pgConConyugue.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Conclusion.pgConConyugue" %>

<asp:GridView ID="grdDEP" CssClass="table table-condensed table-striped table-hover alanGrid-theme" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:TemplateField HeaderText="Nombre">
            <ItemTemplate>
                <asp:Literal ID="ltrNombre" runat="server" Text='<%#Eval("V_NOMBRE_COMPLETO")%>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Parentesco">
            <ItemTemplate>
                <asp:Image ID="imgParentesco" width="24px" Height="24px" ImageUrl='<%# String.Concat("~/Images/CAT_TIPO_DEPENDIENTE/",Eval("NID_TIPO_DEPENDIENTE"),".png") %>' runat="server" />
                <asp:Literal ID="ltrParentesco" runat="server" Text='<%#Eval("V_TIPO_DEPENDIENTE")%>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha Nacimiento">
            <ItemTemplate>
                <asp:Literal ID="ltrFechaNacimiento" runat="server" Text='<%#Eval("F_NACIMIENTO","{0:dd/MM/yyyy}")%> ' ></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
 