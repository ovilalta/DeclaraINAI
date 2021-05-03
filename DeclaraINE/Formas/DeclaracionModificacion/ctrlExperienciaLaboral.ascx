<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlExperienciaLaboral.ascx.cs" Inherits="DeclaraINE.Formas.DeclaracionModificacion.ctrlExperienciaLaboral" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>





<table class="f">
    <tbody>
        <tr>
            <th colspan="2">
                <l>Ámbito / Sector</l>
            </th>
            <td>
                <asp:UpdatePanel runat="server" EnableViewState="true" ClientIDMode="Static">
                    <ContentTemplate>
                        <div class="yesno">
                            <div>
                                <asp:RadioButton ID="rbtnPu" GroupName="yn" runat="server" CssClass="yes" Text="Público" OnCheckedChanged="rbtnPu_CheckedChanged" AutoPostBack="true" />
                                <asp:RadioButton ID="rbtPr" GroupName="yn" runat="server" CssClass="yes" Text="Privado" OnCheckedChanged="rbtPr_CheckedChanged" AutoPostBack="true" />
                                <asp:RadioButton ID="rbtnOtro" GroupName="yn" runat="server" CssClass="yes" Text="Otro (Especifique)" OnCheckedChanged="rbtPrOtro_CheckedChanged" AutoPostBack="true" />
                            </div>
                            <asp:RadioButton ID="rbtAny" GroupName="yn" runat="server" Text="*Seleccione una opción" Checked="true" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </tbody>
</table>



<asp:HiddenField ID="NID_EXPERIENCIA" runat="server" />

<table class="f" runat="server" visible="false" id="tbExperiencia">
    <tbody>
        <tr runat="server" id="trPU_nivel" visible="false">
            <th>
                <l><asp:label runat="server"  ID="ltrPU_nivel" /></l>
            </th>
            <td>
                <asp:DropDownList ID="cmbPU_nivel" runat="server" requerido="btnGuardarExperienciaLaboral"></asp:DropDownList>
            </td>
        </tr>

        <tr runat="server" id="trPU_Ambito" visible="false">
            <th>
                <l>Ámbito Público</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbPU_Ambito" runat="server" requerido="btnGuardarExperienciaLaboral"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <th>
                <l><asp:label runat="server"  ID="ltrPuPr_Nombre" /></l>
            </th>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" requerido="btnGuardarExperienciaLaboral"></asp:TextBox>
            </td>
        </tr>
        <tr runat="server" id="trPR_RFC" visible="false">
            <th>
                <l>RFC</l>
            </th>
            <td>
                <asp:TextBox ID="txtRFC" runat="server" requerido="btnGuardarExperienciaLaboral" MaxLength="13"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <th>
                <l><asp:label runat="server"  ID="ltrPuPr_Area" /></l>
            </th>
            <td>
                <asp:TextBox ID="txtArea" runat="server" requerido="btnGuardarExperienciaLaboral"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <th>
                <l><asp:label runat="server"  ID="ltrPuPr_Puesto" /></l>
            </th>
            <td>
                <asp:TextBox ID="txtPuesto" runat="server" requerido="btnGuardarExperienciaLaboral"></asp:TextBox>
            </td>
        </tr>

        <tr runat="server" id="trPr_Funcion" visible="true">
            <th>
                <l>Especifique la Función Principal</l>                
            </th>
            <td>
                <asp:TextBox ID="txtFuncion" runat="server" requerido="btnGuardarExperienciaLaboral" MaxLength="250" ToolTip="Máximo 250 caracteres"></asp:TextBox>
                <%--<sub>Máximo 250 caracteres</sub>--%>
            </td>
        </tr>

        <tr runat="server" id="trPR_Sector" visible="false">
            <th>
                <l>Sector</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbPR_Sector" runat="server" requerido="btnGuardarExperienciaLaboral"></asp:DropDownList>

            </td>
        </tr>

        <tr>
            <th>
                <l> Fecha de Ingreso</l>
            </th>
            <td>
                <asp:TextBox ID="txtF_FechaIngreso" requerido="btnGuardarExperienciaLaboral" Date="S" runat="server" MaxLength="10"></asp:TextBox>
                <asp:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtF_FechaIngreso" Format="dd/MM/yyyy" />

            </td>
        </tr>

        <tr>
            <th>
                <l>Fecha de Egreso</l>
            </th>
            <td>
                <asp:TextBox ID="txtF_Egreso" requerido="btnGuardarExperienciaLaboral" Date="S" runat="server" MaxLength="10"></asp:TextBox>
                <asp:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtF_Egreso" Format="dd/MM/yyyy" />

            </td>
        </tr>

        <tr>
            <th>
                <l>Lugar donde se ubica</l>
            </th>
            <td>
                <asp:DropDownList ID="cmbPuPr_Lugar" runat="server" requerido="btnGuardarExperienciaLaboral"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <th>
                <l>Aclaraciones/Observaciones</l>
            </th>
            <td>
                <asp:TextBox ID="txtObservaciones" runat="server" MaxLength="1000" TextMode="MultiLine" Width="100%"></asp:TextBox>
            </td>
        </tr>

    </tbody>
</table>



