
using System;

namespace EYE.Model
{
	public class Usuario
	{
		private const int INDEX_DATA = 0;
		private const int INDEX_HORA = 0;

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
		private Computador[] computadoresUsuario;
		private string ultimaLeitura;

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
		public Computador[] ComputadoresUsuario { get => computadoresUsuario; set => computadoresUsuario = value; }
		public string UltimaLeitura { get => ultimaLeitura; set => ultimaLeitura = value; }

		public static bool HoraAtualizada(string tempoCompleto)
		{
			var dataCompleta = tempoCompleto.Split(' ');
			var datas =dataCompleta[INDEX_DATA].Split('/');
			var horas = dataCompleta[INDEX_DATA].Split(':');
			var ano = int.Parse(datas[2]);
			var mes = int.Parse(datas[1]);
			var dia = int.Parse(datas[0]);
			var segundo = int.Parse(horas[2]);
			var minuto = int.Parse(horas[1]);
			var hora = int.Parse(horas[0]);

			var dataBanco = new DateTime(ano, mes, dia, hora, minuto, segundo);
			var dataAtrasada = DateTime.Now.AddMinutes(-5);
			return dataBanco > dataAtrasada;
		}
	}
}