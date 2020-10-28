<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>

<asp:Content ID="formPlanes" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <form runat="server">
     <asp:Panel CssClass="panel" HorizontalAlign="Center" runat="server">
        <asp:GridView ID="GridView" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion Plan" />
                <asp:BoundField DataField="DescEspecialidad" HeaderText="Especialidad" />
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
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion:">

        </asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server">

        </asp:TextBox>
        <br />
        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:">

        </asp:Label>
        <asp:DropDownList ID="dwEspecialidades" runat="server">
        </asp:DropDownList>     
        <asp:Panel runat="server">
            <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click">Aceptar</asp:LinkButton>  
            <asp:LinkButton ID="btnCancelar" runat="server" OnClick="LinkButton1_Click">Cancelar</asp:LinkButton> 
        </asp:Panel>      
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" />
        <br/>
    </asp:Panel>     
        </form>
</asp:Content>

