package br.com.eye.controller;

import br.com.eye.model.dao.StatementUsuario;
import java.sql.SQLException;

public class ControllerUsuario {

    public boolean Logar(String login, String senha) throws SQLException {
        int salt = new StatementUsuario().buscarSalt(login);
        String senhaBanco = new StatementUsuario().buscarSenhaHash(login);
        if (salt == 0 || senhaBanco == null) {
            return false;
        }

        return validaSenha(senhaBanco, senha, salt);
    }

    public boolean validaSenha(String senhaBanco, String senha, int salt) {
        return true;
        //return senhaBanco.Equals(ControllerCriptografia.gerarSenhaHash(senha, salt));
    }

    public int getCodUsuario(String username) throws SQLException {
        return new StatementUsuario().getCodUsuario(username);
    }
}
