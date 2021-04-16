<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionConclusion/_Conclusion.master" AutoEventWireup="true" CodeBehind="DatosCurriculares.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionConclusion.DatosCurriculares" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">

    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server"></asp:Literal>
    </div>
    <div id="cuerpo">
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />
        <asp:AlanMessageBox runat="server" ID="MsgBox" />
        <asp:AlanQuestionBox runat="server" ID="QstSiguiente" NoText="No" YesText="Si" OnYes="QstSiguiente_Yes" OnNo="QstSiguiente_No" YesCssClass="" NoCssClass="" />
        

        <%--<asp:Panel ID="pnlDatosCurriculum" runat="server">--%>
        <div runat="server" id="grdCurriculum">
            <div>
                <asp:Button ID="btnAgregarCurriculum" runat="server" ToolTip="Agregar Dato Curricular" CssClass="big" Text="" OnClick="btnAgregarCurriculum_Click" />
                <div class="a">
                    <label>
                        Agregar Datos Curriculares
                    </label>
                    <br>
                    <%--<se>
                        </se>--%>
                </div>
                <div class="b">
                </div>
            </div>
        </div>
        <%--  </asp:Panel>--%>
    </div>
    <br />
    <br />
    <br />
    <asp:AlanModalPopUp runat="server" ID="mppDatosCurriculares" HeaderText="Datos Curriculares">
        <ContentTemplate>
            <table class="f">
                <tbody>
                    <tr>
                        <th>
                            <l>Nivel</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbNIVEL_ESCOLARIDAD" runat="server" CssClass="n3">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Institución Educativa</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtInstitucionEducativa" requerido="btnGuardarDatoCurricular" runat="server" Visible="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <l>Carrera o Área de Conocimiento</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtAREA_CONOCIMIENTO" requerido="btnGuardarDatoCurricular" runat="server" Visible="true"></asp:TextBox>
                        </td>

                    </tr>

                    <tr>
                        <th>
                            <l>Estatus</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbEstado" requerido="btnGuardarDatoCurricular" runat="server">
                            </asp:DropDownList>

                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Documento Obtenido</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbDoctoObtenido" requerido="btnGuardarDatoCurricular" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Fecha de Obtención del  Documento</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtF_OBT_DOCTO_C" requerido="btnGuardarDatoCurricular" Date="S" runat="server" MaxLength="10"></asp:TextBox>
                            <asp:CalendarExtender runat="server" ID="CalendarExtender" TargetControlID="txtF_OBT_DOCTO_C" Format="dd/MM/yyyy" />
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Lugar donde se ubica la Institución Educativa (País)</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbPais" requerido="btnGuardarDatoCurricular" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <l>Aclaraciones/Observaciones</l>
                        </th>
                        <td>
                            <asp:TextBox ID="mltObservaciones" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="right">
                <asp:Button ID="btnCerrarModal" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarModal_Click" />
                <asp:Button ID="btnGuardarDatoCurricular" runat="server" Text="Guardar" OnClick="btnGuardarDatoCurricular_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>
    <asp:AlanAlert runat="server" ID="AlertaInferior" />
</asp:Content>
