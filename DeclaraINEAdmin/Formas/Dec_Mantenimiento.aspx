<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/Site.Master" AutoEventWireup="true" CodeBehind="Dec_Mantenimiento.aspx.cs" Inherits="DeclaraINEAdmin.Formas.Dec_Mantenimiento" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Inicio/DGDatosPersonales.ascx" TagPrefix="uc1" TagName="DGDatosPersonales" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Inicio/DGDomicilioParticular.ascx" TagPrefix="uc1" TagName="DGDomicilioParticular" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Inicio/DGCargo.ascx" TagPrefix="uc1" TagName="DGCargo" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Inicio/DGDomicilioLaboral.ascx" TagPrefix="uc1" TagName="DGDomicilioLaboral" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Inicio/DGConyuge.ascx" TagPrefix="uc1" TagName="DGConyuge" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Inicio/BienesInmuebles.ascx" TagPrefix="uc1" TagName="BienesInmuebles" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Inicio/BienesOtrosBienes.ascx" TagPrefix="uc1" TagName="BienesOtrosBienes" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Inicio/BienesVehiculos.ascx" TagPrefix="uc1" TagName="BienesVehiculos" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Inicio/Inversiones.ascx" TagPrefix="uc1" TagName="Inversiones" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Inicio/Adeudos.ascx" TagPrefix="uc1" TagName="Adeudos" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Inicio/Observaciones.ascx" TagPrefix="uc1" TagName="Observaciones" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Inicio/DeclaracionInteres.ascx" TagPrefix="uc1" TagName="DeclaracionInteres" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Inicio/DecEnvio.ascx" TagPrefix="uc1" TagName="DecEnvio" %>

<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModDGDatosPersonales.ascx" TagPrefix="uc1" TagName="pgModDGDatosPersonales" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModDGDomicilioLaboral.ascx" TagPrefix="uc1" TagName="pgModDGDomicilioLaboral" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModDGDomicilioParticular.ascx" TagPrefix="uc1" TagName="pgModDGDomicilioParticular" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModDGCargo.ascx" TagPrefix="uc1" TagName="pgModDGCargo" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModDGConyuge.ascx" TagPrefix="uc1" TagName="pgModDGConyuge" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModBienesInmuebles.ascx" TagPrefix="uc1" TagName="pgModBienesInmuebles" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModBienesMuebles.ascx" TagPrefix="uc1" TagName="pgModBienesMuebles" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModBienesVehiculos.ascx" TagPrefix="uc1" TagName="pgModBienesVehiculos" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModInversiones.ascx" TagPrefix="uc1" TagName="pgModInversiones" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModAdeudos.ascx" TagPrefix="uc1" TagName="pgModAdeudos" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModTarjetas.ascx" TagPrefix="uc1" TagName="pgModTarjetas" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModImpuestos.ascx" TagPrefix="uc1" TagName="pgModImpuestos" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModOtrosGastos.ascx" TagPrefix="uc1" TagName="pgModOtrosGastos" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModObservaciones.ascx" TagPrefix="uc1" TagName="pgModObservaciones" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModConflicto.ascx" TagPrefix="uc1" TagName="pgModConflicto" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModEnvio.ascx" TagPrefix="uc1" TagName="pgModEnvio" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Modificacion/pgModIngresos.ascx" TagPrefix="uc1" TagName="pgModIngresos" %>

