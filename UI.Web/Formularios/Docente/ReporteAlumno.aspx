<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteAlumno.aspx.cs" Inherits="UI.Web.Formularios.Docente.ReporteAlumno" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <form runat="server">
        <div>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 
        <rsweb:ReportViewer ID="RvInscripciones" runat="server" ProcessingMode="Local">
    <ServerReport ReportPath="@A:\Juan\Facu\NET\Unidad 5\Lab5.6\TP2L05\UI.desktop\Formularios Principales\Docente\ReporteAlumnos.rdlc" ReportServerUrl="~/Formularios/Docente/ReporteAlumno" />
    </rsweb:ReportViewer>

            </div>
    </form>
</asp:Content>
