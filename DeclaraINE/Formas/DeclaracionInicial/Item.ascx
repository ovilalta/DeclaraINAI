<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Item.ascx.cs" Inherits="DeclaraINE.Formas.DeclaracionInicial.Item" %>

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
                    <asp:Button ID="btnEditar" runat="server" ToolTip="Modificar"  Text="Modificar" OnClick="Edita" />
                    <asp:Button ID="btnEliminar" runat="server" ToolTip="Eliminar" Text="Eliminar" OnClick="Elimina" />
                </div>
            </div> 