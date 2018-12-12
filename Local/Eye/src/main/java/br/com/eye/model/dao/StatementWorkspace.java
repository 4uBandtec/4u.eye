package br.com.eye.model.dao;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class StatementWorkspace {

    public boolean workspaceValido(String workspacename) throws SQLException {
        String sql = "SELECT * FROM workspace WHERE workspacename = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setString(1, workspacename);
        ResultSet resultado = query.executeQuery();
        return (resultado.next());
    }

    public static int getCodWorkspace(int codUsuario) throws SQLException {
        String sql = "SELECT cod_workspace FROM usuario WHERE cod_usuario = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        ResultSet resultado = query.executeQuery();
        return resultado.next() ? resultado.getInt("cod_workspace") : 0;
    }
}
