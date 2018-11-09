﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Eye.Model;

namespace Eye.DAO
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

        public static Monitor[] ListarComputadores(int codUsuario)
        {
            Monitor[] monitores = new Monitor[ContaComputador(codUsuario)];
            var contador = 0;
            var conexao = Conexao.GetConexao();
            conexao.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT nome, sistema_operacional, versao_sistema, versao_bits, processador, total_disco, total_memoria FROM computador WHERE cod_usuario = @cod_usuario", conexao))
            {
                cmd.Parameters.AddWithValue("@cod_usuario", codUsuario);
                using (SqlDataReader leitor = cmd.ExecuteReader())
                {
                    do
                    {
                        while (leitor.Read())
                        {

                            monitores[contador] = new Monitor();
                            monitores[contador].NomeComputador = leitor.GetString(0);
                            monitores[contador].SistemaOperacional = leitor.GetString(1);
                            monitores[contador].VersaoSistema = leitor.GetString(2);
                            monitores[contador].VersaoBits = leitor.GetInt32(3);
                            monitores[contador].Processador = leitor.GetString(4);
                            monitores[contador].DiscoTotal = leitor.GetDecimal(5);
                            monitores[contador].RAMTotal = leitor.GetDecimal(6);
                            monitores[contador].CodUsuario = codUsuario;
                            
                            ++contador;
                        }
                    }
                    while (leitor.NextResult());
                }
            }
            return monitores;
        }

    }
}
