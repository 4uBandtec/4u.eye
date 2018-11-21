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
}
