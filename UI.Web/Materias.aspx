<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
     <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="HsSemanales" HeaderText="Horas Semanales" />
                <asp:BoundField DataField="HsTotales" HeaderText="Horas Totales" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="IdPlan" HeaderText="ID Plan" />
                <asp:BoundField DataField="DescripcionPlan" HeaderText="Descripcion Plan" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <asp:Panel ID="gridActionPanel" runat="server">
            <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnEditar_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="btnEliminar" runat="server" OnClick="btnEliminar_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server" Visible="false">
        <asp:Label ID="lblHsSemanales" runat="server" Text="Horas Semanales:"></asp:Label>
        <asp:TextBox ID="txtHsSemanales" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" id="reqHsSemanales" controltovalidate="txtHsSemanales" errormessage="*" ForeColor="Red" />
        <br />
        <asp:Label ID="lblHsTotales" runat="server" Text="Horas Totales: "></asp:Label>
        <asp:TextBox ID="txtHsTotales" runat="server"> </asp:TextBox>
        <asp:RequiredFieldValidator runat="server" id="reqHsTotales" controltovalidate="txtHsTotales" errormessage="*" ForeColor="Red" />
        <br />
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" id="reqDescripcion" controltovalidate="txtDescripcion" errormessage="*" ForeColor="Red" />
        <br />
        <asp:DropDownList ID="dropPlan" runat="server"></asp:DropDownList>
        <asp:Panel runat="server">
            <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click">Aceptar</asp:LinkButton>  
            <asp:LinkButton ID="btnCancelar" runat="server" OnClick="LinkButton1_Click">Cancelar</asp:LinkButton> 
        </asp:Panel>
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" />
        <br />
    </asp:Panel>
    
     </asp:Content>