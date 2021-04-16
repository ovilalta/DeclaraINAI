<%@ Control Language="C#" AutoEventWireup   ="true" CodeBehind="BienesInmuebles.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Inicio.BienesInmuebles" %>
<asp:GridView ID="grdInmueblesBienes"   OnRowDataBound="grdInmueblesBienes_RowDataBound"   CssClass="table table-condensed table-striped table-hover alanGrid-theme" runat="server" AutoGenerateColumns="false" >
    <Columns>
        <asp:TemplateField HeaderText="Tipo de bien">
            <ItemTemplate>
                <asp:Image ID="imgTipo" Width="24px" Height="24px" ImageUrl='<%# string.Concat("~/Images/CAT_TIPO_INMUEBLE/", Eval("NID_TIPO") , ".png")%>' runat="server" />
                <asp:Literal ID="ltrTipo" runat="server"  Text='<%#Eval("V_TIPO")%>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Ubicación">
            <ItemTemplate>
                <asp:Literal ID="ltrUbicacion" runat="server" Text='<%#Eval("E_UBICACION")%>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Fecha adquisición">
            <ItemTemplate>
                <asp:Literal ID="ltrFecha" runat="server" Text='<%#Eval("F_ADQUISICION","{0:dd/MM/yyyy}")%> '></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Valor de adquisición">
            <ItemTemplate>
                <asp:Literal ID="moneytxtValor" runat="server" Text='<%#Eval("M_VALOR_INMUEBLE","{0:C0}")%>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
            
        <asp:TemplateField HeaderText="Tiene Adeudo">
            <ItemTemplate>
                <asp:CheckBox Id="chAdeudo" runat="server" Text=" " Enabled="false" CssClass="onoff"/>        
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Titulares">
            <ItemTemplate>
                <asp:Literal ID="ltrTitulares" runat="server" ></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
