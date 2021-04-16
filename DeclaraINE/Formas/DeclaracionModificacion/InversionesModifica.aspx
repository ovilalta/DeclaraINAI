<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionModificacion/_Modificacion.master" AutoEventWireup="true" CodeBehind="InversionesModifica.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionModificacion.InversionesModifica" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/SioNo.ascx" TagPrefix="uc1" TagName="SioNo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si" OnNo="QstBox_No" OnYes="QstBox_Yes" YesCssClass="" NoCssClass="" />

    <div class="subtitulo">
        <asp:Literal ID="Literal1" runat="server" Text="Modificacion de Inversiones" EnableViewState="false"></asp:Literal>
    </div>
    <asp:AlanAlert runat="server" ID="AlertaSuperiorMod" />
    <div id="cuerpo">
        <asp:Literal ID="SinInversionesBR" runat="server" Text="<br />" EnableViewState="false" Visible="false"></asp:Literal>
        <asp:AlanAlert runat="server" ID="SinInversiones" />
        <div runat="server" id="grdMod" />
    </div>
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Alta de Inversiones" EnableViewState="false"></asp:Literal>
    </div>
    <div class="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
        <div runat="server" id="grd">
            <div>
                <asp:Button ID="btnAgregarInversion" runat="server" CssClass="big" Text="" OnClick="btnAgregarInversion_Click" />
                <div class="a">
                    <label>
                        Agregar Inversión
                    </label>
                    <br>
                    <se></se>
                </div>
                <div class="b">
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />

    <asp:AlanModalPopUp runat="server" ID="mppInversion" HeaderText="Inversión">
        <ContentTemplate>
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>Tipo de Inversión</l>
                        </th>
                        <td>

                            <asp:DropDownList ID="cmbNID_TIPO_INVERSION" runat="server" CssClass="n2" requerido="btnGuardarInv" OnSelectedIndexChanged="cmbNID_TIPO_INVERSION_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:DropDownList ID="cmbNID_SUBTIPO_INVERSION" runat="server" CssClass="n2">
                            </asp:DropDownList>

                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Localización de la Inversión</l>
                        </th>
                        <td>

                            <asp:DropDownList ID="cmbNID_PAIS" runat="server" CssClass="n3" AutoPostBack="True" requerido="btnGuardarInv" OnSelectedIndexChanged="cmbNID_PAIS_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="cmbCID_ENTIDAD_FEDERATIVA" runat="server" CssClass="n3">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtV_LUGAR" runat="server" CssClass="n3" Visible="False"></asp:TextBox>
                        </td>
                    </tr>

                    <tr runat="server" id="trInstitucion">
                        <th>
                            <l>Institución o Razón Social</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbNID_INSTITUCION" runat="server" AutoPostBack="True" requerido="btnGuardarInv" CssClass="n2" OnSelectedIndexChanged="cmbNID_INSTITUCION_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtV_OTRO" runat="server" Visible="false" CssClass="n2"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Saldo a la fecha de conclusión del encargo</l>
                        </th>
                        <td>
                            <asp:TextBox ID="moneytxtM_SALDO" requerido="btnGuardarInv" runat="server" ClientIDMode="Static" AutoCompleteType="None" MaxLength="19"></asp:TextBox>
                            <div id="divmoneytxtM_SALDO"></div>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l> Número de Cuenta o Contrato</l>
                        </th>

                        <td>
                            <asp:TextBox ID="txtE_CUENTA" runat="server" requerido="btnGuardarInv" MaxLength="100"></asp:TextBox>

                        </td>

                    </tr>
                    <tr>
                        <th>
                            <l>Fecha de Apertura de la Inversión</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtF_APERTURA" requerido="btnGuardarInv" Date="S" runat="server" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="txtF_APERTURA_C" TargetControlID="txtF_APERTURA" Format="dd/MM/yyyy" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Titular(es) de la cuenta</l>
                        </th>
                        <td>

                            <asp:CheckBoxList ID="cblTitulares" runat="server"></asp:CheckBoxList>

                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <div class="right">
                <asp:Button ID="btnCerrarModal" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarModal_Click" />

                <asp:Button ID="btnGuardarInv" runat="server" Text="Guardar" OnClick="btnGuardaInv_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
            </div>
            <br />
            <br />
        </ContentTemplate>
    </asp:AlanModalPopUp>
    <asp:AlanModalPopUp runat="server" ID="mppInversionMod" HeaderText="Actualizar Inversión">
        <ContentTemplate>
            <table class="f">
                <tbody>

                    <tr>
                        <th>
                            <l>Tipo de Inversión</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtTipoInversion" runat="server" CssClass="n2" Enabled="false"></asp:TextBox>
                            <asp:TextBox ID="txtSubtipoInversion" runat="server" CssClass="n2" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Localización de la Inversión</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtPais" runat="server" CssClass="n3" Enabled="false"></asp:TextBox>
                            <asp:TextBox ID="txtEntidadFederativa" runat="server" CssClass="n3" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Institución o Razón Social</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtInstitucion" runat="server" CssClass="n2" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l> Número de Cuenta o Contrato</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtCuenta" runat="server" requerido="btnGuardarMod" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>
                            ¿La cuenta sigue activa?  
                            </l>
                        </th>
                        <td>
                            <uc1:SioNo runat="server" ID="cbx" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Saldo anterior</l>
                        </th>
                        <td>
                            <asp:TextBox ID="moneytxtM_SALDO_ANTERIOR" requerido="btnGuardarMod" runat="server" ClientIDMode="Static" AutoCompleteType="None" MaxLength="19"></asp:TextBox>
                            <div id="divmoneytxtM_SALDO_ANTERIOR"></div>
                        </td>
                    </tr>


                    <tr>
                        <th>
                            <l>Saldo de la Inversión a la fecha de la baja</l>
                        </th>
                        <td>
                            <asp:TextBox ID="moneytxtM_SALDO_ACTUAL_MOD" requerido="btnGuardarMod" runat="server" ClientIDMode="Static" AutoCompleteType="None" MaxLength="19"></asp:TextBox>
                            <div id="divmoneytxtM_SALDO_ACTUAL_MOD"></div>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Titular(es) de la cuenta</l>
                        </th>
                        <td>

                            <asp:CheckBoxList ID="cblTitularesMod" runat="server"></asp:CheckBoxList>

                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="right">
                <asp:Button ID="btnCerrarMod" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarMod_Click" />
                <asp:Button ID="btnGuardarMod" runat="server" Text="Guardar" OnClick="btnGuardaMod_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>
</asp:Content>

