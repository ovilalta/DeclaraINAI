<%@ Page Title="" Language="C#" MasterPageFile="~/Formas/Patrimonio/_patrimonio.master" AutoEventWireup="true" CodeBehind="Patrimonio.aspx.cs" Inherits="DeclaraINE.Formas.Patrimonio.Patrimonio" %>

<%@ Register TagPrefix="ascx" TagName="Item" Src="~/Formas/Patrimonio/Item.ascx" %>
<%@ Register Src="~/Formas/Patrimonio/Adeudo.ascx" TagPrefix="uc1" TagName="Adeudo" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">



    <div class="subtitulo">
        <asp:Literal ID="Literal1" runat="server" Text="Inmuebles"></asp:Literal>
    </div>
    <asp:Panel ID="pnlBienesInmuebles" runat="server">
        <div runat="server" class="grdMD" id="grdInmueble"></div>
    </asp:Panel>
 


    <div class="subtitulo">
        <asp:Literal ID="Literal2" runat="server" Text="Muebles"></asp:Literal>
    </div>
    <asp:Panel ID="pnlOtrosBienes" runat="server">
        <div runat="server" class="grdMD" id="grdMueble"></div>
    </asp:Panel>


    <div class="subtitulo">
        <asp:Literal ID="Literal3" runat="server" Text="Vehiculos"></asp:Literal>
    </div>
    <asp:Panel ID="pnlVehiculos" runat="server">
        <div runat="server" class="grdMD" id="grdVehiculos"></div>
    </asp:Panel>
 



    <div class="subtitulo">
        <asp:Literal ID="Literal4" runat="server" Text="Inversiones"></asp:Literal>
    </div>
 
     <asp:Panel ID="pnlInversiones" runat="server">
        <div runat="server" class="grdMD" id="grdInversiones"></div>
    </asp:Panel>
 



    <div class="subtitulo">
        <asp:Literal ID="Literal5" runat="server" Text="Adeudos"></asp:Literal>
    </div>
    <asp:Panel ID="pnlAdeudo" runat="server">
        <div runat="server" class="grdMD" id="grdAdeudo"></div>
    </asp:Panel>
    

    

    <asp:AlanModalPopUp runat="server" ID="mppDetalles">
        <ContentTemplate>
            <asp:GridView ID="grdDetalles" runat="server" AutoGenerateColumns="false" ShowHeader="false" CssClass="f" Visible="true">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Literal runat="server" Text="<th><l>"></asp:Literal>
                            <asp:Literal runat="server" ID="Etiqueta" Text='<%# Eval("Etiqueta") %>' ></asp:Literal>
                            <asp:Literal runat="server" Text="</l></th>"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                              <asp:Literal runat="server" ID="Texto" Text='<%# Eval("Texto") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="right">
                <asp:Button ID="btnCerrarDetalles" runat="server" ToolTip="Cerrar" Text="Cerrar" OnClick="btnCerrarDetalles_Click" />
            </div>
        </ContentTemplate>
    </asp:AlanModalPopUp>









</asp:Content>
