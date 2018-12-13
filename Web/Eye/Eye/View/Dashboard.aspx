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

        <div id="blockArea" onclick="hidePopup()">
        </div>
        <div id="popup">

            <div class="areaConfig">

                <div class="areaTextoSwitch">
                    <div class="switch__container">
                        <input id="switch-tema" class="switch switch--shadow" type="checkbox" onchange="mudarTema()" />
                        <label for="switch-tema"></label>
                    </div>
                    <div class="switchText">
                        Modo Claro
                    </div>


                </div>
                <div class="areaTextoSwitch">
                    <div class="switch__container">
                        <input id="switch-notificacao" class="switch switch--shadow" type="checkbox" />
                        <label for="switch-notificacao"></label>
                    </div>
                    
                    <div class="switchText">
                        Ativar Notificações
                    </div>
                </div>

            </div>


        </div>

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


            <!--Coloca o link do app no lugar desse de baixo-->
            <a href="https://4ueye.file.core.windows.net/eye/4uEye.jar?sv=2018-03-28&ss=bqtf&srt=sco&sp=rwdlacup&se=2018-12-13T05:23:46Z&sig=XK1DC3XUOCzi29g4cDi5sKu48TvDqYJMFkod%2BREsA7g%3D&_=1544649839918">
                <div class="itemMenu">

                    <div class="itemIcon">
                        <img src="../Component/download.png" />
                    </div>
                    <div class="itemMenuBackGround"></div>

                    <div class="itemTxt">
                        Baixar App Local
               
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


            <a href="CadastroSlack.aspx">
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


            <a onclick="displayPopup()">
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


        <asp:UpdatePanel ID="updtPnlConfiguracao" runat="server">
            <ContentTemplate>
                <div id="meuResumo">

                    <div class="txtMeuResumo">Online:</div>
                    <asp:Panel runat="server" ID="pnlOnline">

                        <asp:Label ID="lblMensagem" Text="" CssClass="mensagem" runat="server" />
                    </asp:Panel>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="Timer" runat="server" Interval="5000" OnTick="Timer_Tick"></asp:Timer>

        <!--Area com os containers dos computadores-->
        <div id="areaInfo">


            <!--Eles são adds através da função iniciarDash() no script EYEDash.js-->

        </div>

        <!--/Area com os containers dos computadores-->
    </form>
</body>
</html>
