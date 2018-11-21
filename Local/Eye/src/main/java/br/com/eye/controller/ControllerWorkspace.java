package br.com.eye.controller;

import br.com.eye.model.dao.StatementWorkspace;
import java.sql.SQLException;

public class ControllerWorkspace {

    public boolean ValidarWorkspace(String workspacename) throws SQLException {
       return new StatementWorkspace().workspaceValido(workspacename);
    }
}
