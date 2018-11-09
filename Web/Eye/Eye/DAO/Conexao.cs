using System.Data.SqlClient;

namespace Eye.DAO
{
    public class Conexao
    {
        public static SqlConnection GetConexao()
        {
            return new SqlConnection("Server=tcp:bandtecserver.database.windows.net,1433;Initial Catalog=bd4U;Persist Security Info=False;User ID=henriquegs;Password=digitalSCH00L;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; Min Pool Size=5; Max Pool Size=250;");
        }
    }
}