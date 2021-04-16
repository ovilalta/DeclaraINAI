<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pgModAdeudos.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion.pgModAdeudos" %>

<div class="panel panel-default">

    <div class="panel-heading">Modificación de Adeudos </div>
    <asp:GridView ID="grdAdeudosModificacion" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdAdeudosModificacion_RowDataBound" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
        <Columns>
            <asp:TemplateField HeaderText="Tipo de Adeudo">
                <ItemTemplate>
                    <asp:Image ID="imgTipoMod" runat="server" Width="24px" Height="24px" />
                    <asp:Literal ID="ltrTipoMod" runat="server" ></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Localización del Adeudo">
                <ItemTemplate>
                    <asp:Literal ID="ltrPaisMod" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>    
            <asp:TemplateField HeaderText="Institución o Razón Social">
                <ItemTemplate>
                    <asp:Literal ID="ltrInstitucionMod" runat="server" ></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Saldo del Adeudo">
                <ItemTemplate>
                    <asp:Literal ID="moneytxtValor" runat="server" Text='<%#Eval("M_SALDOS","{0:C0}")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Numero de cuenta">
                <ItemTemplate>
                    <asp:Literal ID="ltrNumeroCuentaMod" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de apertura">
                <ItemTemplate>
                    <asp:Literal ID="ltrFechaMod" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<div class="panel panel-default">
        <div class="panel-heading">Alta de Adeudos</div>
    <asp:GridView ID="grdAdeudos" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdAdudos_RowDataBound" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
        <Columns>
            <asp:TemplateField HeaderText="Tipo de Adeudo">
                <ItemTemplate>
                    <asp:Image ID="imgTipo" runat="server" Width="24px" Height="24px" ImageUrl='<%# string.Concat("~/Images/CAT_TIPO_ADEUDO/", Eval("NID_TIPO_ADEUDO") , ".png")%>' />
                    <asp:Literal ID="ltrTipo" runat="server" Text='<%#Eval("V_TIPO_ADEUDO")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Localización del Adeudo">
                <ItemTemplate>
                    <asp:Literal ID="ltrPais" runat="server" Text='<%#Eval("V_PAIS") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Institución o Razón Social">
                <ItemTemplate>
                    <asp:Literal ID="ltrInstitucion" runat="server" Text='<%#Eval("V_INSTITUCION") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Saldo del Adeudo">
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
        </Columns>
    </asp:GridView>
</div>


