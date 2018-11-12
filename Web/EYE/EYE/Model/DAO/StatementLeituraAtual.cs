using System.Data.SqlClient;

namespace EYE.Model.DAO
{
    public class StatementLeituraAtual
    {
        

        public static double getRAMAtual(int codComputador)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT ram FROM leitura WHERE cod_computador = @cod_computador", conexao))
            {
                cmd.Parameters.AddWithValue("@cod_computador", codComputador);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return leitor.GetDouble(0);
                    }
                }
                return 0.0;
            }
        }
        public static double getCPUAtual(int codComputador)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT cpu FROM leitura WHERE cod_computador = @cod_computador", conexao))
            {
                cmd.Parameters.AddWithValue("@cod_computador", codComputador);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return leitor.GetDouble(0);
                    }
                }
                return 0.0;
            }
        }

        public static double getHDAtual(int codComputador)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT hd FROM leitura WHERE cod_computador = @cod_computador", conexao))
            {
                cmd.Parameters.AddWithValue("@cod_computador", codComputador);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return leitor.GetDouble(0);
                    }
                }
                return 0.0;
            }
        }
    }
}