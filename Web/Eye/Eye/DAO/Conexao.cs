using System.Data.SqlClient;

namespace Eye.DAO
{
    public class Conexao
    {
        public static void GetConexao()
        {
            var conexao = new SqlConnection("Server=tcp:bandtecserver.database.windows.net,1433;Initial Catalog=bd4U;Persist Security Info=False;User ID=henriquegs@bandtecserver;Password=digitalSCHO00L;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            conexao.Open();
        }
    }
}