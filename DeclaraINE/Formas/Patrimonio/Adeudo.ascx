<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Adeudo.ascx.cs" Inherits="DeclaraINAI.Formas.Patrimonio.Adeudo" %>
<table class="f">
    <tbody>
        <tr>
            <th>
                <l>Tipo de Adeudo</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbNID_TIPO_ADEUDO" runat="server" Enabled="false" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>
                <l>Localización del Adeudo</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbNID_PAIS" runat="server"  AutoPostBack="True" CssClass="n3"  Enabled="false"></asp:DropDownList>
                <asp:DropDownList ID="cmbCID_ENTIDAD_FEDERATIVA" runat="server" CssClass="n3"  Enabled="false"></asp:DropDownList>
                <asp:TextBox ID="txtV_LUGAR" runat="server" Visible="false" CssClass="n3"  Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <l>Institución o Razón Social</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbNID_INSTITUCION" runat="server"  CssClass="n2"  Enabled="false"> </asp:DropDownList>
                <asp:TextBox ID="txtV_OTRO" runat="server" Visible="false" CssClass="n2"  Enabled="false"></asp:TextBox>
            </td>

        </tr>

          <tr>
            <th>
                <l>Fecha de Adquisición del adeudo</l>
            </th>
            <td>
                <asp:TextBox ID="txtF_ADEUDO" CssClass="AlineadoDerecha" TextMode="Date" runat="server"  Enabled="false"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <th>
                <l>Monto original del Adeudo</l>
            </th>
            <td>
                <asp:TextBox ID="moneytxtM_ORIGINAL" runat="server" ClientIDMode="Static"  Enabled="false"></asp:TextBox>
                <div id="divmoneytxtM_ORIGINAL"></div>
            </td>
        </tr>

        <tr>
            <th>
                <l>Saldo del Adeudo</l>
            </th>
            <td>
                <asp:TextBox ID="moneytxtM_SALDO" runat="server"  CssClass="AlineadoDerecha" ClientIDMode="Static"  Enabled="false"></asp:TextBox>
                <div id="divmoneytxtM_SALDO"></div>
            </td>
        </tr>

        <tr>
            <th>
                <l>Número de Cuenta o Contrato</l>
            </th>
            <td>
                <asp:TextBox ID="txtE_CUENTA" runat="server"  Enabled="false" ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <th>
                <l>Titular(es) de la cuenta</l>
            </th>
            <td>
                <asp:CheckBoxList ID="cblTitulares" runat="server"  Enabled="false"></asp:CheckBoxList>

            </td>
        </tr>
    </tbody>
</table>
