using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace EYE.Model.DAO
{
    public class StatementPerfil
    {
        private const int MINIMO_DE_ALTERACAO = 1;
        public static Perfil BuscarMinutosUtilizados(int codUsuario)
        {
            var perfil = new Perfil();
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT minutos_trabalho, minutos_jogo, minutos_social, minutos_outros FROM  perfil_usuario WHERE cod_usuario = @cod_usuario", conexao))
                {
                    cmd.Parameters.AddWithValue("@cod_usuario", codUsuario);
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            perfil.Trabalho = leitor.GetInt32(0);
                            perfil.Jogo = leitor.GetInt32(1);
                            perfil.Social = leitor.GetInt32(2);
                            perfil.Outros = leitor.GetInt32(3);
                        }
                    }
                }
            }
            return perfil;
        }
        public static bool UpdatePerfilProcesso(string codProcesso, int codPerfil)
        {
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE perfil_processo_usuario set cod_perfil = @cod_perfil where cod_processo = @cod_processo", conexao))
                {
                    cmd.Parameters.AddWithValue("@cod_perfil", codPerfil);
                    cmd.Parameters.AddWithValue("@cod_processo", codProcesso);
                    return (cmd.ExecuteNonQuery() >= MINIMO_DE_ALTERACAO);
                }
            }
        }

        public static Processo BuscaProcessoSemPerfil(int codWorkspace)
        {
            var processo = new Processo();
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd =
                    new SqlCommand(
                        "SELECT cod_processo, nome_aplicacao FROM processo WHERE nome_aplicacao != 'NULL' AND cod_processo IN " +
                        "   (SELECT cod_processo  from perfil_processo_usuario " +
                        "      WHERE cod_perfil = 5 AND cod_usuario IN " +
                        "           (SELECT cod_usuario FROM usuario WHERE cod_workspace = @cod_workspace))", conexao))
                {
                    cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            processo.CodProcesso = leitor.GetInt32(0);
                            processo.NomeAplicacao = leitor.GetString(1);
                        }
                    }
                }
            }
            return processo;
        }

        public static DropDownList AlimentaDropDownListPerfil(DropDownList ddlPerfil)
        {
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT cod_perfil, nome FROM perfil WHERE cod_perfil != 5", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cod_perfil = reader.GetInt32(0);
                            var nome = reader.GetString(1);
                            ddlPerfil.Items.Add(new ListItem(nome, cod_perfil.ToString()));
                        }
                    }
                }          
            }
            return ddlPerfil;
        }

    }
}