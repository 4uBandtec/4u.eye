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

        public static List<ProcessoTarefa> GetNomeUsuario(List<ProcessoTarefa> lista)
        {
            using (var conexao = Conexao.GetConexao())
            {
                foreach (var item in lista)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT nome FROM usuario WHERE cod_usuario = @cod_usuario", conexao))
                    {
                        cmd.Parameters.AddWithValue("@cod_usuario", item.CodUsuario);
                        using (SqlDataReader leitor = cmd.ExecuteReader())
                        {
                            item.NomeUsuario = leitor.Read() ? leitor.GetString(0) : null;
                        }
                    }
                }

            }
            return lista;
        }
    }
}