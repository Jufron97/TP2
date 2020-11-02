<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocenteCursos.aspx.cs" Inherits="UI.Web.Formularios.DocenteCursos" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel runat="server" style="border: 1px solid #000; width: 100%; height:80%; left:0%;position:relative;">
    <div runat="server" class="form-inline" Height="100%" Width="100%" Padding="0%" Position="absolute">
        <asp:Panel runat="server">
          <asp:Panel ID="gridPanel" HorizontalAlign="Center" runat="server">
          <asp:GridView ID="GridView" CssClass="table-striped" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
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
            <div class="form-group">
            <asp:Label ID="lblDocente" runat="server" Text="Docente: "></asp:Label>
                <div class="dropdown">
            <asp:DropDownList ID="dwDocente" CssClass="btn btn-primary dropdown-toggle" runat="server"></asp:DropDownList>
                    </div>
                </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblCurso" runat="server" Text="Curso: "></asp:Label>
                <div class="dropdown">
            <asp:DropDownList ID="dwCurso" CssClass="btn btn-primary dropdown-toggle" runat="server"></asp:DropDownList> 
                    </div>
                </div>
            <br />
            <div class="form-group">
            <asp:Label ID="lblCargo" runat="server" Text="Cargo: "></asp:Label>
                <div class="dropdown">
            <asp:DropDownList ID="dwCargo" CssClass="btn btn-primary dropdown-toggle" runat="server"></asp:DropDownList> 
                    </div>
                </div>
            <br />
            <asp:Panel runat="server">
                <div class="form-group">
                <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click">Aceptar</asp:LinkButton>  
                <asp:LinkButton ID="btnCancelar" runat="server" OnClick="LinkButton1_Click">Cancelar</asp:LinkButton> 
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
