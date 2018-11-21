using System.Data.SqlClient;

namespace EYE.Model.DAO
{
	public class StatementComputador
	{
		public static int ContaComputador(int codUsuario)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT COUNT(cod_computador) FROM computador WHERE cod_usuario = @cod_usuario", conexao))
				{
					cmd.Parameters.AddWithValue("@cod_usuario", codUsuario);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						return leitor.Read() ? leitor.GetInt32(0) : 0;
					}
				}
			}
		}

		public static Computador[] ListarComputadores(int codUsuario)
		{
			Computador[] computadores = new Computador[ContaComputador(codUsuario)];
			var contador = 0;
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT cod_computador, nome, sistema_operacional, versao_sistema, versao_bits, processador, total_hd, total_ram FROM computador WHERE cod_usuario = @cod_usuario", conexao))
				{
					cmd.Parameters.AddWithValue("@cod_usuario", codUsuario);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						do
						{
							while (leitor.Read())
							{
								computadores[contador] = new Computador();
								computadores[contador].CodComputador = leitor.GetInt32(0);
								computadores[contador].NomeComputador = "Computador sem nome definido";//leitor.GetString(1);
								computadores[contador].SistemaOperacional = leitor.GetString(2);
								computadores[contador].VersaoSistema = leitor.GetString(3);
								computadores[contador].VersaoBits = leitor.GetInt32(4);
								computadores[contador].Processador = leitor.GetString(5);
								computadores[contador].HdTotal = leitor.GetInt64(6);
								computadores[contador].RamTotal = leitor.GetInt64(7);
								computadores[contador].CodUsuario = codUsuario;

								++contador;
							}
						}
						while (leitor.NextResult());
					}
				}
			}
			return computadores;
		}
	}
}

