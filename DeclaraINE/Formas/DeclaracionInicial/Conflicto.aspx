<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionInicial/_Inicial.master" AutoEventWireup="true" CodeBehind="Conflicto.aspx.cs" Inherits="DeclaraINAI.Formas.DeclaracionInicial.Conflicto" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Src="~/Formas/SioNo.ascx" TagPrefix="uc1" TagName="SioNo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <asp:AlanMessageBox runat="server" ID="MsgBox" />
    <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server" Text="II. Declaración de Intereses"></asp:Literal>
    </div>
    <div id="cuerpo">
        <label>
            La declaración de intereses tendrá por objeto informar y determinar el conjunto de intereses de un servidor público a fin de delimitar cuándo éstos entran en conflicto con su función.
            <br />
            El conflicto de interés es la posible afectación del desempeño imparcial y objetivo de las funciones de los Servidores Públicos en razón de intereses personales, familiares o de negocios.
        </label>
        <asp:GridView ID="grdRubros" runat="server" AutoGenerateColumns="false" CssClass="table table-striped borderless" OnRowDataBound="grdRubros_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="En este sentido:">
                    <ItemTemplate>
                        <asp:Label ID="NID_RUBRO" runat="server" Text='<%# Eval("NID_RUBRO") %>' CssClass="invisible"></asp:Label>
                        <asp:Literal ID="ltrPregunta" runat="server" Text='<%# Eval("V_RUBRO") %>'></asp:Literal>
                        <br />
                        <asp:Panel runat="server" ID="panel" Visible='<%# Eval("L_ENCABEZADOS") %>' ClientIDMode="Static" CssClass="right" >
                            <asp:GridView ID="grdEncabezados" runat="server" CssClass="table table-striped table-condensed table-hover" ShowHeader="false" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltrDescripcion" runat="server" Text='<%# Eval("V_DESCRIPCION") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnEditar" runat="server" Text="Editar" ToolTip="Editar" OnClick="btnEditar_Click" CommandArgument='<%# Eval("NID_RUBRO").ToString()  + "|" + Eval("NID_ENCABEZADO").ToString() %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnBorrar" runat="server" Text="Eliminar" ToolTip="Eliminar" OnClick="btnBorrar_Click" CommandArgument='<%# Eval("NID_RUBRO").ToString()  + "|" + Eval("NID_ENCABEZADO").ToString() %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>

                       
                        </asp:Panel>
                             <br />
                        <asp:Button ID="btnAgregarEncabezado" runat="server" Text="Agregar " OnClick="btnSI_Click" CommandArgument='<%# Eval("NID_RUBRO") %>' Visible="false" />
                             <br />
                             <br />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Si">
                    <ItemTemplate>
                        <asp:Button ID="btnSI" runat="server" Text="" CommandArgument='<%# Eval("NID_RUBRO") %>' CssClass='<%# Eval("L_RESPUESTA") == null ? "btnFalse2" : (!Convert.ToBoolean(Eval("L_RESPUESTA")) ? "btnFalse2" : "btnTrue2") %>' OnClick="btnSI_Click" Enabled='<%#  Eval("L_RESPUESTA") == null ? true : !Convert.ToBoolean(Eval("L_RESPUESTA")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No">
                    <ItemTemplate>
                        <asp:Button ID="btnNO" runat="server" Text="" CommandArgument='<%# Eval("NID_RUBRO") %>' CssClass='<%# Eval("L_RESPUESTA") == null ? "btnFalse2" : !Convert.ToBoolean(Eval("L_RESPUESTA")) ? "btnTrue2" : "btnFalse2" %>' OnClick="btnNO_Click" Enabled='<%# Eval("L_RESPUESTA") == null ? true : Convert.ToBoolean(Eval("L_RESPUESTA")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="row">            
                <l>Aclaraciones/Observaciones</l>            
            
                <asp:TextBox ID="GuardarObservacionesConflicto" runat="server" onkeyDown="nombrecampo('btnGuardarObservacionesConflicto',this,'1000')"
                    onkeyup="nombrecampo('btnGuardarObservacionesConflicto',this,'1000')" MaxLength="1000" TextMode="MultiLine" Width="100%"></asp:TextBox>            
        </div>
        <div>
            <br />
        </div>
        <div class="row">
            <asp:Button ID="btnGuardarObservacion" runat="server" Text="Guardar" OnClick="btnGuardarObservacionesConflicto"  Visible="true" />
            <%--<asp:Button ID="btnRegresarIndex" runat="server" Text="Terminar" OnClick="btnRegresarIndex2"  Visible="true" />--%>
        </div>
    </div>
    <br />
    <br />
    <br />



    <asp:AlanModalPopUp runat="server" ID="mppPreguntas" HeaderText="Información Adicional">
        <ContentTemplate>
             <table class="f" style="display:none">
                <tr>
                    <td>
                        <asp:Label ID="lblEncabezado" runat="server" Text="" Font-Size="Smaller"></asp:Label></br>
                        ¿Esta relación le genera o puede ser susceptible de un conflicto de intereses con relación a su cargo público?    
                        <uc1:SioNo runat="server" ID="cbx" />
                    </td>
                </tr>
            </table>
             <table class="f" >
                <tr>
                    <td>
                        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="grdPreguntas" CssClass="table-striped table-condensed borderless" runat="server" AutoGenerateColumns="false" ShowHeader="false" OnRowDataBound="grdPreguntas_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="NID_RUBRO" runat="server" Text='<%# Eval("NID_RUBRO") %>' CssClass="invisible"></asp:Label>
                            <asp:Label ID="NID_ENCABEZADO" runat="server" Text='<%# Eval("NID_ENCABEZADO") %>' CssClass="invisible"></asp:Label>
                            <asp:Label ID="NID_PREGUNTA" runat="server" Text='<%# Eval("NID_PREGUNTA") %>' CssClass="invisible"></asp:Label>
                            <asp:Literal ID="ltrPregunta" runat="server" Text='<%# Eval("V_RUBRO") %>'></asp:Literal>
                            <asp:DropDownList ID="cmbRespuesta" runat="server" OnSelectedIndexChanged="cmbRespuesta_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:TextBox ID="txtRespuesta" runat="server" Text='<%# Eval("V_RESPUESTA") %>'></asp:TextBox>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

           

            <div class="right">
                <asp:Button ID="btnCerrarModal" runat="server" ToolTip="" Text="Cerrar" OnClick="btnCerrarModal_Click" />
                <asp:Button ID="btnGuardarPreguntas" runat="server" Text="Guardar" OnClick="btnGuardar_Click" OnClientClick="return CheckReq();" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>

</asp:Content>
