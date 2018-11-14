using System.Data.SqlClient;

namespace EYE.Model.DAO
{
    public class StatementLeituraAtual
    {
        

        public static double getRAMAtual(int codComputador)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT ram FROM leitura_atual WHERE cod_computador = @cod_computador", conexao))
            {
                cmd.Parameters.AddWithValue("@cod_computador", codComputador);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        float result = leitor.GetFloat(0);
                        conexao.Close();
                        return result;
                    }
                }
                return 0.0;
            }
        }
        public static double getCPUAtual(int codComputador)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT cpu FROM leitura_atual WHERE cod_computador = @cod_computador", conexao))
            {
                cmd.Parameters.AddWithValue("@cod_computador", codComputador);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        float result = leitor.GetFloat(0);
                        conexao.Close();
                        return result;
                    }
                }
                return 0.0;
            }
        }

        public static long getHDAtual(int codComputador)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT hd FROM leitura_atual WHERE cod_computador = @cod_computador", conexao))
            {
                cmd.Parameters.AddWithValue("@cod_computador", codComputador);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        long result = leitor.GetInt64(0);
                        conexao.Close();
                        return result;
                    }
                }
                return 0;
            }
        }
    }
}