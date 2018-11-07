package br.com.eye.model;

import br.com.eye.controller.ControllerUsuario;

public class Usuario {
    
    private int codUsuario;
    private String login;
    private String senha;
    private int salt;
    private String codWorkspace;

    
     public boolean Logar(String login, String senha) {
        System.out.println("Ta clicando no botão de LOGIN");
         return ControllerUsuario.Logar(login, senha);
    }
    
}
