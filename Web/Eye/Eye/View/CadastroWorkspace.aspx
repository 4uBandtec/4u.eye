<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroWorkspace.aspx.cs" Inherits="Eye.View.CadastroWorkspace" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link runat="server" rel="shortcut icon" href="../Component/favicon.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="../Component/favicon.ico" type="image/ico" />

    <title>Cadastro | EYE by 4U</title>
    <link href="../Model/EYE.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript" src="../Controller/Dashboard.js"></script>
    <script type="text/javascript" src="../Controller/DashStyle.js"></script>
    <script type="text/javascript" src="../Controller/CamposFormulario.js"></script>
</head>
<body onload="getCamposCadastro()">

    <div class="radialBlack" id="radialBlack"></div>
    <form id="form1" runat="server">

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

                    <asp:TextBox ID="txtNome" runat="server" Placeholder="Seu nome" CssClass="campoCadastro"></asp:TextBox>

                    <asp:TextBox ID="txtWorkspacename" runat="server" Placeholder="Workspacename" CssClass="campoCadastro"></asp:TextBox>

                    <asp:TextBox ID="txtSenha" runat="server" Placeholder="Sua Senha" type="password" CssClass="campoCadastro"></asp:TextBox>

                    <asp:TextBox ID="txtConfirmaSenha" runat="server" Placeholder="Confirme sua senha" type="password" CssClass="campoCadastro"></asp:TextBox>

                    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Seu Email" CssClass="campoCadastro"></asp:TextBox>


                </div>

                <div class="campos" onmousemove="getCoordenadas()">

                    <div class="btnForm" id="btnFormCadastrar" onmousemove="startaHover('itemMenuBackGround', 'btnFormCadastrar')">


                        <div class="itemMenuBackGround" id="itemMenuBackGround"></div>
                        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
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
        
        <asp:Button ID="btnIrPara" runat="server" Text="Ir para o Login" OnClick="btnIrParaLogin_Click" CssClass="defaultButton" />
    </form>
</body>
</html>
