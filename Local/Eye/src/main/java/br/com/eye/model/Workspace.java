package br.com.eye.model;

import br.com.eye.controller.ControllerWorkspace;

public class Workspace {
    private int codWorkspace;

    public boolean ValidarWorkspace() {
        System.out.println("Ta clicando no botão de PROXIMO");
        return ControllerWorkspace.workspaceValido();
   }
   public long getCodWorkspace() {
    return discoDisponivel;
    }

    public void setCodWorkspace(int codWorkspace) {
        this.codWorkspace = codWorkspace;
    }
}
