<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Formularios.Cursos" %>
<asp:Content ID="formCursos" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel runat="server" style="border: 1px solid #000; width: 90%; height:80%; margin-top:5%; left:10%;position:relative;">
    <div runat="server" class="form-inline" Height="100%" Width="100%" Padding="0%" Position="absolute">
        <asp:Panel runat="server">
    <asp:Panel runat="server">
        <asp:GridView ID="GridView" CssClass="table-striped" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
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
        <div class="form-group">
        <asp:Label ID="lblMateria" runat="server" Text="Materia:">
        </asp:Label>
            <div class="dropdown">
        <asp:DropDownList ID="dwMateria" CssClass="btn btn-primary dropdown-toggle" runat="server">
        </asp:DropDownList>
                </div>
            </div>
        <br />
        <div class="form-group">
        <asp:Label ID="lblComision" runat="server" Text="Comision:">

        </asp:Label>
            <div class="dropdown">
        <asp:DropDownList ID="dwComision" CssClass="btn btn-primary dropdown-toggle" runat="server">

        </asp:DropDownList> 
                </div>
            </div>
        <br />
        <div class="form-group">
        <asp:Label ID="lblAño" runat="server" Text="Año:"></asp:Label>
        <asp:TextBox ID="txtAño" CssClass="form-control" runat="server"></asp:TextBox>   
            </div>
        <br />
        <div class="form-group">
        <asp:Label ID="lblCupo" runat="server" Text="Cupo:"></asp:Label>
        <asp:TextBox ID="txtCupo" CssClass="form-control" runat="server"></asp:TextBox>   
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
        <br/>
    </asp:Panel>   
            </asp:Panel>
        </div>
        </asp:Panel>
</asp:Content>
