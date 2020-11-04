<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeDocente.aspx.cs" Inherits="UI.Web.Formularios.Docente.FormularioDocente" EnableEventValidation="false" %>

<asp:Content ID="HomeDocente" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
      <asp:Panel style="position:relative; left:40%; width:60%; align-content:center; align-self:center;" runat="server">
            <h1>Menu Docente<asp:Label ID="lblNombreUsuario" style="position:absolute; left:80%; align-content:center; align-self:center;" runat="server" Text=""></asp:Label>
            </h1>

        </asp:Panel>
       
        
            <!--
            <asp:Menu ID="Menu" runat="server">
            <Items>
                <asp:MenuItem NavigateUrl="~/Formularios/Docente/RegistroNotas.aspx" Text="Registro de Notas" Value="Usuarios"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Formularios/Docente/ReporteAlumno.aspx" Text="Reporte de Cursos" Value="Especialidades"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Formularios/Docente/ReportePlanes.aspx" Text="Reporte de Planes" Value="Planes"></asp:MenuItem>
            </Items>
            </asp:Menu>-->
        
</asp:Content>
