using System.Data.SqlClient;

namespace EYE.Model.DAO
{
    public class Conexao
    {
        public static SqlConnection GetConexao()
        {
            SqlConnection conexao = new SqlConnection("Server=tcp:bandtecserver.database.windows.net,1433;Initial Catalog=bd4U;Persist Security Info=False;User ID=henriquegs;Password=digitalSCH00L;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Min Pool Size=5;Max Pool Size=250;");
            conexao.Open();
            return conexao;
        }
    }
}