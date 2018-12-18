<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroTarefas.aspx.cs" Inherits="EYE.View.CadastroTarefas" %>

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

    <script type="text/javascript" src="../Controller/Tarefas.js"></script>
    <script type="text/javascript" src="../Controller/download.js"></script>
</head>
<body onload="iniciarEstilo(), iniciarPainelTarefas()">
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



        <div id="areaInfo" onkeyup="validaCamposTarefa()" onchange="validaCamposTarefa()">


            <asp:Label Text="" ID="lblMensagem" CssClass="msgTarefa" runat="server" />

            <div id="AreaCadastroTarefa" class="AreaTarefa">

                <div class="tituloComputador">
                    Quer cadastrar uma tarefa?
                </div>



                <div class="campos">
                    <div class="tituloCampo">
                        Dê um título para ela:
                    </div>
                    <asp:TextBox ID="txtNome" Placeholder="Qual é a tarefa?" runat="server" MaxLength="50"></asp:TextBox>
                </div>
                <div class="campos">

                    <div class="tituloCampo">
                        Descreva essa tarefa pra sua equipe:
                    </div>
                    <asp:TextBox ID="txtDescricao" Placeholder="Descreva ela..." runat="server" MaxLength="199"></asp:TextBox>
                </div>
                <div class="campos">

                    <div class="tituloCampo">
                        Quando essa tarefa será INICIADA?
                    </div>
                    <asp:TextBox ID="txtDataInicio" Placeholder="Quando ela começa?" runat="server" MaxLength="10" onkeyup="mascaraData('txtDataInicio')"></asp:TextBox>
                </div>
                <div class="campos">

                    <div class="tituloCampo">
                        Até quando ela pode ser FINALIZADA?
                    </div>
                    <asp:TextBox ID="txtDataFim" Placeholder="Até quando?" runat="server" MaxLength="10" onkeyup="mascaraData('txtDataFim')"></asp:TextBox>
                </div>

                <div class="campos">

                    <div class="tituloCampo">
                        Ativar envio de notificações sobre a tarefa?
                    </div>
                    
                    <div class="switch__container">
                        <div class="tituloSwitchNotificacao">Notificar Equipe</div>
                        <input id="cbNotificacao" class="switch switch--shadow" type="checkbox" checked="checked" />
                        <label for="cbNotificacao" class="lblNotificacao"></label>
                    </div>
                    
                    <div class="switch__container">
                        
                        <div class="tituloSwitchNotificacao">Notificar Usuarios</div>
                        <input id="cbNotificacaoUser" class="switch switch--shadow" type="checkbox" checked="checked" />
                        <label for="cbNotificacaoUser" class="lblNotificacao"></label>
                    </div>

                </div>




            </div>



            <div id="AreaConfig" class="AreaTarefa">

                <div class="tituloComputador">
                    Quem vai participar?
                </div>
                <asp:Panel ID="pnlConfiguracao" runat="server">
                </asp:Panel>
                <input type="button" id="btnAdicionar" value="+ Usuário" runat="server" onclick="AdicionarPainel()" disabled="disabled" />
            </div>


            <div class="btnForm" id="btnFormCadastrarTarefa" onmousemove="getCoordenadas(), startaHover('itemMenuBackGround', 'btnFormCadastrarTarefa')">


                <div class="itemMenuBackGround" id="itemMenuBackGround"></div>
                <input type="button" id="btnCadastrarTarefa" runat="server" value="Cadastrar Tarefa" onclick="cadastrarClick()" disabled="disabled" />

            </div>





        </div>

    </form>
</body>
</html>
