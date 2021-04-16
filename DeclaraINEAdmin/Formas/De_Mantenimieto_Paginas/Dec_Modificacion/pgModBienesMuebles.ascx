<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pgModBienesMuebles.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion.pgModBienesMuebles" %>


<div class="panel panel-default">
        <div class="panel-heading">Actualización de Otros Bienes Muebles</div>
    <asp:GridView ID="grdBienesModificacion" OnRowDataBound="grdBienesModificacion_RowDataBound" CssClass="table table-condensed table-striped table-hover alanGrid-theme" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Tipo de bien">
                <ItemTemplate>
                    <asp:Image runat="server" ID="imgTipo" Width="24px" Height="24px" ImageUrl='<%# String.Concat("~/Images/CAT_TIPO_MUEBLE/", Eval("NID_TIPO"), ".png") %>' />
                    <asp:Literal ID="ltrTipo" runat="server" Text='<%#Eval("V_TIPO") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de adquisición">
                <ItemTemplate>
                    <asp:Literal ID="ltrFecha" runat="server" Text='<%#Eval("F_ADQUISICION","{0:dd/MM/yyyy}") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor de adquisición">
                <ItemTemplate>
                    <asp:Literal ID="moneytxtValor" runat="server" Text='<%#Eval("M_VALOR","{0:C0}") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Titulares" >
                <ItemTemplate>
                    <asp:Literal ID="ltrTitularesModificacion" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

<div class="panel panel-default">

        <div class="panel-heading">Alta de Otros Bienes Muebles</div>
    <asp:GridView ID="grdBienesDecInicial" OnRowDataBound="grdBienesDecInicial_RowDataBound" CssClass="table table-condensed table-striped table-hover alanGrid-theme" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Tipo de bien">
                <ItemTemplate>
                    <asp:Image runat="server" ID="imgTipo" Width="24px" Height="24px" ImageUrl='<%# String.Concat("~/Images/CAT_TIPO_MUEBLE/", Eval("NID_TIPO"), ".png") %>' />
                    <asp:Literal ID="ltrTipo" runat="server" Text='<%#Eval("V_TIPO") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de adquisición">
                <ItemTemplate>
                    <asp:Literal ID="ltrFecha" runat="server" Text='<%#Eval("F_ADQUISICION","{0:dd/MM/yyyy}") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor de adquisición">
                <ItemTemplate>
                    <asp:Literal ID="moneytxtValor" runat="server" Text='<%#Eval("M_VALOR","{0:C0}") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Titulares" >
                <ItemTemplate>
                    <asp:Literal ID="ltrTitulares" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

