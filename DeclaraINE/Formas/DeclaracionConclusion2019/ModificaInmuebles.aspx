<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionConclusion/_Conclusion.master" AutoEventWireup="true" CodeBehind="ModificaInmuebles.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionConclusion.ModificaInmuebles" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionConclusion/ctrlGastos.ascx" TagPrefix="uc1" TagName="ctrlGastos" %>
<%@ Register Src="~/Formas/DeclaracionConclusion/Adeudo.ascx" TagPrefix="ascx" TagName="Adeudo" %>
<%@ Register Src="~/Formas/DeclaracionConclusion/ctrlDesincorpora.ascx" TagPrefix="ascx" TagName="ctrlDesincorpora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">

    <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si"  OnNo="QstBox_No" YesCssClass="" NoCssClass="" />
    <asp:AlanMessageBox runat="server" ID="MsgBox" />

    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Actualización de Bienes Inmuebles" EnableViewState="false"></asp:Literal>
    </div>

    <div id="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
        <div runat="server" id="grd">
        </div>
    </div>
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTituloN" runat="server" Text="Alta de Bienes Inmuebles" EnableViewState="false"></asp:Literal>
    </div>
    <div class="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperior3" />
        <div runat="server" id="grdInmueble">
            <div>
                <asp:Button ID="btnAgregarInmuebles" runat="server" ToolTip="Agregar Inmueble" CssClass="big" Text="" OnClick="btnAgregarInmuebles_Click" />
                <div class="a">
                    <label>
                        Agregar Inmueble
                    </label>
                    <br>
                    <se> </se>
                </div>
                <div class="b">
                </div>
            </div>
        </div>
    </div>

    <asp:AlanModalPopUp runat="server" ID="mppGasto" HeaderText="Reparaciones y Remodelaciones">

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
                        <l>Superficie del terreno m&sup2;</l>
                    </th>
                    <td>
                        <asp:TextBox ID="numbertxtSuperficieTerreno" runat="server" requerido="btnGuardarInmueble" Enabled="true" MaxLength="19"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Superficie de construcción m&sup2;</l>
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

                <%-- <tr>
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
                </tr>--%>
            </table>
            <div class="right">
                <asp:Button ID="btnCerrarInmuebles" runat="server" ToolTip="Cerrar" Text="Cerrar" OnClick="btnCerrarInmuebles_Click" />
                <asp:Button ID="btnGuardarInmueble" runat="server" ToolTip="Guardar" Text="Guardar" OnClientClick="return CheckReq();" ClientIDMode="Static" OnClick="btnGuardarInmueble_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="mppBaja" HeaderText="Venta, Siniestro o Donación de Inmueble">
        <ContentTemplate>
            <ascx:ctrlDesincorpora runat="server" ID="ctrlDesincorpora1" />
            <div class="right">
                <asp:Button ID="btnCerrarBaja" runat="server" Text="Cerrar" OnClick="btnCerrarBaja_Click" />
                <asp:Button ID="btnGuardarBaja" runat="server" Text="Guardar" OnClick="btnGuardarBaja_Click" />
                <asp:Button ID="btnEliminarBaja" runat="server" Text="Eliminar" OnClick="btnEliminarBaja_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>


    <asp:AlanModalPopUp runat="server" ID="mppInmuebleNuevo">
        <ContentTemplate>
            <table class="f">
                <tr>
                    <th>
                        <l>Tipo de bien</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmbTipoBienN" runat="server" requerido="btnGuardarPropiedad" OnSelectedIndexChanged="cmbTipoBienSelect_Change" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Ubicación del Inmueble</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtUbicacionInmuebleN" runat="server" requerido="btnGuardarPropiedad" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <th>
                        <l>Superficie del terreno m&sup;2</l>
                    </th>
                    <td>
                        <asp:TextBox ID="numbertxtSuperficieTerrenoN" runat="server" requerido="btnGuardarPropiedad" Enabled="true" MaxLength="19"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Superficie de construcción m&sup;2</l>
                    </th>
                    <td>
                        <asp:TextBox ID="numbertxtSuperficieConstruccionN" runat="server" requerido="btnGuardarPropiedad" Enabled="true" MaxLength="19"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Fecha de adquisición</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtFechaAfquisicionN" runat="server" Date="S" requerido="btnGuardarPropiedad" MaxLength="10"></asp:TextBox>
                        <asp:CalendarExtender runat="server" ID="txtFechaAfquisicionN_C" TargetControlID="txtFechaAfquisicionN" Format="dd/MM/yyyy" StartDate='<%# new DateTime(1900,1,1) %>' EndDate='<%# DateTime.Today.AddDays(-1) %>' />
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Valor de adquisición</l>
                    </th>
                    <td>
                        <asp:TextBox ID="moneytxtValorAdqusicionN" runat="server" requerido="btnGuardarPropiedad" ClientIDMode="Static" AutoCompleteType="None" MaxLength="19"></asp:TextBox>
                        <div id="divmoneytxtValorAdqusicionN"></div>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Tipo de uso</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmbTipoUsoN" runat="server" requerido="btnGuardarPropiedad"></asp:DropDownList>
                    </td>
                </tr>


                <tr>
                    <th>
                        <l>Titular(es)</l>
                    </th>
                    <td>
                        <div class="flista">
                            <asp:CheckBoxList CssClass="table table-striped table-hover" ID="chbDependietesN" runat="server" RepeatDirection="Vertical"></asp:CheckBoxList>
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
                <asp:Button ID="btnCerrarInmueblesN" runat="server" ToolTip="Cerrar" Text="Cerrar" OnClick="btnCerrarInmueblesN_Click" />
                <asp:Button ID="btnGuardarPropiedad" runat="server" ToolTip="Guardar" Text="Guardar" OnClientClick="return CheckReq();" ClientIDMode="Static" OnClick="btnGuardarInmuebleN_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="mppAdeudos" HeaderText="Adeudo">
        <ContentTemplate>
            <ascx:Adeudo runat="server" ID="Adeudo" />
            <div class="right">
                <asp:Button ID="btnCerrarModal" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarModal_Click" />
                <asp:Button ID="btnGuardarAdeudo" runat="server" Text="Guardar" OnClick="btnGuardarAdeudo_Click" OnClientClick="return CheckReq();" />

            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <br />
    <br />
    <br />

</asp:Content>
