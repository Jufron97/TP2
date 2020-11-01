<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteAlumno.aspx.cs" Inherits="UI.Web.Formularios.Docente.ReporteAlumno" EnableEventValidation="false" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <form runat="server">

        <asp:Panel ID="Panel1" CssClass="panel" runat="server" style="border: 1px solid #000; width: 90%; height:80%; margin-top:5%; left:10%;position:relative;">
         
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 
        <rsweb:ReportViewer ID="RvInscripciones" runat="server" ProcessingMode="Local" Height="100%" Width="100%" Padding="0%" Position="absolute">
    <ServerReport ReportPath="@A:\Juan\Facu\NET\Unidad 5\Lab5.6\TP2L05\UI.desktop\Formularios Principales\Docente\ReporteAlumnos.rdlc" ReportServerUrl="~/Formularios/Docente/ReporteAlumno" />
    </rsweb:ReportViewer>

            
        </asp:Panel>
            
    </form>
</asp:Content>
