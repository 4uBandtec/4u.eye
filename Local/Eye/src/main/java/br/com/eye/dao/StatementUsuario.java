package br.com.eye.dao;

import br.com.eye.model.LeituraComputador;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class StatementUsuario {
    public int buscarSalt(String username) throws SQLException {
        String sql = "SELECT salt FROM workspace WHERE username = ?";
        PreparedStatement query = Conexao.getConnection().prepareStatement(sql);
        query.setString(1, workspacename);
        ResultSet resultado = username.executeQuery();
        return resultado.next() ? resultado.getInt("salt") : null;
    }

    public String buscarSenhaHash(String username) throws SQLException {
        String sql = "SELECT senha FROM workspace WHERE username = ?";
        PreparedStatement query = Conexao.getConnection().prepareStatement(sql);
        query.setString(1, username);
        ResultSet resultado = query.executeQuery();
        return resultado.next() ? resultado.getString("senha") : "";
    }

    public int getCodUsurio(String username) throws SQLException {
        String sql = "SELECT cod_usuario FROM workspace WHERE username = ?";
        PreparedStatement query = Conexao.getConnection().prepareStatement(sql);
        query.setString(1, username);
        ResultSet resultado = query.executeQuery();
        return resultado.next() ? resultado.getInt("cod_usuario") : 0;
    }
}