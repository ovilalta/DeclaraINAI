<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlDependiente.ascx.cs" Inherits="DeclaraINE.Formas.DeclaracionConclusion.ctrlDependiente" %>
<%@ Register Src="~/Formas/SioNo.ascx" TagPrefix="uc1" TagName="SioNo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<table class="f">
    <tbody>
        <tr>
            <th>
                <l>Parentesco</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbNID_TIPO_DEPENDIENTE" runat="server" OnSelectedIndexChanged="cmbNID_TIPO_DEPENDIENTE_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>
                <l>Nombre</l>
            </th>
            <td>
                <asp:TextBox ID="txtE_NOMBRE" runat="server"  MaxLength="127"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <l>Primer Apellido</l>
            </th>
            <td>
                <asp:TextBox ID="txtE_PRIMER_A" runat="server"  MaxLength="127"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <l>Segundo Apellido</l>
            </th>
            <td>
                <asp:TextBox ID="txtE_SEGUNDO_A" runat="server"   MaxLength="127"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <l>Fecha de Nacimiento</l>
            </th>
            <td>
                <asp:TextBox ID="txtF_NACIMIENTO" runat="server" OnTextChanged="txtF_NACIMIENTO_TextChanged" Date="S" AutoPostBack="true"  MaxLength="10"></asp:TextBox>
                 <asp:CalendarExtender runat="server" ID="txtF_NACIMIENTO_C" TargetControlID="txtF_NACIMIENTO" Format="dd/MM/yyyy" />
            </td>
        </tr>
        <tr>
            <th>
                <l>RFC</l>
            </th>
            <td>
                <asp:TextBox ID="txtE_RFC" runat="server"  MaxLength="13"></asp:TextBox>
            </td>
        </tr>
        <tr runat="server" id="trDepende1" >
            <th colspan="2">
                <l>¿Depende económicamente del declarante?    <uc1:SioNo runat="server" ID="cbxL_DEPENDE_ECO" /> </l> 
            </th>
             </tr>
<%--        <tr runat="server" id="trDepende2">
            <td colspan="2" class="center">
             
            </td>
        </tr>--%>
         <tr>
            <th colspan="2">
                <l>¿El domicilio del dependiente es el mismo que el del declarante?     <asp:CheckBox CssClass="onoff" ID="chk_L_MISMO_DOMICIO" runat="server" AutoPostBack="true" Text=" "  OnCheckedChanged="chk_L_MISMO_DOMICIO_CheckedChanged" /></l>
            </th>
              </tr>
       
         <tr runat="server" visible="false" id="trDomicilio">
            <th>
                <l>Domicilio del dependiente</l>
            </th>
            <td>
                <asp:TextBox ID="txt_V_DOMICILIO" runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
            </td>
        </tr>
    </tbody>
</table>