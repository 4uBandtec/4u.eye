using EYE.Model.Enum;
using System.Data.SqlClient;

namespace EYE.Model.DAO
{
	public class StatementNotificacao
	{
		private const int MINIMO_DE_ALTERACAO = 1;
		public static bool RegistrarNotificacao(string mensagem, int codRemetente, int canal, Remetente remetente)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("INSERT INTO usuario (cod_mensagem, cod_remetente, canal_envio, remetente, enviado) VALUES (@cod_mensagem, @cod_remetente, @canal_envio, @remetente, @enviado)", conexao))
				{
					cmd.Parameters.AddWithValue("@mensagem", mensagem);
					cmd.Parameters.AddWithValue("@cod_remetente", codRemetente);
					cmd.Parameters.AddWithValue("@canal_envio", canal);
					cmd.Parameters.AddWithValue("@remetente", remetente);
					cmd.Parameters.AddWithValue("@enviado", StatusVida.Ativo);
					return (cmd.ExecuteNonQuery() >= MINIMO_DE_ALTERACAO);
				}
			}
		}
	}
}