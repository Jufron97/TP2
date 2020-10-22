<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="UI.Web.HomeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="buttonPanel" CssClass="panel" HorizontalAlign="Center" runat="server">

        <asp:Menu ID="Menu" runat="server">
        <Items>
            <asp:MenuItem NavigateUrl="~/Formularios/Usuarios.aspx" Text="Usuarios" Value="Usuarios"></asp:MenuItem>
        </Items>
    </asp:Menu>
    

        </asp:Panel>
    
</asp:Content>

