<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Eye.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="formLogin" runat="server">
        <div class="campos">
            <asp:Label Text="Nome" CssClass="lbl" ID="lblNome" runat="server"/>
            <asp:TextBox runat="server" ID="txtNome" MaxLength="50"/>
        </div>
    </form>
</body>
</html>
