﻿
using EYE.Controller;
using System.Data.SqlClient;

namespace EYE.Model.DAO
{
    public class StatementWorkspace
    {
        public static bool VerificaWorkspacenameUnico(string workspacename)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT workspacename FROM workspace WHERE workspacename = @workspacename", conexao))
            {
                cmd.Parameters.AddWithValue("@workspacename", workspacename);
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
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM workspace WHERE email = @email", conexao))
            {
                cmd.Parameters.AddWithValue("@email", email);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    return !(leitor.Read());
                }
            }
        }
        public static int BuscaSalt(string workspacename)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT salt FROM workspace WHERE workspacename = @workspacename  OR email = @workspacename", conexao))
            {
                cmd.Parameters.AddWithValue("@workspacename", workspacename);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return leitor.GetInt32(0);
                    }
                }
            }
            return 0;
        }
        public static string BuscaSenhaHash(string workspacename)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT senha FROM workspace WHERE workspacename = @workspacename OR email = @workspacename", conexao))
            {
                cmd.Parameters.AddWithValue("@workspacename", workspacename);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        return leitor.GetString(0);
                    }
                }
            }
            return null;
        }
        public static int BuscaCodigo(string workspacename)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT cod_workspace FROM workspace WHERE workspacename = @workspacename OR email = @workspacename", conexao))
            {
                cmd.Parameters.AddWithValue("@workspacename", workspacename);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    return (leitor.Read()) ? leitor.GetInt32(0) : 0;
                }
            }
        }
        public static bool InserirWorkspace(Workspace workspace)
        {
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO workspace (workspacename, nome, email, senha, salt) VALUES (@workspacename, @nome, @email, @senha, @salt)", conexao))
            {
                cmd.Parameters.AddWithValue("@workspacename", workspace.Workspacename);
                cmd.Parameters.AddWithValue("@nome", workspace.Nome);
                cmd.Parameters.AddWithValue("@email", workspace.Email);
                cmd.Parameters.AddWithValue("@senha", workspace.Senha);
                cmd.Parameters.AddWithValue("@salt", workspace.Salt);
                return (cmd.ExecuteNonQuery() == 1);
            }
        }

    }
}