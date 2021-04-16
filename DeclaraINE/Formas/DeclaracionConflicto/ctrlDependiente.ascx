<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlDependiente.ascx.cs" Inherits="DeclaraINE.Formas.DeclaracionConflicto.ctrlDependiente" %>
<%@ Register Src="~/Formas/SioNo.ascx" TagPrefix="uc1" TagName="SioNo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>






<table class="f"  runat="server" >
    <tbody>
        <tr>
            <th colspan="2">
                <l>Registrar xxxx</l>
            </th>
            <td>
                <asp:UpdatePanel runat="server" EnableViewState="true" ClientIDMode="Static">
                    <ContentTemplate>
                        <div class="yesno">
                            <div>
                                <asp:RadioButton ID="rbtP" GroupName="ynDep" runat="server" CssClass="yes" Text="6. Datos de la pareja" OnCheckedChanged="rbtP_CheckedChanged" AutoPostBack="true" />
                                <asp:RadioButton ID="rbtD" GroupName="ynDep" runat="server" CssClass="yes" Text="7. datos del dependiente económico" OnCheckedChanged="rbtD_CheckedChanged" AutoPostBack="true" />
                            </div>
                            <asp:RadioButton ID="rbtAny" GroupName="ynDep" runat="server" Text="*Seleccione una opción" Checked="true" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </tbody>
</table>






