<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeAlumno.aspx.cs" Inherits="UI.Web.Formularios.Alumno.HomeAlumno" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="HomeAlumno" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
        <asp:Panel runat="server">
            <asp:Label ID="lblNombreUsuario" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <!--
            <asp:Menu ID="Menu" runat="server">
                <Items>
                    <asp:MenuItem NavigateUrl="~/Formularios/Alumno/AlumnoInscripcion.aspx?op=VisualizarCursos" Text="Visualizar Cursos" Value="Visualizar Cursos"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Formularios/Alumno/AlumnoInscripcion.aspx?op=InscripcionCurso" Text="Inscripción a cursos" Value="Inscripción a cursos"></asp:MenuItem>          
                </Items>
            </asp:Menu>
            -->
        </asp:Panel>
</asp:Content>
