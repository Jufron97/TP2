<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	<link rel="stylesheet" href="App_Themes\LoginStyle.css"/>
</head>
<body>
    <div class="wrapper">
	<div class="container">
		<h1>Bienvenido</h1>
		
		<form class="form">
			<input id="txtUsuario" type="text" placeholder="Usuario"/>
			<input id="txtContraseña" type="password" placeholder="Contraseña"/>
			<button type="submit" id="IngresarButton">Ingresar</button>
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
</body>
</html>
