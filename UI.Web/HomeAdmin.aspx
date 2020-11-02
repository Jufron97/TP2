<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="UI.Web.HomeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel runat="server" style="border: 1px solid #000; width: 10%; height:80%; margin-top:5%; left:0%;position:relative;">
    <form runat="server" class="form-inline" Height="100%" Width="100%" Padding="0%" Position="absolute">
    <asp:Panel ID="MenuPanel" HorizontalAlign="Center" runat="server">

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
    </form>
        </asp:Panel>
</asp:Content>

