using System.Data.SqlClient;

namespace EYE.Model.DAO
{
    public class StatementSlack
    {
        private const int MINIMO_DE_ALTERACAO = 1;
        public static bool InserirSlack(Slack slack)
        {
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE workspace SET url_slack = @url_slack WHERE cod_workspace = @cod_workspace", conexao))
                {
                    cmd.Parameters.AddWithValue("@url_slack", slack.Url);
                    cmd.Parameters.AddWithValue("@cod_workspace", slack.CodWorkspace);
					return cmd.ExecuteNonQuery() >= MINIMO_DE_ALTERACAO;
                }
            }
        }
		public static string VerificaUrlCadastrada(int codWorkspace)
		{
			using (var conexao = Conexao.GetConexao())
			{
				using (SqlCommand cmd = new SqlCommand("SELECT url_slack FROM workspace WHERE cod_workspace = @cod_workspace", conexao))
				{
					cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
					using (SqlDataReader leitor = cmd.ExecuteReader())
					{
						return (leitor.Read()) ? leitor.GetString(0) : null;
					}
				}
			}
		}
	}
}