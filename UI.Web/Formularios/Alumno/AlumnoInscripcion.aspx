<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlumnoInscripcion.aspx.cs" Inherits="UI.Web.Formularios.Alumno.CursosAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel runat="server" style="border: 1px solid #000; width: 90%; height:80%; margin-top:5%; left:10%;position:relative;">
    <form runat="server" class="form-inline" Height="100%" Width="100%" Padding="0%" Position="absolute">
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">      
        <asp:GridView ID="GridViewCurso" CssClass="table-striped" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridViewInsc" CssClass="table-striped" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="GridViewInsc_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <br />
        <asp:Button ID="btnInscribir" CssClass="btn-default" runat="server" Text="Inscribirse" OnClick="btnInscribir_Click" />
    </asp:Panel>
    </form>
        </asp:Panel>
</asp:Content>
