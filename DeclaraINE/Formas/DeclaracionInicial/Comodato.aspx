<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionInicial/_Inicial.master" AutoEventWireup="true" CodeBehind="Comodato.aspx.cs" Inherits="DeclaraINAI.Formas.DeclaracionInicial.Comodato" %>
<%@ Register TagPrefix="ascx" TagName="Item" Src="~/Formas/DeclaracionInicial/Item.ascx" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
        <asp:Literal ID="ltrSubTitulo" runat="server"></asp:Literal>
    </div>
     <div id="cuerpo">
          <asp:AlanQuestionBox runat="server" ID="QstBoxInm" NoText="No" YesText="Si" YesCssClass="" NoCssClass="" OnNo="QstBoxInm_No" OnYes="QstBoxInm_Yes" />   
        <asp:AlanAlert runat="server" ID="AlertaSuperior" />

        <asp:Panel ID="pnlComoDato" runat="server">
            <div runat="server" id="grdComoDato">
                <div>
                    <asp:Button ID="btnAgregarComoDato" runat="server" ToolTip="Agregar Dato" CssClass="big" Text=""  OnClick="btnAgregarComoDato_Click" />
                    <div class="a">
                        <label>
                            Agregar
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
    <asp:AlanModalPopUp runat="server" ID="mppDatos">
        <ContentTemplate>
            <table class="f">
                <tr>
                    <th>
                        <l>Tipo de bien</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmbTipoBien" runat="server" requerido="btnGuardarComodo"  AutoPostBack="true"  OnSelectedIndexChanged="cmbTipoBien_SelectedIndexChanged" >
                              <asp:ListItem Text="" Value=""></asp:ListItem>
                              <asp:ListItem Text="Inmueble" Value="1"></asp:ListItem>
                              <asp:ListItem Text="Vehículo" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Dueño o Titular</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmbTipoPersona" runat="server" requerido="btnGuardarComodo"  AutoPostBack="true" OnSelectedIndexChanged="cmbTipoPersona_SelectedIndexChanged1" >
                              <asp:ListItem Text="" Value=""></asp:ListItem>
                              <asp:ListItem Text="Persona Moral" Value="M"></asp:ListItem>
                              <asp:ListItem Text="Persona Fisica" Value="F"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Nombre del Dueño o Titular</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtvNombre" runat="server" requerido="btnGuardarComodo" ClientIDMode="Static" AutoCompleteType="None" MaxLength="250"></asp:TextBox>
                    </td>
                </tr>


                 <tr>
                    <th>
                        <l>PRIMER APELLIDO	del Dueño o Titular</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtvPrimer_Apelido" runat="server" requerido="btnGuardarComodo" ClientIDMode="Static" AutoCompleteType="None" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>

               <tr>
                    <th>
                        <l>SEGUNDO APELLIDO del Dueño o Titular</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtvSegundo_Apellido" runat="server" requerido="btnGuardarComodo" ClientIDMode="Static" AutoCompleteType="None" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <th>
                        <l>RFC</l>
                    </th>
                    <td>
                        <asp:TextBox ID="txtvRFC" runat="server" requerido="btnGuardarComodo" ClientIDMode="Static" AutoCompleteType="None" MaxLength="13"></asp:TextBox>
                       
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>Relación con el dueño o titular</l>
                    </th>
                    <td>
                        <%--<asp:CheckBoxList ID="cblTitulares" runat="server"></asp:CheckBoxList>--%>
                        <asp:DropDownList ID="cmbNID_TIPO_RELACION" runat="server"  requerido="btnGuardarComodo" Visible="false" AutoPostBack="true"  OnSelectedIndexChanged="cmbNID_TIPO_RELACION_SelectedIndexChanged" ></asp:DropDownList>
                        <asp:TextBox ID="txtTipo_relacion" MaxLength="50" runat="server"></asp:TextBox>
                    </td>
                </tr>
               <%-- <tr>
                    <th>
                        <l>Aclaraciones/Observaciones</l>

                        
                    </th>
                    <td>
                        <asp:TextBox ID="txtObservaciones" runat="server" onkeyDown="nombrecampo('txtObservaciones',this,'2000')" 
                            onkeyup="nombrecampo('txtObservaciones',this,'2000')" MaxLength="2000" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </td>
                </tr>--%>
                 
            </table>
            <div id="idVeviculos" runat="server" visible="false">
             <table class="f" >
                <tr>
                    <th>
                        <l>Tipo Vehículo</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmdNID_TIPO_VEHICULO" runat="server" requerido="btnGuardarComodo" AutoPostBack="true" OnSelectedIndexChanged="cmdNID_TIPO_VEHICULO_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <th>
                        <l>Marca</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmbMarca" runat="server" requerido="btnGuardarComodo"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                        <th>
                            <%--<l>Descripción del vehículo</l>--%>
                            <l>Modelo</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtTipo" runat="server" requerido="btnGuardarComodo" MaxLength="255"></asp:TextBox>
                        </td>
                 </tr>
                 <tr>
                        <th>
                            <l>Año</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="dpModelo" runat="server" requerido="btnGuardarComodo"></asp:DropDownList>
                        </td>
                 </tr>
                 <tr>
                        <th>
                            <l>País de Registro/Entidad Federativa</l>
                        </th>
                        <td>
                            <asp:DropDownList ID="cmbnIdPaisOrigen" runat="server" CssClass="n2" requerido="btnGuardarComodo"  OnSelectedIndexChanged="cmbnIdPaisOrigen_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:DropDownList ID="cmbcIdEntidadFederativaOrigen" runat="server" CssClass="n2" requerido="btnGuardarComodo" AutoPostBack="true"></asp:DropDownList>

                        </td>
                 </tr>
                  <tr>
                        <th>
                            <l>Número de Serie</l>
                        </th>
                        <td>
                            <asp:TextBox ID="txtvSerie" runat="server" requerido="btnGuardarComodo" ClientIDMode="Static" AutoCompleteType="None" MaxLength="17"></asp:TextBox>
                        </td>
                 </tr>
              </table>
            </div>
            <div id="idInmueble" runat="server" visible="false">
               <table class="f" >
                <tr>
                    <th>
                        <l>Tipo Inmueble</l>
                    </th>
                    <td>
                        <asp:DropDownList ID="cmbNID_TIPO_INMUEBLE" runat="server" requerido="btnGuardarComodo" AutoPostBack="true"  OnSelectedIndexChanged="cmbNID_TIPO_INMUEBLE_SelectedIndexChanged" ></asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>
                    <th>
                        <l>País</l>
                    </th>
                    <td>
                               <asp:DropDownList ID="cmbnIdPais" runat="server" CssClass="n2" requerido="btnGuardarComodo"  OnSelectedIndexChanged="cmbnIdPais_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList>
                               <asp:DropDownList ID="cmbcIdEntidadFederativa" runat="server" CssClass="n2" requerido="btnGuardarComodo" OnSelectedIndexChanged="cmbcIdEntidadFederativa_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                    </td>
                </tr>
                 <tr runat="server" visible="true" id="idMunicipio">
                    <th>
                        <l>Municipio o Alcaldia</l>
                    </th>
                    <td>
                       <asp:DropDownList ID="cmbMunicipio" runat="server"  requerido="btnGuardarComodo"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <th>
                        <l>C.P.</l>
                    </th>
                    <td>
                       <asp:TextBox ID="txtcCodigoPostal" runat="server" MaxLength="5" requerido="btnGuardarComodo" OnTextChanged="txtcCodigoPostal_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                     
                    <th>
                        <l><asp:Label ID="lblLocalidad" runat="server" Text="Colonio/localidad"></asp:Label></l>
                    </th>
                    <td>
                       <asp:TextBox ID="txtColoniaParticular" runat="server" requerido="btnGuardarComodo" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>

                <tr runat="server" id="idEdoProv" visible="false">
                     
                    <th>
                        <l>Estado/Provincia</l>
                    </th>
                    <td>
                       <asp:TextBox ID="txtEdo_Provincia" runat="server" requerido="btnGuardarComodo" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th><l>Calle/No. Exterior/No. Interior</l></th>
                    <td>
                         <asp:TextBox ID="txtCalle" runat="server" requerido="btnGuardarComodo" CssClass="n3" MaxLength="150"></asp:TextBox>
                        <asp:TextBox ID="txtNumExterior" runat="server" requerido="btnGuardarComodo" CssClass="n3" MaxLength="15"></asp:TextBox>
                        <asp:TextBox ID="txtNumInterior" runat="server" CssClass="n3" MaxLength="15"></asp:TextBox>
                    </td>
                </tr>
              </table>
            </div>
             <div  id="divObservaciones" runat="server" visible="false" >
                 <table class="f" >
                         <tr>
                            <th>
                                <l>Aclaraciones/Observaciones  </l>

                        
                            </th>
                            <td>
                                <asp:TextBox ID="txtObservaciones" runat="server" onkeyDown="nombrecampo('txtObservaciones',this,'2000')" 
                                    onkeyup="nombrecampo('txtObservaciones',this,'2000')" MaxLength="2000" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                 
                    </table>
            </div>
            <div class="right">
               
                <asp:Button ID="btnCerrarComodo" runat="server" ToolTip="Cerrar" Text="Cerrar" OnClick="btnCerrarComodo_Click" />
                <asp:Button ID="btnGuardarComodo" runat="server" ToolTip="Guardar" Text="Guardar" OnClientClick="return CheckReq();" ClientIDMode="Static" OnClick="btnGuardarComodo_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>
    <br />
    <br />
    <br />

</asp:Content>


