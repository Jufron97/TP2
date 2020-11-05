<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="UI.Web.HomeAdmin" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel style="position:relative; left:40%; width:60%; align-content:center; align-self:center;" runat="server">
            <h1>Menu Admin
            <asp:Label ID="lblNombreUsuario" style="position:absolute; left:70%; align-content:center; align-self:center;" runat="server" Text="Administrador"></asp:Label>
            </h1>
    </asp:Panel>
</asp:Content>

