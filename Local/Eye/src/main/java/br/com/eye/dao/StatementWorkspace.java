package br.com.eye.dao;

import br.com.eye.model.LeituraComputador;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class StatementWorkspace {
    public boolean workspaceValido(string workspacename) throws SQLException {
        String sql = "SELECT * FROM workspace WHERE workspacename = ?";
        PreparedStatement query = Conexao.getConnection().prepareStatement(sql);
        query.setString(1, workspacename);
        ResultSet resultado = query.executeQuery();

        return (resultado.next());
    }
}