package br.com.eye.controller;

import br.com.eye.dao.StatementWorkspace;
import java.sql.SQLException;

public class ControllerWorkspace {

    public boolean WorkspaceValido(String workspacename) throws SQLException {
       return new StatementWorkspace().workspaceValido(workspacename);
    }
}
