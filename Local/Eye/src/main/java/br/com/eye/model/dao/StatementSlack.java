package br.com.eye.model.dao;

import br.com.eye.model.SlackMensagem;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class StatementSlack {

    public static SlackMensagem getSlack(int codWorkspace) throws SQLException {
        SlackMensagem slack = new SlackMensagem();
        String sql = "SELECT url, canal FROM slack WHERE cod_workspace = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codWorkspace);
        ResultSet resultado = query.executeQuery();
        if (resultado.next()) {
        slack.setUrl(resultado.getString("url"));
            slack.setCanal(resultado.getString("canal"));
               
        }
        return slack;
    }
}
