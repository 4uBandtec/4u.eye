package br.com.eye.model;

import br.com.eye.controller.ControllerUsuario;
import java.sql.SQLException;

public class Usuario {

    private int codUsuario;
    private String login;
    private String senha;
    private int salt;
    private String codWorkspace;

    public boolean Logar(String login, String senha) throws SQLException {
        return new ControllerUsuario().autenticarUsuario(login, senha);
    }

    public int getCodUsuario(String username) throws SQLException {
        return new ControllerUsuario().getCodUsuario(username);
    }
}
