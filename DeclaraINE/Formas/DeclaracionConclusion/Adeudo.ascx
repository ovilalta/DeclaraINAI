<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Adeudo.ascx.cs" Inherits="DeclaraINAI.Formas.DeclaracionConclusion.Adeudo" %>
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
                        <%--$('#<%=txtcuenta.ClientID%>').val(Text = "Número de caractéres capturados:" + numeroDeC);--%>
                    }
                }
            }


 </script>
<table class="f">
    <tbody>
        
        <tr>
            <th>
                <l>Tipo de adeudo/pasivo</l>
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
               <l>RFC del Otorgante</l> 
            </th>
            <td>
                <asp:TextBox ID="txtRfc" runat="server" Visible="true" CssClass="n2" requerido="btnGuardarAdeudo"  MaxLength="13"></asp:TextBox>
            </td>
        </tr>

          <tr>
            <th>
                <l>Fecha de Adquisición del adeudo</l>
                 <p style="color: red;"> (Respete el formato de fecha dd/mm/aaaa)</p>
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

        <%--<tr>
            <th>
                <l>Tipo de moneda</l>
            </th>
            <td>
                <asp:TextBox ID="txtTipo_Moneda"  runat="server" ClientIDMode="Static" requerido="btnGuardarAdeudo" MaxLength="30"></asp:TextBox>
                <div id="divmoneytxtTipo_Moneda"></div>
            </td>
        </tr>--%>

        <tr>
            <th>
                <l>Tipo de moneda</l>
            </th>
            <td>
                 <asp:DropDownList ID="ddlTipoMonedaInm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoMonedaInm_SelectedIndexChanged" />
                <asp:TextBox ID="txtTipo_Moneda"  runat="server" ClientIDMode="Static"  Visible="false" MaxLength="30"></asp:TextBox>
                <div id="divmoneytxtTipo_Moneda"></div>
            </td>
        </tr>

        <tr>
            <th>
                <l>Saldo insoluto (situación actual)</l>
            </th>
            <td>
                <asp:TextBox ID="moneytxtM_SALDO" runat="server" requerido="btnGuardarAdeudo" CssClass="AlineadoDerecha" ClientIDMode="Static"  MaxLength="19"></asp:TextBox>
                <div id="divmoneytxtM_SALDO"></div>
            </td>
        </tr>
        <tr>
            <th>
                <l>Titular del Adeudo/Pasivo</l>
            </th>
            <td>
                <asp:DropDownList ID="chbDependietesInm" runat="server"  OnSelectedIndexChanged="chbDependietesInm_SelectedIndexChanged"  AutoPostBack="true">
                                    <asp:ListItem Text="Declarante" VALUE= "0"></asp:ListItem>
                                    <asp:ListItem Text="Declarante y Cónyuge"  Value= "1"></asp:ListItem>
                                    <asp:ListItem Text="Declarante en Copropiedad con Terceros"  Value= "3"></asp:ListItem>
                                    <asp:ListItem Text="Declarante y Cónyuge en Copropiedad con Terceros"  Value= "2"></asp:ListItem>
                                    <asp:ListItem Text="Declarante y Concubina o Concubinario"  Value= "4"></asp:ListItem>
                                    <asp:ListItem Text="Declarante y Concubina o Concubinario en Copropiedad con Terceros"  Value= "5"></asp:ListItem>
                                    <asp:ListItem Text="Cónyuge"  Value= "6"></asp:ListItem>
                                    <asp:ListItem Text="Cónyuge en Copropiedad con Terceros"  Value= "7"></asp:ListItem>
                                    <asp:ListItem Text="Concubina o Concubinario"  Value= "8"></asp:ListItem>
                                    <asp:ListItem Text="Concubina o Concubinario en Copropiedad con Terceros"  Value= "9"></asp:ListItem>
                                    <asp:ListItem Text="Conviviente"  Value= "10"></asp:ListItem>
                                    <asp:ListItem Text="Declarante y Conviviente"  Value= "11"></asp:ListItem>
                                    <asp:ListItem Text="Declarante y Conviviente en Copropiedad con Terceros"  Value= "12"></asp:ListItem>
                                    <asp:ListItem Text="Conviviente y Dependiente Económico"  Value= "13"></asp:ListItem>
                                    <asp:ListItem Text="Conviviente y Dependiente Económico en Copropiedad con Terceros"  Value= "14"></asp:ListItem>
                                    <asp:ListItem Text="Dependiente Económico"  Value= "15"></asp:ListItem>
                                    <asp:ListItem Text="Declarante y Dependiente Económico"  Value= "16"></asp:ListItem>
                                    <asp:ListItem Text="Dependiente Económico en Copropiedad con Terceros"  Value= "17"></asp:ListItem>
                                    <asp:ListItem Text="Declarante, Cónyuge y Dependiente Económico"  Value= "18"></asp:ListItem>
                                    <asp:ListItem Text="Declarante, Concubina o Concubinario y Dependiente Económico"  Value= "19"></asp:ListItem>
                                    <asp:ListItem Text="Cónyuge y Dependiente Económico"  Value= "20"></asp:ListItem>
                                    <asp:ListItem Text="Concubina o Concubinario y Dependiente Económico"  Value= "21"></asp:ListItem>
                                    <asp:ListItem Text="Cónyuge y Dependiente Económico en Copropiedad con Terceros"  Value= "22"></asp:ListItem>
                                    <asp:ListItem Text="Concubina o Concubinario y Dependiente Económico en Copropiedad con Terceros"  Value= "23"></asp:ListItem>
                                   <asp:ListItem Text="Otro"  Value= "24"></asp:ListItem>
                            </asp:DropDownList>
                <asp:CheckBoxList ID="cblTitulares" Visible="false" runat="server"></asp:CheckBoxList>

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
                <asp:TextBox ID="txtNombre_terceros" runat="server"  CssClass="AlineadoDerecha" ClientIDMode="Static"  MaxLength="200"></asp:TextBox>
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

        <%--<tr>
            <th>
                <l>Titular del Adeudo/Pasivo</l>
            </th>
            <td>
                <asp:CheckBoxList ID="cblTitulares" runat="server"></asp:CheckBoxList>

            </td>
        </tr>--%>

        <tr>
            <th>
                <l>Aclaraciones/Observaciones </l>
            </th>
            <td>
               <%-- <asp:TextBox ID="txtObservaciones" runat="server" Textmode="MultiLine" requerido="btnGuardarAdeudo" MaxLength="100" ></asp:TextBox>--%>
                <asp:TextBox ID="txtObservaciones" runat="server" onkeyDown="nombrecampo('txtObservaciones',this,'100')" 
                            onkeyup="nombrecampo('txtObservaciones',this,'100')" MaxLength="100" TextMode="MultiLine" Width="100%" Height="65px"></asp:TextBox>
            </td>
        </tr>
    </tbody>
</table>