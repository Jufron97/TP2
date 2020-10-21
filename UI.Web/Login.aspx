<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<asp:Content ID="formLogin" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">  
	<div class="container"> 
		<asp:Login ID="loginPrueba" TitleTextStyle-HorizontalAlign="center" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" OnAuthenticate="loginPrueba_Authenticate" >
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <tr>
                                    <td align="center" colspan="2" style="color:White;background-color:#6B696B;font-weight:bold;">Iniciar sesión</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="loginPrueba">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="loginPrueba">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Recordármelo la próxima vez." />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login"  Text="Inicio de sesión" ValidationGroup="loginPrueba" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" HorizontalAlign="Center" />
        </asp:Login>			
    </div>
	<!-->
        <div class="container" >
			<asp:Panel HorizontalAlign="Center" runat="server">
				<h1>Bienvenido al sistema</h1>
				<input id="txtUsuario" type="text" placeholder="Usuario" runat="server"/>
				<input id="txtContraseña" type="password" placeholder="Contraseña" runat="server"/>
				<button type="submit" id="IngresarButton" runat="server">Ingresar</button>
			</asp:Panel>
		</div>			
	<script src="Scripts/LoginJs.js"></script>
	<!-->
</asp:Content>
