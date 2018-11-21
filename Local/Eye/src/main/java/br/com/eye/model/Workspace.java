package br.com.eye.model;


public class Workspace {

    private int codWorkspace;

    public int getCodWorkspace() {
        return codWorkspace;
    }

    public void setCodWorkspace(int codWorkspace) {
        this.codWorkspace = codWorkspace;
    }

<<<<<<< HEAD
=======
    public boolean ValidarWorkspace(String workspacename) throws SQLException {
        return new ControllerWorkspace().WorkspaceValido(workspacename);
    }
>>>>>>> 4287f4d4939e422c23471e5bd48b4e22fd8b88fe

}
