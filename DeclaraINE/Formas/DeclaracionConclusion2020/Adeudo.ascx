﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Adeudo.ascx.cs" Inherits="DeclaraINE.Formas.DeclaracionInicial.Adeudo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

        <script type="text/javascript">

            function nombrecampo(nombre, area, maximo) {
                NombreTXT = nombre;
                limite = maximo;
                numeroDeC = area.value.length;

                if (numeroDeC > limite) {
                    area.value = area.value.substring(0, limite);
                }
                else {
                    if (NombreTXT == "txtObservaciones") {
                        $('#<%=txtcuenta.ClientID%>').val(Text = "Número de caractéres capturados:" + numeroDeC);
                    }
                }
            }


 </script>
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
                <asp:DropDownList ID="cmbNID_PAIS" runat="server" OnSelectedIndexChanged="cmbNID_PAIS_SelectedIndexChanged" requerido="btnGuardarAdeudo" AutoPostBack="True" CssClass="n3"></asp:DropDownList>
                <asp:DropDownList ID="cmbCID_ENTIDAD_FEDERATIVA" runat="server" CssClass="n3"></asp:DropDownList>
                <asp:TextBox ID="txtV_LUGAR" runat="server" Visible="false" CssClass="n3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <l>Institución o Razón Social</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbNID_INSTITUCION" runat="server" AutoPostBack="True" requerido="btnGuardarAdeudo" OnSelectedIndexChanged="cmbNID_INSTITUCION_SelectedIndexChanged" CssClass="n2"> </asp:DropDownList>
                <asp:TextBox ID="txtV_OTRO" runat="server" Visible="false" CssClass="n2" requerido="btnGuardarAdeudo"  MaxLength="150"></asp:TextBox>
            </td>
        </tr>
            
        <tr>
            <th>
               <l>RFC</l> 
            </th>
            <td>
                <asp:TextBox ID="txtRfc" runat="server" Visible="true" CssClass="n2" requerido="btnGuardarAdeudo"  MaxLength="13"></asp:TextBox>
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
                <asp:TextBox ID="moneytxtM_ORIGINAL"  runat="server" ClientIDMode="Static" requerido="btnGuardarAdeudo" MaxLength="19"></asp:TextBox>
                <div id="divmoneytxtM_ORIGINAL"></div>
            </td>
        </tr>

        <tr>
            <th>
                <l>Tipo de moneda</l>
            </th>
            <td>
                <asp:TextBox ID="txtTipo_Moneda"  runat="server" ClientIDMode="Static" requerido="btnGuardarAdeudo" MaxLength="30"></asp:TextBox>
                <div id="divmoneytxtTipo_Moneda"></div>
            </td>
        </tr>

        <tr>
            <th>
                <l>Saldo del Adeudo</l>
            </th>
            <td>
                <asp:TextBox ID="moneytxtM_SALDO" runat="server" requerido="btnGuardarAdeudo" CssClass="AlineadoDerecha" ClientIDMode="Static"  MaxLength="19"></asp:TextBox>
                <div id="divmoneytxtM_SALDO"></div>
            </td>
        </tr>

        <tr>
            <th>
                <l>Tercero</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbTercero" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="cmbNID_INSTITUCION_SelectedIndexChanged" CssClass="n2">
                    <asp:ListItem Text = " " />
                    <asp:ListItem Text = "Persona Física" Value ="F" />
                    <asp:ListItem Text ="Persona Moral" Value ="M" />
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <th>
                <l>Nombre del tercero o terceros</l>
            </th>
            <td>
                <asp:TextBox ID="txtNombre_terceros" runat="server"  CssClass="AlineadoDerecha" ClientIDMode="Static"  MaxLength="19"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <th>
               <l>RFC</l> 
            </th>
            <td>
                <asp:TextBox ID="txtRfc_Terceros" runat="server" Visible="true" CssClass="n2"   MaxLength="150"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <th>
                <l>Otorgante del crédito</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbOtorgante_credito" runat="server" AutoPostBack="True" requerido="btnGuardarAdeudo" OnSelectedIndexChanged="cmbNID_INSTITUCION_SelectedIndexChanged" CssClass="n2">
                    <asp:ListItem Text = " " />
                    <asp:ListItem Text = "Persona Física" Value = "F" />
                    <asp:ListItem Text = "Persona Moral" Value = "M" />
                </asp:DropDownList>
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

        <tr>
            <th>
                <l>Aclaraciones/Observaciones (máximo permitidos: 100)  <asp:TextBox ID="txtcuenta"  runat="server" BackColor="#EEEEEE" ReadOnly="True"></asp:TextBox> </l>
            </th>
            <td>
               <%-- <asp:TextBox ID="txtObservaciones" runat="server" Textmode="MultiLine" requerido="btnGuardarAdeudo" MaxLength="100" ></asp:TextBox>--%>
                <asp:TextBox ID="txtObservaciones" runat="server" onkeyDown="nombrecampo('txtObservaciones',this,'100')" 
                            onkeyup="nombrecampo('txtObservaciones',this,'100')" MaxLength="100" TextMode="MultiLine" Width="100%" Height="65px"></asp:TextBox>
            </td>
        </tr>
    </tbody>
</table>