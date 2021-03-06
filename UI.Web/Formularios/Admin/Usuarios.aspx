﻿<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" EnableEventValidation="false" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="formUsuario" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel runat="server" style="border: 1px solid #000; width: 100%; height:80%; left:0%;position:relative;">
    <div runat="server" class="form-inline" Height="100%" Width="100%" Padding="0%" Position="absolute">
    <asp:Panel runat="server">
          <asp:Panel ID="gridPanel" runat="server">
          <asp:GridView ID="GridView" CssClass="table-striped" style="align-self:center;position:relative;font-size:20px;" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
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
            <asp:RequiredFieldValidator runat="server" id="reqNombre" controltovalidate="txtNombre" errormessage="Nombre Invalido" ValidationGroup="1" Enabled="false" ForeColor="Red" >*</asp:RequiredFieldValidator>
                </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"> </asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqApellido" controltovalidate="txtApellido" errormessage="Apellido Invalido" ValidationGroup="1" Enabled="false" ForeColor="Red" >*</asp:RequiredFieldValidator>
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
            <asp:RequiredFieldValidator runat="server" id="reqNombUsuario" controltovalidate="txtNombreUsuario" errormessage="Nombre Usuario Invalido" ValidationGroup="1" Enabled="false" ForeColor="Red" >*</asp:RequiredFieldValidator>
                </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqEmail" controltovalidate="txtEmail" errormessage="Email Invalido" ValidationGroup="1" Enabled="false" ForeColor="Red" >*</asp:RequiredFieldValidator>
                 </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblTelefono" runat="server" Text="Telefono: "></asp:Label>
            <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqTelefono" controltovalidate="txtTelefono" errormessage="Telefono Invalido" ValidationGroup="1" Enabled="false" ForeColor="Red" >*</asp:RequiredFieldValidator>
                 </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblDireccion" runat="server" Text="Direccion: "></asp:Label>
            <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="reqDireccion" controltovalidate="txtDireccion" errormessage="Direccion Invalida" ValidationGroup="1" Enabled="false" ForeColor="Red">*</asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <div class="form-group">
            <asp:Label ID="lblPlan" runat="server" Text="Plan: "></asp:Label>
            <asp:DropDownList ID="dwPlan" runat="server" ></asp:DropDownList>
            </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblFechaNac" runat="server" Text="Fecha Nacimiento: "></asp:Label>
            <br />
            <br />
            <asp:Calendar ID="CalFechaNac" runat="server"></asp:Calendar>
            </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblTipoPersona" runat="server" Text="Tipo Persona: "></asp:Label>
            <asp:DropDownList ID="dwTiposPersonas" runat="server"></asp:DropDownList>
            <br />
            </div>
            <br/>
            <div class="form-group">
            <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="txtClave" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="reqClave" controltovalidate="txtClave" errormessage="Clave Invalida" ValidationGroup="1" Enabled="false" ForeColor="Red" >*</asp:RequiredFieldValidator>
                </div>
            <br/>
            <div class="form-group">
            <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
            <asp:TextBox ID="txtRepetirClave" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="reqRepetirClave" controltovalidate="txtRepetirClave" errormessage="" ValidationGroup="1" Enabled="false" ForeColor="Red" >*</asp:RequiredFieldValidator>
                </div>  
            <br />
            <asp:Panel runat="server">
                <div class="form-group">
            <br/>
            <br/>
                <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click">Aceptar</asp:LinkButton>  
                <asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click">Cancelar</asp:LinkButton> 
                    </div>
            </asp:Panel>   
            <div class="form-group">
        <asp:ValidationSummary ID="vsUsuario" ValidationGroup="1" runat="server" />
                </div>
        <br />
        </asp:Panel>
   </asp:Panel>
   </div>
         </asp:Panel>
</asp:Content>
