<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" EnableEventValidation="false" %>

<asp:Content ID="formUsuario" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel runat="server" style="border: 1px solid #000; width: 100%; height:80%; left:0%;position:relative;">
    <div runat="server" class="form-inline" Height="100%" Width="100%" Padding="0%" Position="absolute">
    <asp:Panel runat="server">
          <asp:Panel ID="gridPanel" runat="server">
          <asp:GridView ID="GridView" CssClass="table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
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
            <div class="form-group">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqNombre" controltovalidate="txtNombre" errormessage="*" Enabled="false" ForeColor="Red" />
                </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"> </asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqApellido" controltovalidate="txtApellido" errormessage="*" Enabled="false" ForeColor="Red" />
                </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado"></asp:Label>
            <asp:CheckBox ID="checkHabilitado" runat="server"/>
               </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqNombUsuario" controltovalidate="txtNombreUsuario" errormessage="*" Enabled="false" ForeColor="Red" />
                </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqEmail" controltovalidate="txtEmail" errormessage="*" Enabled="false" ForeColor="Red" />
                 </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="txtClave" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqClave" controltovalidate="txtClave" errormessage="*" Enabled="false" ForeColor="Red" />
                </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
            <asp:TextBox ID="txtRepetirClave" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqRepetirClave" controltovalidate="txtRepetirClave" errormessage="*" Enabled="false" ForeColor="Red" />
                </div>
            <asp:Panel runat="server">
                <div class="form-group">
                <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click">Aceptar</asp:LinkButton>  
                <asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click">Cancelar</asp:LinkButton> 
                    </div>
            </asp:Panel>   
            <div class="form-group">
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" />
                </div>
        <br />
        </asp:Panel>
   </asp:Panel>
   </div>
         </asp:Panel>
</asp:Content>
