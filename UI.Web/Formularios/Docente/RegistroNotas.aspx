<%@ Page Title="Registro de Notas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroNotas.aspx.cs" Inherits="UI.Web.Formularios.Docente.RegistroNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
 <asp:Panel runat="server" style="border: 1px solid #000; width: 100%; height:80%; left:0%;position:relative;">
    <div runat="server" class="form-inline" Height="100%" Width="100%" Padding="0%" Position="absolute">
    <asp:Panel runat="server">
        <asp:GridView ID="GridView" CssClass="table-striped" HorizontalAlign="Center" style="align-self:center;position:relative;font-size:20px;" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="NombreAlumno" HeaderText="Nombre" />
                <asp:BoundField DataField="ApellidoAlumno" HeaderText="Apellido" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Panel ID="gridActionPanel" HorizontalAlign="Center" runat="server">
            <asp:LinkButton ID="btnCorregir" runat="server" OnClick="btnCorregir_Click">Corregir</asp:LinkButton>
        </asp:Panel>
        <br/>
    <asp:Panel ID="formPanel" HorizontalAlign="Center" runat="server" Visible="false">  
        <div class="form-group">
        <asp:Label ID="lblNombre"  runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        <br />
        <div class="form-group">
        <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox> 
            </div>
        <br />
        <div class="form-group">
        <asp:Label ID="lblNota" runat="server" Text="Nota:"></asp:Label>
        <asp:TextBox ID="txtNota" CssClass="form-control" runat="server"></asp:TextBox>  
            <asp:RequiredFieldValidator runat="server" id="reqNota"  controltovalidate="txtNota" errormessage="Valor ingresado no es numerico" ValidationGroup="1" Enabled="false" ForeColor="Red" >*</asp:RequiredFieldValidator>
            
            </div>
        <br/>
    </asp:Panel> 
    <asp:Panel ID="gridPanelFormCorregir" HorizontalAlign="Center" runat="server">
        <div class="form-group">
            <br/>
            <br/>
        <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click">Cancelar</asp:LinkButton>  
            </div>
    </asp:Panel>
        <div class="form-group">
        <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="1" runat="server" />
            </div>
 </asp:Panel>
</div>
     </asp:Panel>
</asp:Content>
