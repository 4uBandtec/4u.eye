<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroUsuario.aspx.cs" Inherits="Eye.View.CadastroUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro de Usuários | EYE by 4U</title>
    <link href="../Model/EYE.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript" src="../Controller/Dashboard.js"></script>
    <script type="text/javascript" src="../Controller/DashStyle.js"></script>
    <script type="text/javascript" src="../Controller/CamposFormulario.js"></script>
</head>
<body onload="getCamposCadastroUsuario()">

    <div class="radialBlack" id="radialBlack"></div>

    <form id="formCadastroUsuario" runat="server">

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

                <div class="campos" onkeydown="tabPress(event)" onkeyup="keyUp()">

                    <asp:TextBox ID="txtNome" runat="server" Placeholder="Qual o nome dele?" CssClass="campoCadastro"></asp:TextBox>

                    <asp:TextBox ID="txtUsername" runat="server" Placeholder="E o Username?" CssClass="campoCadastro"></asp:TextBox>

                    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Coloque o email" type="email" CssClass="campoCadastro"></asp:TextBox>

                    <asp:TextBox ID="txtDataNascimento" runat="server" Placeholder="Data de Nascimento" CssClass="campoCadastro" MaxLength="10"></asp:TextBox>


                    <asp:DropDownList runat="server" ID="ddlSexo" CssClass="campoCadastro"  onchange="keyUp()">
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
    </form>
</body>
</html>
