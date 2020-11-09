<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportePlanes.aspx.cs" Inherits="UI.Web.Formularios.Docente.ReportePlanes" EnableEventValidation="false"  %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div runat="server">       
       <asp:Panel ID="PanelReport" runat="server" style="border: 1px solid #000; width: 100%; height:80%; left:0%;position:relative;">
        <asp:ScriptManager ID="ScriptManager1"  runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="RvPlanes" runat="server" ProcessingMode="Local" Width="800px" >
            <ServerReport  ReportServerUrl="~/Formularios/Docente/ReportePlanes" />
        </rsweb:ReportViewer>
        </asp:Panel>
   </div>  
</asp:Content>