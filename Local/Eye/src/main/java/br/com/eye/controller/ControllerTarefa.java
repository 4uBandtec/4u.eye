package br.com.eye.controller;

import br.com.eye.model.dao.StatementTarefa;
import java.sql.SQLException;

public class ControllerTarefa {
    public static boolean startTarefa(int codTarefa, int codProcesso, int codUsuario) throws SQLException{
        return  StatementTarefa.desativaTarefas(codUsuario) && StatementTarefa.ativaTarefa(codTarefa, codProcesso, codUsuario);
    }
}
