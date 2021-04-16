<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pgConBieneVehiculos.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Conclusion.pgConBieneVehiculos" %>

<div class="panel panel-default">
    <div class="panel-heading">Actualización de Vehiculos</div>
    <asp:GridView runat="server" ID="grdVehiculosModificacion" OnRowDataBound="grdVehiculosModificacion_RowDataBound" AutoGenerateColumns="false" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
        <Columns>
            <asp:TemplateField HeaderText="Tipo de Vehiculo">
                <ItemTemplate>
                    <asp:Image ID="imgTipo" Width="24px" Height="24px" runat="server" />
                    <asp:Literal ID="ltrTipo" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Marca">
                <ItemTemplate>
                    <asp:Literal ID="ltrMarcaMod" runat="server" Text='<%#Eval("V_MARCA")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripción de Adquisición">
                <ItemTemplate>
                    <asp:Literal ID="ltrDescrip" runat="server" Text='<%#Eval("V_DESCRIPCION")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Modelo">
                <ItemTemplate>
                    <asp:Literal ID="ltrModelo" runat="server" Text='<%#Eval("C_MODELO")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de adquisición">
                <ItemTemplate>
                    <asp:Literal ID="ltrFecha" runat="server" Text='<%#Eval("F_ADQUISICION","{0:dd/MM/yyyy}")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor de adquisición">
                <ItemTemplate>
                    <asp:Literal ID="moneytxtValor" runat="server" Text='<%#Eval("M_VALOR_VEHICULO","{0:C0}")%>'></asp:Literal>
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
    <div class="panel-heading">Alta de Vehiculos </div>
    <asp:GridView runat="server" ID="grdVehiculosDecInicial" OnRowDataBound="grdVehiculos_RowDataBound" AutoGenerateColumns="false" CssClass="table table-condensed table-striped table-hover alanGrid-theme">
        <Columns>
            <asp:TemplateField HeaderText="Tipo de Vehiculo">
                <ItemTemplate>
                    <asp:Image ID="imgTipo" Width="24px" Height="24px" ImageUrl='<%# string.Concat("~/Images/CAT_TIPO_VEHICULO/", Eval("NID_TIPO_VEHICULO") , ".png")%>' runat="server" />
                    <asp:Literal ID="ltrTipo" runat="server" Text='<%#Eval("V_TIPO_VEHICULO")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Marca">
                <ItemTemplate>
                    <asp:Literal ID="ltrMarca" runat="server" Text='<%#Eval("V_MARCA")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripción de Adquisición">
                <ItemTemplate>
                    <asp:Literal ID="ltrDescrip" runat="server" Text='<%#Eval("V_DESCRIPCION")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Modelo">
                <ItemTemplate>
                    <asp:Literal ID="ltrModelo" runat="server" Text='<%#Eval("C_MODELO")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de adquisición">
                <ItemTemplate>
                    <asp:Literal ID="ltrFecha" runat="server" Text='<%#Eval("F_ADQUISICION","{0:dd/MM/yyyy}")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor de adquisición">
                <ItemTemplate>
                    <asp:Literal ID="moneytxtValor" runat="server" Text='<%#Eval("M_VALOR_VEHICULO","{0:C0}")%>'></asp:Literal>
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
