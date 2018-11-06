using Eye.Model;
using System.Data.SqlClient;

namespace Eye.DAO
{
    public class StatementUsuario
    {
        public bool VerificaUsernameUnico(string username)
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

        public bool VerificaEmailUnico(string email)
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

        public bool InserirUsuario(Usuario usuario)
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
    }
}