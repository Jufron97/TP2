<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" EnableEventValidation="false" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceholder" runat="server">
	<link rel="stylesheet" href="App_Themes\LoginStyle.css"/>	
    <div class="wrapper">
	<div class="container">
		<h1>Bienvenido</h1>
        <form class="form" runat="server">			
            <input id="txtUsuario" name="txtUsu" type="text" placeholder="Usuario" runat="server" value="" />
			<input id="txtContraseña" name="txtcont" type="password" placeholder="Contraseña" runat="server" value="" />
			<button type="submit" id="IngresarButton" runat="server">Ingresar</button>
			<!--
			<
			<asp:RequiredFieldValidator ID="reqUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="Usuario Requerido" style="color: #FF0000" ValidationGroup="1">*</asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="reqContraseña" runat="server" ControlToValidate="txtContraseña" ErrorMessage="Clave Requerida" style="color: #FF0000" ValidationGroup="1">*</asp:RequiredFieldValidator>			
			-->
			<asp:ValidationSummary ID="ValidationSummary1" runat="server" style="color: #FF0000" ValidationGroup="1" /> 
			<asp:CustomValidator ID="cvContraseña" runat="server" ControlToValidate="txtContraseña" ErrorMessage="Clave o Usuario incorrectos" ValidationGroup="1" style="color: #FF0000">*</asp:CustomValidator>    			
			 </form>
	</div>
	<ul class="bg-bubbles">
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
	</ul>
</div>
	<script src="Scripts/LoginJs.js"></script>
</asp:Content>
