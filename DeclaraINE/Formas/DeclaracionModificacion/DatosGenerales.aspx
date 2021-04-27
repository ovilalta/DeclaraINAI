<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionModificacion/_Modificacion.master" AutoEventWireup="true" CodeBehind="DatosGenerales.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionModificacion.DatosGenerales" EnableEventValidation="false" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionModificacion/ctrlDependiente.ascx" TagPrefix="uc1" TagName="ctrlDependiente" %>
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
                     <%-- $('#<%=txtcuenta.ClientID%>').val(Text = "Número de caractéres capturados:" + numeroDeC);--%>
                }
            }
        }
    </script> 
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server"></asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <asp:AlanQuestionBox runat="server" ID="QstBoxDep" NoText="No" YesText="Si" OnYes="QstBoxDep_Yes" OnNo="QstBoxDep_No" YesCssClass="" NoCssClass="" />
    <asp:AlanQuestionBox runat="server" ID="QstEjercicio" NoText="No" YesText="Si" OnYes="QstEjercicio_Yes" OnNo="QstEjercicio_No" YesCssClass="" NoCssClass="" />
    <div id="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
        <asp:Panel ID="pnlDatosPersonales" runat="server"> 
            <!--
            <div class="modal fade" id="mdAvisoModificacion" role="dialog">
                <div class="modal-dialog" style="margin-top: 10%;">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">AVISO DE MIGRACIÓN DE DATOS</h5>
                        </div>
                        <div class="modal-body" style="text-align: justify;"> 
                            Compañero(a) servidor(a) público(a), como observarás, la mayoría de los datos de tu anterior declaración relativos a generales, domicilio, empleo actual, pareja y dependientes económicos, han sido migrados y aparecerán en esta declaración patrimonial de modificación que estás llevando a cabo. En el caso de que tengas un nivel menor a jefe de departamento, esto facilitará tu declaración simplificada. En cualquier caso, <u>te suplicamos la revises y confirmes su vigencia</u> para esta declaración.
                            Para otros rubros, no fue posible migrar los datos, dado que en los nuevos formatos, aprobados por el Comité Coordinador del Sistema Nacional Anticorrupción, la información solicitada se desagrega o clasifica en forma distinta a la que se venía realizando, amén de contener muchos apartados novedosos, por lo que, a fin de proteger la integridad de tu información, será necesario la incorpores y/o <u>actualices</u> nuevamente.
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" onclick=" return CerrarModal();">Cerrar</button>
                        </div>
                        </div>
                    </div>
                </div>
            </div>-->

            <table class="f">
                <tbody>
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

                    <tr style="display: none">
                        <th>
                            <l>Fecha de Nacimiento </l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtfNacimiento" runat="server" Date="S" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>

                    <tr style="display: none">
                        <th>
                            <l>Sexo</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbcGenero" runat="server" requerido="btnSiguiente" OnSelectedIndexChanged="cmbcGenero_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Masculino" Value="M" Selected="True"></asp:ListItem>
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
                            <l>RFC</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtvIdNombre" runat="server" Enabled="false" CssClass="n2">
                            </asp:TextBox><asp:TextBox ID="txtvIdFecha" runat="server" Enabled="false" CssClass="n2"> </asp:TextBox>

                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>HOMOCLAVE</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtVIdHomoClave" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Correo Electrónico Institucional</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_CORREO_INE" runat="server" TextMode="Email" requerido="btnSiguiente" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>


                    <tr>
                        <th>
                            <l>Correo Electrónico Personal/Alterno</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_CORREO_PERSONAL" runat="server" TextMode="Email" requerido="btnSiguiente" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Número telefónico de Casa</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_TEL_PARTICULAR" runat="server" TextMode="Phone" requerido="btnSiguiente" MaxLength="10" CssClass="n2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Número de Celular Personal</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_TEL_CELULAR" runat="server" TextMode="Phone" MaxLength="10" CssClass="n2" requerido="btnSiguiente"></asp:TextBox>
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

                            <asp:DropDownList ID="cmbRegimenMatrimonial" runat="server" requerido="btnSiguiente" AutoPostBack="True"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>País de Nacimiento</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbnIdPaisNacimiento" runat="server" CssClass="n2" requerido="btnSiguiente" OnSelectedIndexChanged="cmbnIdPaisNacimiento_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="cmbcIdEntidadFederativaNacimiento" runat="server" CssClass="n2" Visible="false" AutoPostBack="true"></asp:DropDownList>
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
                            <l>País/Entidad Federativa/Municipio o Alcaldía</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbPaisDomParticular" runat="server" CssClass="n3" OnSelectedIndexChanged="cmbPaisDomParticular_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="cmbEntidadFederativaDomParticular" runat="server" CssClass="n3" OnSelectedIndexChanged="cmbEntidadFederativaDomParticular_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="cmbMunicipioDomParticular" runat="server" CssClass="n3" requerido="btnSiguiente"></asp:DropDownList>

                            <asp:TextBox ID="txtbEntidadFederativaDomicilioParticular" CssClass="n3" runat="server" requerido="btnSiguiente" MaxLength="100" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtMunicipioDomicilioParticular" CssClass="n3" runat="server" requerido="btnSiguiente" MaxLength="100" Visible="false"></asp:TextBox>

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
                            <l><asp:Label  id="idDomDeclarante" runat="server" Text=""></asp:Label></l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtColoniaParticular" runat="server" requerido="btnSiguiente" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>

                    <!-- OEVM Aquí estaba el CP-->
                    <tr>
                        <th>
                            <l>Aclaraciones/Observaciones</l>
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
                            <l>Ámbito Público</l>
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
                                <asp:ListItem Enabled="true" Selected="true" Text="Instituto Nacional de Transparencia, Acceso a la Información y Protección de Datos"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Unidad Administrativa</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbVID_PRIMER_NIVEL" runat="server" requerido="btnSiguiente" OnSelectedIndexChanged="txtVID_PRIMER_NIVEL_TextChanged" AutoPostBack="true"></asp:DropDownList>
                            <%-- <ajaxToolkit:ComboBox ID="cmbVID_PRIMER_NIVEL" runat="server"
                                AutoPostBack="true"
                                Width="100%"
                                DropDownStyle="DropDownList"
                                AutoCompleteMode="SuggestAppend"
                                CaseSensitive="False"
                                OnSelectedIndexChanged="txtVID_PRIMER_NIVEL_TextChanged"  CssClass="n1"
                                ItemInsertLocation="Append">
                            </ajaxToolkit:ComboBox>--%>
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
                            <l>Código de Puesto</l>
                            <a href="../../pdf1/CatalogoPuestosINAI.pdf" target="_blank">&nbsp<i class="fa fa-book fa-3" aria-hidden="true"></i>Catálogo de Puestos INAI</a>
                        </th>
                        <td>
                             <asp:DropDownList ID="cmbVID_CLAVEPUESTO" runat="server" requerido="btnSiguiente" OnSelectedIndexChanged="cmbVID_CLAVEPUESTO_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                           <%-- <ajaxToolkit:ComboBox ID="cmbVID_CLAVEPUESTO" runat="server"
                                AutoPostBack="true"
                                DropDownStyle="DropDownList"
                                AutoCompleteMode="SuggestAppend"
                                CaseSensitive="False"
                                Width="100%"
                                OnSelectedIndexChanged="cmbVID_CLAVEPUESTO_SelectedIndexChanged"
                                ItemInsertLocation="Append">
                            </ajaxToolkit:ComboBox>--%>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Indique si esta Contratado(a) por Honorarios</l>
                        </th>
                        <td>
                            <asp:GridView ID="grdPreguntas" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="V_RESTRICCION" Visible="false" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <uc1:SioNo runat="server" ID="cbx" CheckedNullable='<%# Eval("L_RESPUESTA") %>' AutoPostBack="true" />
                                            <asp:HiddenField ID="NID_RESTRICCION" runat="server" Value='<%# Eval("NID_RESTRICCION") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Nivel del Empleo Cargo o Comisión</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbVID_NIVEL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbVID_NIVEL_SelectedIndexChanged" requerido="btnSiguiente"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Empleo Cargo o Comisión</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_DENOMINACION_PUESTO" runat="server" Enabled="false" requerido="btnSiguiente"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Especifique la Función Principal</l>
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
                            <l>Fecha de posesión del empleo, cargo o comisión</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtF_POSESION" runat="server" date="S" requerido="btnSiguiente" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="txtF_POSESION_C" TargetControlID="txtF_POSESION" Format="dd/MM/yyyy" />

                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <th>
                            <l>Fecha de Ingreso al Instituto</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtF_INGRESO" runat="server" Date="S" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="txtF_INGRESO_C" TargetControlID="txtF_INGRESO" Format="dd/MM/yyyy" />
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
                        <th colspan="2">
                            <l>Domicilio del Empleo, Cargo o Comisión</l>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <l>País/Entidad/Municipio</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbNID_PAIS_LABORAL" runat="server" CssClass="n3" Enabled="false">
                                <asp:ListItem Selected="True" Text="MÉXICO" Value="1"></asp:ListItem>
                            </asp:DropDownList>

                            <asp:TextBox Enabled="false" Text="Ciudad de México" ID="Estado" value="33" runat="server" requerido="btnSiguiente" CssClass="n3" ></asp:TextBox>
                                
                            <asp:TextBox Enabled="false" Text="Coyoacán" ID="Alcaldia" value="003" runat="server" requerido="btnSiguiente" CssClass="n3" ></asp:TextBox>
                               
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Calle/No. Exterior/No. Interior</l>
                        </th>
                        <td>
                            <asp:TextBox Enabled="false" Text="Insurgentes Sur" ID="txtV_DOMICILIO_LABORAL" runat="server" requerido="btnSiguiente" CssClass="n3" MaxLength="150"></asp:TextBox>
                            <asp:TextBox Enabled="false" Text="3211" ID="txtNumExteriorDOMICILIO_LABORAL" runat="server" requerido="btnSiguiente" CssClass="n3" MaxLength="15"></asp:TextBox>
                            <asp:TextBox Enabled="false" ID="txtNumInteriorDOMICILIO_LABORAL" runat="server" CssClass="n3" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Colonia/Localidad</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_COLONIA_LABORAL" text="Insurgentes Cuicuilco" runat="server" requerido="btnSiguiente" MaxLength="255" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Código Postal</l>
                        </th>
                        <td>
                            <asp:TextBox ID="C_CODIGO_POSTAL" text="04530" runat="server" MaxLength="5" OnTextChanged="C_CODIGO_POSTAL_TextChanged" AutoPostBack="true" requerido="btnSiguiente" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th>
                            <l>Correo Electrónico</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtV_CORREO_LABORAL" runat="server" TextMode="Email" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>


                    <tr>
                        <th>
                            <%--<l>Aclaraciones/Observaciones (máximo permitidos: 1000)<asp:TextBox ID="txtcuenta"  runat="server" BackColor="#EEEEEE" ReadOnly="True"></asp:TextBox> </l>--%>
                            <l>Aclaraciones/Observaciones </l>

                        </th>
                        <td>
                            <asp:TextBox ID="txtObservaciones" runat="server" onkeyDown="nombrecampo('txtObservaciones',this,'1000')"
                                onkeyup="nombrecampo('txtObservaciones',this,'1000')" MaxLength="1000" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>¿Cuenta con otro empleo, cargo o comisión en el servicio público distinto al declarado?</l>
                        </th>
                        <td>
                            <div class="subtitulo">
                                <asp:Literal ID="Literal1" runat="server"> </asp:Literal>
                                <asp:CheckBox ID="cbxOtroEmpleo" runat="server" Checked="false" AutoPostBack="true" OnCheckedChanged="cbxOtroEmpleo_CheckedChanged" CssClass="onoff" Text=" " />
                            </div>

                        </td>
                    </tr>
                </tbody>
            </table>
            <div id="DivOtroEmpleo" runat="server" visible="false">
                <table class="f">
                    <tbody>
                        <tr>
                            <th>
                                <l>Nivel / Orden de gobierno </l>
                            </th>
                            <td>
                                <asp:CheckBoxList CssClass="table table-striped table-hover" ID="chbOtroOrdenGobierno" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
                                <asp:RadioButtonList ID="rbtOtroOrdenGobierno" CssClass="table table-striped table-hover" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <l>Ámbito Público</l>
                            </th>
                            <td>
                                <asp:RadioButtonList ID="rbtAmbitoPublico" CssClass="table table-striped table-hover" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>

                            </td>
                        </tr>
                        <tr>
                            <th>
                                <l>Nombre del ente público</l>
                            </th>
                            <td>
                                <asp:TextBox ID="txtCargoEntePublico" runat="server" requerido="btnSiguiente"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <l>Área de adscripción</l>
                            </th>
                            <td>
                                <asp:TextBox ID="txtCargoAreaAdscripcion" runat="server" requerido="btnSiguiente"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <l>Empleo, cargo o comisión</l>
                            </th>
                            <td>
                                <asp:TextBox ID="txtCargoEmpleo" runat="server" requerido="btnSiguiente"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <th>
                                <l>¿Está contratado por Honorarios?</l>
                            </th>
                            <td>
                                <div class="subtitulo">
                                    <asp:Literal ID="Literal2" runat="server"> </asp:Literal>
                                    <asp:CheckBox ID="cbxCargoHonorarios" runat="server" Checked="false" AutoPostBack="true" CssClass="onoff" Text=" " />
                                </div>

                            </td>
                        </tr>
                        <tr>
                            <th>
                                <l>Nivel del empleo cargo o comisión</l>
                            </th>
                            <td>
                                <asp:TextBox ID="txtCargoNivel" runat="server" requerido="btnSiguiente"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <l>Especifique la Función Principal</l>
                            </th>
                            <td>
                                <asp:TextBox ID="txtCargoFuncion" runat="server" requerido="btnSiguiente"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <l>Fecha de posesión del empleo, cargo o comisión</l>
                            </th>
                            <td>
                                <asp:TextBox ID="txtCargoFechaPosesion" runat="server" Date="S" MaxLength="10"></asp:TextBox>
                                <asp:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtCargoFechaPosesion" Format="dd/MM/yyyy" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <l>Teléfono de oficina y extensión </l>
                            </th>
                            <td>
                                <asp:TextBox ID="txtCARGOV_TELEFONO" runat="server" requerido="btnSiguiente" MaxLength="15" CssClass="n2"></asp:TextBox>
                                <asp:TextBox ID="txtCARGOV_TELEFONO_EXT" runat="server" MaxLength="15" CssClass="n4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <l>País/Entidad/Municipio</l>
                            </th>
                            <td>
                                <asp:DropDownList ID="cmbCARGO_NID_PAIS_OTRO" runat="server" OnSelectedIndexChanged="cmbCARGO_NID_PAIS_OTRO_SelectedIndexChanged" AutoPostBack="true" CssClass="n3">
                                </asp:DropDownList>
                                <asp:DropDownList ID="cmbCARGO_CID_ENTIDAD_FEDERATIVA_OTRO" runat="server" CssClass="n3" OnSelectedIndexChanged="cmbCARGO_CID_ENTIDAD_FEDERATIVA_OTRO_SelectedIndexChanged" AutoPostBack="true" requerido="btnSiguiente"></asp:DropDownList>
                                <asp:DropDownList ID="cmbCARGO_CID_MUNICIPIO_OTRO" runat="server" CssClass="n3" requerido="btnSiguiente"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <l>Calle/No. Exterior/No. Interior</l>
                            </th>
                            <td>
                                <asp:TextBox ID="txtCargoV_DOMICILIO_O" runat="server" requerido="btnSiguiente" CssClass="n3" MaxLength="150"></asp:TextBox>
                                <asp:TextBox ID="txtCargoNumExteriorDOMICILIO_O" runat="server" requerido="btnSiguiente" CssClass="n3" MaxLength="15"></asp:TextBox>
                                <asp:TextBox ID="txtCargoNumInteriorDOMICILIO_O" runat="server" CssClass="n3" MaxLength="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <l><asp:Label id="lblCargoDescribe" runat="server" Text="Localidad/Colonia"></asp:Label></l>
                            </th>
                            <td>
                                <asp:TextBox ID="txtCargoColonia" requerido="btnSiguiente" runat="server" MaxLength="200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="txtCargoExtrangero" runat="server" visible="false">
                            <th>
                                <l>Estado o Provincia</l>
                            </th>
                            <td>
                                <asp:TextBox ID="txtCargoEstado" requerido="btnSiguiente" runat="server" MaxLength="100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <l>Código Postal</l>
                            </th>
                            <td>
                                <asp:TextBox ID="txtCARGO_CODIGO_POSTAL_O" runat="server" MaxLength="5" AutoPostBack="true" requerido="btnSiguiente"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <l>Aclaraciones/Observaciones <%--<asp:TextBox ID="txtcuenta_O"  runat="server" BackColor="#EEEEEE" ReadOnly="True"></asp:TextBox>--%> </l>


                            </th>
                            <td>
                                <asp:TextBox ID="txtCargoObserva" runat="server" onkeyDown="nombreOtro('txtCargoObserva',this,'1000')"
                                    onkeyup="nombrecampo('txtCargoObserva',this,'1000')" MaxLength="1000" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlDomicilioLaboral" runat="server" Visible="false">
            <table class="f">
                <tbody>
                </tbody>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlDependientes" runat="server" Visible="false">
            <div runat="server" id="grd">
                <div>
                    <asp:Button ID="btnAgregarDependiente" runat="server" CssClass="big" OnClick="btnAgregarDependientePareja_Click" />
                    <div class="a">
                        <label>
                            Agregar
                        </label>
                        <br>
                        <se>
                        </se>
                    </div>
                    <div class="b">
                    </div>
                </div>
            </div>
            <div class="subtitulo">
                Apartado 7. Dar de Alta Datos del Dependiente económico
            </div>
            <div runat="server" id="grdx7">
                <div>
                    <asp:Button ID="Button1" runat="server" CssClass="big" OnClick="btnAgregarDependiente_Click" />
                    <div class="a">
                        <label>
                            Agregar
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
                    <asp:Button ID="btnGuardarDependiente" runat="server" Text="Guardar" OnClientClick="return CheckReq();" OnClick="btnGuardaDependiente_Click" ClientIDMode="Static" />
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




    <script>
        function CerrarModal() {
            $('#mdAvisoModificacion').modal('toggle');
        }
    </script>
</asp:Content>
