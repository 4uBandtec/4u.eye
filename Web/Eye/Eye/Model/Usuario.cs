﻿
namespace EYE.Model
{
    public class Usuario
    {
        private int codUsuario;
        private string username;
        private string nome;
        private string email;
        private string senha;
        private string dataNascimento;
        private string sexo;
        private int salt;
        private int codWorkspace;
		private int perfil;

		public int CodUsuario { get => codUsuario; set => codUsuario = value; }
		public string Username { get => username; set => username = value; }
		public string Nome { get => nome; set => nome = value; }
		public string Email { get => email; set => email = value; }
		public string Senha { get => senha; set => senha = value; }
		public string DataNascimento { get => dataNascimento; set => dataNascimento = value; }
		public string Sexo { get => sexo; set => sexo = value; }
		public int Salt { get => salt; set => salt = value; }
		public int CodWorkspace { get => codWorkspace; set => codWorkspace = value; }
		public int Perfil { get => perfil; set => perfil = value; }
		public Computador[] ComputadoresUsuario { get; set; }

	}
}