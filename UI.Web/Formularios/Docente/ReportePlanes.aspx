﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReportePlanes.aspx.cs" Inherits="UI.Web.Formularios.Docente.ReportePlanes" EnableEventValidation="false"  %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server">
        
            <asp:Panel ID="PanelReport" runat="server" style="border: 1px solid #000; width: 100%; height:80%; left:0%;position:relative;">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 
        <rsweb:ReportViewer ID="RvPlanes" runat="server" ProcessingMode="Local" Height="100%" Width="100%" Padding="0%" Position="absolute">
            <ServerReport  ReportServerUrl="~/Formularios/Docente/ReportePlanes" ReportPath="C:\Users\Jeremias\Desktop\Gonza\Facultad\4°\.Net\Laboratorios\Unidad 4\TP 2 - Laboratorio 5\TP2\UI.desktop\Formularios Principales\Docente\ReportePlanes.rdlc"/>
        </rsweb:ReportViewer>
</asp:Panel>
    </div>
    
</asp:Content>