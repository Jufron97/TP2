<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="loginContentPlaceholder" runat="server">
    <div class="wrapper">
	<div class="container">
		<h1>Bienvenido</h1>
		<form class="form">
			<input id="txtUsuario" type="text" placeholder="Usuario" runat="server"/>
			<input id="txtContraseña" type="password" placeholder="Contraseña" runat="server"/>
			<button type="submit" id="IngresarButton" runat="server">Ingresar</button>
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
