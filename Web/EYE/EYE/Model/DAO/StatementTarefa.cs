using System.Data.SqlClient;

namespace EYE.Model.DAO
{
	public class StatementTarefa
	{
		private const int MINIMO_DE_ALTERACAO = 1;
		public static bool InserirTarefa(Tarefa tarefa)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("INSERT INTO tarefa (nome, descricao, data_inicio, data_fim, data_conclusao, cod_andamento, status_vida, cod_workspace) VALUES (@nome, @descricao, @data_inicio, @data_fim, @data_conclusao, @cod_andamento, @status_vida, @cod_workspace)", conexao))
				{
					cmd.Parameters.AddWithValue("@nome", tarefa.Nome);
					cmd.Parameters.AddWithValue("@descricao", tarefa.Descricao);
					cmd.Parameters.AddWithValue("@data_inicio", tarefa.DataInicio);
					cmd.Parameters.AddWithValue("@data_fim", tarefa.DataFim);
					cmd.Parameters.AddWithValue("@data_conclusao", tarefa.DataConclusao);
					cmd.Parameters.AddWithValue("@cod_andamento", tarefa.CodAndamento);
					cmd.Parameters.AddWithValue("@status_vida", tarefa.StatusVida);
					cmd.Parameters.AddWithValue("@cod_workspace", tarefa.CodWorkspace);

					return (cmd.ExecuteNonQuery() >= MINIMO_DE_ALTERACAO);
				}
			}
		}
	}
}