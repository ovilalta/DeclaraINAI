﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionInicial/_Inicial.master" AutoEventWireup="true" CodeBehind="DatosGenerales.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionInicial.DatosGenerales" EnableEventValidation="false" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionInicial/ctrlDependiente.ascx" TagPrefix="uc1" TagName="ctrlDependiente" %>
<%@ Register Src="~/Formas/SioNo.ascx" TagPrefix="uc1" TagName="SioNo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
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
    <style>
        .onoff label::before {
            margin-left: 6px !important;
        }
    </style>
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server"></asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <asp:AlanQuestionBox runat="server" ID="QstBoxDep" NoText="No" YesText="Si" OnYes="QstBoxDep_Yes" OnNo="QstBoxDep_No" YesCssClass="" NoCssClass="" />
    <asp:AlanQuestionBox runat="server" ID="QstEjercicio" NoText="No" YesText="Si" OnYes="QstEjercicio_Yes" OnNo="QstEjercicio_No" YesCssClass="" NoCssClass="" />
    <div id="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
        <asp:Panel ID="pnlDatosPersonales" runat="server">
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>Primer Apellido</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtvPrimerA" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Segundo Apellido</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtvSegundoA" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Nombre(s)</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtvNombre" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Fecha de Nacimiento</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtfNacimiento" runat="server" Date="S" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>RFC</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtvIdNombre" runat="server" Enabled="false" CssClass="n3">
                            </asp:TextBox><asp:TextBox ID="txtvIdFecha" runat="server" Enabled="false" CssClass="n3">
                            </asp:TextBox><asp:TextBox ID="txtVIdHomoClave" runat="server" Enabled="false" CssClass="n3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Sexo</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbcGenero" runat="server" requerido="btnSiguiente" OnSelectedIndexChanged="cmbcGenero_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                                <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>CURP</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtvCURP" runat="server" requerido="btnSiguiente" MaxLength="18"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>País de Nacimiento</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbnIdPaisNacimiento" runat="server" CssClass="n2" requerido="btnSiguiente" OnSelectedIndexChanged="cmbnIdPaisNacimiento_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="cmbcIdEntidadFederativaNacimiento" runat="server" CssClass="n2" requerido="btnSiguiente" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Nacionalidad</l>
                        </th>
                        <td>

                            <asp:DropDownList ID="cmbNacionalidad" runat="server" requerido="btnSiguiente"></asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Situación Personal/Estado Civil</l>
                        </th>
                        <td>

                            <asp:DropDownList ID="cmbEstadoCivil" runat="server" requerido="btnSiguiente"></asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Régimen matrimonial</l>
                        </th>
                        <td>

                            <asp:DropDownList ID="cmbRegimenMatrimonial" runat="server" requerido="btnSiguiente" AutoPostBack="True" ></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Aclaraciones/Observaciones</l>
                        </th>
                        <td>

                            <asp:TextBox ID="txtObservacionesDatosGenerales" runat="server" onkeyDown="nombrecampo('txtObservacionesDatosGenerales',this,'1000')"
                                onkeyup="nombrecampo('txtObservacionesDatosGenerales',this,'1000')" MaxLength="1000" TextMode="MultiLine" Width="100%"></asp:TextBox>

                        </td>
                    </tr>





                </tbody>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlDomicilioParticular" runat="server">
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>Código Postal</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtcCodigoPostal" runat="server" MaxLength="5" requerido="btnSiguiente" OnTextChanged="txtcCodigoPostal_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>País/Entidad/Municipio</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbPaisDomimicioParticular" runat="server" CssClass="n3" OnSelectedIndexChanged="cmbPaisDomimicioParticular_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="cmbEntidadFederativaDomicilioParticular" runat="server" CssClass="n3" OnSelectedIndexChanged="cmbEntidadFederativaDomicilioParticular_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="cmbMunicipioDomicilioParticular" runat="server" CssClass="n3" requerido="btnSiguiente"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Localidad o Colonia</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtColoniaParticular" runat="server" requerido="btnSiguiente" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Calle</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtCalleDomParticular" runat="server" requerido="btnSiguiente" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Número Exterior</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtNumeroExteriorDomParticular" runat="server" requerido="btnSiguiente" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Número Interior</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtNumeroInteriorDomParticular" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Correo Electrónico Personal</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_CORREO_PERSONAL" runat="server" TextMode="Email" requerido="btnSiguiente" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Teléfono Particular</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_TEL_PARTICULAR" runat="server" TextMode="Phone" requerido="btnSiguiente" MaxLength="10" CssClass="n2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Teléfono Celular</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_TEL_CELULAR" runat="server" TextMode="Phone" MaxLength="10" CssClass="n2" requerido="btnSiguiente"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Observaciones</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtE_OBSERVACIONES" runat="server" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlCargo" runat="server" Visible="false">
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>Nivel/Orden de Gobierno</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbOrdenGobierno" runat="server" Enabled="false" requerido="btnSiguiente">
                                <asp:ListItem Enabled="true" Selected="true" Text="Federal"></asp:ListItem>
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Ambito Publico</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbAmbitoPublico" runat="server" Enabled="false" requerido="btnSiguiente">
                                <asp:ListItem Enabled="true" Selected="true" Text="Órgano Autónomo"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Nombre del Ente Público</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbEnte" runat="server" Enabled="false" requerido="btnSiguiente">
                                <asp:ListItem Enabled="true" Selected="true" Text="Instituto Nacional Electoral"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l> Clave de Puesto</l>
                        </th>
                        <td>
                            <ajaxToolkit:ComboBox ID="cmbVID_CLAVEPUESTO" runat="server"
                                AutoPostBack="true"
                                DropDownStyle="DropDownList"
                                AutoCompleteMode="SuggestAppend"
                                CaseSensitive="False"
                                Width="100%"
                                OnSelectedIndexChanged="cmbVID_CLAVEPUESTO_SelectedIndexChanged"
                                ItemInsertLocation="Append">
                            </ajaxToolkit:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Clave de Nivel</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbVID_NIVEL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbVID_NIVEL_SelectedIndexChanged" requerido="btnSiguiente"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Denominación del Puesto</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_DENOMINACION_PUESTO" runat="server" Enabled="false" requerido="btnSiguiente"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Especifique la Fúnción Principal</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txt_DENOMINACION_CARGO" runat="server" requerido="btnSiguiente" MaxLength="127"></asp:TextBox>
                            <ajaxToolkit:AutoCompleteExtender
                                runat="server"
                                ID="txt_DENOMINACION_CARGO_AutoCompleteExtender"
                                TargetControlID="txt_DENOMINACION_CARGO"
                                ServiceMethod="CAT_DENOMINACION"
                                ServicePath="autocomplete.asmx"
                                MinimumPrefixLength="1"
                                CompletionInterval="1000">
                            </ajaxToolkit:AutoCompleteExtender>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Unidad Administrativa</l>
                        </th>
                        <td>
                            <ajaxToolkit:ComboBox ID="cmbVID_PRIMER_NIVEL" runat="server"
                                AutoPostBack="true"
                                Width="100%"
                                DropDownStyle="DropDownList"
                                AutoCompleteMode="SuggestAppend"
                                CaseSensitive="False"
                                OnSelectedIndexChanged="txtVID_PRIMER_NIVEL_TextChanged"
                                ItemInsertLocation="Append">
                            </ajaxToolkit:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Área de Adscripción</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbVID_SEGUNDO_NIVEL" runat="server" requerido="btnSiguiente"></asp:DropDownList>
                        </td>
                    </tr>


                    <tr>
                        <th>
                            <l>Fecha de Toma de Posesión del Cargo Actual</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtF_POSESION" runat="server" date="S" requerido="btnSiguiente" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="txtF_POSESION_C" TargetControlID="txtF_POSESION" Format="dd/MM/yyyy" />

                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Fecha de Ingreso al Instituto</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtF_INGRESO" runat="server" Date="S" requerido="btnSiguiente" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="txtF_INGRESO_C" TargetControlID="txtF_INGRESO" Format="dd/MM/yyyy" />
                        </td>
                    </tr>
                    <tr>
                        <th colspan="2">
                            <l>Datos Adicionales Relativos al Cargo</l>
                        </th>
                    </tr>
                    <tr>
                        <th colspan="2">
                            <asp:GridView ID="grdPreguntas" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="V_RESTRICCION" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <uc1:SioNo runat="server" ID="cbx" CheckedNullable='<%# Eval("L_RESPUESTA") %>' />
                                            <asp:HiddenField ID="NID_RESTRICCION" runat="server" Value='<%# Eval("NID_RESTRICCION") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </th>
                    </tr>
                </tbody>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlDomicilioLaboral" runat="server" Visible="false">
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>Código Postal</l>
                        </th>
                        <td>
                            <asp:TextBox ID="C_CODIGO_POSTAL" runat="server" MaxLength="5" OnTextChanged="C_CODIGO_POSTAL_TextChanged" AutoPostBack="true" requerido="btnSiguiente"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>País/Entidad/Municipio</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbNID_PAIS_LABORAL" runat="server" OnSelectedIndexChanged="cmbNID_PAIS_LABORAL_SelectedIndexChanged" CssClass="n3" Enabled="false">
                                <asp:ListItem Selected="True" Text="MÉXICO" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="cmbCID_ENTIDAD_FEDERATIVA_LABORAL" runat="server" CssClass="n3" OnSelectedIndexChanged="cmbCID_ENTIDAD_FEDERATIVA_LABORAL_SelectedIndexChanged" AutoPostBack="true" requerido="btnSiguiente"></asp:DropDownList>
                            <asp:DropDownList ID="cmbCID_MUNICIPIO_LABORAL" runat="server" CssClass="n3" requerido="btnSiguiente"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Localidad o Colonia</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_COLONIA_LABORAL" runat="server" requerido="btnSiguiente" MaxLength="255"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Calle/No. Exterior/No. Interior</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_DOMICILIO_LABORAL" runat="server" requerido="btnSiguiente" CssClass="n3" MaxLength="150"></asp:TextBox>
                            <asp:TextBox ID="txtNumExteriorDOMICILIO_LABORAL" runat="server" requerido="btnSiguiente" CssClass="n3" MaxLength="15"></asp:TextBox>
                            <asp:TextBox ID="txtNumInteriorDOMICILIO_LABORAL" runat="server" CssClass="n3" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>

                    <%--<tr>
                        <th>
                            <l>Calle y Número(s)</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_DOMICILIO_LABORAL" runat="server" TextMode="MultiLine" requerido="btnSiguiente"  MaxLength="500"></asp:TextBox>
                        </td>
                    </tr>--%>

                    <tr>
                        <th>
                            <l>Correo Electrónico</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_CORREO_LABORAL" runat="server" TextMode="Email" requerido="btnSiguiente" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Teléfono + Extensión</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_TELEFONO_LABORAL1" runat="server" requerido="btnSiguiente" MaxLength="15" CssClass="n2"></asp:TextBox>
                            <asp:TextBox ID="txtV_TELEFONO_LABORAL2" runat="server" MaxLength="15" CssClass="n4"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Aclaraciones/Observaciones (máximo permitidos: 1000)<asp:TextBox ID="txtcuenta"  runat="server" BackColor="#EEEEEE" ReadOnly="True"></asp:TextBox> </l>


                        </th>
                        <td>
                            <asp:TextBox ID="txtObservaciones" runat="server" onkeyDown="nombrecampo('txtObservaciones',this,'1000')"
                                onkeyup="nombrecampo('txtObservaciones',this,'1000')" MaxLength="1000" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlDependientes" runat="server" Visible="false">
            <div runat="server" id="grd">
                <div>
                    <asp:Button ID="btnAgregarDependiente" runat="server" CssClass="big" OnClick="btnAgregarDependiente_Click" />
                    <div class="a">
                        <label>
                            Agregar Dependiente
                        </label>
                        <br>
                        <se>
                        </se>
                    </div>
                    <div class="b">
                    </div>
                </div>
            </div>




        </asp:Panel>

        <asp:AlanModalPopUp runat="server" ID="mdlDependiente">
            <ContentTemplate>
                <uc1:ctrlDependiente runat="server" ID="ctrlDependiente1" />
                <div class="right">
                    <asp:Button ID="btnCerrar" runat="server" Text="Cancelar" OnClick="btnCerrar_Click" />
                    <asp:Button ID="btnGuardarDependiente" runat="server" Text="Guardar" OnClientClick="return CheckReq();" OnClick="btnGuardaDependiente_Click" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnGuardarDependiente" />
            </Triggers>
        </asp:AlanModalPopUp>

        <asp:AlanAlert runat="server" ID="AlertaInferior" />
    </div>
    <br />
    <br />
    <br />

</asp:Content>
