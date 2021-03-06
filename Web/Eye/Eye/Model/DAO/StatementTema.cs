﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EYE.Model.DAO
{
    public class StatementTema
    {
        private const int MINIMO_DE_ALTERACAO = 1;
        public static int BuscaModo(int codWorkspace)
        {
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT modo FROM workspace WHERE cod_workspace = @cod_workspace", conexao))
                {
                    cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        return (leitor.Read()) ? leitor.GetInt32(0) : 0;
                    }
                }
            }
        }

        public static int BuscaTema(int codWorkspace)
        {
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT tema FROM workspace WHERE cod_workspace = @cod_workspace", conexao))
                {
                    cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        return (leitor.Read()) ? leitor.GetInt32(0) : 0;
                    }
                }
            }
        }

        public static bool TrocarTema(int codWorkspace, int novoTema)
        {
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE workspace set tema = @novo_tema where cod_workspace = @cod_workspace", conexao))
                {
                    cmd.Parameters.AddWithValue("@novo_tema", novoTema);
                    cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
                    return (cmd.ExecuteNonQuery() >= MINIMO_DE_ALTERACAO);
                }
            }
        }

        public static bool TrocarModo(int codWorkspace, int novoModo)
        {
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE workspace set modo = @novo_modo where cod_workspace = @cod_workspace", conexao))
                {
                    cmd.Parameters.AddWithValue("@novo_modo", novoModo);
                    cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
                    return (cmd.ExecuteNonQuery() >= MINIMO_DE_ALTERACAO);
                }
            }
        }


        public static int BuscaIntensidade(int codWorkspace)
        {
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT intensidade FROM workspace WHERE cod_workspace = @cod_workspace", conexao))
                {
                    cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        return (leitor.Read()) ? leitor.GetInt32(0) : 0;
                    }
                }
            }
        }

        public static bool TrocarIntensidade(int codWorkspace, int novaIntensidade)
        {
            using (var conexao = Conexao.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE workspace set intensidade = @nova_intensidade where cod_workspace = @cod_workspace", conexao))
                {
                    cmd.Parameters.AddWithValue("@nova_intensidade", novaIntensidade);
                    cmd.Parameters.AddWithValue("@cod_workspace", codWorkspace);
                    return (cmd.ExecuteNonQuery() >= MINIMO_DE_ALTERACAO);
                }
            }
        }
    }
}