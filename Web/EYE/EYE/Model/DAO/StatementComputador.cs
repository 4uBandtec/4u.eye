
using System.Data.SqlClient;

namespace EYE.Model.DAO
{
    public class StatementComputador
    {
        public static int ContaComputador(int codUsuario)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(cod_computador) FROM computador WHERE cod_usuario = @cod_usuario", conexao))
            {
                cmd.Parameters.AddWithValue("@cod_usuario", codUsuario);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return (leitor.GetInt32(0));
                    }
                }
            }
            return 0;
        }

        public static Computador[] ListarComputadores(int codUsuario)
        {
            Computador[] computadores = new Computador[ContaComputador(codUsuario)];
            var contador = 0;
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT nome, sistema_operacional, versao_sistema, versao_bits, processador, total_hd, total_ram FROM computador WHERE cod_usuario = @cod_usuario", conexao))
            {
                cmd.Parameters.AddWithValue("@cod_usuario", codUsuario);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    do
                    {
                        while (leitor.Read())
                        {

                            computadores[contador] = new Computador();
                            computadores[contador].NomeComputador = leitor.GetString(0);
                            computadores[contador].SistemaOperacional = leitor.GetString(1);
                            computadores[contador].VersaoSistema = leitor.GetString(2);
                            computadores[contador].VersaoBits = leitor.GetInt32(3);
                            computadores[contador].Processador = leitor.GetString(4);
                            computadores[contador].HDTotal = leitor.GetInt64(5);
                            computadores[contador].RAMTotal = leitor.GetInt64(6);
                            computadores[contador].CodUsuario = codUsuario;
                            
                            ++contador;
                        }
                    }
                    while (leitor.NextResult());
                }
            }
            return computadores;
        }

    }
}

