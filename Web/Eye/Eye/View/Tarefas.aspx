<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tarefas.aspx.cs" Inherits="EYE.View.Tarefas" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link runat="server" rel="shortcut icon" href="../Component/favicon.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="../Component/favicon.ico" type="image/ico" />

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Tarefas | EYE by 4U</title>
    <link href="../Model/EYE.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../Controller/DashStyle.js"></script>
    <script type="text/javascript" src="../Controller/BreakSession.js"></script>

    <script type="text/javascript" src="../Controller/ListarTarefas.js"></script>
    <script type="text/javascript" src="../Controller/download.js"></script>
</head>
<body onload="iniciarEstilo(), listar()">
    <form id="form1" runat="server">


        <asp:ScriptManager ID="ScriptManager" runat="server"
            EnablePageMethods="true" />


        <div id="blockArea" onclick="hidePopup()">
        </div>
        <div id="popup">

            <div id="demoCoresBW"></div>
            <div id="demoCores"></div>
            <div class="areaConfig">

                <div class="slidecontainer">
                    Intensidade das cores:
                    <input type="range" min="1" max="100" value="100" class="slider" id="slideCor" oninput="grayscale()" onmouseup="mudarIntensidade()" />
                </div>

                <div class="areaTextoSwitch">


                    <div class="radioTema">
                        Modo Claro
                    </div>
                    <div class="switch__container">
                        <input id="switch-tema" class="switch switch--shadow" type="checkbox" onchange="mudarModo()" />
                        <label for="switch-tema"></label>
                    </div>


                </div>
                <div class="areaTextoSwitch">

                    <div class="radioTema">
                        Escolha o tema
                    </div>

                    <div class="radioTema">
                        <input type="radio" name="tema" id="tema0" value="0" checked="checked" onchange="mudarTema()" />
                        <label for="tema0">Padrão</label>
                    </div>


                    <div class="radioTema">
                        <input type="radio" name="tema" id="tema1" value="1" onchange="mudarTema()" />
                        <label for="tema1">Godez</label>
                    </div>

                    <div class="radioTema">
                        <input type="radio" name="tema" id="tema2" value="2" onchange="mudarTema()" />
                        <label for="tema2">Martins</label>
                    </div>

                    <div class="radioTema">
                        <input type="radio" name="tema" id="tema3" value="3" onchange="mudarTema()" />
                        <label for="tema3">Sayuri</label>
                    </div>

                    <div class="radioTema">
                        <input type="radio" name="tema" id="tema4" value="4" onchange="mudarTema()" />
                        <label for="tema4">Volpe</label>
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
            <a onclick="baixar()">
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


            <a href="Tarefas.aspx">
                <div class="itemMenu">

                    <div class="itemIcon">
                        <img src="../Component/Tarefa.png" />
                    </div>
                    <div class="itemMenuBackGround"></div>

                    <div class="itemTxt">
                        Tarefas
               
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
                        Personalizar Cores
               
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

                        <asp:Label ID="Label1" Text="" CssClass="mensagem" runat="server" />
                    </asp:Panel>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="Timer" runat="server" Interval="5000" OnTick="Timer_Tick"></asp:Timer>

        <div id="areaInfo">

        </div>

    </form>
</body>
</html>
