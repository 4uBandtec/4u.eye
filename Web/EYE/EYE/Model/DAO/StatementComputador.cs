using System.Collections.Generic;
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
								computadores[contador].NomeComputador = "Computador de ";
                                computadores[contador].SistemaOperacional = leitor.GetString(2);
								computadores[contador].VersaoSistema = leitor.GetString(3);
								computadores[contador].VersaoBits = leitor.GetInt32(4);
								computadores[contador].Processador = leitor.GetString(5);
								computadores[contador].HdTotal = leitor.GetInt64(6);
								computadores[contador].RamTotal = leitor.GetInt64(7);
								computadores[contador].CodUsuario = codUsuario;
                                computadores[contador].UltimaLeitura = StatementLeituraAtual.GetUltimaLeitura(leitor.GetInt32(0));

								++contador;
							}
						}
						while (leitor.NextResult());
					}
				}
			}
			return computadores;
		}
		public static List<Computador> ListaUltimaLeituraComputador(int codWorkspace)
		{
			var computadores = new List<Computador>();
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand($"SELECT cod_computador, ultima_leitura FROM leitura_atual" +
													   $" WHERE cod_computador " +
													   $"IN( SELECT cod_computador FROM computador " +
													   $"WHERE cod_usuario " +
													   $"IN(SELECT cod_usuario FROM usuario" +
													   $" WHERE cod_workspace = @cod_workspace)); ", conexao))
				{
					cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						do
						{
							while (leitor.Read())
							{
								computadores.Add(new Computador()
								{
									CodComputador = leitor.GetInt32(0),
									UltimaLeitura = leitor.GetString(1)
								});
							}
						}
						while (leitor.NextResult());
					}
				}
			}
			return computadores;
		}
		public static List<Computador> AdicionaNomeUsuario(List<Computador> computadores)
		{
			using (var conexao = Conexao.GetConexao())
			{
				foreach (var item in computadores)
				{
					using (SqlCommand cmd = new SqlCommand($"SELECT cod_usuario, username FROM usuario " +
														   $"WHERE cod_usuario = " +
														   $"(SELECT cod_usuario FROM computador " +
														   $"WHERE cod_computador = @cod_computador);", conexao))
					{

						cmd.Parameters.AddWithValue("@cod_computador", item.CodComputador);
						using (SqlDataReader leitor = cmd.ExecuteReader())
						{
							do
							{
								while (leitor.Read())
								{
									item.CodUsuario = leitor.GetInt32(0);
									item.Nome = leitor.GetString(1);
								}
							}
							while (leitor.NextResult());
						}
					}
				}
			}
			return computadores;
		}
	}
}

