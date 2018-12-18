<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroUsuario.aspx.cs" Inherits="Eye.View.CadastroUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link runat="server" rel="shortcut icon" href="../Component/favicon.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="../Component/favicon.ico" type="image/ico" />

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro de Usuários | EYE by 4U</title>
    <link href="../Model/EYE.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript" src="../Controller/Dashboard.js"></script>
    <script type="text/javascript" src="../Controller/DashStyle.js"></script>
    <script type="text/javascript" src="../Controller/BreakSession.js"></script>
    <script type="text/javascript" src="../Controller/CamposFormulario.js"></script>
    <script type="text/javascript" src="../Controller/download.js"></script>
</head>
<body onload="getCamposCadastroUsuario(), iniciarEstilo()">

    <div class="radialBlack" id="radialBlack"></div>

    <form id="formCadastroUsuario" runat="server">

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
                    <input type="range" min="1" max="100" value="100" class="slider" id="slideCor" oninput="grayscale()" onmouseup="mudarIntensidade()"/>
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
                        <input type="radio" name="tema" id="tema0" value="0" checked="checked" onchange="mudarTema()"/>
                        <label for="tema0">Padrão</label>
                    </div>


                    <div class="radioTema">
                        <input type="radio" name="tema" id="tema1" value="1" onchange="mudarTema()"/>
                        <label for="tema1">Godez</label>
                    </div>

                    <div class="radioTema">
                        <input type="radio" name="tema" id="tema2" value="2" onchange="mudarTema()"/>
                        <label for="tema2">Martins</label>
                    </div>

                    <div class="radioTema">
                        <input type="radio" name="tema" id="tema3" value="3" onchange="mudarTema()"/>
                        <label for="tema3">Sayuri</label>
                    </div>

                    <div class="radioTema">
                        <input type="radio" name="tema" id="tema4" value="4" onchange="mudarTema()"/>
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

        <div id="areaTela">

            <div id="progressTrack">
                <div id="progressBar">
                </div>
            </div>
            <div class="campos">
                <asp:Label ID="lblTexto" Text="" runat="server" />
            </div>

            <div class="cadastroCampos">
                <div class="areaCampos">
                    <asp:Label ID="lblMensagem" Text="" CssClass="mensagem" runat="server" />

                    <div class="campos" onkeydown="tabPress(event)" onkeyup="keyUp(event)">

                        <asp:TextBox ID="txtNome" runat="server" Placeholder="Qual o nome dele?" CssClass="campoCadastro"></asp:TextBox>

                        <asp:TextBox ID="txtUsername" runat="server" Placeholder="E o Username?" CssClass="campoCadastro"></asp:TextBox>

                        <asp:TextBox ID="txtEmail" runat="server" Placeholder="Coloque o email" type="email" CssClass="campoCadastro"></asp:TextBox>

                        <asp:TextBox ID="txtDataNascimento" runat="server" Placeholder="Data de Nascimento" CssClass="campoCadastro" MaxLength="10"></asp:TextBox>


                        <asp:DropDownList runat="server" ID="ddlSexo" CssClass="campoCadastro" onchange="keyUp(event)">
                            <asp:ListItem Text="Qual o sexo?" Value="" Selected="True" />
                            <asp:ListItem Text="Feminino" Value="F" />
                            <asp:ListItem Text="Masculino" Value="M" />
                            <asp:ListItem Text="Outro" Value="O" />
                        </asp:DropDownList>


                        <asp:TextBox ID="txtSenha" runat="server" Placeholder="A primeira Senha dele" type="password" CssClass="campoCadastro"></asp:TextBox>

                        <asp:TextBox ID="txtConfirmarSenha" runat="server" Placeholder="Confirme a Senha" type="password" CssClass="campoCadastro"></asp:TextBox>


                    </div>


                    <div class="campos" onmousemove="getCoordenadas()">

                        <div class="btnForm" id="btnFormCadastrar" onmousemove="startaHover('itemMenuBackGround', 'btnFormCadastrar')">


                            <div class="itemMenuBackGround" id="itemMenuBackGround"></div>
                            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrarUsuario_Click" />
                        </div>

                        <div class="btnForm" id="btnFormPrevious"
                            onmousemove="startaHover('itemMenuBackGroundPrevious', 'btnFormPrevious')"
                            onfocus="alert('a')">

                            <div class="itemMenuBackGround" id="itemMenuBackGroundPrevious"></div>
                            <input type="button" id="btnPrevious" value="Voltar" onclick="previousCampo()" />
                        </div>

                        <div class="btnForm" id="btnFormNext"
                            onmousemove="startaHover('itemMenuBackGroundNext', 'btnFormNext')">

                            <div class="itemMenuBackGround" id="itemMenuBackGroundNext"></div>
                            <input type="button" id="btnNext" value="Próximo" onclick="nextCampo()" />
                        </div>
                    </div>




                </div>
            </div>
        </div>
        <!-- 
        <asp:Button ID="btnIrPara" runat="server" Text="Ir para a Dashboard" OnClick="btnIrPara_Click" CssClass="defaultButton" />
        -->
    </form>
</body>
</html>
