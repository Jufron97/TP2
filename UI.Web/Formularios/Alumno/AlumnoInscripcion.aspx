﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlumnoInscripcion.aspx.cs" Inherits="UI.Web.Formularios.Alumno.CursosAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <form runat="server" >
        <asp:Panel ID="Panel1" runat="server" CssClass="panel" HorizontalAlign="Center">      
        <asp:GridView ID="GridViewInsc" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                <asp:ButtonField CommandName="Select" Text="Seleccionar" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridViewCurso" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                <asp:ButtonField CommandName="Select" Text="Seleccionar" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnInscribir" runat="server" Text="Inscribirse" OnClick="btnInscribir_Click" />
    </asp:Panel>
    </form>
</asp:Content>
