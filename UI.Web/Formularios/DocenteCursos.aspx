<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocenteCursos.aspx.cs" Inherits="UI.Web.Formularios.DocenteCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <form runat="server">
        <asp:Panel CssClass="panel" runat="server">
          <asp:Panel ID="gridPanel" HorizontalAlign="Center" runat="server">
          <asp:GridView ID="GridView" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
           <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="DescMateriaCurso" HeaderText="Materia" />
                <asp:BoundField DataField="DescComisionCurso" HeaderText="Comision" />
                <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
           </Columns>
           <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <asp:Panel ID="gridActionPanel" HorizontalAlign="Center" runat="server">
            <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnEditar_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="btnEliminar" runat="server" OnClick="btnEliminar_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <br />
        <asp:Panel ID="formPanel" HorizontalAlign="Center" runat="server" Visible="false">
            <asp:Label ID="lblDocente" runat="server" Text="Docente: "></asp:Label>
            <asp:DropDownList ID="dwDocente" runat="server"></asp:DropDownList>
            <br />
            <asp:Label ID="lblCurso" runat="server" Text="Curso: "></asp:Label>
            <asp:DropDownList ID="dwCurso" runat="server"></asp:DropDownList> 
            <br />
            <asp:Label ID="lblCargo" runat="server" Text="Cargo: "></asp:Label>
            <asp:DropDownList ID="dwCargo" runat="server"></asp:DropDownList> 
            <br />
            <asp:Panel runat="server">
                <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click">Aceptar</asp:LinkButton>  
                <asp:LinkButton ID="btnCancelar" runat="server" OnClick="LinkButton1_Click">Cancelar</asp:LinkButton> 
            </asp:Panel>      
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" />
        <br />
        </asp:Panel>
   </asp:Panel>
    </form>
</asp:Content>
