﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Eye.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login | EYE by 4U</title>
    <link href="../Model/EYE.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript" src="../Controller/Dashboard.js"></script>
    <script type="text/javascript" src="../Controller/DashStyle.js"></script>
</head>
<<<<<<< HEAD
<body id="body">
    <div class="radialBlack" id="radialBlack"></div>
        <form id="formLogin" runat="server">
            <asp:Button ID="btnIrPara" runat="server" Text="Novo Workspace" OnClick="btnIrPara_Click" cssClass="defaultButton"/>

            <div class="areaCampos">
                <asp:Label ID="lblMensagem" Text="" CssClass="mensagem" runat="server" />
                <div class="campos">

                    <asp:TextBox ID="txtWorkspacename" runat="server" Placeholder="Qual é seu Workspace?"></asp:TextBox>

                    <asp:TextBox ID="txtSenha" runat="server" Placeholder="E a sua Senha?" type="password"></asp:TextBox>

                </div>
                <div class="campos" onmousemove="getCoordenadas()">

                    <div class="btnForm" id="btnForm" onmousemove="startaHover('itemMenuBackGround', 'btnForm')">


                        <div class="itemMenuBackGround" id="itemMenuBackGround"></div>

                        <asp:Button ID="btnLogar" runat="server" Text="Entrar" OnClick="btnLogar_Click" />


                    </div>
                </div>
            </div>
        </form>

=======
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblWorkspace" Text="Workspacename/E-mail" runat="server" />
            <br />
            <asp:TextBox ID="txtWorkspacename" runat="server" Placeholder="Workname ou E-mail"></asp:TextBox>
            <br />
            <asp:Label ID="lblSenha" Text="Senha" runat="server" />
            <br />
            <asp:TextBox ID="txtSenha" runat="server" Placeholder="Senha" type="password"></asp:TextBox>
            <asp:Label ID="lblMensagem" Text="" runat="server" />
            <asp:Button ID="btnLogar" runat="server" Text="Button" OnClick="btnLogar_Click" />
        </div>
    </form>
>>>>>>> develop
</body>
</html>
