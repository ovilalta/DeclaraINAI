<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionInicial/_Inicial.master" AutoEventWireup="true" CodeBehind="Inversiones.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionInicial.Inversiones" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Inversiones"></asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />

    <div id="cuerpo">

        <asp:AlanAlert runat="server" ID="AlertaSuperior" />

        <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si" OnNo="QstBox_No" OnYes="QstBox_Yes" YesCssClass="" NoCssClass="" />

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

                            <asp:DropDownList ID="cmbNID_TIPO_INVERSION" runat="server" CssClass="n2" requerido="btnGuardar" OnSelectedIndexChanged="cmbNID_TIPO_INVERSION_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:DropDownList ID="cmbNID_SUBTIPO_INVERSION" runat="server" CssClass="n2" requerido="btnGuardar">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Localización de la Inversión</l>
                        </th>
                        <td>

                            <asp:DropDownList ID="cmbNID_PAIS" runat="server" CssClass="n3" requerido="btnGuardar" AutoPostBack="True" OnSelectedIndexChanged="cmbNID_PAIS_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="cmbCID_ENTIDAD_FEDERATIVA" runat="server" CssClass="n3">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtV_LUGAR" runat="server" CssClass="n3" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstitucion">
                        <th>
                            <l> Institución o Razón Social </l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbNID_INSTITUCION" runat="server" AutoPostBack="True" requerido="btnGuardar" CssClass="n2" OnSelectedIndexChanged="cmbNID_INSTITUCION_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtV_OTRO" runat="server" requerido="btnGuardar" Visible="false" CssClass="n2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>RFC</l>
                        </th>

                        <td>
                            <asp:TextBox ID="txtV_RFC" runat="server" requerido="btnGuardar" MaxLength="13"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Saldo</l>
                        </th>
                        <td>
                            <asp:TextBox ID="moneytxtM_SALDO" requerido="btnGuardar" runat="server" ClientIDMode="Static" AutoCompleteType="None" MaxLength="19"></asp:TextBox>
                            <div id="divmoneytxtM_SALDO"></div>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Número de Cuenta</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtE_CUENTA" runat="server" requerido="btnGuardar" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Fecha de Apertura de la Inversión</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtF_APERTURA" requerido="btnGuardar" Date="S" runat="server" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="txtF_APERTURA_C" TargetControlID="txtF_APERTURA" Format="dd/MM/yyyy" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Tipo de moneda</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtTipoMoneda" runat="server" requerido="btnGuardar" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l><b>TERCERO</b></l>
                        </th>

                    </tr>
                    <tr>
                        <th>
                            <l>Tercero</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbTerceroInversion" runat="server" OnSelectedIndexChanged="cmbTerceroInversion_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Persona Física" Value="F"></asp:ListItem>
                                <asp:ListItem Text="Persona Moral" Value="M"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Nombre del Tercero o Terceros</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtTerceroNombre" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>RFC del tercero</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtTerceroRFC" runat="server" MaxLength="13" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Titular(es)</l>
                        </th>
                        <td>
                            <asp:CheckBoxList ID="cblTitulares" runat="server"></asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Aclaraciones / Observaciones</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtObservaciones" runat="server" MaxLength="1000" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>

                </tbody>
            </table>
            <br />
            <div class="right">
                <asp:Button ID="btnCerrarModal" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarModal_Click" />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuarda_Click" OnClientClick="return CheckReq();" ClientIDMode="Static" />
            </div>
            <br />
            <br />
        </ContentTemplate>
    </asp:AlanModalPopUp>
</asp:Content>

