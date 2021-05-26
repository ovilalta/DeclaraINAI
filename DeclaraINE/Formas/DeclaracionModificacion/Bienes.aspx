<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionModificacion/_Modificacion.master" AutoEventWireup="true" CodeBehind="Bienes.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionModificacion.Bienes" Culture="es-MX" UICulture="es-MX" %>

<%@ Register TagPrefix="ascx" TagName="Item" Src="~/Formas/DeclaracionModificacion/ItemBaja.ascx" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionModificacion/Adeudo.ascx" TagPrefix="ascx" TagName="Adeudo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionModificacion/ctrlDesincorpora.ascx" TagPrefix="ascx" TagName="ctrlDesincorpora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
             <asp:AlanQuestionBox runat="server" ID="QstBoxInm" NoText="No" YesText="Si" YesCssClass="" NoCssClass="" OnNo="QstBoxInm_No" OnYes="QstBoxInm_Yes" />
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server"></asp:Literal>
    </div>
     <asp:AlanQuestionBox runat="server" ID="QstBoxMue" NoText="No" YesText="Si" YesCssClass="" NoCssClass="" OnNo="QstBoxMue_No" OnYes="QstBoxMue_Yes" />
    <asp:AlanMessageBox runat="server" ID="MsgBox" />



    <div id="cuerpo">
        <asp:AlanQuestionBox runat="server" ID="QstBoxVehic" NoText="No" YesText="Si" YesCssClass="" NoCssClass="" OnNo="QstBoxVehic_No" OnYes="QstBoxVehic_Yes" />
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />

        <asp:Panel ID="pnlBienesInmuebles" runat="server">
            <div runat="server" id="grdInmueble">
                <div>
                    <asp:Button ID="btnAgregarInmuebles" runat="server" ToolTip="Agregar Inmueble" CssClass="big" Text="" OnClick="btnAgregarInmuebles_Click" />
                    <div class="a">
                        <label>
                            Agregar Inmueble
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

        <asp:Panel ID="pnlOtrosBienes" runat="server">
            <div runat="server" id="grdMueble">
                <div>
                    <asp:Button ID="btnAgregarMueble" runat="server" ToolTip="Agregar Bien" Text="" CssClass="big" OnClick="btnAgregarMueble_Click" />
                    <div class="a">
                        <label>
                            Agregar Otro Bien Mueble
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





        <asp:Panel ID="pnlVehiculos" runat="server">
            <div runat="server" id="grdVehiculos">
                <div>
                    <asp:Button ID="btnAgregarVehiculos" runat="server" ToolTip="Agregar vehículo" CssClass="big" Text="" OnClick="btnAgregarVehiculo_Click" />
                    <div class="a">
                        <label>
                            Agregar Vehículo
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

    </div>

     <asp:AlanModalPopUp runat="server" ID="mppBaja">
        <ContentTemplate>
            <ascx:ctrlDesincorpora runat="server" ID="ctrlDesincorpora1" />
            <div class="right">
                <br />
                
                
                <asp:Button ID="btnCerrarBaja" runat="server"  Text="Cerrar" OnClick="btnCerrarBaja_Click"  />
                <asp:Button ID="btnGuardarBaja" runat="server" Text="Guardar" OnClick="btnGuardarBaja_Click" />
                 <asp:Button ID="btnEliminarBaja" runat="server" Text="Eliminar"  OnClick="btnEliminarBaja_Click" />
                 <br />
                 <br />
                 <br />
                 <br />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>


    <asp:AlanModalPopUp runat="server" ID="mppInmuebles">
        <ContentTemplate>
            <table class="f">
                <tr>
                    <th>
                        <l>Tipo de bien</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmbTipoBien" runat="server" requerido="btnGuardarInmueble" OnSelectedIndexChanged="cmbTipoBienSelect_Change" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <th>
                        <l>Código Postal</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtcCodigoPostalInmueble" runat="server" MaxLength="5" requerido="btnGuardarInmueble" OnTextChanged="txtcCodigoPostalInmueble_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                  <th>
                      <l><b>País/Entidad/Municipio</b></l>
                  </th>
                  <td>
                      <asp:DropDownList ID="cmbPaisInmueble" runat="server"  OnSelectedIndexChanged="cmbPaisInmueble_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  </td>
                </tr>

                <tr>
                    <th>
                        <l><asp:Label ID="idLocal_colon" runat="server" Text="Localidad o Colonia"></asp:Label></l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtColoniaInmueble" runat="server" requerido="btnGuardarInmueble" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l><asp:Label runat="server" id="idEnt_Munic" Text="Ciudad/Localidad"></asp:Label> </l>
                    </th>
                    <td>                          
                        <asp:DropDownList ID="cmbEntidadFederativaInmueble" runat="server" CssClass="n2" OnSelectedIndexChanged="cmbEntidadFederativaInmueble_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:DropDownList ID="cmbMunicipioInmueble" runat="server" CssClass="n2" requerido="btnGuardarInmueble"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <th>
                        <l>Calle</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtCalleInmueble" runat="server"  requerido="btnGuardarInmueble" MaxLength="100"></asp:TextBox>
                    </td>
               </tr>
               <tr>
                    <th>
                        <l>Número Exterior</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtNumeroExteriorInmueble" runat="server" requerido="btnGuardarInmueble" MaxLength="50"></asp:TextBox>
                     </td>
                </tr>
                <tr>
                    <th>
                        <l>Número Interior</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtNumeroInteriorInmueble" runat="server"  MaxLength="50"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <th>
                        <l>Superficie del terreno m&sup2</l>
                    </th>
                    <td>
                        <asp:TextBox ID="numbertxtSuperficieTerreno" runat="server" requerido="btnGuardarInmueble" Enabled="true" MaxLength="19"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <th>
                        <l>Superficie de construcción m&sup2</l>
                    </th>
                    <td>
                        <asp:TextBox ID="numbertxtSuperficieConstruccion" runat="server" requerido="btnGuardarInmueble" Enabled="true" MaxLength="19"></asp:TextBox>
                    </td>
                </tr>

                <tr style="display:none">
                    <th>
                        <l>Tipo de uso</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmbTipoUso" runat="server" requerido="btnGuardarInmueble"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <th>
                        <l>Fecha de adquisición del inmueble</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtFechaAfquisicion" runat="server" Date="S" requerido="btnGuardarInmueble" MaxLength="10"></asp:TextBox>
                        <asp:CalendarExtender runat="server" ID="txtFechaAfquisicion_C" TargetControlID="txtFechaAfquisicion" Format="dd/MM/yyyy" />
                    </td>
                </tr>

                <tr>
                    <th>
                        <l>Valor de adquisición</l>
                    </th>
                    <td>
                        <asp:TextBox ID="moneytxtValorAdqusicion" runat="server" requerido="btnGuardarInmueble" ClientIDMode="Static" AutoCompleteType="None" MaxLength="19"></asp:TextBox>
                        <div id="divmoneytxtValorAdqusicion"></div>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Tipo de moneda</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlTipoMonedaInm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoMonedaInm_SelectedIndexChanged">
                        </asp:DropDownList>                       

                        <%--<asp:TextBox ID="txtTipoMoneda" runat="server" requerido="btnGuardarInmueble" MaxLength="128"></asp:TextBox>--%>
                        <asp:TextBox ID="txtTipoMoneda" runat="server"  MaxLength="128" Visible="false"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <th>
                        <l>Datos del Registro Público de <br /> la Propiedad. Folio Real u otro dato <br />que permita su identificación</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtRegistroPublicoPropiedad" runat="server" requerido="btnGuardarInmueble" MaxLength="256"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <th>
                        <l>¿El valor de adquisición del <br /> inmueble es conforme a?</l>
                    </th>
                    <td>

                        <asp:DropDownList ID="cmbValorAdquisicion" runat="server" requerido="btnGuardarInmueble"></asp:DropDownList>

                    </td>
                </tr>

                <tr>
                    <th>
                        <l>Forma de adquisición</l>
                    </th>
                    <td>

                        <asp:DropDownList ID="cmbFormaAdquisicionInmueble" runat="server" requerido="btnGuardarInmueble"></asp:DropDownList>

                    </td>
                </tr>

                <tr>
                    <th>
                        <l>Forma de pago</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmbFormaPagoInmueble" runat="server" requerido="btnGuardarInmueble"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <th>
                        <l>Titular del inmueble</l>
                    </th>
                    <td>
                        <div class="flista">
                            <asp:DropDownList ID="chbDependietesInm" runat="server"  OnSelectedIndexChanged="chbDependietesInm_SelectedIndexChanged"  AutoPostBack="true" Enabled="True">
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
                                   <asp:ListItem Text="Otro" Value= "24"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:CheckBoxList CssClass="table table-striped table-hover" ID="chbDependietes" Visible="false" runat="server" RepeatDirection="Vertical">
                               
                            </asp:CheckBoxList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Porcentaje de propiedad del declarante <br />conforme a escrituración o contrato</l>
                    </th>
                    <td>
                        <asp:TextBox ID="numbertxtPorcentajeDeclarante" runat="server" requerido="btnGuardarInmueble" Enabled="true" MaxLength="19"></asp:TextBox>
                    </td>
                </tr>
                 
                 <%-- <tr>
                        <th>
                            <l><b>TERCERO</b></l>
                        </th>

                </tr>--%>
                <tr>
                        <th>
                            <l>Tercero</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbTercero" runat="server" >
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Persona Física" Value="F"></asp:ListItem>
                                <asp:ListItem Text="Persona Moral"  Value="M"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                </tr>

                <tr>
                    <th>
                        <l>Nombre del tercero o terceros</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtNombreTercero" runat="server"  MaxLength="256"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>RFC del tercero</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtRFCTercero" runat="server"  MaxLength="13"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                        <th>
                            <l>Transmisor</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbTransmisor" runat="server">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Persona Física" Value="F"></asp:ListItem>
                                <asp:ListItem Text="Persona Moral"  Value="M"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                </tr>

                <tr>
                    <th>
                        <l>Nombre o razón social del <br />transmisor de la propiedad</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtNombreTransmisor" runat="server" MaxLength="256"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>RFC del transmisor de la propiedad</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtRFCTransmisor" runat="server" MaxLength="13"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Relación del transmisor de la <br /> propiedad con el titular</l>
                    </th>
                    <td>

                        <asp:DropDownList ID="cmbRelacionTransmisor" runat="server"></asp:DropDownList>

                    </td>
                </tr>           


                
              
                <tr runat="server" visible="true">
                     <th>
                            <l>En caso de baja <br />del inmueble incluir motivo</l>
                        </th>
                     <th>
                         <asp:DropDownList ID="cmbInmuMotivoBajaInmu"  runat="server"  >
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Venta" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Donación"  Value="2"></asp:ListItem>
                                <asp:ListItem Text="Siniestro"  Value="3"></asp:ListItem>
                                <asp:ListItem Text="[Otros] Especifique"  Value="99"></asp:ListItem>
                            </asp:DropDownList>
                     </th>
                </tr>

                <tr style="display:none">
                     <th>
                            <l><span style="color:red"><strong>Fecha de baja del inmueble</strong></span</l>
                        </th>
                     <td>
                         <asp:TextBox ID="txtF_BAJA_INM" runat="server"  Date="S" AutoPostBack="true" MaxLength="10"></asp:TextBox>
                         <asp:CalendarExtender runat="server" ID="txtF_BAJA_C" TargetControlID="txtF_BAJA_INM" Format="dd/MM/yyyy" />
                     </td>
                </tr>


                <tr  runat="server" visible="true" id="RenglonAdeudo">
                    <th>
                        <l>¿Existe algún adeudo vigente <br /> por el inmueble?</l>
                    </th>
                    <td>
                        <asp:CheckBox ID="cbxTieneAdeudo" runat="server" Checked="false" AutoPostBack="true" OnCheckedChanged="cbxTieneAdeudo_CheckedChanged" CssClass="onoff" Text=" " />
                        <table class="table table-striped table-hover" runat="server" visible="false" id="tablaAdeudo">
                            <tr>
                                <td>
                                    <asp:Button ID="btnEditarAdeudo1" runat="server" Text="" CssClass="mbtn" ToolTip="Editar" OnClick="btnEditarAdeudo1_Click" />
                                    <asp:Button ID="btnBorrarAdeudo1" runat="server" Text="" CssClass="mbtn" ToolTip="Eliminar" OnClick="btnBorrarAdeudo1_Click" />
                                    <asp:Literal ID="ltrAdeudo1" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr runat="server" visible="true" id="trAgregarAdeudo">
                                <td>
                                    <asp:Button ID="btnAgregarAdeudo" runat="server" Text="" CssClass="mbtn" ToolTip="Agregar adeudo" OnClick="btnAgregarAdeudo_Click" />
                                </td>
                            </tr>
                            <tr runat="server" visible="false" id="trAdeudo2">
                                <td>
                                    <asp:Button ID="btnEditarAdeudo2" runat="server" Text="" CssClass="mbtn" ToolTip="Editar" OnClick="btnEditarAdeudo2_Click" />
                                    <asp:Button ID="btnEliminarAdeudo2" runat="server" Text="" CssClass="mbtn" ToolTip="Eliminar" OnClick="btnBorrarAdeudo2_Click" />

                                    <asp:Literal ID="ltrAdeudo2" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                
                <tr>
                        <th>
                            <l>Aclaraciones/Observaciones</l>
                        </th>
                        <td>

                            <asp:TextBox ID="txtObservacionesBienesInmuebles" runat="server" onkeyDown="nombrecampo('txtObservacionesBienesInmuebles',this,'1000')"
                                    onkeyup="nombrecampo('txtObservacionesBienesInmuebles',this,'1000')" MaxLength="1000" TextMode="MultiLine" Width="100%"></asp:TextBox>

                        </td>
                    </tr>

            </table>
            <div class="right">
                <asp:Button ID="btnCerrarInmuebles" runat="server" ToolTip="Cerrar" Text="Cerrar" OnClick="btnCerrarInmuebles_Click" />
                <asp:Button ID="btnGuardarInmueble" runat="server" ToolTip="Guardar" Text="Guardar" OnClientClick="return CheckReq();" ClientIDMode="Static" OnClick="btnGuardarInmueble_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="mppMuebles">
        <ContentTemplate>
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>Tipo de bien</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="dpTipoBienMueble" runat="server" requerido="btnGuardarMueble"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l> Descripción general del bien</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtEspecifica" runat="server" requerido="btnGuardarMueble" MaxLength="1000"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Valor de adquisición</l>
                        </th>
                        <td>
                            <asp:TextBox ID="moneytxtValorAdqusicionMueble" runat="server" requerido="btnGuardarMueble" AutoCompleteType="None" ClientIDMode="Static" MaxLength="19"></asp:TextBox>
                            <div id="divmoneytxtValorAdqusicionMueble"></div>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Fecha de adquisición</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtF_ADQUISICION" runat="server" Date="S" requerido="btnGuardarMueble" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="txtF_ADQUISICION_C" TargetControlID="txtF_ADQUISICION" Format="dd/MM/yyyy" />
                        </td>
                    </tr>
                    <tr>
                    <th>
                        <l>Tipo de moneda</l>
                    </th>
                    <td>
                        
                        <asp:DropDownList ID="ddlTipoMonedaMue" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoMonedaMue_SelectedIndexChanged" />
                        <asp:TextBox ID="txtTipoMonedaMueble" runat="server"  Visible="false" MaxLength="128"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <th>
                        <l>Forma de adquisición</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmbFormaAdquisicionMueble" runat="server" requerido="btnGuardarMueble"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <th>
                        <l>Forma de pago</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmbFormaPagoMueble" runat="server" requerido="btnGuardarMueble"></asp:DropDownList>
                    </td>
                </tr>

                    <tr>
                        <th>
                            <l>Titular del bien</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="chbDependietesMue" runat="server"  OnSelectedIndexChanged="chbDependietesMue_SelectedIndexChanged"  AutoPostBack="true">
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
                            <asp:CheckBoxList CssClass="table table-striped table-hover" ID="chbDependietesMuebles" runat="server" Visible="false" RepeatDirection="Vertical"></asp:CheckBoxList>
                        </td>
                    </tr>

                <tr>
                        <th>
                            <l>Tercero</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbTerceroMueble" runat="server" >
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Persona Física" Value="F"></asp:ListItem>
                                <asp:ListItem Text="Persona Moral"  Value="M"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                </tr>

                <tr>
                    <th>
                        <l>Nombre del tercero o terceros</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtNombreTerceroMueble" runat="server"  MaxLength="256"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>RFC del tercero</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtRFCTerceroMueble" runat="server"  MaxLength="13"></asp:TextBox>
                    </td>
                </tr>
               <%-- <tr>
                        <th>
                           <l><b>TRANSMISOR</b></l>
                        </th>

                </tr>--%>
                <tr>
                        <th>
                            <l>Transmisor</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbTransmisorMueble" runat="server"  requerido="btnGuardarMueble" >
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Persona Física" Value="F"></asp:ListItem>
                                <asp:ListItem Text="Persona Moral"  Value="M"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                </tr>

                <tr>
                    <th>
                        <l>Nombre o razón social del <br />transmisor de la propiedad</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtNombreTransmisorMueble" runat="server" requerido="btnGuardarMueble" MaxLength="256"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>RFC del transmisor de la propiedad</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtRFCTransmisorMueble" runat="server" requerido="btnGuardarMueble" MaxLength="13"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Relación del transmisor del <br /> mueble con el titular</l>
                    </th>
                    <td>

                        <asp:DropDownList ID="cmbRelacionTransmisorMueble" requerido="btnGuardarMueble" runat="server" ></asp:DropDownList>

                    </td>
                </tr>
                <tr runat="server" visible="true">
                     <th>
                            <l>En caso de baja <br />del mueble incluir motivo</l>
                        </th>
                     <td>
                         <asp:DropDownList ID="cmbMotivoBaja" runat="server"  >
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Venta" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Donación"  Value="2"></asp:ListItem>
                                <asp:ListItem Text="Siniestro"  Value="3"></asp:ListItem>
                                <asp:ListItem Text="[Otros] Especifique"  Value="99"></asp:ListItem>
                            </asp:DropDownList>
                     </td>
                </tr>
                    <tr style="display: none">
                        <th>
                            <l>Fecha de baja del bien mueble</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtF_BAJA_MUEB" runat="server" Date="S" AutoPostBack="true" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtF_BAJA_MUEB" Format="dd/MM/yyyy" />
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Aclaraciones/Observaciones</l>
                        </th>
                        <td>

                            <asp:TextBox ID="txtObservacionesBienesMuebles" runat="server" onkeyDown="nombrecampo('txtObservacionesBienesMuebles',this,'1000')"
                                onkeyup="nombrecampo('txtObservacionesBienesMuebles',this,'1000')" MaxLength="1000" TextMode="MultiLine" Width="100%"></asp:TextBox>

                        </td>
                    </tr>

            </table>
            <div class="right">
                <asp:Button ID="btnCerrarMueble" runat="server" ToolTip="Cerrar" Text="Cerrar" OnClick="btnCerrarMueble_Click" />
                <asp:Button ID="btnGuardarMueble" runat="server" ToolTip="Cerrar" Text="Guardar" OnClientClick="return CheckReq();" ClientIDMode="Static" OnClick="btnGuardarMueble_Click" />
            </div>
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="mppVehículos">
        <ContentTemplate>
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>Tipo de Vehículo</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbTipoVehiculo" runat="server" requerido="btnGuardarVehiculo2"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Marca</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbMarca" runat="server" requerido="btnGuardarVehiculo2"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%--<l>Descripción del vehículo</l>--%>
                             <l>Modelo</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtTipo" runat="server" requerido="btnGuardarVehiculo2" MaxLength="255"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Fecha de adquisición</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtFechaAdquisicionVehiculo" runat="server" Date="S" requerido="btnGuardarVehiculo2" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="txtFechaAdquisicionVehiculo_C" TargetControlID="txtFechaAdquisicionVehiculo" Format="dd/MM/yyyy" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%--<l>Modelo</l>--%>
                            <l>Año</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="dpModelo" runat="server" requerido="btnGuardarVehiculo2"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Valor de adquisición</l>
                        </th>
                        <td>
                            <asp:TextBox ID="moneytxtValorAdquisicion" runat="server" requerido="btnGuardarVehiculo2" ClientIDMode="Static" AutoCompleteType="None" MaxLength="19"></asp:TextBox>
                            <div id="divmoneytxtValorAdquisicion"></div>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <th>
                            <l>Tipo de uso</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="dpTipoUso" runat="server" requerido="btnGuardarVehiculo2"></asp:DropDownList>
                        </td>
                    </tr>

                <tr>
                    <th>
                        <l>Tipo de moneda</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlTipoMonedaVeh" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoMonedaVeh_SelectedIndexChanged" >
                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                <asp:ListItem Text="MXN" Value="101"></asp:ListItem>
                                <asp:ListItem Text="USN"  Value="148"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtTipoMonedaVehiculo" runat="server"  Visible="false" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <th>
                        <l>Forma de adquisición</l>
                    </th>
                    <td>

                        <asp:DropDownList ID="cmbFormaAdquisicionVehiculo" runat="server" requerido="btnGuardarVehiculo2"></asp:DropDownList>

                    </td>
                </tr>

                <tr>
                    <th>
                        <l>Forma de pago</l>
                    </th>
                    <td>

                        <asp:DropDownList ID="cmbFormaPagoVehiculo" runat="server" requerido="btnGuardarVehiculo2"></asp:DropDownList>

                    </td>
                </tr>
                 <tr>
                    <th>
                        <l>Número de serie o Registro</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtNumeroSerie" runat="server" requerido="btnGuardarVehiculo2" MaxLength="256"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                        <th>
                            <l>Donde se encuentra registrado: País/Entidad</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbPaisVehiculo" runat="server" CssClass="n3" OnSelectedIndexChanged="cmbPaisVehiculo_SelectedIndexChanged" requerido="btnGuardarVehiculo2" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="cmbEntidadFederativaVehiculo" runat="server" CssClass="n3" OnSelectedIndexChanged="cmbEntidadFederativaVehiculo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Titular del vehículo</l>
                        </th>
                        <td>
                             <asp:DropDownList ID="chbDependietesVeh" runat="server"  OnSelectedIndexChanged="chbDependietesVeh_SelectedIndexChanged"  AutoPostBack="true">
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
                            <asp:CheckBoxList CssClass="table table-striped table-hover" ID="chbDependietesVehiculo" runat="server" Visible="false" RepeatDirection="Vertical"></asp:CheckBoxList>
                        </td>
                    </tr>

              <%--  <tr>
                        <th>
                            <l><b>TERCERO</b></l>
                        </th>

                </tr>--%>
                <tr>
                        <th>
                            <l>Tercero</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbTerceroVehiculo" runat="server" >
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Persona Física" Value="F"></asp:ListItem>
                                <asp:ListItem Text="Persona Moral"  Value="M"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                </tr>

                <tr>
                    <th>
                        <l>Nombre del tercero o terceros</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtNombreTerceroVehiculo" runat="server"  MaxLength="256"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>RFC del tercero</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtRFCTerceroVehiculo" runat="server"  MaxLength="13"></asp:TextBox>
                    </td>
                </tr>
               <%-- <tr>
                        <th>
                           <l><b>TRANSMISOR</b></l>
                        </th>

                </tr>--%>
                <tr>
                        <th>
                            <l>Transmisor</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbTransmisorVehiculo" runat="server" requerido="btnGuardarVehiculo2" >
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Persona Física" Value="F"></asp:ListItem>
                                <asp:ListItem Text="Persona Moral"  Value="M"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                </tr>

                <tr>
                    <th>
                        <l>Nombre o razón social del <br />transmisor de la propiedad</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtNombreTransmisorVehiculo" runat="server" requerido="btnGuardarVehiculo2"  MaxLength="256"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>RFC del transmisor de la propiedad</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtRFCTransmisorVehiculo" runat="server" requerido="btnGuardarVehiculo2"  MaxLength="13"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Relación del transmisor del <br /> Vehículo con el titular</l>
                    </th>
                    <td>

                        <asp:DropDownList ID="cmbRelacionTransmisorVehiculo" runat="server" requerido="btnGuardarVehiculo2" ></asp:DropDownList>

                    </td>
                </tr>


                    <tr runat="server" visible="true" id="RenglonAdeudoVeh">
                        <th>
                            <l>¿Existe algún adeudo vigente <br /> por el vehículo?</l>
                        </th>
                        <td>
                            <asp:CheckBox ID="cbxAdeudoVehiculo" runat="server" Checked="false" AutoPostBack="true" CssClass="onoff" Text=" " OnCheckedChanged="cbxAdeudoVehiculo_CheckedChanged" />
                            <table class="table table-striped table-hover" runat="server" visible="false" id="tblAdeudoVehiculo">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnEditarAdeudoVehiculo" runat="server" Text="" CssClass="mbtn" ToolTip="Editar" OnClick="btnModificarAdeudoVehiculo_Click" />
                                        <asp:Button ID="btnEliminarAdeudo" runat="server" Text="" CssClass="mbtn" ToolTip="Eliminar" OnClick="btnEliminarAdeudo_Click" />
                                        <asp:Literal ID="ltrAdeudoVehiculo" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server" visible="true">
                     <th>
                            <l>En caso de baja <br />del vehículo incluir motivo</l>
                        </th>
                     <th>
                         <asp:DropDownList ID="cmbVehiMotivoBaja"    runat="server"  >
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Venta" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Donación"  Value="2"></asp:ListItem>
                                <asp:ListItem Text="Siniestro"  Value="3"></asp:ListItem>
                                <asp:ListItem Text="[Otros] Especifique"  Value="99"></asp:ListItem>
                            </asp:DropDownList>
                     </th>
                   </tr>

                    <tr style="display:none">
                         <th>
                                <l>Fecha de baja del vehículo</l>
                            </th>
                         <td>
                             <asp:TextBox ID="txtF_BAJA_VEHIC" runat="server"  Date="S" AutoPostBack="true" MaxLength="10"></asp:TextBox>
                             <asp:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtF_BAJA_VEHIC" Format="dd/MM/yyyy" />
                         </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Aclaraciones/Observaciones</l>
                        </th>
                        <td>

                            <asp:TextBox ID="txtObservacionesVehiculos" runat="server" onkeyDown="nombrecampo('txtObservacionesVehiculos',this,'1000')"
                                    onkeyup="nombrecampo('txtObservacionesVehiculos',this,'1000')" MaxLength="1000" TextMode="MultiLine" Width="100%"></asp:TextBox>

                        </td>
                    </tr>

            </table>
            <div class="right">
                <asp:Button ID="btnCerrarMppVehículos" runat="server" ToolTip="Cerrar" Text="Cerrar" OnClick="btnCerrarMppVehículos_Click" />
                <asp:Button ID="btnGuardarVehiculo2" runat="server" Text="Guardar" OnClick="btnGuardarVehiculo2_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
                <asp:Button ID="btnGuardarVehiculo" runat="server" ToolTip="Cerrar" Text="Guardar" OnClientClick="return CheckReq();" Visible="false" ClientIDMode="Static" OnClick="btnGuardarVehiculo_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="mppAdeudos">
        <ContentTemplate>
            <ascx:Adeudo runat="server" ID="Adeudo" />
            <div class="right">
                <asp:Button ID="btnCerrarModal" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarModal_Click" />
                <asp:Button ID="btnGuardarAdeudo" runat="server" Text="Guardar" OnClick="btnGuardarAdeudo_Click" OnClientClick="return CheckReq();" />
               
                <asp:Button ID="btnCerrarModalVehiculo" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarModalVehiculo_Click" />
                <asp:Button ID="btnGuardarAdeudoVehiculo" runat="server" Text="Guardar" OnClick="btnGuardarAdeudoVehiculo_Click" OnClientClick="return CheckReq();" />

               
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>




    <br />
    <br />
    <br />


</asp:Content>
