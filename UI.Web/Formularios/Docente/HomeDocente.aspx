<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeDocente.aspx.cs" Inherits="UI.Web.Formularios.Docente.FormularioDocente" %>

<asp:Content ID="HomeDocente" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <form runat="server">

        <asp:Panel runat="server">

            <asp:Label ID="lblNombreUsuario" runat="server" Text=""></asp:Label>

            <asp:Label ID="lblLegajo" runat="server" Text=""></asp:Label>

        </asp:Panel>


        <asp:Panel ID="MenuPanel" CssClass="panel" HorizontalAlign="Center" runat="server">

        <asp:Menu ID="Menu" runat="server" OnMenuItemClick="Menu_MenuItemClick">
        <Items>

            <asp:MenuItem NavigateUrl="~/Formularios/Docente/RegistroNotas.aspx" Text="Registro de Notas" Value="Usuarios"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Formularios/Docente/ReporteCursos.aspx" Text="Reporte de Cursos" Value="Especialidades"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Formularios/Docente/ReportePlanes.aspx" Text="Reporte de Planes" Value="Planes"></asp:MenuItem>

        </Items>
    </asp:Menu>
    

        </asp:Panel>

        </form>
</asp:Content>
