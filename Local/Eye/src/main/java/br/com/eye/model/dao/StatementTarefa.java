package br.com.eye.model.dao;

import br.com.eye.model.ProcessoTarefa;
import br.com.eye.model.Tarefa;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class StatementTarefa {

    public static boolean ativaTarefa(int codProcessoTarefa) throws SQLException {
        String sql = "UPDATE processo_tarefa set ativa = 1 WHERE cod_proc_tarefa = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codProcessoTarefa);
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

    public static boolean adicionaMinuto(int codProcessoTarefa) throws SQLException {
        String sql = "UPDATE processo_tarefa set minutos_feitos = ((SELECT minutos_feitos FROM processo_tarefa where cod_usuario = ? AND ativa = 1) + 1)WHERE cod_usuario = ? AND ativa = 1";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codProcessoTarefa);
        query.setInt(2, codProcessoTarefa);
        return query.execute();
    }

    public static List<Tarefa> retornaProcessoTarefas(int codUsuario) throws SQLException {
        String sql = "SELECT cod_proc_tarefa, cod_tarefa, cod_processo, minutos_meta, minutos_feitos, ativa from processo_tarefa where cod_Usuario = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        ResultSet resultado = query.executeQuery();
        List<Tarefa> tarefas = new ArrayList<>();
        while (resultado.next()) {
            ProcessoTarefa processoTarefa = new ProcessoTarefa(
                    resultado.getInt("cod_proc_tarefa"),
                    resultado.getInt("cod_tarefa"),
                    resultado.getInt("cod_processo"),
                    resultado.getInt("minutos_meta"),
                    resultado.getInt("minutos_feitos"),
                    resultado.getBoolean("ativa")
            );
            Tarefa tarefa = new Tarefa();
            tarefa.setProcessos(processoTarefa);
            tarefas.add(tarefa);
        }
        return tarefas;
    }

    public static List<Tarefa> adicionaInformacoesTarefa(List<Tarefa> listaTarefa) throws SQLException {
        for (Tarefa tarefa : listaTarefa) {
            String sql = "SELECT nome, cod_workspace from tarefa where cod_tarefa = ?";
            PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
            query.setInt(1, tarefa.getProcessos().getCodTarefa());
            ResultSet resultado = query.executeQuery();
            List<Tarefa> tarefas = new ArrayList<>();
            while (resultado.next()) {
                tarefa.setNome(resultado.getString("nome"));
                tarefa.setCodWorkspace(resultado.getInt("cod_workspace"));
            }
        }
        return listaTarefa;
    }
}
