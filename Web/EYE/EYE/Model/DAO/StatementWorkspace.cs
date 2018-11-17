
using EYE.Controller;
using System.Data.SqlClient;

namespace EYE.Model.DAO
{
    public class StatementWorkspace
    {
        public static bool VerificaWorkspacenameUnico(string workspacename)
        {
            bool retorno = false;
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT workspacename FROM workspace WHERE workspacename = @workspacename", conexao))
                {
                    cmd.Parameters.AddWithValue("@workspacename", workspacename);
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        retorno = !(leitor.Read());
                    }
                }
            }
            return retorno;
        }

        public static bool VerificaEmailUnico(string email)
        {

            bool retorno = false;
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM workspace WHERE email = @email", conexao))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        retorno = !(leitor.Read());
                    }
                }
            }
            return retorno;
        }
        public static int BuscaSalt(string workspacename)
        {
            int retorno = 0;
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT salt FROM workspace WHERE workspacename = @workspacename  OR email = @workspacename", conexao))
                {
                    cmd.Parameters.AddWithValue("@workspacename", workspacename);
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            retorno = leitor.GetInt32(0);
                        }
                    }
                }
            }
            return retorno;
        }
        public static string BuscaSenhaHash(string workspacename)
        {
            string retorno = null;
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT senha FROM workspace WHERE workspacename = @workspacename OR email = @workspacename", conexao))
                {
                    cmd.Parameters.AddWithValue("@workspacename", workspacename);
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            retorno = leitor.GetString(0);
                        }
                    }
                }
            }
            return retorno;
        }
        public static int BuscaCodigo(string workspacename)
        {
            int retorno = 0;
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT cod_workspace FROM workspace WHERE workspacename = @workspacename OR email = @workspacename", conexao))
                {
                    cmd.Parameters.AddWithValue("@workspacename", workspacename);
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        retorno = (leitor.Read()) ? leitor.GetInt32(0) : 0;
                    }
                }
            }
            return retorno;
        }
        public static bool InserirWorkspace(Workspace workspace)
        {
            bool retorno = false;
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO workspace (workspacename, nome, email, senha, salt) VALUES (@workspacename, @nome, @email, @senha, @salt)", conexao))
                {
                    cmd.Parameters.AddWithValue("@workspacename", workspace.Workspacename);
                    cmd.Parameters.AddWithValue("@nome", workspace.Nome);
                    cmd.Parameters.AddWithValue("@email", workspace.Email);
                    cmd.Parameters.AddWithValue("@senha", workspace.Senha);
                    cmd.Parameters.AddWithValue("@salt", workspace.Salt);
                    retorno = (cmd.ExecuteNonQuery() == 1);
                }
            }
            return retorno;
        }

    }
}