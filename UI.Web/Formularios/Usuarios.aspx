<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="formUsuario" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <form runat="server">
    <asp:Panel CssClass="panel" runat="server">
          <asp:Panel ID="gridPanel" HorizontalAlign="Center" runat="server">
          <asp:GridView ID="GridView" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
           <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
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
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqNombre" controltovalidate="txtNombre" errormessage="*" ForeColor="Red" />
            <br />
            <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"> </asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqApellido" controltovalidate="txtApellido" errormessage="*" ForeColor="Red" />
            <br />
            <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado"></asp:Label>
            <asp:CheckBox ID="checkHabilitado" runat="server"/>
            <br />
            <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre Usuario: "></asp:Label>
            <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqNombUsuario" controltovalidate="txtNombreUsuario" errormessage="*" ForeColor="Red" />
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqEmail" controltovalidate="txtEmail" errormessage="*" ForeColor="Red" />
            <br />
            <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqClave" controltovalidate="txtClave" errormessage="*" ForeColor="Red" />
            <br />
            <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
            <asp:TextBox ID="txtRepetirClave" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqRepetirClave" controltovalidate="txtRepetirClave" errormessage="*" ForeColor="Red" />
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
