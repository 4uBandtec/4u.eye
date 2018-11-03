<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroWorkspace.aspx.cs" Inherits="Eye.View.CadastroWorkspace" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblWorkspacename" Text="Workspacename" runat="server" />
            <br />
            <asp:TextBox ID="txtWorkspacename" runat="server" Placeholder="Workspacename"></asp:TextBox>
            <br />
            <asp:Label ID="lblNome" Text="Nome" runat="server" />
            <br />
            <asp:TextBox ID="txtNome" runat="server" Placeholder="Nome"></asp:TextBox>
            <br />
            <asp:Label ID="lblEmail" Text="E-mail" runat="server" />
            <br />
            <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox>
            <br />
            <asp:Label ID="lblSenha" Text="Senha" runat="server" />
            <br />
            <asp:TextBox ID="txtSenha" runat="server" Placeholder="Senha" type="password"></asp:TextBox>
            <br />
            <asp:Label ID="lblMensagem" Text="" runat="server" />
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
        </div>
    </form>
</body>
</html>
