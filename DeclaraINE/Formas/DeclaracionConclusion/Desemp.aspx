<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionConclusion/_Conclusion.master" AutoEventWireup="true" CodeBehind="Desemp.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionConclusion.Desemp" %>
<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/SioNo.ascx" TagPrefix="uc1" TagName="SioNo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">

  
        <script type="text/javascript">

            function nombrecampo(nombre, area, maximo) {
                NombreTXT = nombre;
                limite = maximo;
                numeroDeC = area.value.length;

                if (numeroDeC > limite) {
                    area.value = area.value.substring(0, limite);
                }
                else {
                    if (NombreTXT == "txtObservaciones") {
                       <%-- $('#<%=txtcuenta.ClientID%>').val(Text = "Número de caractéres capturados:" + numeroDeC);--%>
                    }
                }
            }


 </script>
      <div class="subtitulo">
        <asp:Literal ID="ltrSubTitulo" runat="server"> </asp:Literal> 
        <asp:CheckBox ID="cbxFuisteServidor" runat="server" Checked="false" AutoPostBack="true" OnCheckedChanged="cbxFuisteServidor_CheckedChanged" CssClass="onoff" Text=" " />
    </div>
   
     <asp:Label ID="lblAuxiliar" runat="server"  Visible="false" Width="25px" Text="Label"></asp:Label>
        <asp:Label ID="lblAuxiliarBE" runat="server"  Visible="false" Width="25px" Text="Label"></asp:Label>
    <asp:AlanAlert runat="server" ID="AlertaSuperior" />
  <div id="cuerpo" runat="server" visible="false">
        <table class="f">
                <tbody>
                <tr>
                    <td>
                        <l>                                  </l>
                    </td>
                    <td>Fecha de inicio
                    </td>
                    <td>
                        <asp:TextBox ID="txtF_INGRESO" runat="server" Date="S" MaxLength="10" ></asp:TextBox>
                        <asp:CalendarExtender runat="server" ID="txtF_INGRESO_C" TargetControlID="txtF_INGRESO" Format="dd/MM/yyyy" />
                    </td>
                    <td>Fecha de conclusión
                    </td>
                    <td>
                        <asp:TextBox ID="txtF_FINAL" runat="server" Date="S" MaxLength="10"></asp:TextBox>
                        <asp:CalendarExtender runat="server" ID="txtF_FINAL_C" TargetControlID="txtF_FINAL" Format="dd/MM/yyyy" />
                </tr>
                </tbody>
            </table>

     
         <asp:GridView ID="grdPreguntas" CssClass="table-striped table-condensed borderless" runat="server" AutoGenerateColumns="false" ShowHeader="false" OnRowDataBound="grdPreguntas_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText=""  ItemStyle-Width="60%">
                        <ItemTemplate>
                              <asp:Literal ID="ltrPregunta" runat="server" Text='<%# Eval("E_ESPECIFICAR") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="NID_INGRESO" runat="server"  Text='<%# Eval("NID_INGRESO") %>' CssClass="invisible"></asp:Label>
                            <asp:DropDownList ID="cmbRespuesta" runat="server"  OnSelectedIndexChanged="cmbRespuesta_SelectedIndexChanged" AutoPostBack="true">

                            </asp:DropDownList>
                            <asp:DropDownList ID="cmbRespuestaBE" runat="server"  OnSelectedIndexChanged="cmbRespuestaBE_SelectedIndexChanged" 
                                AutoPostBack="true">
                                  <asp:ListItem Text="" Value=""></asp:ListItem>
                                  <asp:ListItem Text="Mueble" Value="1"></asp:ListItem>
                                  <asp:ListItem Text="Inmueble" Value="2"></asp:ListItem>
                                  <asp:ListItem Text="Vehículo" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtRespuesta" runat="server" Text='<%# Eval("E_ESPECIFICAR_COMPLEMENTO") %>'   CssClass="invisible" ></asp:TextBox>
                            <asp:TextBox ID="txtC_TITULAR" runat="server" Text='<%# Eval("C_TITULAR") %>' CssClass="invisible"></asp:TextBox>
                            <asp:TextBox ID="txtMonto" runat="server" Text='<%# Eval("M_INGRESO") %>'   MaxLength="19"   OnTextChanged="txtMonto_TextChanged" 
                                CssClass="invisible" ></asp:TextBox>
                            <div id="divtxtMonto"></div>
                               
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <table class="f">
                <tr>
                    <th>
                        <l>Aclaraciones/Observaciones</l>

                        
                    </th>
                    <td>
                        <asp:TextBox ID="txtObservaciones" runat="server" onkeyDown="nombrecampo('txtObservaciones',this,'2000')" 
                            onkeyup="nombrecampo('txtObservaciones',this,'2000')" MaxLength="2000" TextMode="MultiLine" Width="100%" Height="65px"></asp:TextBox>
                    </td>
                </tr>
            </table>
    </div>
      <div class="right">
                <asp:Button ID="btnGuardarPreguntas" runat="server" Text="Guardar" OnClick="btnGuardarPreguntas_Click" OnClientClick="return CheckReq();" />
      </div>
    <br />
    <br />
    <br />
</asp:Content>
