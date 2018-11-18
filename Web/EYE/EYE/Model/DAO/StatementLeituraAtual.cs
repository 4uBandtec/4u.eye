using System.Data.SqlClient;

namespace EYE.Model.DAO
{
	public class StatementLeituraAtual
	{
		public static double GetRAMAtual(int codComputador)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT ram FROM leitura_atual WHERE cod_computador = @cod_computador", conexao))
				{
					cmd.Parameters.AddWithValue("@cod_computador", codComputador);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						return leitor.Read() ? leitor.GetFloat(0) : 0;
					}
				}
			}
		}
		public static double GetCPUAtual(int codComputador)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT cpu FROM leitura_atual WHERE cod_computador = @cod_computador", conexao))
				{
					cmd.Parameters.AddWithValue("@cod_computador", codComputador);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						return leitor.Read() ? leitor.GetFloat(0) : 0;
					}
				}
			}
		}

		public static long GetHDAtual(int codComputador)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT hd FROM leitura_atual WHERE cod_computador = @cod_computador", conexao))
				{
					cmd.Parameters.AddWithValue("@cod_computador", codComputador);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						return leitor.Read() ? leitor.GetInt64(0) : 0;
					}
				}
			}
		}
	}
}