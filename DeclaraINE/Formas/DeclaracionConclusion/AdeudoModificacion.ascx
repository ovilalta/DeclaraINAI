<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdeudoModificacion.ascx.cs" Inherits="DeclaraINE.Formas.DeclaracionConclusion.AdeudoModificacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

        <tr>
            <th>
                <l>Tipo de Adeudo</l>
            </th>
            <td>
                <asp:TextBox ID="txtTIPO_ADEUDO" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <l>Localización del Adeudo</l>
            </th>
            <td>
                <asp:TextBox ID="txtLugarPais" runat="server" CssClass="n3"  Enabled="false"></asp:TextBox>
                <asp:TextBox ID="txtLugarEntidad" runat="server" CssClass="n3"  Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <l>Institución o Razón Social</l>
            </th>
            <td>
                <asp:TextBox ID="txtInstitución" runat="server"  Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <l>Monto Original del Adeudo</l>
            </th>
            <td>
                <asp:TextBox ID="txtMontoOriginal" runat="server"  Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <l>Número de Cuenta o Contrato</l>
            </th>
            <td>
                <asp:TextBox ID="txtCuenta" runat="server"  Enabled="false"></asp:TextBox>
            </td>
        </tr>
<%--        <tr>
            <th>
                <l>Monto de pagos realizados <br /> a la fecha de conclusión del encargo</l>
            </th>
            <td>
                <asp:TextBox ID="moneytxtM_ORIGINAL" runat="server" ClientIDMode="Static" MaxLength="19"></asp:TextBox>
                <div id="divmoneytxtM_ORIGINAL"></div>
            </td>
        </tr>--%>

        <tr>
            <th>
                <l>Saldo del adeudo <br />a la fecha de conclusión del encargo</l>
            </th>
            <td>
                <asp:TextBox ID="moneytxtM_SALDO" runat="server" requerido="btnGuardarMod" CssClass="AlineadoDerecha" ClientIDMode="Static" MaxLength="19"></asp:TextBox>
                <div id="divmoneytxtM_SALDO"></div>
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
