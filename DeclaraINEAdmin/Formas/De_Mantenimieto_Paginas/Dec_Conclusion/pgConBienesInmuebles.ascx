<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pgConBienesInmuebles.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Conclusion.pgConBienesInmuebles" %>

<div class="panel panel-default">
    <div class="panel-heading">Actualización de Bienes Inmuebles</div>
    <asp:GridView ID="grdBienesInmueblesModificacion" OnRowDataBound="grdBienesInmueblesModificacion_RowDataBound" CssClass="table table-condensed table-striped table-hover alanGrid-theme" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Tipo de bien">
                <ItemTemplate>
                    <asp:Image ID="imgTipo" runat="server" Width="24px" Height="24px" ImageUrl='<%# String.Concat("~/Images/CAT_TIPO_INMUEBLE/", Eval("NID_TIPO"), ".png") %>' />
                    <asp:Literal ID="ltrTipo" runat="server" Text='<%#Eval("V_TIPO") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ubicación">
                <ItemTemplate>
                    <asp:Literal ID="ltrUbicacion" runat="server" Text='<%#Eval("E_UBICACION") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de adquisición">
                <ItemTemplate>
                    <asp:Literal ID="ltrFecha" runat="server" Text='<%#Eval("F_ADQUISICION", "{0:dd/MM/yyyy}") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor de adquisición">
                <ItemTemplate>
                    <asp:Literal ID="moneytxtValor" runat="server" Text='<%#Eval("M_VALOR_INMUEBLE","{0:C0}") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tiene Adeudo">
                <ItemTemplate>
                    <asp:CheckBox ID="chAdeudoModificacion" runat="server" Text=" " Enabled="false" CssClass="onoff" />
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
    <div class="panel-heading">Alta de Bienes Inmuebles</div>
    <asp:GridView ID="grdBienesInmueblesDecInicial" OnRowDataBound="grdBienesInmuebles_RowDataBound" CssClass="table table-condensed table-striped table-hover alanGrid-theme" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Tipo de bien">
                <ItemTemplate>
                    <asp:Image ID="imgTipo" runat="server" Width="24px" Height="24px" ImageUrl='<%# String.Concat("~/Images/CAT_TIPO_INMUEBLE/", Eval("NID_TIPO"), ".png") %>' />
                    <asp:Literal ID="ltrTipo" runat="server" Text='<%#Eval("V_TIPO") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ubicación">
                <ItemTemplate>
                    <asp:Literal ID="ltrUbicacion" runat="server" Text='<%#Eval("E_UBICACION") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de adquisición">
                <ItemTemplate>
                    <asp:Literal ID="ltrFecha" runat="server" Text='<%#Eval("F_ADQUISICION", "{0:dd/MM/yyyy}") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor de adquisición">
                <ItemTemplate>
                    <asp:Literal ID="moneytxtValor" runat="server" Text='<%#Eval("M_VALOR_INMUEBLE","{0:C0}") %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tiene Adeudo">
                <ItemTemplate>
                    <asp:CheckBox ID="chAdeudo" runat="server" Text=" " Enabled="false" CssClass="onoff" />
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
