<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Eye.View.Dashboard" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link runat="server" rel="shortcut icon" href="../Component/favicon.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="../Component/favicon.ico" type="image/ico" />

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Dashboard | EYE by 4U</title>
    <link href="../Model/EYE.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.4.0/Chart.min.js"></script>
    <script type="text/javascript" src="../Controller/Dashboard.js"></script>
    <script type="text/javascript" src="../Controller/DashStyle.js"></script>
    <script type="text/javascript" src="../Controller/BreakSession.js"></script>

</head>
<body onload="iniciarEstilo(), GetUsuariosWorkspace()">
    <form id="formDashboard" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server"
            EnablePageMethods="true" />
        <!--MENU-->
        <div id="sideMenu" onmousemove="getCoordenadas()">
            <a href="Dashboard.aspx">
                <div class="itemMenu">


                    <div class="itemIcon">
                        <img src="../Component/Dashboard.png" />
                    </div>
                    <div class="itemMenuBackGround"></div>

                    <div class="itemTxt">
                        Dashboard
               
                    </div>

                </div>

            </a>



            <a href="Dashboard.aspx">
                <div class="itemMenu">

                    <div class="itemIcon">
                        <img src="../Component/Usuarios.png" />
                    </div>
                    <div class="itemMenuBackGround"></div>

                    <div class="itemTxt">
                        Usuários
               
                    </div>

                </div>
            </a>


            <a href="CadastroUsuario.aspx">
                <div class="itemMenu">

                    <div class="itemIcon">
                        <img src="../Component/AddUsuarios.png" />
                    </div>
                    <div class="itemMenuBackGround"></div>

                    <div class="itemTxt">
                        Cadastrar Usuário
               
                    </div>

                </div>
            </a>


            <a href="CadastroTarefas.aspx">
                <div class="itemMenu">

                    <div class="itemIcon">
                        <img src="../Component/Tarefa.png" />
                    </div>
                    <div class="itemMenuBackGround"></div>

                    <div class="itemTxt">
                        Cadastrar Tarefas
               
                    </div>

                </div>
            </a>


            <a href="Dashboard.aspx">
                <div class="itemMenu">

                    <div class="itemIcon">
                        <img src="../Component/Slack.png" />
                    </div>
                    <div class="itemMenuBackGround"></div>

                    <div class="itemTxt">
                        Cadastrar SlackBot
               
                    </div>

                </div>
            </a>


            <a href="Dashboard.aspx">
                <div class="itemMenu">

                    <div class="itemIcon">
                        <img src="../Component/Opcoes.png" />
                    </div>
                    <div class="itemMenuBackGround"></div>

                    <div class="itemTxt">
                        Opções
               
                    </div>

                </div>
            </a>


            <a href="Dashboard.aspx">
                <div class="itemMenu" onclick="breakSession()">
                    <div class="itemIcon">
                        <img src="../Component/Logout.png" />
                    </div>
                    <div class="itemMenuBackGround"></div>

                    <div class="itemTxt">
                        Logout
                    </div>

                </div>
            </a>

        </div>

        <!--/MENU-->



        <div id="meuResumo">
            <div class="txtMeuResumo">TIME:</div>

            <asp:Label ID="lblMensagem" Text="" CssClass="mensagem" runat="server" />
        </div>

        <!--Area com os containers dos computadores-->
        <div id="areaInfo">


            <!--Eles são adds através da função iniciarDash() no script EYEDash.js-->

        </div>

        <!--/Area com os containers dos computadores-->
    </form>
</body>
</html>
