
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EYE.Model;
using EYE.Model.DAO;

namespace EYE.Controller
{
	public class ControllerUsuario
	{
		public bool Cadastrar(TextBox txtUsername, TextBox txtNome, TextBox txtEmail, TextBox txtSenha, TextBox txtDataNascimento, DropDownList ddlSexo, string codWorkspace, Label lblMensagem)
		{
			if (!Validacao.StringVazia(txtUsername, txtNome, txtEmail, txtSenha, txtDataNascimento))
			{
				lblMensagem.Text = "Parece que você digitou algo errado, certifique-se de que não esqueceu nada";
				return false;
			}
			else if (!Validacao.DropDownListVazia(ddlSexo))
			{
				lblMensagem.Text = "Você não me disse seu sexo, por favor escolha um";
				return false;
			}
			else if (!VerificaUsernameUnico(txtUsername.Text))
			{
				lblMensagem.Text = "Má noticia, alguém já tem o Username " + txtUsername.Text + ", seja mais criativo";
				return false;
			}
			else if (!VerificaEmailUnico(txtEmail.Text))
			{
				lblMensagem.Text = "Alguém já usa esse e-mail, ele não pode ser usado de novo";
				return false;
			}

			var usuario = new Usuario();
			usuario.Username = txtUsername.Text;
			usuario.Nome = txtNome.Text;
			usuario.Email = txtEmail.Text;
			usuario.Senha = txtSenha.Text;
			usuario.DataNascimento = txtDataNascimento.Text;
			usuario.Sexo = ddlSexo.SelectedValue;
			usuario.CodWorkspace = int.Parse(codWorkspace);



			usuario.Salt = Criptografia.GerarSalt();
			usuario.Senha = Criptografia.GerarSenhaHash(usuario.Senha, usuario.Salt);

			if (StatementUsuario.InserirUsuario(usuario))
			{
				lblMensagem.Text = "O novo usuário foi cadastrado, dê as boas vindas á ele por mim";

				txtUsername.Text = "";
				txtNome.Text = "";
				txtEmail.Text = "";
				txtSenha.Text = "";
				txtDataNascimento.Text = "";
				ddlSexo.SelectedValue = "";

				return true;
			}
			lblMensagem.Text = "Ops, deu algo errado, acho que a culpa é nossa";
			return false;
		}

		public static bool VerificaEmailUnico(string email)
		{
			return StatementUsuario.VerificaEmailUnico(email);
		}

		public static bool VerificaUsernameUnico(string username)
		{
			return StatementUsuario.VerificaUsernameUnico(username);
		}

		public int ContaUsuarioWorkspace(int codWorkspace)
		{
			return StatementUsuario.ContaUsuario(codWorkspace);
		}

		public Usuario[] ListarUsuarios(int codWorkspace)
		{
			return StatementUsuario.ListarUsuarios(codWorkspace);
		}

		public static List<int> RetornaUsuariosOnline(int codWorkspace)
		{
			var usuarios = StatementUsuario.ListaUltimaLeituraUsuario(codWorkspace);
			var lista = new List<int>();
			for (var contador = 0; contador > usuarios.Length; contador++)
			{
				if (!Usuario.HoraAtualizada(usuarios[contador].UltimaLeitura))
					lista.Add(usuarios[contador].CodUsuario);
			}
			return lista;
		}
	}
}