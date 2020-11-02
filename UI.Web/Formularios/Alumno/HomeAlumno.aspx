<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeAlumno.aspx.cs" Inherits="UI.Web.Formularios.Alumno.FormularioAlumno" %>
<asp:Content ID="HomeAlumno" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel runat="server" style="border: 1px solid #000; width: 10%; height:80%; margin-top:5%; left:0%;position:relative;">
    <form runat="server" class="form-inline" Height="100%" Width="100%" Padding="0%" Position="absolute">
        <asp:Panel runat="server">
            <div class="form-group">
            <asp:Label ID="lblNombreUsuario" runat="server" Text=""></asp:Label>
            
                </div>
            <br />
            <br />
            <br />
            <asp:Menu ID="Menu" runat="server">
                <Items>
                    <asp:MenuItem NavigateUrl="~/Formularios/Alumno/AlumnoInscripcion.aspx?op=VisualizarCursos" Text="Visualizar Cursos" Value="Visualizar Cursos"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Formularios/Alumno/AlumnoInscripcion.aspx?op=InscripcionCurso" Text="Inscripción a cursos" Value="Inscripción a cursos"></asp:MenuItem>          
                </Items>
            </asp:Menu>

        </asp:Panel>

    </form>
        </asp:Panel>

</asp:Content>
