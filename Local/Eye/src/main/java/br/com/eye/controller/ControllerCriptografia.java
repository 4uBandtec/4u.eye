package br.com.eye.controller;


import br.com.eye.model.Criptografia;
import java.security.NoSuchAlgorithmException;

public class ControllerCriptografia {

    public String gerarSenhaHash(String senha, int salt) throws NoSuchAlgorithmException {
        
        return Criptografia.gerarSenhaHash(senha, salt);
    }
}
