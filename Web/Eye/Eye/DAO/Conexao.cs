using System.Data.SqlClient;

namespace Eye.DAO
{
    public class Conexao
    {
        public static void GetConexao()
        {
            var conexao = new SqlConnection("");
            conexao.Open();
        }
    }
}