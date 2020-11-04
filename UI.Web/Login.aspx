<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" EnableEventValidation="false" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceholder" runat="server">
	<link rel="stylesheet" href="App_Themes\LoginStyle.css"/>	
    <div class="wrapper">
	<div class="container">
		<h1>Bienvenido</h1>
        <div class="form" runat="server">			
            <input id="txtUsuario" name="txtUsu" type="text" placeholder="Usuario" runat="server" value="" />
			<input id="txtContraseña" name="txtcont" type="password" placeholder="Contraseña" runat="server" value="" />
			<button type="submit" id="IngresarButton" runat="server">Ingresar</button>
			</div>
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
