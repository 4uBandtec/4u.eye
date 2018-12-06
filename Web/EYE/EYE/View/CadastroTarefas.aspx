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
</head>
<body onload="iniciarEstilo(), iniciarPainelTarefas()">
    <form id="form1" runat="server">


        <asp:ScriptManager ID="ScriptManager" runat="server"
            EnablePageMethods="true" />

        <!--MENU 
            precisa ter o script dashStyle.js e 
            função "iniciarEstilo" no onLoad do body-->
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

            <asp:Label ID="Label1" Text="" CssClass="mensagem" runat="server" />
        </div>


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
                    <asp:TextBox ID="txtNome" Placeholder="Qual é a tarefa?" runat="server"></asp:TextBox>
                </div>
                <div class="campos">

                    <div class="tituloCampo">
                        Descreva essa tarefa pra sua equipe:
                    </div>
                    <asp:TextBox ID="txtDescricao" Placeholder="Descreva ela..." runat="server"></asp:TextBox>
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
