<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlumnoInscripcion.aspx.cs" Inherits="UI.Web.Formularios.Alumno.AlumnoInscripcion" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div runat="server" >   
        <asp:GridView ID="GridViewCurso" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridViewInsc" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="GridViewInsc_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <br />
        <asp:Button ID="btnInscribir" runat="server" Text="Inscribirse" OnClick="btnInscribir_Click" />
        </div>
</asp:Content>
