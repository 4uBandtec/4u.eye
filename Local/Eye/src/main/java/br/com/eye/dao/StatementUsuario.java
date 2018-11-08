package br.com.eye.dao;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class StatementUsuario {

    public int buscarSalt(String username) throws SQLException {
        String sql = "SELECT salt FROM usuario WHERE username = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setString(1, username);
        ResultSet resultado = query.executeQuery();
        return resultado.next() ? resultado.getInt("salt") : null;
    }

    public String buscarSenhaHash(String username) throws SQLException {
        String sql = "SELECT senha FROM usuario WHERE username = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setString(1, username);
        ResultSet resultado = query.executeQuery();
        return resultado.next() ? resultado.getString("senha") : "";
    }

    public int getCodUsuario(String username) throws SQLException {
        String sql = "SELECT cod_usuario FROM usuario WHERE username = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setString(1, username);
        ResultSet resultado = query.executeQuery();
        return resultado.next() ? resultado.getInt("cod_usuario") : 0;
    }
}
