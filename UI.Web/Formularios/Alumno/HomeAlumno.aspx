<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeAlumno.aspx.cs" Inherits="UI.Web.Formularios.Alumno.FormularioAlumno" %>
<asp:Content ID="HomeAlumno" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <form runat="server">
        <asp:Panel runat="server" CssClass="panel">
            <asp:Label ID="lblNombreUsuario" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblLegajo" runat="server" Text=""></asp:Label>
        </asp:Panel>
        <asp:Panel ID="MenuPanel" CssClass="panel" HorizontalAlign="Center" runat="server">
            <asp:Menu ID="Menu" runat="server">
                <Items>
                    <asp:MenuItem NavigateUrl="~/Formularios/Alumno/AlumnoInscripcion.aspx?op=Curso" Text="Visualizar Cursos" Value="Visualizar Cursos"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Formularios/Alumno/AlumnoInscripcion.aspx?op=Inscripcion" Text="Inscripción a cursos" Value="Inscripción a cursos"></asp:MenuItem>          
                </Items>
            </asp:Menu>
        </asp:Panel>
    </form>
</asp:Content>
