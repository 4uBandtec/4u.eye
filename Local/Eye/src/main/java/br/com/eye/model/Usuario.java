package br.com.eye.model;

import br.com.eye.controller.ControllerUsuario;

public class Usuario {
    
    private int CodUsuario;
    private String Login;
    private String Senha;
    private int Salt;
    private String CodWorkspace;

     public boolean Logar() {
         System.out.println("oooie");
         return ControllerUsuario.Logar();
    }
    
}
