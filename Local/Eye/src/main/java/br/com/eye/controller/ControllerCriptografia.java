package br.com.eye.controller;

public class ControllerCriptografia {

    public String gerarSenhaHash(String senha, int salt) {
		md = MessageDigest.getInstance("MD5");
		BigInteger hash = new BigInteger(1, md.digest((senha+salt).getBytes()));
		return hash.toString(16);			
    }
}
