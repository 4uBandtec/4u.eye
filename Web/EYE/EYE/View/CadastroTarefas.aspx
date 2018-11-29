﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroTarefas.aspx.cs" Inherits="EYE.View.CadastroTarefas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link runat="server" rel="shortcut icon" href="../Component/favicon.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="../Component/favicon.ico" type="image/ico" />

	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
            <asp:Panel ID="pnlConfiguracao" runat="server" BackColor="#FFF"> </asp:Panel>
            <asp:Button ID="btnAdicionar" Text="+" runat="server"  OnClick="btnAdicionar_Click"/>
			<div>
				<p>
					Tarefa
				</p>
				<p>
					Nome:
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
				</p>
				<p>
					Descrição:
            <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
				</p>
				<p>
					Data Inicio:
            <asp:TextBox ID="txtDataInicio" runat="server"></asp:TextBox>
				</p>
				<p>
					Data: Fim:
            <asp:TextBox ID="txtDataFim" runat="server"></asp:TextBox>
				</p>
				<p>
					Data Conclusão:
            <asp:TextBox ID="txtDataConclusao" runat="server"></asp:TextBox>
				</p>
			</div>
			<asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
			<asp:Label Text="" ID="lblMensagem" runat="server" />
		</div>
	</form>
</body>
</html>
