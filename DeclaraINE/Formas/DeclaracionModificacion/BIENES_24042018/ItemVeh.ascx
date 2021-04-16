<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemVeh.ascx.cs" Inherits="DeclaraINE.Formas.DeclaracionModificacion.ItemVeh" %>

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
                    <asp:Button ID="btnEditar" runat="server" ToolTip="Editar"  Text="Editar" OnClick="Edita" />
                    <asp:Button ID="btnRepara" runat="server" ToolTip="Registrar Gasto De Reparaciones mayores" Text="Gastos" CssClass="mto" OnClick="Elimina" />
                                  <asp:Button ID="btnBaja" runat="server" ToolTip="Dar de baja el Vehículo (Venta,Siniestro,Donación)" CssClass="baja" Text="Desincorporar" OnClick="Baja" />
                </div>
            </div> 