<asp:Panel runat="server" ID="tbAltaParejaDependiente" Visible="true">

    <table class="f">
        <tbody>

            <tr>
                <th>
                    <l>Nombre</l>
                </th>
                <td>

                    <asp:TextBox ID="txtE_NOMBRE" runat="server" MaxLength="127" requerido="btnGuardarDependiente"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <l>Primer Apellido</l>
                </th>
                <td>
                    <asp:TextBox ID="txtE_PRIMER_A" runat="server" MaxLength="127" requerido="btnGuardarDependiente"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <l>Segundo Apellido</l>
                </th>
                <td>
                    <asp:TextBox ID="txtE_SEGUNDO_A" runat="server" MaxLength="127" requerido="btnGuardarDependiente"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <l>Fecha de Nacimiento</l>
                </th>
                <td>
                    <asp:TextBox ID="txtF_NACIMIENTO" runat="server" OnTextChanged="txtF_NACIMIENTO_TextChanged" Date="S" AutoPostBack="true" MaxLength="10" requerido="btnGuardarDependiente"></asp:TextBox>
                    <asp:CalendarExtender runat="server" ID="txtF_NACIMIENTO_C" TargetControlID="txtF_NACIMIENTO" Format="dd/MM/yyyy" />
                </td>
            </tr>
            <tr>
                <th>
                    <l>RFC</l>
                </th>
                <td>
                    <asp:TextBox ID="txtE_RFC" runat="server" MaxLength="13" requerido="btnGuardarDependiente"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <th>
                    <l><asp:label runat="server"  ID="labTipoRelacion" /></l>
                </th>
                <td>
                    <asp:DropDownList ID="cmbNID_TIPO_DEPENDIENTE_DEP" runat="server" requerido="btnGuardarDependiente"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    <l>¿Es ciudadano extranjero?</l>
                </th>
                <td>
                    <asp:CheckBox ID="cbxEstrangero" runat="server" Checked="false" CssClass="onoff" Text=" " />
                </td>
            </tr>

            <tr>
                <th>
                    <l>Curp</l>
                </th>
                <td>
                    <asp:TextBox ID="txtCurp" runat="server" MaxLength="18" requerido="btnGuardarDependiente"></asp:TextBox>
                </td>
            </tr>




            <tr runat="server" id="trPareja">
                <th>
                    <l>¿Depende económicamente del declarante?    </l>

                </th>

                <td>
                    <asp:CheckBox ID="cbxL_DEPENDE_ECO" runat="server" Checked="false" CssClass="onoff" Text=" " />

                </td>
            </tr>

            <tr>
                <th>
                    <l><asp:label runat="server"  ID="lblDomicilio" /></l>
                </th>

                <td>
                    <asp:CheckBox CssClass="onoff" ID="chk_L_MISMO_DOMICIO_DEP" runat="server" AutoPostBack="true" Text=" " OnCheckedChanged="chk_L_MISMO_DOMICIO_CheckedChanged" Checked="false" />

                </td>

            </tr>

            <asp:Panel runat="server" ID="pnlDependiente">
                <tr>
                    <th>
                        <l>Domicilio del dependiente</l>
                    </th>
                </tr>

                <tr>
                    <th>
                        <l>Código Postal</l>
                    </th>
                    <td>
                        <asp:TextBox ID="C_CODIGO_POSTAL_DEP" runat="server" MaxLength="5" OnTextChanged="C_CODIGO_POSTAL_DEP_TextChanged" AutoPostBack="true" requerido="btnGuardarDependiente" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>País/Entidad/Municipio</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmbNID_PAIS_LABORAL_DEP" runat="server" OnSelectedIndexChanged="cmbNID_PAIS_LABORAL_DEP_SelectedIndexChanged" CssClass="n3" requerido="btnGuardarDependiente"  AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:DropDownList ID="cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP" runat="server" CssClass="n3" OnSelectedIndexChanged="cmbCID_ENTIDAD_FEDERATIVA_LABORAL_DEP_SelectedIndexChanged" AutoPostBack="true" requerido="btnGuardarDependiente"></asp:DropDownList>
                        <asp:DropDownList ID="cmbCID_MUNICIPIO_LABORAL_DEP" runat="server" CssClass="n3" requerido="btnGuardarDependiente"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Localidad o Colonia</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtV_COLONIA_LABORAL" runat="server" requerido="btnGuardarDependiente" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Calle/No. Exterior/No. Interior</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtV_DOMICILIO_LABORAL" runat="server" requerido="btnGuardarDependiente" CssClass="n3" MaxLength="150"></asp:TextBox>
                        <asp:TextBox ID="txtNumExteriorDOMICILIO_LABORAL" runat="server" requerido="btnGuardarDependiente" CssClass="n3" MaxLength="15" TextMode="Number"></asp:TextBox>
                        <asp:TextBox ID="txtNumInteriorDOMICILIO_LABORAL" runat="server" CssClass="n3" MaxLength="15" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>


            </asp:Panel>

            <tr>
                <th>
                    <l>Actividad laboral</l>
                </th>
                <td>
                    <asp:UpdatePanel runat="server" EnableViewState="true" ClientIDMode="Static">
                        <ContentTemplate>
                            <div class="yesno">
                                <div>
                                    <asp:RadioButton ID="rbtPr" GroupName="yn" runat="server" CssClass="yes" Text="Privado" OnCheckedChanged="rbtPr_CheckedChanged" AutoPostBack="true" />
                                    <asp:RadioButton ID="rbtnPu" GroupName="yn" runat="server" CssClass="yes" Text="Público" OnCheckedChanged="rbtnPu_CheckedChanged" AutoPostBack="true" />
                                    <asp:RadioButton ID="rbtnOtros" GroupName="yn" runat="server" CssClass="yes" Text="Otros" OnCheckedChanged="rbtnOtros_CheckedChanged" AutoPostBack="true" />
                                    <asp:RadioButton ID="rbtnNinguno" GroupName="yn" runat="server" CssClass="yes" Text="Ninguno" OnCheckedChanged="rbtnNinguno_CheckedChanged" AutoPostBack="true" />
                                </div>
                                
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>

            <tr runat="server" id="trPU_nivel" visible="false">
                <th>
                    <l><asp:label runat="server"  ID="ltrPU_nivel" /></l>
                </th>
                <td>
                    <asp:DropDownList ID="cmbPU_nivel" runat="server" requerido="btnGuardarDependiente"></asp:DropDownList>
                </td>
            </tr>

            <tr runat="server" id="trPU_Ambito" visible="false">
                <th>
                    <l>Ámbito público</l>
                </th>
                <td>
                    <asp:DropDownList ID="cmbPU_Ambito" runat="server" requerido="btnGuardarDependiente"></asp:DropDownList>
                </td>
            </tr>

            <tr runat="server" id="tr_Mixto1" visible="false">
                <th>
                    <l><asp:label runat="server"  ID="ltrPuPr_Nombre" /></l>
                </th>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" requerido="btnGuardarDependiente"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" id="tr_Mixto2" visible="false">
                <th>
                    <l><asp:label runat="server"  ID="ltrPuPr_Puesto" /></l>
                </th>
                <td>
                    <asp:TextBox ID="txtPuesto" runat="server" requerido="btnGuardarDependiente"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" id="trPR_RFC" visible="false">
                <th>
                    <l>RFC</l>
                </th>
                <td>
                    <asp:TextBox ID="txtRFC" runat="server" requerido="btnGuardarDependiente" MaxLength="12"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" id="tr_Mixto3" visible="false">
                <th>
                    <l> Fecha de Ingreso</l>
                </th>
                <td>
                    <asp:TextBox ID="txtF_FechaIngreso" requerido="btnGuardarDependiente" Date="S" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtF_FechaIngreso" Format="dd/MM/yyyy" />

                </td>
            </tr>

            <tr runat="server" id="trPr_Area" visible="false">
                <th>
                    <l><asp:label runat="server"  ID="ltrPuPr_Area" /></l>
                </th>
                <td>
                    <asp:TextBox ID="txtArea" runat="server" requerido="btnGuardarDependiente"></asp:TextBox>
                </td>
            </tr>



            <tr runat="server" id="trPr_Funcion" visible="false">
                <th>
                    <l>Especifique función principal</l>
                </th>
                <td>
                    <asp:TextBox ID="txtFuncion" runat="server" requerido="btnGuardarDependiente"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" id="tr_Mixto4" visible="false">
                <th>
                    <l>Salario mensual neto</l>
                </th>
                <td>
                    <asp:TextBox ID="moneytxtM_Salario" runat="server" ClientIDMode="Static" requerido="btnGuardarDependiente" MaxLength="19"></asp:TextBox>
                    <div id="divmoneytxtM_Salario"></div>
                </td>
            </tr>
            <tr runat="server" id="trPR_Sector" visible="false">
                <th>
                    <l>Sector</l>
                </th>
                <td>
                    <asp:DropDownList ID="cmbPR_Sector" runat="server" requerido="btnGuardarDependiente"></asp:DropDownList>
                </td>
            </tr>

            <tr runat="server" id="trPr_Proveedor" visible="false">
                <th>
                    <l>¿Es proveedor o contratista del gobierno?</l>
                </th>
                <td>
                    <asp:CheckBox ID="cbxProveedor" runat="server" Checked="false" CssClass="onoff" Text=" " />
                </td>
            </tr>

            <tr>
                <th>
                    <l>Observaciones</l>
                </th>
                <td>
                    <asp:TextBox ID="txtObservaciones" runat="server" MaxLength="1000" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>

        </tbody>
    </table>

</asp:Panel>
