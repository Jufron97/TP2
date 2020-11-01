﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportePlanes.aspx.cs" Inherits="UI.Web.Formularios.Docente.ReportePlanes" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <style>
        html,body,form,#div1 {
            height: 100%; 
        }
    </style>
    <form runat="server">
        <div style="height:100vh;">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 
        <rsweb:ReportViewer ID="RvPlanes" runat="server" ProcessingMode="Remote">
    <ServerReport ReportPath="@A:\Juan\Facu\NET\Unidad 5\Lab5.6\TP2L05\UI.desktop\Formularios Principales\Docente\ReportePlanes.rdlc" ReportServerUrl="~/Formularios/Docente/ReportePlanes" />
    </rsweb:ReportViewer>

            </div>
    </form>
</asp:Content>