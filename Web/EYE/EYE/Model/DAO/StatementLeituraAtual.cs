using System.Data.SqlClient;

namespace EYE.Model.DAO
{
    public class StatementLeituraAtual
    {


        public static double getRAMAtual(int codComputador)
        {
            float retorno = 0;
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ram FROM leitura_atual WHERE cod_computador = @cod_computador", conexao))
                {
                    cmd.Parameters.AddWithValue("@cod_computador", codComputador);
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            retorno = leitor.GetFloat(0);
                        }
                    }
                }
                return retorno;
            }
        }
        public static double getCPUAtual(int codComputador)
        {
            double retorno = 0;
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT cpu FROM leitura_atual WHERE cod_computador = @cod_computador", conexao))
                {
                    cmd.Parameters.AddWithValue("@cod_computador", codComputador);
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            retorno = leitor.GetFloat(0);
                        }
                    }
                }
                return retorno;
            }
        }

        public static long getHDAtual(int codComputador)
        {
            long retorno = 0;
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT hd FROM leitura_atual WHERE cod_computador = @cod_computador", conexao))
                {
                    cmd.Parameters.AddWithValue("@cod_computador", codComputador);
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            retorno = leitor.GetInt64(0);
                        }
                    }
                }
                return retorno;
            }
        }
    }
}