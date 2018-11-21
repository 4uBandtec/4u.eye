package br.com.eye.model;


public class Usuario {

    private int codUsuario;
    private String login;
    private String senha;
    private int salt;
    private String codWorkspace;
    
    
    public int getCodUsuario() {
        return codUsuario;
    }

    public void setCodUsuario(int codUsuario) {
        this.codUsuario = codUsuario;
    }

    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    public String getSenha() {
        return senha;
    }

    public void setSenha(String senha) {
        this.senha = senha;
    }

    public int getSalt() {
        return salt;
    }

    public void setSalt(int salt) {
        this.salt = salt;
    }

    public String getCodWorkspace() {
        return codWorkspace;
    }

    public void setCodWorkspace(String codWorkspace) {
        this.codWorkspace = codWorkspace;
    }

}
