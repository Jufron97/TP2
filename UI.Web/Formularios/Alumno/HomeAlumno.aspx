<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeAlumno.aspx.cs" Inherits="UI.Web.Formularios.Alumno.HomeAlumno" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="HomeAlumno" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
        <asp:Panel style="position:relative; left:40%; width:60%; align-content:center; align-self:center;" runat="server">
            <h1>Menu Usuario
            <asp:Label ID="lblNombreUsuario" style="position:absolute; left:80%; align-content:center; align-self:center;" runat="server" Text=""></asp:Label>
            </h1>
        </asp:Panel>
</asp:Content>
