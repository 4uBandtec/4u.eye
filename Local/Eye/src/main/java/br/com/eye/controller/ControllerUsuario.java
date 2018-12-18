package br.com.eye.controller;

import br.com.eye.model.dao.StatementUsuario;
import java.security.NoSuchAlgorithmException;
import java.sql.SQLException;

public class ControllerUsuario {

    public boolean Logar(String login, String senha) throws SQLException, NoSuchAlgorithmException {
        int salt = new StatementUsuario().buscarSalt(login);
        String senhaBanco = new StatementUsuario().buscarSenhaHash(login);
        if (salt == 0 || senhaBanco == null) {
            return false;
        }
        return validaSenha(senhaBanco, senha, salt);
    }

    public static boolean validaSenha(String senhaBanco, String senha, int salt) throws NoSuchAlgorithmException {
        return  senhaBanco.equals(ControllerCriptografia.gerarSenhaHash(senha, salt));
    }

    public int getCodUsuario(String username) throws SQLException {
        return new StatementUsuario().getCodUsuario(username);
    }
}
