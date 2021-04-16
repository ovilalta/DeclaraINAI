<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemInv.ascx.cs" Inherits="DeclaraINE.Formas.DeclaracionModificacion.ItemInv" %>

<div >
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
    </div>
</div>
