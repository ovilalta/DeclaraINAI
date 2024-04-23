<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/DeclaracionModificacion/_Modificacion.master" AutoEventWireup="true" CodeBehind="Inversiones.aspx.cs" Inherits="DeclaraINE.Formas.DeclaracionModificacion.Inversiones" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Formas/DeclaracionModificacion/ctrlDesincorpora.ascx" TagPrefix="ascx" TagName="ctrlDesincorpora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
	<div class="subtitulo">
		<asp:Literal ID="ltrSubTitulo" runat="server" Text="12. Inversiones, Cuentas Bancarias y otro tipo de Valores/Activos (Entre el 1 de enero y el 31 de diciembre del año inmediato anterior) <br/> <h6> Todos los datos de las inversiones, cuentas bancarias y otro tipo de valores/activos a nombre de la pareja, dependientes económicos y/o terceros o que sean en copropiedad con el declarante no serán públicos </br> Inversiones, cuentas bancarias y otro tipo de valores del declarante, pareja y/o dependientes económicos"> </asp:Literal>
	</div>
	<asp:AlanMessageBox runat="server" ID="MsgBox" />

		
	<div id="cuerpo">


		<asp:AlanQuestionBox runat="server" ID="QstBox" NoText="No" YesText="Si" OnNo="QstBox_No" OnYes="QstBox_Yes" YesCssClass="" NoCssClass="" />

		<div runat="server" id="grd">
			<div>
				<asp:Button ID="btnAgregarInversion" runat="server" CssClass="big" Text="" OnClick="btnAgregarInversion_Click" />
				<div class="a">
					<label>
						Agregar
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
							<l>Tipo de Inversión/activo</l>
						</th>
						<td>

							<%--<asp:DropDownList ID="cmbNID_TIPO_INVERSION" runat="server" CssClass="n2" requerido="btnGuardar" OnSelectedIndexChanged="cmbNID_TIPO_INVERSION_SelectedIndexChanged" AutoPostBack="True">
									<asp:ListItem Text="" VALUE= "0"></asp:ListItem>
									<asp:ListItem Text="Bancaria"  Value= "1"></asp:ListItem>
									<asp:ListItem Text="Fondos de Inversión"  Value= "3"></asp:ListItem>
									<asp:ListItem Text="Organizaciones Privadas y/o Mercantiles"  Value= "4"></asp:ListItem>
									<asp:ListItem Text="Posesión de Monedas y/o Metales"  Value= "5"></asp:ListItem>
									<asp:ListItem Text="Seguros"  Value= "11"></asp:ListItem>
									<asp:ListItem Text="Valores Bursátiles"  Value= "2"></asp:ListItem>
									<asp:ListItem Text="Afores y otros"  Value= "10"></asp:ListItem>
								   
							</asp:DropDownList>--%>
							<asp:DropDownList ID="cmbNID_TIPO_INVERSION" runat="server" CssClass="n2" requerido="btnGuardar" OnSelectedIndexChanged="cmbNID_TIPO_INVERSION_SelectedIndexChanged" AutoPostBack="True">
							</asp:DropDownList>
							<asp:DropDownList ID="cmbNID_SUBTIPO_INVERSION" runat="server" CssClass="n2" requerido="btnGuardar">
							</asp:DropDownList>

						</td>
					</tr>
					  <tr>
						<th>
							<l>Titular de la inversión, cuenta bancaria <br /> y otro tipo de valores</l>
						</th>
						<td>
							<asp:DropDownList ID="chbDependietesInm" runat="server"  OnSelectedIndexChanged="chbDependietesInm_SelectedIndexChanged"  AutoPostBack="true">
									<asp:ListItem Text="Declarante" VALUE= "0"></asp:ListItem>
									<asp:ListItem Text="Declarante y Cónyuge"  Value= "1"></asp:ListItem>
									<asp:ListItem Text="Declarante en Copropiedad con Terceros"  Value= "3"></asp:ListItem>
									<asp:ListItem Text="Declarante y Cónyuge en Copropiedad con Terceros"  Value= "2"></asp:ListItem>
									<asp:ListItem Text="Declarante y Concubina o Concubinario"  Value= "4"></asp:ListItem>
									<asp:ListItem Text="Declarante y Concubina o Concubinario en Copropiedad con Terceros"  Value= "5"></asp:ListItem>
									<asp:ListItem Text="Cónyuge"  Value= "6"></asp:ListItem>
									<asp:ListItem Text="Cónyuge en Copropiedad con Terceros"  Value= "7"></asp:ListItem>
									<asp:ListItem Text="Concubina o Concubinario"  Value= "8"></asp:ListItem>
									<asp:ListItem Text="Concubina o Concubinario en Copropiedad con Terceros"  Value= "9"></asp:ListItem>
									<asp:ListItem Text="Conviviente"  Value= "10"></asp:ListItem>
									<asp:ListItem Text="Declarante y Conviviente"  Value= "11"></asp:ListItem>
									<asp:ListItem Text="Declarante y Conviviente en Copropiedad con Terceros"  Value= "12"></asp:ListItem>
									<asp:ListItem Text="Conviviente y Dependiente Económico"  Value= "13"></asp:ListItem>
									<asp:ListItem Text="Conviviente y Dependiente Económico en Copropiedad con Terceros"  Value= "14"></asp:ListItem>
									<asp:ListItem Text="Dependiente Económico"  Value= "15"></asp:ListItem>
									<asp:ListItem Text="Declarante y Dependiente Económico"  Value= "16"></asp:ListItem>
									<asp:ListItem Text="Dependiente Económico en Copropiedad con Terceros"  Value= "17"></asp:ListItem>
									<asp:ListItem Text="Declarante, Cónyuge y Dependiente Económico"  Value= "18"></asp:ListItem>
									<asp:ListItem Text="Declarante, Concubina o Concubinario y Dependiente Económico"  Value= "19"></asp:ListItem>
									<asp:ListItem Text="Cónyuge y Dependiente Económico"  Value= "20"></asp:ListItem>
									<asp:ListItem Text="Concubina o Concubinario y Dependiente Económico"  Value= "21"></asp:ListItem>
									<asp:ListItem Text="Cónyuge y Dependiente Económico en Copropiedad con Terceros"  Value= "22"></asp:ListItem>
									<asp:ListItem Text="Concubina o Concubinario y Dependiente Económico en Copropiedad con Terceros"  Value= "23"></asp:ListItem>
								   <asp:ListItem Text="Otro"  Value= "24"></asp:ListItem>
							</asp:DropDownList>
							<asp:CheckBoxList ID="cblTitulares" Visible="false" runat="server"></asp:CheckBoxList>
						</td>
					</tr>
					<%-- <tr>
						<th>
							<l><b>TERCERO</b></l>
						</th>

					</tr>--%>
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
					<tr  >
						<th>
							<l>RFC del tercero</l>
						</th>
						<td>
							<asp:TextBox ID="txtTerceroRFC" runat="server" MaxLength="13" Enabled="false"></asp:TextBox>
						</td>
					</tr>

					 <tr>
						<th>
							<l>Número de Cuenta, Contrato o Póliza</l>
						</th>
						<td>
							<asp:TextBox ID="txtE_CUENTA" runat="server" requerido="btnGuardar" MaxLength="100"></asp:TextBox>
						</td>
					</tr>

					<tr>
						<th>
							<l>¿Dónde se localiza la inversión, cuenta bancaria<br /> y otro tipo de valores / activos?</l>
						</th>
						<td>

							<asp:DropDownList ID="cmbNID_PAIS" runat="server" CssClass="n3" requerido="btnGuardar" AutoPostBack="True" OnSelectedIndexChanged="cmbNID_PAIS_SelectedIndexChanged">
							</asp:DropDownList>
							<asp:DropDownList ID="cmbCID_ENTIDAD_FEDERATIVA" runat="server" CssClass="n3">
							</asp:DropDownList>
							<asp:TextBox ID="txtV_LUGAR" runat="server" CssClass="n3"  Visible="False"></asp:TextBox>
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
					<tr runat="server" id="idRFC" visible="false">
						<th>
							<l>RFC</l>
						</th>

						<td>
							<asp:TextBox ID="txtV_RFC" runat="server" requerido="btnGuardar" MaxLength="13"></asp:TextBox>

						</td>
					</tr>
					<tr>
						<th>
							<l>Saldo al 31 de diciembre del año inmediato anterior</l>
						</th>
						<td>
							<asp:TextBox ID="moneytxtM_SALDO" requerido="btnGuardar" runat="server" ClientIDMode="Static" AutoCompleteType="None" MaxLength="19"></asp:TextBox>
							<div id="divmoneytxtM_SALDO"></div>
						</td>
					</tr>
				   
					<tr style="display:none">
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
							<asp:DropDownList ID="ddlTipoMonedaInm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoMonedaInm_SelectedIndexChanged">
								<asp:ListItem Text="" Value="0"></asp:ListItem>
								<asp:ListItem Text="MXN-Peso Mexicano" Value="101"></asp:ListItem>
                                <asp:ListItem Text="USN-Dolar Americano"  Value="148"></asp:ListItem>
                                <asp:ListItem Text="CAD-Dolar Canadiense"  Value="27"></asp:ListItem>
								<asp:ListItem Text="EUR-EUro"  Value="48"></asp:ListItem>
								<asp:ListItem Text="MXV-UDI"  Value="102"></asp:ListItem>
						</asp:DropDownList>
							<asp:TextBox ID="txtTipoMoneda" runat="server"  Visible="false" MaxLength="50"></asp:TextBox>
						</td>
					</tr>
				   
					<tr style="display:none">
						<th>
							<l>Fecha de baja del tipo de Inversión/Activo</l>
						</th>
						<td>
						   
							 <asp:TextBox ID="txtF_BAJA" runat="server"  Date="S" AutoPostBack="true" MaxLength="10"></asp:TextBox>
							 <asp:CalendarExtender runat="server" ID="txtF_BAJA_C" TargetControlID="txtF_BAJA" Format="dd/MM/yyyy" />
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

		 <asp:AlanModalPopUp runat="server" ID="mppBaja">
		<ContentTemplate>
			<ascx:ctrlDesincorpora runat="server" ID="ctrlDesincorpora1" />
			<div class="right">
				<br />
				
				
				<asp:Button ID="btnCerrarBaja" runat="server"  Text="Cerrar" OnClick="btnCerrarBaja_Click"  />
				<asp:Button ID="btnGuardarBaja" runat="server" Text="Guardar" OnClick="btnGuardarBaja_Click" />
				 <asp:Button ID="btnEliminarBaja" runat="server" Text="Eliminar"  OnClick="btnEliminarBaja_Click" />
				 <br />
				 <br />
				 <br />
				 <br />
			</div>
		</ContentTemplate>
	</asp:AlanModalPopUp>
</asp:Content>

