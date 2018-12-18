package br.com.eye.controller;

import br.com.eye.model.Tarefa;
import br.com.eye.model.dao.StatementProcesso;
import br.com.eye.model.dao.StatementTarefa;
import java.sql.SQLException;
import java.util.List;
import javax.swing.JComboBox;

public class ControllerTarefa {

    public static boolean startTarefa(List<Tarefa> listaTarefa, int index, int codUsuario) throws SQLException {
        int codProcessoTarefa = listaTarefa.get(index).getProcessos().getCodProcessoTarefa();
        StatementTarefa.desativaTarefas(codUsuario);
        return StatementTarefa.ativaTarefa(codProcessoTarefa);
    }

    public static List<Tarefa> getTarefa(int codUsuario, JComboBox cmbTarefas) throws SQLException {
        List<Tarefa> listaTarefa = StatementTarefa.retornaProcessoTarefas(codUsuario);
        listaTarefa = StatementTarefa.adicionaInformacoesTarefa(listaTarefa);
        listaTarefa = StatementProcesso.adicionaNomeProcesso(listaTarefa);
        for (Tarefa tarefa : listaTarefa) {
            cmbTarefas.addItem(tarefa.getNome() + " " + tarefa.getProcessos().getNomeProcesso());
        }
        return listaTarefa;
    }
    public static boolean desativaTarefa( int codUsuario) throws SQLException {
        return  StatementTarefa.desativaTarefas(codUsuario);
    }
}
