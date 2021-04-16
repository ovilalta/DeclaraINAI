<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Adeudo.ascx.cs" Inherits="DeclaraINE.Formas.DeclaracionConclusion.Adeudo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<table class="f">
    <tbody>
        <tr>
            <th>
                <l>Tipo de Adeudo</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbNID_TIPO_ADEUDO" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>
                <l>Localización del Adeudo</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbNID_PAIS" runat="server" OnSelectedIndexChanged="cmbNID_PAIS_SelectedIndexChanged" AutoPostBack="True" CssClass="n3" requerido="btnGuardarAdeudo" ></asp:DropDownList>
                <asp:DropDownList ID="cmbCID_ENTIDAD_FEDERATIVA" runat="server" CssClass="n3"></asp:DropDownList>
                <asp:TextBox ID="txtV_LUGAR" runat="server" Visible="false" CssClass="n3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <l>Institución o Razón Social</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbNID_INSTITUCION" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbNID_INSTITUCION_SelectedIndexChanged" CssClass="n2" requerido="btnGuardarAdeudo"> </asp:DropDownList>
                <asp:TextBox ID="txtV_OTRO" runat="server" Visible="false" CssClass="n2"   MaxLength="150"></asp:TextBox>
            </td>

        </tr>

          <tr>
            <th>
                <l>Fecha de Adquisición del adeudo</l>
            </th>
            <td>
                <asp:TextBox ID="txtF_ADEUDO" requerido="btnGuardarAdeudo" Date="S" runat="server"  MaxLength="10"></asp:TextBox>
                 <asp:CalendarExtender runat="server" ID="txtF_ADEUDO_C" TargetControlID="txtF_ADEUDO" Format="dd/MM/yyyy"  />
            </td>
        </tr>

        <tr>
            <th>
                <l>Monto original del Adeudo</l>
            </th>
            <td>
                <asp:TextBox ID="moneytxtM_ORIGINAL"  runat="server" ClientIDMode="Static"  MaxLength="19" requerido="btnGuardarAdeudo"></asp:TextBox>
                <div id="divmoneytxtM_ORIGINAL"></div>
            </td>
        </tr>

        <tr>
            <th>
                <l>Saldo del Adeudo a la fecha de conclusión del encargo</l>
            </th>
            <td>
                <asp:TextBox ID="moneytxtM_SALDO" runat="server" requerido="btnGuardarAdeudo" CssClass="AlineadoDerecha" ClientIDMode="Static"  MaxLength="19"></asp:TextBox>
                <div id="divmoneytxtM_SALDO"></div>
            </td>
        </tr>

        <tr>
            <th>
                <l>Número de Cuenta o Contrato</l>
            </th>
            <td>
                <asp:TextBox ID="txtE_CUENTA" runat="server" requerido="btnGuardarAdeudo" MaxLength="100" ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <th>
                <l>Titular(es) de la cuenta</l>
            </th>
            <td>
                <asp:CheckBoxList ID="cblTitulares" runat="server"></asp:CheckBoxList>

            </td>
        </tr>
    </tbody>
</table>