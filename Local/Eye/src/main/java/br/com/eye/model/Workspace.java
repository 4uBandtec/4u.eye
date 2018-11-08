package br.com.eye.model;

import br.com.eye.controller.ControllerWorkspace;
import java.sql.SQLException;

public class Workspace {

    private int codWorkspace;

    public int getCodWorkspace() {
        return codWorkspace;
    }

    public void setCodWorkspace(int codWorkspace) {
        this.codWorkspace = codWorkspace;
    }

    public boolean ValidarWorkspace(String workspacename) throws SQLException {
        return new ControllerWorkspace().workspaceValido(workspacename);
    }

}
