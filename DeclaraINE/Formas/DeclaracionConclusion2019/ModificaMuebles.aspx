<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionConclusion/_Conclusion.master" AutoEventWireup="true" CodeBehind="ModificaMuebles.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionConclusion.ModificaMuebles" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionConclusion/ctrlDesincorpora.ascx" TagPrefix="ascx" TagName="ctrlDesincorpora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
        <asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si" OnNo="QstBox_No" YesCssClass="" NoCssClass="" />
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="Actualización de Otros Bienes Muebles" EnableViewState="false"></asp:Literal>
    </div>
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <div id="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
                 <asp:Literal ID="SinMueblesBR" runat="server" Text="<br />" EnableViewState="false" Visible="false"></asp:Literal>
        <asp:AlanAlert runat="server" ID="SinMuebles" />
        <div runat="server" id="grd">
        </div>
    </div>
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTituloN" runat="server" Text="Alta de Otros Bienes Muebles" EnableViewState="false"></asp:Literal>
    </div>
    <div class="cuerpo">

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
    </div>
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
                    <%-- <tr>
                        <th>
                            <l>Fecha de adquisición</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtF_ADQUISICION" runat="server" Date="S" requerido="btnGuardarVehiculo" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="txtF_ADQUISICION_C" TargetControlID="txtF_ADQUISICION" Format="dd/MM/yyyy" />
                        </td>
                    </tr>--%>
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

    <asp:AlanModalPopUp runat="server" ID="mppBaja" HeaderText="Venta, Siniestro o Donación de Bien Mueble">
        <ContentTemplate>
            <ascx:ctrlDesincorpora runat="server" ID="ctrlDesincorpora1" />
            <div class="right">
                <asp:Button ID="btnCerrarBaja" runat="server" Text="Cerrar" OnClick="btnCerrarBaja_Click" />
                <asp:Button ID="btnGuardarBaja" runat="server" Text="Guardar" OnClick="btnGuardarBaja_Click" />
                <asp:Button ID="btnEliminarBaja" runat="server" Text="Eliminar" OnClick="btnEliminarBaja_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="mppMueblesN">
        <ContentTemplate>
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>Tipo de bien</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="dpTipoBienMuebleN" runat="server" requerido="btnGuardarMuebleN"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l> Especificar tipo de bien</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtEspecificaN" runat="server" requerido="btnGuardarMuebleN" MaxLength="1000"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Valor de adquisición</l>
                        </th>
                        <td>
                            <asp:TextBox ID="moneytxtValorAdqusicionMuebleN" runat="server" requerido="btnGuardarMuebleN" AutoCompleteType="None" ClientIDMode="Static" MaxLength="19"></asp:TextBox>
                            <div id="divmoneytxtValorAdqusicionMuebleN"></div>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Fecha de adquisición</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtF_ADQUISICIONN" runat="server" Date="S" requerido="btnGuardarMuebleN" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="txtF_ADQUISICIONN_C" TargetControlID="txtF_ADQUISICIONN" Format="dd/MM/yyyy" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Titular(es)</l>
                        </th>
                        <td>
                            <asp:CheckBoxList CssClass="table table-striped table-hover" ID="chbDependietesMueblesN" runat="server" RepeatDirection="Vertical"></asp:CheckBoxList>
                        </td>
                    </tr>

            </table>
            <div class="right">
                <asp:Button ID="btnCerrarMuebleN" runat="server" ToolTip="Cerrar" Text="Cerrar" OnClick="btnCerrarMuebleN_Click" />
                <asp:Button ID="btnGuardarMuebleN" runat="server" ToolTip="Cerrar" Text="Guardar" OnClientClick="return CheckReq();" ClientIDMode="Static" OnClick="btnGuardarMuebleN_Click" />
            </div>
            <br />
            <br />
            <br />
        </ContentTemplate>

    </asp:AlanModalPopUp>
    <br />
    <br />
    <br />
</asp:Content>
