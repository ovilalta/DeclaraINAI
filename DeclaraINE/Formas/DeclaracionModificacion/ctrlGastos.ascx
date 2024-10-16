<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlGastos.ascx.cs" Inherits="DeclaraINAI.Formas.DeclaracionModificacion.ctrlGastos" %>


<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

        <asp:GridView ID="grd" runat="server" ShowHeader="false" CssClass="table-striped table-condensed borderless" OnRowDataBound="grd_RowDataBound" AutoGenerateColumns="false" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:DropDownList ID="cmbV_GASTO" runat="server" ></asp:DropDownList>
                        <asp:TextBox ID="txtV_GASTO" runat="server" ></asp:TextBox>
                        <div style="color: white">C</div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:TextBox ID="moneytxtM_GASTO" runat="server" Text='<%# Eval("M_GASTO","{0:C0}") %>'></asp:TextBox>
                        <div runat="server" id="div" clientidmode="Static"></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="NID_GASTO" runat="server" Text='<%# Eval("NID_GASTO") %>' CssClass="invisible"></asp:Label>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("NID_GASTO") %>' OnClick="btnEliminar_Click" Visible='<%# !Convert.ToBoolean(Eval("L_AUTOGENERADO")) %>' />
                        <div style="color: white">C</div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