<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Conclusion/pgConDatosPersonales.ascx" TagPrefix="uc1" TagName="pgConDatosPersonales" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Conclusion/pgConDomicilioParticular.ascx" TagPrefix="uc1" TagName="pgConDomicilioParticular" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Conclusion/pgConCargo.ascx" TagPrefix="uc1" TagName="pgConCargo" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Conclusion/pgConDomicilioLaboral.ascx" TagPrefix="uc1" TagName="pgConDomicilioLaboral" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Conclusion/pgConConyugue.ascx" TagPrefix="uc1" TagName="pgConConyugue" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Conclusion/pgConBieneVehiculos.ascx" TagPrefix="uc1" TagName="pgConBieneVehiculos" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Conclusion/pgConBienesMuebles.ascx" TagPrefix="uc1" TagName="pgConBienesMuebles" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Conclusion/pgConBienesInmuebles.ascx" TagPrefix="uc1" TagName="pgConBienesInmuebles" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Conclusion/pgConEnvio.ascx" TagPrefix="uc1" TagName="pgConEnvio" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Conclusion/pgConInversiones.ascx" TagPrefix="uc1" TagName="pgConInversiones" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Conclusion/pgConObservaciones.ascx" TagPrefix="uc1" TagName="pgConObservaciones" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Conclusion/pgConAdeudos.ascx" TagPrefix="uc1" TagName="pgConAdeudos" %>
<%@ Register Src="~/Formas/De_Mantenimieto_Paginas/Dec_Conclusion/pgConConflicto.ascx" TagPrefix="uc1" TagName="pgConConflicto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .modal-dialog .level1 {
            background-color: #ffffff;
            border-color: #C124BD;
            border-width: 1px;
            vertical-align: middle central;
            text-align: center;
            display: inline;
            margin-bottom: 18px;
        }

            .modal-dialog .level1 ul {
                padding: 0 0 13px 0;
                border-color: #9E9E9E;
            }

        .modal-dialog .right {
            text-align: right;
            padding: 14px 0px 2px 2px;
        }

        .modal-dialog .level1 a {
            cursor: inherit;
            text-decoration: underline;
        }

        .completeNone {
            background-color: #f7f7f7 !important;
        }

        .complete {
            background-color: #197a0a !important;
        } 

        .alanGrid-theme td button:disabled, .alanGrid-theme td input[type="submit"]:disabled {
            display: inline;
        }
    </style>
        <div class="filtro-header">
            Mantenimiento de Declaraciones
        </div>
        <asp:AlanMessageBox runat="server" ID="MsgBox" />
        <nav class="filtro">
            <div class="filtro-checks">
                <asp:CheckBox ID="chNRFC" AutoPostBack="True" Text="RFC" runat="server" CssClass="checkbox-success checkbox-inline " Enabled="false" />&nbsp;&nbsp;
                            <asp:CheckBox ID="chNTD" AutoPostBack="True" Text="Tipo de Declaración" runat="server" CssClass="checkbox-success checkbox-inline " />&nbsp;&nbsp;
                            <asp:CheckBox ID="chnFD" AutoPostBack="True" Text="Fecha de la Declaracion" runat="server" CssClass="checkbox-success checkbox-inline " />&nbsp;&nbsp;
                            <asp:CheckBox ID="chnED" AutoPostBack="True" Text="Estado de la Declaracion" runat="server" CssClass="checkbox-success checkbox-inline " />&nbsp;&nbsp;
            </div>
            <asp:Panel ID="pnlchchNRFC" runat="server" Visible="false">
                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        RFC:
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtRFC" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlchNTD" runat="server" Visible="false">
                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        Tipo de Declaración:
                    </div>
                    <div class="col-md-10  checkboxlistFiltro">

                        <asp:CheckBoxList ID="dpNT" runat="server" RepeatDirection="Horizontal" CssClass="form-control"></asp:CheckBoxList>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlchnFD" runat="server" Visible="false">
                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        Fechas por rango
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtFInicio" runat="server" AutoCompleteType="Disabled" Date="S" placeholder="Fecha Inicio"></asp:TextBox>
                        <asp:CalendarExtender runat="server" ID="txtFInicio_C" TargetControlID="txtFInicio" Format="dd/MM/yyyy" />
                        <asp:TextBox ID="txtFFin" runat="server" AutoCompleteType="Disabled" MaxLength="10" Date="S" placeholder="Fecha Final"></asp:TextBox>
                        <asp:CalendarExtender runat="server" ID="txtFFin_C" TargetControlID="txtFFin" Format="dd/MM/yyyy" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlchnED" runat="server" Visible="false">
                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        Estado de la Declaracion  
                    </div>
                    <div class="col-md-10 checkboxlistFiltro">
                        <asp:CheckBoxList ID="dpED" runat="server" RepeatDirection="Horizontal" CssClass="form-control"></asp:CheckBoxList>
                    </div>
                </div>
            </asp:Panel>
            <div class="filtro-button">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-default btnImage Image-Search" OnClick="btnBuscar_Click" />
            </div>
        </nav>
        <asp:AlanAlert runat="server" ID="AlertaBusqueda" />
        <div class="filtro">
            <asp:GridView ID="grdDec" runat="server" OnRowDataBound="grdDec_RowDataBound" AutoGenerateColumns="false" CssClass="table table-condensed table-striped table-hover alanGrid-theme" Visible="true">
                <Columns>
                    <asp:TemplateField HeaderText="RFC">
                        <ItemTemplate>
                            <asp:Label ID="LabRFC" runat="server" Text='<%# String.Format("{0}{1}{2}@{3}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE"), Eval("NID_DECLARACION")) %>' CssClass="invisible"></asp:Label>
                            <asp:Literal ID="ltrRFC" runat="server" Text='<%# String.Format("{0}{1}{2}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE")) %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Literal ID="ltrNombreCompreto" runat="server" Text='<%# String.Format("{0} {1} {2}", Eval("V_PRIMER_A"), Eval("V_SEGUNDO_A"), Eval("V_NOMBRE")) %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo Declaracion">
                        <ItemTemplate>
                            <asp:Image runat="server" ID="imgTipo" Width="24px" Height="24px" />
                            <asp:Literal ID="ltrV_TIPO_DECLARACION" runat="server" Text='<%#Eval("V_TIPO_DECLARACION")%>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ejercicio">
                        <ItemTemplate>
                            <asp:Literal ID="ltrPVID_PRIMER_NIVEL" runat="server" Text='<%#Eval("C_EJERCICIO")%>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha de envio">
                        <ItemTemplate>
                            <asp:Literal ID="ltrFE" runat="server" Text='<%#Eval("F_ENVIO") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Image runat="server" ID="imgEstado" ImageUrl='<%# String.Concat("~/Images/CAT_ESTADO_DECLARACION/",Eval("NID_ESTADO"),".png") %>' />
                            <asp:Literal runat="server" ID="ltrEstado" Text='<%#Eval("V_ESTADO") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Declaración">
                        <ItemTemplate>
                            <asp:Button ID="btnGridDeclaracion" runat="server" Text="" CommandArgument='<%# String.Format("{0}{1}{2}@{3}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE"), Eval("NID_DECLARACION")) %>' OnClick="btnGridDeclaracion_Click" CssClass="mpdf" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Declaración de Interes">
                        <ItemTemplate>
                            <asp:Button ID="btnGridDeclaracionConflicto" runat="server" Text="" CommandArgument='<%# String.Format("{0}{1}{2}@{3}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE"), Eval("NID_DECLARACION")) %>' OnClick="btnGridDeclaracionConflicto_Click" CssClass="mpdf" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acuse">
                        <ItemTemplate>
                            <asp:Button ID="btnGridDeclaracionAcuse" runat="server" Text="" CommandArgument='<%# String.Format("{0}{1}{2}@{3}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE"), Eval("NID_DECLARACION")) %>' OnClick="btnGridDeclaracionAcuse_Click" CssClass="mpdf" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apartados">
                        <ItemTemplate>
                            <asp:Button ID="btnOpenFolderDeclaracionApartados" runat="server" Text="" CommandArgument='<%# String.Format("{0}{1}{2}@{3}", Eval("VID_NOMBRE"), Eval("VID_FECHA"), Eval("VID_HOMOCLAVE"), Eval("NID_DECLARACION")) %>' OnClick="btnEditarDeclaracionApartados_Click" CssClass="Image-OpenFolder" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>



    <asp:AlanModalPopUp runat="server" ID="appApartados">
        <ContentTemplate>
            <asp:AlanAlert runat="server" ID="AlertaSuperiorAA" />
            <div class=" level1">
                <asp:Panel ID="pnlDI" runat="server" Visible="false">
                    <table class="table table-condensed table-striped table-hover alanGrid-theme">
                        <tr>
                            <th scope="col">Apartado</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarDatosGeneralesI" runat="server" Text="" OnClick="btnEditarDatosGeneralesI_Click" />
                                <img runat="server" id="imgDatosGeneralesI" src="../../Content/nok.png" />Datos Generales</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarBienesI" runat="server" Text="" OnClick="btnEditarBienesI_Click" />
                                <img runat="server" id="imgBienesI" src="../../Content/nok.png" />Bienes</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarInversionesI" runat="server" Text="" OnClick="btnEditarInversionesI_Click" />
                                <img runat="server" id="imgInversionesI" src="../../Content/nok.png" />Inversiones</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarAdeudosI" runat="server" Text="" OnClick="btnEditarAdeudosI_Click" />
                                <img runat="server" id="imgAdeudosI" src="../../Content/nok.png" />Adeudos</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarObservacionesI" runat="server" Text="" OnClick="btnEditarObservacionesI_Click" />
                                <img runat="server" id="imgObservacionesI" src="../../Content/nok.png" />Observaciones</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarInteresesI" runat="server" Text="" OnClick="btnEditarInteresesI_Click" />
                                <img runat="server" id="imgConflictoInteresI" src="../../Content/nok.png" />Declaración de Intereses</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarEnvíoI" runat="server" Text="" OnClick="btnEditarEnvíoI_Click" />
                                <img runat="server" id="imgEnvioI" src="../../Content/nok.png" />Envío</td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlDM" runat="server" Visible="false">
                    <table class="table table-condensed table-striped table-hover alanGrid-theme">
                        <tr>
                            <th scope="col">Apartado</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarDatosGeneralesM" runat="server" OnClick="btnEditarDatosGeneralesM_Click" />
                                <img runat="server" id="imgDatosGeneralesM" src="../../Content/nok.png" />Datos Generales</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarBienesM" runat="server" Text="" OnClick="btnEditarBienesM_Click" />
                                <img runat="server" id="imgBienesM" src="../../Content/nok.png" />Bienes</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarInversionesM" runat="server" Text="" OnClick="btnEditarInversionesM_Click" />
                                <img runat="server" id="imgInversionesM" src="../../Content/nok.png" />Inversiones</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarAdeudosM" runat="server" Text="" OnClick="btnEditarAdeudosM_Click" />
                                <img runat="server" id="imgAdeudosM" src="../../Content/nok.png" />Adeudos</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarIngresosM" runat="server" Text="" OnClick="btnEditarIngresosM_Click" />
                                <img runat="server" id="imgIngresosM" src="../../Content/nok.png" />Ingresos</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarGastosM" runat="server" Text="" OnClick="btnEditarGastosM_Click" />
                                <img runat="server" id="imgGastosM" src="../../Content/nok.png" />Gastos</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarObservacionesM" runat="server" Text="" OnClick="btnEditarObservacionesM_Click" />
                                <img runat="server" id="imgObservacionesM" src="../../Content/nok.png" />Observaciones</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarInteresesM" runat="server" Text="" OnClick="btnEditarInteresesM_Click" />
                                <img runat="server" id="imgConflictoInteresM" src="../../Content/nok.png" />Declaración de Intereses</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarEnvíoM" runat="server" Text="" OnClick="btnEditarEnvíoM_Click" />
                                <img runat="server" id="imgEnvioM" src="../../Content/nok.png" />Envío</td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlDC" runat="server" Visible="false">
                    <table class="table table-condensed table-striped table-hover alanGrid-theme">
                        <tr>
                            <th scope="col">Apartado</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarDatosGeneralesC" runat="server" Text="" OnClick="btnEditarDatosGeneralesC_Click" />
                                <img runat="server" id="imgDatosGeneralesC" src="../../Content/nok.png" />Datos Generales</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarBienesC" runat="server" Text="" OnClick="btnEditarBienesC_Click" />
                                <img runat="server" id="imgBienesC" src="../../Content/nok.png" />Bienes</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarInversionesC" runat="server" Text="" OnClick="btnEditarInversionesC_Click" />
                                <img runat="server" id="imgInversionesC" src="../../Content/nok.png" />Inversiones</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarAdeudosC" runat="server" Text="" OnClick="btnEditarAdeudosC_Click" />
                                <img runat="server" id="imgAdeudosC" src="../../Content/nok.png" />Adeudos</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarObservacionesC" runat="server" Text="" OnClick="btnEditarObservacionesC_Click" />
                                <img runat="server" id="imgObservacionesC" src="../../Content/nok.png" />Observaciones</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarInteresesC" runat="server" Text="" OnClick="btnEditarInteresesC_Click" />
                                <img runat="server" id="imgConflictoInteresC" src="../../Content/nok.png" />Declaración de Intereses</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarEnvíoC" runat="server" Text="" OnClick="btnEditarEnvíoC_Click" />
                                <img runat="server" id="imgEnvioC" src="../../Content/nok.png" />Envío</td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <div class="right">
                <asp:Button ID="btnCerrarappApartados" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarappApartados_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

    <asp:AlanModalPopUp runat="server" ID="appApartadoSelectInicio">
        <ContentTemplate>
            <div class=" level1">

                <%--Seccion Dec. Inicial--%>

                <div runat="server" enableviewstate="false" id="menu1I" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkDatosPersonalesI" OnClick="lkDatosPersonalesI_Click" runat="server" d-t="Datos Personales" EnableViewState="true">
                                <img alt="Inicio" src="../../images/icons/ColorX32/Identity%20Theft.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkDomicilioParticularI" OnClick="lkDomicilioParticularI_Click" runat="server" d-t="Domicilio Particular" EnableViewState="true">
                               <img alt="Inicio" src="../../images/icons/ColorX32/Home.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkCargoI" runat="server" OnClick="lkCargoI_Click" d-t="Cargo" EnableViewState="true">
                               <img alt="Inicio" src="../../images/icons/ColorX32/Flow%20Chart.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkDomicilioLaboralI" OnClick="lkDomicilioLaboralI_Click" runat="server" d-t="Domicilio Laboral" EnableViewState="true">
                               <img alt="Inicio" src="../../images/icons/ColorX32/Factory.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkDependientesEconomicosI" OnClick="lkDependientesEconomicosI_Click" runat="server" d-t="Cónyuge, concubina o concubinario y/o dependientes económicos" EnableViewState="true">
                               <img alt="Inicio" src="../../images/icons/ColorX32/Family%20Man%20Woman.png">
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu2I" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkBienesInmueblesI" OnClick="lkBienesInmueblesI_Click" runat="server" d-t="Bienes Inmuebles" EnableViewState="true">
                        <img alt="Inicio" src="../../images/icons/ColorX32/Exterior.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkBienesMueblesI" OnClick="lkBienesMueblesI_Click" runat="server" d-t="Otros Bienes" EnableViewState="true">
                        <img alt="Inicio" src="../../images/icons/ColorX32/Table.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkVehiculosI" OnClick="lkVehiculosI_Click" runat="server" d-t="Vehículos" EnableViewState="true">
                        <img alt="Inicio" src="../../images/icons/ColorX32/embotellamiento.png">
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu3I" visible="false">
                    <ul class="nav nav-tabs">

                        <li>
                            <asp:LinkButton ID="lkInversionesI" OnClick="lkInversionesI_Click" runat="server" d-t="Inversiones" EnableViewState="true">
                        <img src="../../images/icons/ColorX32/Money%20Bag.png"></asp:LinkButton>

                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu4I" visible="false">
                    <ul class="nav nav-tabs">

                        <li>
                            <asp:LinkButton ID="lkAdeudosI" OnClick="lkAdeudosI_Click" runat="server" d-t="Adeudos" EnableViewState="true">
                        <img src="../../images/icons/ColorX32/Tax.png"></asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu5I" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkObservacionesI" OnClick="lkObservacionesI_Click" runat="server" d-t="Observaciones y Aclaraciones" EnableViewState="true">
                        <img src="../../images/icons/ColorX32/Search.png"></asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu6I" visible="false">
                    <ul class="nav nav-tabs">

                        <li>
                            <asp:LinkButton ID="lknConflictoI" runat="server" OnClick="lknConflictoI_Click" d-t="Declaración de Intereses" EnableViewState="true">
                        <img src="../../images/icons/ColorX32/Transfer%20Between%20Users.png"></asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu7I" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkEnvioI" runat="server" OnClick="lkEnvioI_Click" d-t="Envío de Declaración" EnableViewState="true">                       
                        <img src="../../images/icons/ColorX32/Reading%20Confirmation.png"></asp:LinkButton>
                        </li>

                    </ul>
                </div>


                <%--Seccion Dec. Modificacion--%>
                <div runat="server" enableviewstate="false" id="menu1M" visible="false">
                    <ul class="nav nav-tabs ">
                        <li>
                            <asp:LinkButton ID="lkDatosPersonalesM" OnClick="lkDatosPersonalesM_Click" runat="server" d-t="Datos Personales" EnableViewState="true">
                                <img alt="Inicio" src="../../images/icons/ColorX32/Identity%20Theft.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkDomicilioParticularM" OnClick="lkDomicilioParticularM_Click" runat="server" d-t="Domicilio Particular" EnableViewState="true">
                               <img alt="Inicio" src="../../images/icons/ColorX32/Home.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkCargoM" runat="server" OnClick="lkCargoM_Click" d-t="Cargo" EnableViewState="true">
                               <img alt="Inicio" src="../../images/icons/ColorX32/Flow%20Chart.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkDomicilioLaboralM" OnClick="lkDomicilioLaboralM_Click" runat="server" d-t="Domicilio Laboral" EnableViewState="true">
                               <img alt="Inicio" src="../../images/icons/ColorX32/Factory.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkDependientesEconomicosM" OnClick="lkDependientesEconomicosM_Click" runat="server" d-t="Cónyuge, concubina o concubinario y/o dependientes económicos" EnableViewState="true">
                               <img alt="Inicio" src="../../images/icons/ColorX32/Family%20Man%20Woman.png">
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu8M" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkIngresosM" OnClick="lkIngresosM_Click" runat="server" d-t="Ingresos" EnableViewState="true">
                                            <img src="../../images/icons/ColorX32/Coins.png">
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu2M" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkBienesInmueblesActM" OnClick="lkBienesInmueblesActM_Click" runat="server" d-t="Actualización de Bienes Inmuebles" EnableViewState="true">
                                   <img src="../../images/icons/ColorX32/casa.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkBienesMueblesActM" OnClick="lkBienesMueblesActM_Click" runat="server" d-t="Actualización de Otros Bienes" EnableViewState="true">
                                      <img  src="../../images/icons/ColorX32/editar-imagen.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkVehiculosActM" OnClick="lkVehiculosActM_Click" runat="server" d-t="Actualización de Vehículos" EnableViewState="true">
                                       <img  src="../../images/icons/ColorX32/automotriz.png">
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu3M" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkInversionesActM" OnClick="lkInversionesActM_Click" runat="server" d-t="Modificación de Inversiones" EnableViewState="true">
                                    <img src="../../images/icons/ColorX32/Currency%20Exchange.png">
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu4M" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkAdeudosActM" OnClick="lkAdeudosActM_Click" runat="server" d-t="Actualización de Adeudos" EnableViewState="true">
                                   <img src="../../images/icons/ColorX32/solicitud-de-dinero.png">
                            </asp:LinkButton>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu9M" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkTarjetasM" OnClick="lkTarjetasM_Click" runat="server" d-t="Tarjetas de Crédito" EnableViewState="true">
                                   <img src="../../images/icons/ColorX32/tarjeta-en-uso.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkImpuestos" OnClick="lkImpuestos_Click" runat="server" d-t="Impuestos y Otras Retenciones" EnableViewState="true">
                                   <img src="../../images/icons/ColorX32/flujo-de-fondos.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkOtrosGastosM" OnClick="lkOtrosGastosM_Click" runat="server" d-t="Otros Gastos" EnableViewState="true">
                                   <img src="../../images/icons/ColorX32/efectivo-en-mano.png">
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu5M" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkObservacionesM" OnClick="lkObservacionesM_Click" runat="server" d-t="Observaciones y Aclaraciones" EnableViewState="true">
                        <img src="../../images/icons/ColorX32/Search.png"></asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu6M" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lknConflictoM" runat="server" OnClick="lknConflictoM_Click" d-t="Declaración de Intereses" EnableViewState="true">
                        <img src="../../images/icons/ColorX32/Transfer%20Between%20Users.png"></asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" enabled="false" id="menu7M" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkEnvioM" runat="server" OnClick="lkEnvioM_Click" d-t="Envío de Declaración" EnableViewState="true">                       
                        <img src="../../images/icons/ColorX32/Reading%20Confirmation.png"></asp:LinkButton>
                        </li>
                    </ul>
                </div>


                <%--Seccion Dec. Conclusion--%>


                <div runat="server" enableviewstate="false" id="menu1C" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkDatosPersonalesC" OnClick="lkDatosPersonalesC_Click" runat="server" d-t="Datos Personales" EnableViewState="true">
                                <img alt="Inicio" src="../../images/icons/ColorX32/Identity%20Theft.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkDomicilioParticularC" OnClick="lkDomicilioParticularC_Click" runat="server" d-t="Domicilio Particular" EnableViewState="true">
                               <img alt="Inicio" src="../../images/icons/ColorX32/Home.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkCargoC" runat="server" OnClick="lkCargoC_Click" d-t="Cargo" EnableViewState="true">
                               <img alt="Inicio" src="../../images/icons/ColorX32/Flow%20Chart.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkDomicilioLaboralC" OnClick="lkDomicilioLaboralC_Click" runat="server" d-t="Domicilio Laboral" EnableViewState="true">
                               <img alt="Inicio" src="../../images/icons/ColorX32/Factory.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkDependientesEconomicosC" OnClick="lkDependientesEconomicosC_Click" runat="server" d-t="Cónyuge, concubina o concubinario y/o dependientes económicos" EnableViewState="true">
                               <img alt="Inicio" src="../../images/icons/ColorX32/Family%20Man%20Woman.png">
                            </asp:LinkButton>
                        </li>

                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu2C" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkBienesInmueblesActC" OnClick="lkBienesInmueblesActC_Click" runat="server" d-t="Actualización de Bienes Inmuebles" EnableViewState="true">
                                   <img src="../../images/icons/ColorX32/casa.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkBienesMueblesActC" OnClick="lkBienesMueblesActC_Click" runat="server" d-t="Actualización de Otros Bienes" EnableViewState="true">
                                      <img  src="../../images/icons/ColorX32/editar-imagen.png">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkVehiculosActC" OnClick="lkVehiculosActC_Click" runat="server" d-t="Actualización de Vehículos" EnableViewState="true">
                                       <img  src="../../images/icons/ColorX32/automotriz.png">
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu3C" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkInversionesActC" OnClick="lkInversionesActC_Click" runat="server" d-t="Modificación de Inversiones" EnableViewState="true">
                                    <img src="../../images/icons/ColorX32/Currency%20Exchange.png">
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu4C" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkAdeudosActC" OnClick="lkAdeudosActC_Click" runat="server" d-t="Actualización de Adeudos" EnableViewState="true">
                                   <img src="../../images/icons/ColorX32/solicitud-de-dinero.png">
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu5C" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkObservacionesC" OnClick="lkObservacionesC_Click" runat="server" d-t="Observaciones y Aclaraciones" EnableViewState="true">
                                            <img src="../../images/icons/ColorX32/Search.png"></asp:LinkButton>
                        </li>

                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu6C" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lknConflictoC" OnClick="lknConflictoC_Click" runat="server" d-t="Declaración de Intereses" EnableViewState="true">
                                            <img src="../../images/icons/ColorX32/Transfer%20Between%20Users.png"></asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div runat="server" enableviewstate="false" id="menu7C" visible="false">
                    <ul class="nav nav-tabs">
                        <li>
                            <asp:LinkButton ID="lkEnvioC" OnClick="lkEnvioC_Click" runat="server" d-t="Envío de Declaración" EnableViewState="true">                       
                                            <img src="../../images/icons/ColorX32/Reading%20Confirmation.png"></asp:LinkButton>
                        </li>
                    </ul>
                </div>


                <uc1:DGDatosPersonales runat="server" ID="DGDatosPersonales" EnableViewState="false" Visible="false" />
                <uc1:DGDomicilioParticular runat="server" ID="DGDomicilioParticular" EnableViewState="false" Visible="false" />
                <uc1:DGCargo runat="server" ID="DGCargo" EnableViewState="false" Visible="false" />
                <uc1:DGDomicilioLaboral runat="server" ID="DGDomicilioLaboral" EnableViewState="false" Visible="false" />
                <uc1:DGConyuge runat="server" ID="DGConyuge" EnableViewState="false" Visible="false" />
                <uc1:BienesInmuebles runat="server" ID="BienesInmuebles" EnableViewState="false" Visible="false" />
                <uc1:BienesOtrosBienes runat="server" ID="BienesOtrosBienes" EnableViewState="false" Visible="false" />
                <uc1:BienesVehiculos runat="server" ID="BienesVehiculos" EnableViewState="false" Visible="false" />
                <uc1:Inversiones runat="server" ID="Inversiones" EnableViewState="false" Visible="false" />
                <uc1:Adeudos runat="server" ID="Adeudos" EnableViewState="false" Visible="false" />
                <uc1:Observaciones runat="server" ID="Observaciones" EnableViewState="false" Visible="false" />
                <uc1:DeclaracionInteres runat="server" ID="DeclaracionInteres" EnableViewState="false" Visible="false" />
                <uc1:DecEnvio runat="server" ID="DecEnvio" EnableViewState="false" Visible="false" />


                <uc1:pgModDGDatosPersonales runat="server" ID="pgModDGDatosPersonales" EnableViewState="false" Visible="false" />
                <uc1:pgModDGDomicilioParticular runat="server" ID="pgModDGDomicilioParticular" EnableViewState="false" Visible="false" />
                <uc1:pgModDGCargo runat="server" ID="pgModDGCargo" EnableViewState="false" Visible="false" />
                <uc1:pgModDGDomicilioLaboral runat="server" ID="pgModDGDomicilioLaboral" EnableViewState="false" Visible="false" />
                <uc1:pgModDGConyuge runat="server" ID="pgModDGConyuge" EnableViewState="false" Visible="false" />
                <uc1:pgModBienesInmuebles runat="server" ID="pgModBienesInmuebles" EnableViewState="false" Visible="false" />
                <uc1:pgModBienesMuebles runat="server" ID="pgModBienesMuebles" EnableViewState="false" Visible="false" />
                <uc1:pgModBienesVehiculos runat="server" ID="pgModBienesVehiculos" EnableViewState="false" Visible="false" />
                <uc1:pgModInversiones runat="server" ID="pgModInversiones" EnableViewState="false" Visible="false" />
                <uc1:pgModAdeudos runat="server" ID="pgModAdeudos" EnableViewState="false" Visible="false" />
                <uc1:pgModIngresos runat="server" ID="pgModIngresos" EnableViewState="false" Visible="false" />
                <uc1:pgModTarjetas runat="server" ID="pgModTarjetas" EnableViewState="false" Visible="false" />
                <uc1:pgModImpuestos runat="server" ID="pgModImpuestos" EnableViewState="false" Visible="false" />
                <uc1:pgModOtrosGastos runat="server" ID="pgModOtrosGastos" EnableViewState="false" Visible="false" />
                <uc1:pgModObservaciones runat="server" ID="pgModObservaciones" EnableViewState="false" Visible="false" />
                <uc1:pgModConflicto runat="server" ID="pgModConflicto" EnableViewState="false" Visible="false" />
                <uc1:pgModEnvio runat="server" ID="pgModEnvio" EnableViewState="false" Visible="false" />


                <uc1:pgConDatosPersonales runat="server" ID="pgConDatosPersonales" EnableViewState="false" Visible="false" />
                <uc1:pgConDomicilioParticular runat="server" ID="pgConDomicilioParticular" EnableViewState="false" Visible="false" />
                <uc1:pgConCargo runat="server" ID="pgConCargo" EnableViewState="false" Visible="false" />
                <uc1:pgConDomicilioLaboral runat="server" ID="pgConDomicilioLaboral" EnableViewState="false" Visible="false" />
                <uc1:pgConConyugue runat="server" ID="pgConConyugue" EnableViewState="false" Visible="false" />
                <uc1:pgConBienesInmuebles runat="server" ID="pgConBienesInmuebles" EnableViewState="false" Visible="false" />
                <uc1:pgConBienesMuebles runat="server" ID="pgConBienesMuebles" EnableViewState="false" Visible="false" />
                <uc1:pgConBieneVehiculos runat="server" ID="pgConBieneVehiculos" EnableViewState="false" Visible="false" />
                <uc1:pgConAdeudos runat="server" ID="pgConAdeudos" EnableViewState="false" Visible="false" />
                <uc1:pgConObservaciones runat="server" ID="pgConObservaciones" EnableViewState="false" Visible="false" />
                <uc1:pgConInversiones runat="server" ID="pgConInversiones" EnableViewState="false" Visible="false" />
                <uc1:pgConConflicto runat="server" ID="pgConConflicto" EnableViewState="false" Visible="false" />
                <uc1:pgConEnvio runat="server" ID="pgConEnvio" EnableViewState="false" Visible="false" />

            </div>
            <div class="right">
                <asp:Button ID="btnCerrarappApartadoSelect" runat="server" ToolTip="" Text="Regresar" OnClick="btnCerrarappApartadoSelect_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

</asp:Content>
