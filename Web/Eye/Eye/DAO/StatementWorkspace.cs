
using System.Data.SqlClient;

namespace Eye.DAO
{
    public class StatementWorkspace
    {
        public bool VerificaWorknameUnico(string workspacename)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT workspacename FROM workspace WHERE workspacename = @workspacename", conexao))
            {
                cmd.Parameters.AddWithValue("@workspacename", workspacename);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    return !(leitor.Read());
                }
            }
        }
        public int BuscaSalt(string workspacename)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT salt FROM workspace WHERE workspacename = @workspacename", conexao))
            {
                cmd.Parameters.AddWithValue("@workspacename", workspacename);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return leitor.GetInt32(0);
                    }
                }
            }
            return 0;
        }
        public string BuscaSenhaHash(string workspacename)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT senha FROM workspace WHERE workspacename = @workspacename", conexao))
            {
                cmd.Parameters.AddWithValue("@workspacename", workspacename);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return leitor.GetString(0);
                    }
                }
            }
            return null;
        }
        public int BuscaCodigo(string workspacename)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT cod_workspace FROM workspace WHERE workspacename = @workspacename", conexao))
            {
                cmd.Parameters.AddWithValue("@workspacename", workspacename);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    return (leitor.Read()) ? leitor.GetInt32(0) : 0;
                }
            }
        }
    }
}