<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemAct.ascx.cs" Inherits="DeclaraINAI.Formas.DeclaracionModificacion.ItemAct" %>

<div>
    <asp:Image ID="img" runat="server" />
    <div class="a">
        <label>
            <asp:Literal ID="ltrPrincipal" runat="server"></asp:Literal>
        </label>
        <br>
        <se>
                            <asp:Literal ID="ltrSecundario" runat="server"></asp:Literal>
                        </se>
    </div>
    <div class="b">
        <asp:Button ID="btnEditar" runat="server" ToolTip="Editar" Text="Editar" OnClick="Edita" />
        <asp:Button ID="btnGastos" runat="server" ToolTip="Registrar Gasto (Reparaciones y Remodelaciones)" CssClass="amplia" Text="Rep y Remod" OnClick="Elimina" />
        <asp:Button ID="btnBaja" runat="server" ToolTip="Dar de baja el Inmueble (Venta,Siniestro,Donaciòn)" CssClass="baja" Text="Desincorporar" OnClick="Baja" />
    </div>
</div>
