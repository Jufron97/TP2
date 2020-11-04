<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlumnoInscripcion.aspx.cs" Inherits="UI.Web.Formularios.Alumno.AlumnoInscripcion" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel runat="server" style="border: 1px solid #000; width: 100%; height:80%; left:0%;position:relative;">
    <div runat="server" class="form-inline" Height="100%" Width="100%" Padding="0%" Position="absolute">
        <asp:GridView ID="GridViewCurso" CssClass="table-striped" HorizontalAlign="Right" style="align-self:center;position:relative;font-size:20px;" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridViewInsc" CssClass="table-striped" runat="server" HorizontalAlign="Center" style="align-self:center;position:relative;font-size:20px;" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="GridViewInsc_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <br />
        <br />
        <br />
        </div>
        <div>
        <br />
        <asp:Button ID="btnInscribir" CssClass="btn-primary" style="align-self:center;position:relative;font-size:20px;" runat="server" Text="Inscribirse" OnClick="btnInscribir_Click" />
        </div>
        </asp:Panel>
</asp:Content>
