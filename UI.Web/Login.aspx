<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<asp:Content ID="formLogin" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">  
	<div class="contenedor"> 
		<asp:Login ID="loginPrueba" TitleTextStyle-HorizontalAlign="center" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" OnAuthenticate="loginPrueba_Authenticate" >
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
