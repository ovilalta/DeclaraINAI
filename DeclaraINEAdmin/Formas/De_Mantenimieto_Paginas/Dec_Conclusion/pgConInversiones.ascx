<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pgConInversiones.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Conclusion.pgConInversiones" %>

<div class="panel panel-default">
    <div class="panel-heading">Modificacion de Inversiones</div>
    <asp:GridView runat="server" ID="grdInversionesModificacion" AutoGenerateColumns="false" OnRowDataBound="grdInversionesModificacion_RowDataBound" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
        <Columns>
            <asp:TemplateField HeaderText="Tipo de inversion">
                <ItemTemplate>
                    <asp:Image ID="imgTipoModificacion" Width="24px" Height="24px" runat="server" />
                    <asp:Literal ID="ltrTipoModificacion" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Subtipo de inversion">
                <ItemTemplate>
                    <asp:Literal ID="ltrSubtipoModificacion" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pais">
                <ItemTemplate>
                    <asp:Literal ID="ltrPaisModificacion" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Institucion">
                <ItemTemplate>
                    <asp:Literal ID="ltrInstitucionModificacion" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Saldo">
                <ItemTemplate>
                    <asp:Literal ID="moneytxtValorModificacion" runat="server" Text='<%#Eval("M_SALDO_ACTUAL","{0:C0}") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Numero de cuenta">
                <ItemTemplate>
                    <asp:Literal ID="ltrNumeroCuentaModificacion" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de apertura">
                <ItemTemplate>
                    <asp:Literal ID="ltrFechaModificacion" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Titulares">
                <ItemTemplate>
                    <asp:Literal ID="ltrTitularesModificacion" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<div class="panel panel-default">
    <div class="panel-heading">Alta de Inversiones</div>

    <asp:GridView runat="server" ID="grdInversionesDecInicial" AutoGenerateColumns="false" OnRowDataBound="grdInversionesDecInicial_RowDataBound" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
        <Columns>
            <asp:TemplateField HeaderText="Tipo de inversion">
                <ItemTemplate>
                    <asp:Image ID="imgTipo" Width="24px" Height="24px" runat="server" ImageUrl='<%# string.Concat("~/Images/CAT_TIPO_INVERSION/", Eval("NID_TIPO_INVERSION"), ".png") %>' />
                    <asp:Literal ID="ltrTipo" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Subtipo de inversion">
                <ItemTemplate>
                    <asp:Literal ID="ltrSubtipo" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pais">
                <ItemTemplate>
                    <asp:Literal ID="ltrPais" runat="server" Text='<%#Eval("V_PAIS") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Institucion">
                <ItemTemplate>
                    <asp:Literal ID="ltrInstitucion" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Saldo">
                <ItemTemplate>
                    <asp:Literal ID="moneytxtValor" runat="server" Text='<%#Eval("M_SALDO","{0:C0}") %>'></asp:Literal>
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
                    <asp:Literal ID="ltrTitulares" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
