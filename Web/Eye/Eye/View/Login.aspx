<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Eye.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <label>Workname/E-mail</label>
            <br />
            <asp:TextBox ID="txtWorkspacename" runat="server" Placeholder="Workname ou E-mail"></asp:TextBox>
            <br />
            <label>Senha</label>
            <br />
            <asp:TextBox ID="txtSenha" runat="server" Placeholder="Senha" type="password"></asp:TextBox>
            <asp:Label ID ="lblMensagem" Text="" runat="server"  />
            <asp:Button ID="btnLogar" runat="server" Text="Button" OnClick="btnLogar_Click" />
        </div>
    </form>
</body>
</html>
