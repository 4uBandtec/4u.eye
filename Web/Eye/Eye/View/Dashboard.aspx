<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Eye.View.Dashboard" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Dashboard | EYE by 4U</title>
	<link href="../Model/EYE.css" rel="stylesheet" type="text/css" />


	<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

	<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.4.0/Chart.min.js"></script>
	<script type="text/javascript" src="../Controller/Dashboard.js"></script>
	<script type="text/javascript" src="../Controller/DashStyle.js"></script>

</head>
<body onload="iniciarEstilo(), GetUsuariosWorkspace()">
	<form id="formDashboard" runat="server">
		<asp:ScriptManager ID="ScriptManager" runat="server"
			EnablePageMethods="true" />
		<!--MENU-->
		<div id="sideMenu" onmousemove="getCoordenadas()">

			<a href="CadastroUsuario.aspx">
				<div class="itemMenu">

					<div class="itemIcon">
						<img src="../Component/icon.png" />
					</div>
					<div class="itemMenuBackGround"></div>

					<div class="itemTxt">
						Cadastrar Usuário
               
					</div>

				</div>
			</a>

			<div class="itemMenu">

				<div class="itemIcon">
					<img src="../Component/icon.png" />
				</div>
				<div class="itemMenuBackGround"></div>

				<div class="itemTxt">
					Computador
               
				</div>

			</div>

			<div class="itemMenu">

				<div class="itemIcon">
					<img src="../Component/icon.png" />
				</div>
				<div class="itemMenuBackGround"></div>

				<div class="itemTxt">
					Computador
               
				</div>

			</div>

			<div class="itemMenu">

				<div class="itemIcon">
					<img src="../Component/icon.png" />
				</div>
				<div class="itemMenuBackGround"></div>

				<div class="itemTxt">
					Computador
               
				</div>

			</div>

			<div class="itemMenu">

				<div class="itemIcon">
					<img src="../Component/icon.png" />
				</div>
				<div class="itemMenuBackGround"></div>

				<div class="itemTxt">
					Computador
               
				</div>

			</div>

			<div class="itemMenu">

				<div class="itemIcon">
					<img src="../Component/icon.png" />
				</div>
				<div class="itemMenuBackGround"></div>

				<div class="itemTxt">
					Computador
               
				</div>

			</div>

			<div class="itemMenu">

				<div class="itemIcon">
					<img src="../Component/icon.png" />
				</div>
				<div class="itemMenuBackGround"></div>

				<div class="itemTxt">
					Computador
               
				</div>

			</div>

			<div class="itemMenu" onclick="breakSession()">
				<div class="itemIcon">
					<img src="../Component/icon.png" />
				</div>
				<div class="itemMenuBackGround"></div>

				<div class="itemTxt">
					Loggout
				</div>

			</div>

		</div>

		<!--/MENU-->



		<div id="meuResumo">
			<div class="txtMeuResumo">TIME:</div>

			<asp:Label ID="lblMensagem" Text="" CssClass="mensagem" runat="server" />
		</div>

<<<<<<< HEAD

		<!--Area com os containers dos computadores-->
		<div id="areaInfo">

			<!--Eles são adds através da função iniciarDash() no script EYEDash.js-->
=======
        <!--Area com os containers dos computadores-->
        <div id="areaInfo">


            <!--Eles são adds através da função iniciarDash() no script EYEDash.js-->
>>>>>>> develop

		</div>

		<!--/Area com os containers dos computadores-->
	</form>
</body>
</html>
