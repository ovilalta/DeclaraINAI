<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionConclusion/_Conclusion.master" AutoEventWireup="true" CodeBehind="Bienes.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionConclusion.Bienes" Culture="es-MX" UICulture="es-MX" %>

<%@ Register TagPrefix="ascx" TagName="Item" Src="~/Formas/DeclaracionInicial/Item.ascx" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionConclusion/Adeudo.ascx" TagPrefix="ascx" TagName="Adeudo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionConclusion/ctrlDesincorpora.ascx" TagPrefix="ascx" TagName="ctrlDesincorpora" %>


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
                    <asp:Button ID="btnAgregarVehiculos" runat="server" ToolTip="Agregar Vehiculo" CssClass="big" Text="" OnClick="btnAgregarVehiculo_Click" />
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
                        <l>Ubicación del Inmueble</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtUbicacionInmueble" runat="server" requerido="btnGuardarInmueble" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Superficie del terreno m&sup;2</l>
                    </th>
                    <td>
                        <asp:TextBox ID="numbertxtSuperficieTerreno" runat="server" requerido="btnGuardarInmueble" Enabled="true" MaxLength="19"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Superficie de construcción m&sup;2</l>
                    </th>
                    <td>
                        <asp:TextBox ID="numbertxtSuperficieConstruccion" runat="server" requerido="btnGuardarInmueble" Enabled="true" MaxLength="19"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Fecha de adquisición</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtFechaAfquisicion" runat="server" Date="S" requerido="btnGuardarInmueble" MaxLength="10"></asp:TextBox>
                        <asp:CalendarExtender runat="server" ID="txtFechaAfquisicion_C" TargetControlID="txtFechaAfquisicion" Format="dd/MM/yyyy" StartDate='<%# new DateTime(1900,1,1) %>'  EndDate='<%# DateTime.Today.AddDays(-1) %>' />
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
                        <l>Tipo de uso</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmbTipoUso" runat="server" requerido="btnGuardarInmueble"></asp:DropDownList>
                    </td>
                </tr>


                <tr>
                    <th>
                        <l>Titular(es)</l>
                    </th>
                    <td>
                        <div class="flista">
                            <asp:CheckBoxList CssClass="table table-striped table-hover" ID="chbDependietes" runat="server" RepeatDirection="Vertical"></asp:CheckBoxList>
                        </div>
                    </td>
                </tr>

                <tr>
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
                            <l> Especificar tipo de bien</l>
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
                            <asp:TextBox ID="txtF_ADQUISICION" runat="server" Date="S" requerido="btnGuardarVehiculo" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="txtF_ADQUISICION_C" TargetControlID="txtF_ADQUISICION" Format="dd/MM/yyyy" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Titular(es)</l>
                        </th>
                        <td>
                            <asp:CheckBoxList CssClass="table table-striped table-hover" ID="chbDependietesMuebles" runat="server" RepeatDirection="Vertical"></asp:CheckBoxList>
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
                            <l>Descripción del vehículo</l>
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
                            <l>Modelo</l>
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
                    <tr>
                        <th>
                            <l>Tipo de uso</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="dpTipoUso" runat="server" requerido="btnGuardarVehiculo2"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Titular</l>
                        </th>
                        <td>
                            <asp:CheckBoxList CssClass="table table-striped table-hover" ID="chbDependietesVehiculo" runat="server" RepeatDirection="Vertical"></asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>¿Existe algún adeudo vigente <br /> por el vehiculo?</l>
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


      <asp:AlanModalPopUp runat="server" ID="mppBaja">
        <ContentTemplate>
            <ascx:ctrlDesincorpora runat="server" ID="ctrlDesincorpora1" />
            <div class="right">
                <asp:Button ID="btnCerrarBaja" runat="server"  Text="Cerrar" OnClick="btnCerrarBaja_Click"  />
                <asp:Button ID="btnGuardarBaja" runat="server" Text="Guardar" OnClick="btnGuardarBaja_Click" />
                 <asp:Button ID="btnEliminarBaja" runat="server" Text="Eliminar"  OnClick="btnEliminarBaja_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>



    <br />
    <br />
    <br />


</asp:Content>
