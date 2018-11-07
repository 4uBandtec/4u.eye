using Eye.Model;
using System.Data.SqlClient;

namespace Eye.DAO
{
    public class StatementUsuario
    {
        public static bool VerificaUsernameUnico(string username)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT username FROM usuario WHERE username = @username", conexao))
            {
                cmd.Parameters.AddWithValue("@username", username);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    return !(leitor.Read());
                }
            }
        }

        public static bool VerificaEmailUnico(string email)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM usuario WHERE email = @email", conexao))
            {
                cmd.Parameters.AddWithValue("@email", email);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    return !(leitor.Read());
                }
            }
        }

        public static bool InserirUsuario(Usuario usuario)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO usuario (username, nome, email, senha, data_nascimento, sexo, salt, cod_workspace) VALUES (@username, @nome, @email, @senha, @data_nascimento, @sexo, @salt, @cod_workspace)", conexao))
            {
                cmd.Parameters.AddWithValue("@username", usuario.Username);
                cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@data_nascimento", usuario.DataNascimento);
                cmd.Parameters.AddWithValue("@sexo", usuario.Sexo);
                cmd.Parameters.AddWithValue("@salt", usuario.Salt);
                cmd.Parameters.AddWithValue("@cod_workspace", usuario.CodWorkspace);
                return (cmd.ExecuteNonQuery() == 1);
            }
        }

        public static int ContaUsuario(int codWorkspace)
        {
            Usuario[] usuarios = new Usuario[10];
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(cod_usuario) FROM usuario WHERE cod_workspace = @cod_workspace", conexao))
            {
                cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return (leitor.GetInt32(1));
                    }
                }
            }
            return 0;
        }

        public static bool GetUsuarios(int codWorkspace)
        {
            Usuario[] usuarios = new Usuario[10];
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM usuario WHERE cod_workspace = @cod_workspace", conexao))
            {
                cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    do
                    {
                        while (leitor.Read())
                        {

                            //Fazer:  leitor.GetString(1);
                        }
                    }
                    while (leitor.NextResult());
                }
            }
            return false;
        }

    }
}