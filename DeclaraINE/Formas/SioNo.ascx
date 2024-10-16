<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SioNo.ascx.cs" Inherits="DeclaraINAI.Formas.SioNo" %>

<div class="yesno">
    <div>
        <asp:RadioButton ID="rbtnYes" GroupName="yn" runat="server" CssClass="yes" Text="Si" OnCheckedChanged="Changed" />
        <asp:RadioButton ID="rbtNo" GroupName="yn" runat="server" CssClass="no" Text="No" OnCheckedChanged="Changed" />
    </div>
    <asp:RadioButton ID="rbtAny" GroupName="yn" runat="server" Text="*Seleccione una opción" Checked="true" />
</div>

