
package br.com.eye.model;

import java.math.BigInteger;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

public class Criptografia {
    public static String gerarSenhaHash(String senha, int salt) throws NoSuchAlgorithmException {
        String senhaComposta = senha + salt;
        MessageDigest md5 = MessageDigest.getInstance("MD5");
        md5.update(senhaComposta.getBytes(), 0, senhaComposta.length());
        return new BigInteger(1, md5.digest()).toString(16);
    }
}
