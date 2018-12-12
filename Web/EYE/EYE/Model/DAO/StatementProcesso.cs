using System.Collections.Generic;
using System.Data.SqlClient;

namespace EYE.Model.DAO
{
    public class StatementProcesso
    {
        public static List<Processo> ListarProcessos()
        {
            var processos = new List<Processo>();
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT cod_processo, nome_processo, nome_aplicacao FROM processo", conexao))
                {
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        do
                        {
                            while (leitor.Read())
                            {
                                var processo = new Processo();
                                processo.CodProcesso = leitor.GetInt32(0);                              
                                processo.NomeProcesso = leitor.GetString(1);
                                processo.NomeAplicacao = leitor.GetString(2);
                                processos.Add(processo);
                            }
                        }
                        while (leitor.NextResult());
                    }
                }
            }
            return processos;
        }
    }
}