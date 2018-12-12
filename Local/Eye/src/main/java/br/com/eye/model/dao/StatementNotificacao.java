package br.com.eye.model.dao;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.time.format.FormatStyle;

public class StatementNotificacao {

    public static String getMensagemParaEnviarSlack(int codWorkspace) throws SQLException {
        int codNotificacao = 0;
        String mensagem = null;
        String sql = "SELECT cod_notificacao, mensagem FROM fila_notificacao WHERE cod_remetente = ? AND canal_envio = 1 AND remetente = 1 AND enviado = 0";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codWorkspace);
        ResultSet resultado = query.executeQuery();
        if (resultado.next()) {
            codNotificacao = resultado.getInt("cod_notificacao");
            mensagem = resultado.getString("mensagem");
        }
        String update = "UPDATE fila_notificacao SET enviado = 1 WHERE cod_notificacao = ?";      
        PreparedStatement queryUpdate = new Conexao().getConexao().prepareStatement(update);
        queryUpdate.setInt(1, codNotificacao);
        queryUpdate.execute();
        return mensagem;
    }
}
