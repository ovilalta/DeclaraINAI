<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pgModIngresos.ascx.cs" Inherits="DeclaraINEAdmin.Formas.De_Mantenimieto_Paginas.Dec_Modificacion.pgModIngresos" %>
<%--<asp:GridView runat="server" ID="grdIngresos" AutoGenerateColumns="true" CssClass="table table-condensed table-striped table-hover alanGrid-theme" ></asp:GridView>--%>

<table class="f">
    <tbody>
        <tr>
            <td><l>Indique el periodo laborado del año anterior como servidor público (enero a diciembre) </l></td>
            <td>Del</td>
            <td><asp:Literal  ID="txtF_INGRESO" runat="server" ></asp:Literal></td>
            <td>al</td>
            <td><asp:Literal  ID="txtF_FINAL" runat="server" ></asp:Literal></td>
        </tr>
        <tr>
            <th>
                <l>¿Presentó declaración del impuesto sobre la renta correspondiente al ejercicio  <asp:Literal ID="litAnnio" runat="server"></asp:Literal>?       </l>                   </l>
            </th>
            <td colspan="4"><asp:CheckBox ID="cbPresento" runat="server"  Enabled="false" Text=" " CssClass="onoff" /></td>
        </tr>
        <tr>
            <th>
                <l>Remuneración bruta del declarante por el cargo desempeñado <br />durante el periodo especificado (Anote la suma de sueldos, honorarios, compensaciones, bonos <br />aguinaldo y otras prestaciones)</l>
            </th>
            <td colspan="4">
                <asp:TextBox ID="moneytxtIngresosCargo" Enabled="false" runat="server" ClientIDMode="Static"></asp:TextBox>
                <div id="divmoneytxtIngresosCargo"></div>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="3">
                <div style="color: transparent;">C</div>
            </td>
        </tr>
        <tr>
            <th>
                <l>Otros Ingresos del Declarante</l>
            </th>
            <td colspan="4">
                <asp:TextBox ID="moneytxtOtros" runat="server"  Enabled="false" ClientIDMode="Static"></asp:TextBox>
                <div id="divmoneytxtOtros"></div>
            </td>
        </tr>
        <tr >
            <th>
                <l>Ingresos del Cónyuge <br /> y/o Concubino(a)</l>
            </th>
            <td colspan="4">
                <asp:TextBox ID="moneytxtingresosC" runat="server" Enabled="false" ClientIDMode="Static"></asp:TextBox>
                <div id="divmoneytxtingresosC"></div>
            </td>
       </tr>
        <tr>
            <th>
                <l>Total de recursos disponibles en el ejercicio 2017 </l>
            </th>
            <td colspan="4"> 
                <asp:TextBox ID="moneytxtingresosT" runat="server" Enabled="false" ClientIDMode="Static"></asp:TextBox>
                <div id="divmoneytxtingresosT"></div>
            </td>
        </tr>
    </tbody>
</table>
