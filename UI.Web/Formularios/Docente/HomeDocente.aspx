<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeDocente.aspx.cs" Inherits="UI.Web.Formularios.Docente.FormularioDocente" EnableEventValidation="false" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="HomeDocente" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
      <asp:Panel style="position:relative; left:40%; width:60%; align-content:center; align-self:center;" runat="server">
            <h1>Menu Docente
             <asp:Label ID="lblNombreUsuario" style="position:absolute; left:80%; align-content:center; align-self:center; top: -3px;" runat="server" Text=""></asp:Label>
            </h1>
        </asp:Panel>
</asp:Content>
