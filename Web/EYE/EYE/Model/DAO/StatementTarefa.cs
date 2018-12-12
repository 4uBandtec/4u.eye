using EYE.Controller;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EYE.Model.DAO
{
	public class StatementTarefa
	{
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

                    int modified = (int)cmd.ExecuteScalar();

                    return modified;
                    

                }
			}
		}

		public static bool CadastrarProcessos(List<ProcessoTarefa> lista, int codTarefa)
		{
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
                        
                        return cmd.ExecuteNonQuery() == lista.Count;
					}

                }
			}
			return false;
		}
	}
}