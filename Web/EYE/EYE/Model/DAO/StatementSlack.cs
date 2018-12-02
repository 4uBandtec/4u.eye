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
                using (SqlCommand cmd = new SqlCommand("INSERT INTO slack (url, nome, canal, cod_workspace) VALUES (@url, @nome, @canal, @cod_workspace)", conexao))
                {
                    cmd.Parameters.AddWithValue("@url", slack.Url);
                    cmd.Parameters.AddWithValue("@nome", slack.Nome);
                    cmd.Parameters.AddWithValue("@canal", slack.Canal);
                    cmd.Parameters.AddWithValue("@cod_workspace", slack.CodWorkspace);
                    return (cmd.ExecuteNonQuery() >= MINIMO_DE_ALTERACAO);
                }
            }
        }
    }
}