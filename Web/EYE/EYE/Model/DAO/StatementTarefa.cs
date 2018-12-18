using EYE.Model.Enum;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EYE.Model.DAO
{
	public class StatementTarefa
	{
		private const int MINIMO_DE_ALTERACAO = 1;
		public static int InserirTarefa(Tarefa tarefa)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("INSERT INTO tarefa (nome, descricao, data_inicio, data_fim, cod_andamento, status_vida, cod_workspace) OUTPUT INSERTED.cod_tarefa VALUES (@nome, @descricao, @data_inicio, @data_fim, @cod_andamento, @status_vida, @cod_workspace)", conexao))
				{
					cmd.Parameters.AddWithValue("@nome", tarefa.Nome);
					cmd.Parameters.AddWithValue("@descricao", tarefa.Descricao);
					cmd.Parameters.AddWithValue("@data_inicio", tarefa.DataInicio);
					cmd.Parameters.AddWithValue("@data_fim", tarefa.DataFim);
					cmd.Parameters.AddWithValue("@cod_andamento", tarefa.CodAndamento);
					cmd.Parameters.AddWithValue("@status_vida", tarefa.StatusVida);
					cmd.Parameters.AddWithValue("@cod_workspace", tarefa.CodWorkspace);

					return (int)cmd.ExecuteScalar();
				}
			}
		}

		public static bool CadastrarProcessos(List<ProcessoTarefa> lista, int codTarefa)
		{
			var retorno = true;
			using (var conexao = Conexao.GetConexao())
			{
				foreach (var item in lista)
				{
					using (SqlCommand cmd = new SqlCommand("INSERT INTO processo_tarefa (cod_tarefa, cod_processo, cod_usuario, minutos_meta) VALUES (@cod_tarefa, @cod_processo, @cod_usuario, @minutos_meta)", conexao))
					{
						cmd.Parameters.AddWithValue("@cod_tarefa", codTarefa);
						cmd.Parameters.AddWithValue("@cod_processo", item.CodProcesso);
						cmd.Parameters.AddWithValue("@nome_aplicacao", item.CodProcesso);
						cmd.Parameters.AddWithValue("@cod_usuario", item.CodUsuario);
						cmd.Parameters.AddWithValue("@minutos_meta", item.TempoTarefa);

						retorno = retorno && (cmd.ExecuteNonQuery() >= MINIMO_DE_ALTERACAO);
					}
				}
			}
			return retorno;
		}
		public static List<Tarefa> ListarTarefas(int codWorkspace)
		{
			var lista = new List<Tarefa>();
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT cod_tarefa, nome, descricao, data_inicio, data_fim, cod_andamento, data_conclusao, status_vida  FROM tarefa WHERE cod_workspace = @cod_workspace", conexao))
				{
					cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{

						while (leitor.Read())
						{
							lista.Add(new Tarefa()
							{
								CodTarefa = leitor.GetInt32(0),
								Nome = leitor.GetString(1),
								Descricao = leitor.GetString(2),
								DataInicio = leitor.GetString(3),
								DataFim = leitor.GetString(4),
								CodAndamento = (Andamento)leitor.GetInt32(5),
								DataConclusao = leitor.GetString(6),
								StatusVida = (StatusVida)leitor.GetInt32(7)
							});
						}

					}
				}
			}
			return lista;
		}
		public static List<Tarefa> AdicionaProcessos(List<Tarefa> lista)
		{
			using (var conexao = Conexao.GetConexao())
			{
				foreach (var item in lista)
				{
					item.ProcessoTarefa = new List<ProcessoTarefa>();
					using (SqlCommand cmd = new SqlCommand("SELECT cod_processo, cod_usuario, minutos_meta, minutos_feitos FROM processo_tarefa WHERE cod_tarefa = @cod_tarefa", conexao))
					{
						cmd.Parameters.AddWithValue("@cod_tarefa", item.CodTarefa);
						using (SqlDataReader leitor = cmd.ExecuteReader())
						{

							while (leitor.Read())
							{
								item.ProcessoTarefa.Add(new ProcessoTarefa()
								{
									CodProcesso = leitor.GetInt32(0),
									CodUsuario = leitor.GetInt32(1),
									TempoTarefa = leitor.GetInt32(2),
									TempoFeito = leitor.GetInt32(3)
								});
							}

						}
					}
				}
			}
			return lista;
		}

		public static List<Tarefa> AdicionaNomeUsuario(List<Tarefa> lista)
		{
			using (var conexao = Conexao.GetConexao())
			{
				foreach (var item in lista)
				{
					foreach (var processo in item.ProcessoTarefa)
					{
						using (SqlCommand cmd = new SqlCommand("SELECT nome FROM usuario WHERE cod_usuario = @cod_usuario", conexao))
						{
							cmd.Parameters.AddWithValue("@cod_usuario", processo.CodUsuario);
							using (SqlDataReader leitor = cmd.ExecuteReader())
							{
								if (leitor.Read())
									processo.NomeUsuario = leitor.GetString(0);
							}
						}
					}
				}
			}
			return lista;
		}

		public static List<Tarefa> AdicionaNomeProcesso(List<Tarefa> lista)
		{
			using (var conexao = Conexao.GetConexao())
			{
				foreach (var item in lista)
				{
					foreach (var processo in item.ProcessoTarefa)
					{
						using (SqlCommand cmd = new SqlCommand("SELECT nome_processo, nome_aplicacao FROM processo WHERE cod_processo = @cod_processo", conexao))
						{
							cmd.Parameters.AddWithValue("@cod_processo", processo.CodProcesso);
							using (SqlDataReader leitor = cmd.ExecuteReader())
							{

								while (leitor.Read())
								{
									processo.NomeProcesso = leitor.GetString(1).Equals("NULL") ? leitor.GetString(0) : leitor.GetString(1);
								}

							}
						}
					}
				}
			}
			return lista;
		}
	}
}