<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="UI.Web.HomeAdmin" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel style="position:relative; left:40%; width:60%; align-content:center; align-self:center;" runat="server">
            <h1>Menu Admin<asp:Label ID="lblNombreUsuario" style="position:absolute; left:70%; align-content:center; align-self:center;" runat="server" Text="Administrador"></asp:Label>
            </h1>
        </asp:Panel>

   <!--  <asp:Panel ID="MenuPanel" HorizontalAlign="Center" runat="server">

       <asp:Menu ID="Menu" runat="server">
        <Items>
            <asp:MenuItem NavigateUrl="~/Formularios/Usuarios.aspx" Text="Usuarios" Value="Usuarios"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Formularios/Especialidades.aspx" Text="Especialidades" Value="Especialidades"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Formularios/Planes.aspx" Text="Planes" Value="Planes"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Formularios/Materias.aspx" Text="Materias" Value="Materias"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Formularios/Cursos.aspx" Text="Cursos" Value="Nuevo elemento"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Formularios/Comisiones.aspx" Text="Comisiones" Value="Comisiones"></asp:MenuItem>
        </Items>
    </asp:Menu>
    
        </asp:Panel> -->

</asp:Content>

