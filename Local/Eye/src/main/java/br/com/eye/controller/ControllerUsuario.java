package br.com.eye.controller;

public class ControllerUsuario {

    public static boolean autenticarUsuario(String login, String senha) {
        int salt = new StatementUsuario().buscarSalt(login);
        String senhaBanco = new StatementUsuario().buscarSenhaHash(login);
        if (salt == 0 || senhaBanco == null)
        {
            return false;
        }
        
        return ValidaSenha(senhaBanco, senha, salt);

    }



    public static bool validaSenha(String senhaBanco, String senha, String salt)
    {
        public static bool ValidaSenha(string senhaBanco, string senha, int salt)
        {
            return senhaBanco.Equals(ControllerCriptografia.gerarSenhaHash(senha, salt));
        }
    }
}
