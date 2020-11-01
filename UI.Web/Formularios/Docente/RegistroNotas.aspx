<%@ Page Title="Registro de Notas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroNotas.aspx.cs" Inherits="UI.Web.Formularios.Docente.RegistroNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
 <form runat="server" >
    <asp:Panel CssClass="panel" runat="server">
        <asp:GridView ID="GridView" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="NombreAlumno" HeaderText="Nombre" />
                <asp:BoundField DataField="ApellidoAlumno" HeaderText="Apellido" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Panel ID="gridActionPanel" HorizontalAlign="Center" runat="server">
            <asp:LinkButton ID="btnCorregir" runat="server" OnClick="btnCorregir_Click">Corregir</asp:LinkButton>
        </asp:Panel>
        <br/>
    <asp:Panel ID="formPanel" HorizontalAlign="Center" runat="server" Visible="false">        
        <asp:Label ID="lblNombre"  runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" ReadOnly="true"></asp:TextBox>
        <br />
        <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server" ReadOnly="true"></asp:TextBox>        
        <br />
        <asp:Label ID="lblNota" runat="server" Text="Nota:"></asp:Label>
        <asp:TextBox ID="txtNota" runat="server"></asp:TextBox>  
        <br/>
    </asp:Panel> 
    <asp:Panel ID="gridPanelFormCorregir" HorizontalAlign="Center" runat="server">
        <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click1">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click1">Cancelar</asp:LinkButton>            
    </asp:Panel>
 </asp:Panel>
</form>
</asp:Content>
