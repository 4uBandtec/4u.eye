using System.Data.SqlClient;

namespace EYE.Model.DAO
{
	public class StatementWorkspace
	{
		private const int MINIMO_DE_ALTERACAO = 1;
		public static bool VerificaWorkspacenameUnico(string workspacename)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT workspacename FROM workspace WHERE workspacename = @workspacename", conexao))
				{
					cmd.Parameters.AddWithValue("@workspacename", workspacename);
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
				using (SqlCommand cmd = new SqlCommand("SELECT * FROM workspace WHERE email = @email", conexao))
				{
					cmd.Parameters.AddWithValue("@email", email);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						return !(leitor.Read());
					}
				}
			}
		}
		public static int BuscaSalt(string workspacename)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT salt FROM workspace WHERE workspacename = @workspacename  OR email = @workspacename", conexao))
				{
					cmd.Parameters.AddWithValue("@workspacename", workspacename);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						return (leitor.Read()) ? leitor.GetInt32(0) : 0;
					}
				}
			}
		}
		public static string BuscaSenhaHash(string workspacename)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT senha FROM workspace WHERE workspacename = @workspacename OR email = @workspacename", conexao))
				{
					cmd.Parameters.AddWithValue("@workspacename", workspacename);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						return leitor.Read() ? leitor.GetString(0) : null;
					}
				}
			}
		}
		public static int BuscaCodigo(string workspacename)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT cod_workspace FROM workspace WHERE workspacename = @workspacename OR email = @workspacename", conexao))
				{
					cmd.Parameters.AddWithValue("@workspacename", workspacename);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						return leitor.Read() ? leitor.GetInt32(0) : 0;
					}
				}
			}
		}
		public static bool InserirWorkspace(Workspace workspace)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("INSERT INTO workspace (workspacename, nome, email, senha, salt) VALUES (@workspacename, @nome, @email, @senha, @salt)", conexao))
				{
					cmd.Parameters.AddWithValue("@workspacename", workspace.Workspacename);
					cmd.Parameters.AddWithValue("@nome", workspace.Nome);
					cmd.Parameters.AddWithValue("@email", workspace.Email);
					cmd.Parameters.AddWithValue("@senha", workspace.Senha);
					cmd.Parameters.AddWithValue("@salt", workspace.Salt);
					return (cmd.ExecuteNonQuery() >= MINIMO_DE_ALTERACAO);
				}
			}
		}

	}
}