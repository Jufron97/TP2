<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="UI.Web.HomeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="buttonPanel" CssClass="panel" HorizontalAlign="Center" runat="server">

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
    

        </asp:Panel>
    
</asp:Content>

