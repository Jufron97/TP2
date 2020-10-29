<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Formularios.Cursos" %>
<asp:Content ID="formCursos" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <form runat="server">
        <asp:Panel CssClass="panel" runat="server">
    <asp:Panel runat="server">
        <asp:GridView ID="GridView" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionPanel" HorizontalAlign="Center" runat="server">
            <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnEditar_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="btnEliminar" runat="server" OnClick="btnEliminar_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" HorizontalAlign="Center" runat="server" Visible="false">        
        <asp:Label ID="lblMateria" runat="server" Text="Materia:">

        </asp:Label>
        <asp:DropDownList ID="dwMateria" runat="server">

        </asp:DropDownList>
        <br />
        <asp:Label ID="lblComision" runat="server" Text="Comision:">

        </asp:Label>
        <asp:DropDownList ID="dwComision" runat="server">

        </asp:DropDownList>   
        <br />
        <asp:Label ID="lblAño" runat="server" Text="Año:"></asp:Label>
        <asp:TextBox ID="txtAño" runat="server"></asp:TextBox>        
        <br />
        <asp:Label ID="lblCupo" runat="server" Text="Cupo:"></asp:Label>
        <asp:TextBox ID="txtCupo" runat="server"></asp:TextBox>       
        <asp:Panel runat="server">
            <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click">Aceptar</asp:LinkButton>  
            <asp:LinkButton ID="btnCancelar" runat="server" OnClick="LinkButton1_Click">Cancelar</asp:LinkButton> 
        </asp:Panel>      
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" />
        <br/>
    </asp:Panel>   
            </asp:Panel>
        </form>
</asp:Content>
