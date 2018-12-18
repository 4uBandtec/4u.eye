package br.com.eye.model.dao;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class StatementTarefa {

    public static boolean ativaTarefa(int codTarefa, int codProcesso, int codUsuario) throws SQLException {
        String sql = "UPDATE processo_tarefa set ativa = 1 WHERE cod_tarefa = ? AND cod_processo = ? AND cod_usuario = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codTarefa);
        query.setInt(2, codProcesso);
        query.setInt(3, codUsuario);
        return query.execute();
    }

    public static boolean desativaTarefas(int codUsuario) throws SQLException {
        String sql = "UPDATE processo_tarefa set ativa = 0 WHERE cod_usuario = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        return query.execute();
    }

    public static String retonaProcessoTarefaAtiva(int codUsuario) throws SQLException {
        String sql = "SELECT nome_processo, nome_aplicacao FROM processo WHERE cod_processo IN (SELECT cod_processo FROM processo_tarefa WHERE cod_usuario = ? AND ativa = 1) ";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        ResultSet resultado = query.executeQuery();
        return resultado.next() ? resultado.getString("nome_processo") : null;
    }

    public static boolean AdicionaMinuto(int codUsuario) throws SQLException {       
        String sql = "UPDATE processo_tarefa set minutos_feitos = ((SELECT minutos_feitos where cod_usuario = ? AND ativa = 1) + 1)WHERE cod_usuario = ? AND ativa = 1";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        query.setInt(2, codUsuario);
        return query.execute();
    }
}
