<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroSlack.aspx.cs" Inherits="EYE.View.CadastroSlack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link runat="server" rel="shortcut icon" href="../Component/favicon.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="../Component/favicon.ico" type="image/ico" />

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Slack | EYE by 4U</title>

    <link href="../Model/EYE.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Controller/DashStyle.js"></script>
    <script type="text/javascript" src="../Controller/BreakSession.js"></script>
</head>
<body onload="iniciarEstilo()">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server"
            EnablePageMethods="true" />
        <!--MENU-->
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


            <a onclick="mudarTema()">
                <div class="itemMenu">

                    <div class="itemIcon">
                        <img src="../Component/Opcoes.png" />
                    </div>
                    <div class="itemMenuBackGround"></div>

                    <div class="itemTxt">
                        Trocar Cores do Tema
               
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


        <div id="areaInfoSlack">
            <div class="areaCamposSlack">
                <div class="tituloCampo">
                    Cadastre seu canal do Slack para receber atualizações!!!
                </div>
                <asp:Label ID="lblMensagem" Text="" CssClass="mensagem" runat="server" />
                <div class="campos">

                    <div class="tituloCampo">
                        Você precisa acessar <a href="https://api.slack.com/"><i>ESSE LINK</i></a> e, após cadastrar seu workspace, nos dizer a URL:
                    </div>
                    <asp:TextBox ID="txtUrl" runat="server" Placeholder="(ex: https://hooks.slack.com/services/T0/B0/X)"></asp:TextBox>

                </div>
                <div class="campos">

                    <div class="tituloCampo">
                        Me diga o canal:
                    </div>
                    <asp:TextBox ID="txtCanal" runat="server" Placeholder="(ex: #random)"></asp:TextBox>

                </div>

                <div class="btnForm" id="btnFormCadastrarSlack" onmousemove="startaHover('itemMenuBackGround', 'btnFormCadastrarSlack'), getCoordenadas()">

                    <div class="itemMenuBackGround" id="itemMenuBackGround"></div>

                    <asp:Button ID="btnCadastrar" Text="Cadastrar" runat="server" OnClick="btnCadastrar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
