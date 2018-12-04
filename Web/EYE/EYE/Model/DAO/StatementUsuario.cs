using System.Data.SqlClient;

namespace EYE.Model.DAO
{
	public class StatementUsuario
	{
		private const int MINIMO_DE_ALTERACAO = 1;
		public static bool VerificaUsernameUnico(string username)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT username FROM usuario WHERE username = @username", conexao))
				{
					cmd.Parameters.AddWithValue("@username", username);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						return !(leitor.Read());
					}
				}
			}
		}

		public static bool VerificaEmailUnico(string email)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT * FROM usuario WHERE email = @email", conexao))
				{
					cmd.Parameters.AddWithValue("@email", email);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						return !(leitor.Read());
					}
				}
			}
		}

		public static bool InserirUsuario(Usuario usuario)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("INSERT INTO usuario (username, nome, email, senha, data_nascimento, sexo, salt, cod_workspace) VALUES (@username, @nome, @email, @senha, @data_nascimento, @sexo, @salt, @cod_workspace)", conexao))
				{
					cmd.Parameters.AddWithValue("@username", usuario.Username);
					cmd.Parameters.AddWithValue("@nome", usuario.Nome);
					cmd.Parameters.AddWithValue("@email", usuario.Email);
					cmd.Parameters.AddWithValue("@senha", usuario.Senha);
					cmd.Parameters.AddWithValue("@data_nascimento", usuario.DataNascimento);
					cmd.Parameters.AddWithValue("@sexo", usuario.Sexo);
					cmd.Parameters.AddWithValue("@salt", usuario.Salt);
					cmd.Parameters.AddWithValue("@cod_workspace", usuario.CodWorkspace);
					return (cmd.ExecuteNonQuery() >= MINIMO_DE_ALTERACAO);
				}
			}
		}

		public static int ContaUsuario(int codWorkspace)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT COUNT(cod_usuario) FROM usuario WHERE cod_workspace = @cod_workspace", conexao))
				{
					cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						return leitor.Read() ? leitor.GetInt32(0) : 0;
					}
				}
			}
		}

		public static Usuario[] ListarUsuarios(int codWorkspace)
		{
			var usuarios = new Usuario[ContaUsuario(codWorkspace)];
			var contador = 0;
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT COD_USUARIO, USERNAME, NOME, EMAIL, SEXO, DATA_NASCIMENTO, COD_WORKSPACE FROM usuario WHERE cod_workspace = @cod_workspace", conexao))
				{
					cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						do
						{
							while (leitor.Read())
							{

								usuarios[contador] = new Usuario();
								usuarios[contador].CodUsuario = leitor.GetInt32(0);
								usuarios[contador].Nome = leitor.GetString(1);
								usuarios[contador].Username = leitor.GetString(2);
								usuarios[contador].Email = leitor.GetString(3);
								usuarios[contador].Sexo = leitor.GetString(4);
								usuarios[contador].DataNascimento = leitor.GetString(5);
								usuarios[contador].CodWorkspace = leitor.GetInt32(6);

								++contador;
							}
						}
						while (leitor.NextResult());
					}
				}
			}
			return usuarios;
		}

		public static Usuario[] ListaUltimaLeituraUsuario(int codWorkspace)
		{
			var usuarios = new Usuario[ContaUsuario(codWorkspace)];
			var contador = 0;
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand($"SELECT cod_computador, ultima_leitura FROM leitura_atual" +
													   $" WHERE cod_computador " +
													   $"IN( SELECT cod_computador FROM computador " +
													   $"WHERE cod_usuario " +
													   $"IN(SELECT cod_usuario FROM usuario WHERE cod_workspace = cod_workspace)) ; ", conexao))
				{
					cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						do
						{
							while (leitor.Read())
							{
								usuarios[contador] = new Usuario();
								usuarios[contador].CodUsuario = leitor.GetInt32(0);
								usuarios[contador].UltimaLeitura = leitor.GetString(1);
								++contador;
							}
						}
						while (leitor.NextResult());
					}
				}
			}
			return usuarios;
		}
	}
}