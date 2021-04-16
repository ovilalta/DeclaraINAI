<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionConclusion/_Conclusion.master" AutoEventWireup="true" CodeBehind="ModificaVehiculos.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionConclusion.ModificaVehiculos" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionConclusion/ctrlGastos.ascx" TagPrefix="uc1" TagName="ctrlGastos" %>
<%@ Register Src="~/Formas/DeclaracionConclusion/ctrlDesincorpora.ascx" TagPrefix="ascx" TagName="ctrlDesincorpora" %>
<%@ Register Src="~/Formas/DeclaracionConclusion/Adeudo.ascx" TagPrefix="ascx" TagName="Adeudo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
            <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si" OnNo="QstBox_No" YesCssClass="" NoCssClass="" />
    <asp:AlanMessageBox runat="server" ID="MsgBox" />

    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Actualización de Vehículos" EnableViewState="false"></asp:Literal>
    </div>

    <div id="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
        <div runat="server" id="grd">
        </div>
    </div>

    <div class="subtitulo">
        <asp:Literal ID="ltrSubTituloN" runat="server" Text="Alta de Vehículos" EnableViewState="false"></asp:Literal>
    </div>
    <div class="cuerpo">
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
    </div>

    <asp:AlanModalPopUp runat="server" ID="mppGasto" HeaderText="Reparaciones Mayores">

        <ContentTemplate>
            <asp:AlanAlert runat="server" ID="AlertaSuperior1" />
            <uc1:ctrlGastos runat="server" ID="ctrlGastos1" />
            <div class="right">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnAgregar" runat="server" Text="Nuevo" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" OnClick="btnXGasto_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="mppVehículos">
        <ContentTemplate>
            <table class="f">
                <tbody>
                    <%-- <tr>
                        <th>
                            <l>Tipo de Vehículo</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbTipoVehiculo" runat="server" requerido="btnGuardarVehiculo2"></asp:DropDownList>
                        </td>
                    </tr>--%>
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
                    <%-- <tr>
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
                    </tr>--%>
            </table>
            <div class="right">
                <asp:Button ID="btnCerrarMppVehículos" runat="server" ToolTip="Cerrar" Text="Cerrar" OnClick="btnCerrarMppVehículos_Click" />
                <asp:Button ID="btnGuardarVehiculo" runat="server" ToolTip="Cerrar" Text="Guardar" OnClientClick="return CheckReq();" ClientIDMode="Static" OnClick="btnGuardarVehiculo_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="mppBaja" HeaderText="Venta, Siniestro o Donación de Vehículo">
        <ContentTemplate>
            <ascx:ctrlDesincorpora runat="server" ID="ctrlDesincorpora1" />
            <div class="right">
                <asp:Button ID="btnCerrarBaja" runat="server" Text="Cerrar" OnClick="btnCerrarBaja_Click" />
                <asp:Button ID="btnGuardarBaja" runat="server" Text="Guardar" OnClick="btnGuardarBaja_Click" />
                <asp:Button ID="btnEliminarBaja" runat="server" Text="Eliminar" OnClick="btnEliminarBaja_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>
    <asp:AlanModalPopUp runat="server" ID="mppVehículosN">
        <ContentTemplate>
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>Tipo de Vehículo</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbTipoVehiculoN" runat="server" requerido="btnGuardarVehiculo2N"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Marca</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbMarcaN" runat="server" requerido="btnGuardarVehiculo2N"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Descripción del vehículo</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtTipoN" runat="server" requerido="btnGuardarVehiculo2N" MaxLength="255"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Fecha de adquisición</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtFechaAdquisicionVehiculoN" runat="server" Date="S" requerido="btnGuardarVehiculo2N" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="txtFechaAdquisicionVehiculoN_C" TargetControlID="txtFechaAdquisicionVehiculoN" Format="dd/MM/yyyy" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Modelo</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="dpModeloN" runat="server" requerido="btnGuardarVehiculo2N"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Valor de adquisición</l>
                        </th>
                        <td>
                            <asp:TextBox ID="moneytxtValorAdquisicionN" runat="server" requerido="btnGuardarVehiculo2N" ClientIDMode="Static" AutoCompleteType="None" MaxLength="19"></asp:TextBox>
                            <div id="divmoneytxtValorAdquisicionN"></div>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Tipo de uso</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="dpTipoUsoN" runat="server" requerido="btnGuardarVehiculo2N"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Titular</l>
                        </th>
                        <td>
                            <asp:CheckBoxList CssClass="table table-striped table-hover" ID="chbDependietesVehiculoN" runat="server" RepeatDirection="Vertical"></asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
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
            </table>
            <div class="right">
                <asp:Button ID="btnCerrarMppVehículosN" runat="server" ToolTip="Cerrar" Text="Cerrar" OnClick="btnCerrarMppVehículosN_Click" />
                <asp:Button ID="btnGuardarVehiculo2N" runat="server" Text="Guardar" OnClick="btnGuardarVehiculo2N_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
                <asp:Button ID="btnGuardarVehiculoN" runat="server" ToolTip="Cerrar" Text="Guardar" OnClientClick="return CheckReq();" Visible="false" ClientIDMode="Static" OnClick="btnGuardarVehiculoN_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>
    <asp:AlanModalPopUp runat="server" ID="mppAdeudos" HeaderText="Adeudo">
        <ContentTemplate>
            <ascx:Adeudo runat="server" ID="Adeudo" />
            <div class="right">
                <%--<asp:Button ID="btnCerrarModal" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarModal_Click" />
                <asp:Button ID="btnGuardarAdeudo" runat="server" Text="Guardar" OnClick="btnGuardarAdeudo_Click" OnClientClick="return CheckReq();" />--%>

                <asp:Button ID="btnCerrarModalVehiculo" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarModalVehiculo_Click" />
                <asp:Button ID="btnGuardarAdeudoVehiculo" runat="server" Text="Guardar" OnClick="btnGuardarAdeudoVehiculo_Click" OnClientClick="return CheckReq();" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>
    <br />
    <br />
    <br />
</asp:Content>
