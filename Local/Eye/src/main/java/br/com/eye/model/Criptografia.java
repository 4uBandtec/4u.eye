package br.com.eye.model;

import java.math.BigInteger;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

public class Criptografia {

    public static String gerarSenhaHash(String senha, int salt) throws NoSuchAlgorithmException {
        String senhaComposta = senha + salt;
        MessageDigest md = MessageDigest.getInstance("MD5");
        md.update(senhaComposta.getBytes());
        byte[] senhaByte = md.digest();
        StringBuilder s = new StringBuilder();
        for (int i = 0; i < senhaByte.length; i++) {
            int parteAlta = ((senhaByte[i] >> 4) & 0xf) << 4;
            int parteBaixa = senhaByte[i] & 0xf;
            if (parteAlta == 0) {
                s.append('0');
            }
            s.append(Integer.toHexString(parteAlta | parteBaixa));
        }
        return s.toString();

    }
}
