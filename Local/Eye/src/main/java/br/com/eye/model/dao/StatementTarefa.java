/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.com.eye.model.dao;

import java.sql.PreparedStatement;
import java.sql.SQLException;

/**
 *
 * @author henri
 */
public class StatementTarefa {
    
    public static boolean ativaTarefa(int codTarefa, int codProcesso, int codUsuario) throws SQLException{
        String sql = "UPDATE processo_tarefa set ativa = 1 WHERE cod_tarefa = ? AND cod_processo = ? AND cod_usuario = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codTarefa);
        query.setInt(2, codProcesso);
        query.setInt(3, codUsuario);
        return query.execute();
    }
    
    public static boolean desativaTarefas(int codUsuario) throws SQLException{
        String sql = "UPDATE processo_tarefa set ativa = 0 WHERE cod_usuario = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        return query.execute();
    }
}
