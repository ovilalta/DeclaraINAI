<%@ Page Title="Creación de paquetes de Informes de Transparencia" Language="C#" MasterPageFile="~/Formas/Site.Master" AutoEventWireup="true" CodeBehind="Transparencia.aspx.cs" Inherits="DeclaraINEAdmin.Formas.Transparencia" %>

<%@ Register Assembly="AlanWebControls" Namespace="AlanWebControls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="filtro-header">
            Generación de Paquetes para Transparencia
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" class="filtro">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnGenerar" />
            </Triggers>
            <ContentTemplate>
                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        Año
                    </div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="cmbAgno" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        Trimestre
                    </div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="cmbTrimestre" runat="server" CssClass="form-control">
                            <asp:ListItem Text="I Trimestre" Value="1"></asp:ListItem>
                            <asp:ListItem Text="II Trimestre" Value="2"></asp:ListItem>
                            <asp:ListItem Text="III Trimestre" Value="3"></asp:ListItem>
                            <asp:ListItem Text="IV Trimestre" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                   <div class="form-group">
                    <div class="col-md-2 filtro-label">
                        Generar Solo Públicas
                    </div>
                    <div class="col-md-10">
                        <asp:CheckBox ID="cbxSoloPublicas" runat="server" CssClass="onoff" Text=" " Checked="true"/>
                    </div>
                </div>

                <div class="center filtro-button">
                    <asp:Button ID="btnGenerar" runat="server" Text="Generar" CssClass="Image-Copy" OnClick="btnGenerar_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:AlanAlert runat="server" ID="lrt" />

</asp:Content>
