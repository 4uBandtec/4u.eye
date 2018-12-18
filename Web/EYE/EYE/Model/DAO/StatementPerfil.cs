using System.Data.SqlClient;

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
            return processo;
        }
    }
}