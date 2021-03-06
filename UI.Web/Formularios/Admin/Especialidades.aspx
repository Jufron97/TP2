﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="formEspecialidades" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server"> 
    <asp:Panel runat="server" style="border: 1px solid #000; width: 100%; height:80%; left:0%;position:relative;">
    <div runat="server" class="form-inline" Height="100%" Width="100%" Padding="0%" Position="absolute">
        <asp:Panel runat="server">
    <asp:Panel runat="server" HorizontalAlign="Center">
        <asp:GridView ID="GridView" CssClass="table-striped" HorizontalAlign="Center" style="align-self:center;position:relative;font-size:20px;" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionPanel" HorizontalAlign="Center" runat="server">
            <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnEditar_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="btnEliminar" runat="server" OnClick="btnEliminar_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="formPanel" HorizontalAlign="Center" runat="server" Visible="false">
        <div class="form-group">
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion:"></asp:Label>
        <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>  
            <asp:RequiredFieldValidator runat="server" id="reqDescripcion" controltovalidate="txtDescripcion" errormessage="Descripcion Invalida" ValidationGroup="1" ForeColor="Red" >*</asp:RequiredFieldValidator>
            </div>
        <asp:Panel runat="server">
            <div class="form-group">
                <br/>
            <br/>
            <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click">Aceptar</asp:LinkButton>  
            <asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click">Cancelar</asp:LinkButton> 
                </div>
        </asp:Panel>    
        <div class="form-group">
        <asp:ValidationSummary ID="ValidationSummary2" HeaderText="Campos erroneos" ValidationGroup="1" runat="server" />
            </div>
        <br/>
    </asp:Panel>
            </asp:Panel>
        </div>
        </asp:Panel>
</asp:Content>
