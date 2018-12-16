package br.com.eye.controller;

import br.com.eye.model.LogMensagem;
import br.com.eye.model.SlackMensagem;
import br.com.eye.model.dao.StatementNotificacao;
import br.com.eye.model.dao.StatementSlack;
import java.io.IOException;
import java.sql.SQLException;

public class ControllerNotificacao {

    public static void EnviaSlack(int codWorkspace) throws SQLException, IOException {
        String mensagem = StatementNotificacao.getMensagemParaEnviarSlack(codWorkspace);
        if (mensagem != null) {
            SlackMensagem slack = StatementSlack.getSlack(codWorkspace);
            if (slack.getUrl().length() > 0 && slack.getCanal().length() > 0) {
                SlackMensagem.EnviaMensagem(slack, mensagem);
            }
        }
        LogMensagem.GravarLog("Notificação enviada para o Slack");
    }

}
