<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlDesincorpora.ascx.cs" Inherits="DeclaraINAI.Formas.DeclaracionModificacion.ctrlDesincorpora" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/SioNo.ascx" TagPrefix="uc1" TagName="SioNo" %>


<table class="f">
    <tbody>
        <tr  runat="server" visible="false">
            <th>
                <l>Tipo de Desincorporación</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbNID_TIPO_DEPENDIENTE" runat="server" OnSelectedIndexChanged="cmbNID_TIPO_DEPENDIENTE_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>
                <l>Fecha de la baja</l>
            </th>
            <td>
                <asp:TextBox ID="txtF_BAJA" runat="server"  Date="S" AutoPostBack="true" MaxLength="10"></asp:TextBox>
                <asp:CalendarExtender runat="server" ID="txtF_BAJA_C" TargetControlID="txtF_BAJA" Format="dd/MM/yyyy" />
            </td>
        </tr>
       
    </tbody>
</table>


<asp:Panel ID="pnlVenta" runat="server" Visible="false">
    <table class="f">
        <tbody>
            <tr>
                <th>
                    <l>Importe de la Venta</l>
                </th>
                <td>
                     <asp:TextBox ID="moneytxtM_IMPORTE_VENTA" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <div runat="server" id="divmoneytxtM_IMPORTE_VENTA" clientidmode="Static"></div>
                </td>
            </tr>
               <tr>
                <th>
                    <l>Comprador</l>
                </th>
                <td>
                      <asp:TextBox ID="txtE_BENIFICIARIO" runat="server" MaxLength="120"></asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

<asp:Panel ID="pnlDonacion" runat="server" Visible="false">
    <table class="f">
       <tbody>
            <tr runat="server" visible="false">
                <th>
                    <l>Motivos y/o condiciones <br /> de la donación o baja</l>
                </th>
                <td>
                     <asp:TextBox ID="txtE_ESPECIFICA" runat="server"  MaxLength="255"></asp:TextBox>
                </td>
            </tr>
               <tr >
                <th>
                    <l>Beneficiario (En su caso)</l>
                </th>
                <td>
                      <asp:TextBox ID="txtE_BENIFICIARIO_DONACION" runat="server"  MaxLength="120"></asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

<asp:Panel ID="pnlSiniestro" runat="server">
    <table class="f">
        <tbody>
            <tr>
                <th>¿El bien estaba cubierto por
                    <br />
                    una póliza de seguro?
                </th>
                <td>
                    <asp:CheckBox ID="cbxL_POLIZA" runat="server" Text=" " CssClass="onoff" OnCheckedChanged="cbxL_POLIZA_CheckedChanged" AutoPostBack="true" />
                </td>
            </tr>
            <tr runat="server" id="trM_RECUPERADO">
                <th>
                    <l>Importe Recuperado <br />(Monto Reintegrado Menos Comisiones y Deducibles)</l>
                </th>
                <td>
                    <asp:TextBox ID="moneytxtM_RECUPERADO" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <div runat="server" id="divmoneytxtM_RECUPERADO" clientidmode="Static"></div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>


