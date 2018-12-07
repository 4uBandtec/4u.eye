<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroSlack.aspx.cs" Inherits="EYE.View.CadastroSlack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                Cadastro Slack
            </p>
            <p>
                Url:
            <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
            </p>

            <p>
                Canal:
            <asp:TextBox ID="txtCanal" runat="server"></asp:TextBox>
            </p>
        <asp:Button ID="btnCadastrar" Text="Cadastrar" runat="server" OnClick="btnCadastrar_Click" />
        <asp:Label ID="lblMensagem" Text="" runat="server" />
        </div>
    </form>
</body>
</html>
