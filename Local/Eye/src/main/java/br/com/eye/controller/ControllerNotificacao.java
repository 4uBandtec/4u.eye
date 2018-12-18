package br.com.eye.controller;

import br.com.eye.model.LogMensagem;
import br.com.eye.model.Notificacao;
import br.com.eye.model.SlackMensagem;
import br.com.eye.model.dao.StatementNotificacao;
import br.com.eye.model.dao.StatementSlack;
import java.awt.AWTException;
import java.awt.TrayIcon;
import java.io.IOException;
import java.sql.SQLException;

public class ControllerNotificacao {

    public static void EnviaSlack(int codWorkspace) throws SQLException, IOException {
        SlackMensagem slack = StatementSlack.getSlack(codWorkspace);
        if (slack.getUrl().length() > 0) {
            String mensagem = StatementNotificacao.getMensagemParaEnviarSlack(codWorkspace);
            if (mensagem != null) {
                SlackMensagem.EnviaMensagem(slack, mensagem);
            }
        }
    }

    public static void EnviaLocal(int codUsuario) throws SQLException, IOException, AWTException {
        String mensagem = StatementNotificacao.getMensagemParaEnviarLocal(codUsuario);
        if (mensagem != null) {
            new Notificacao().construirNotificacaoLocal(mensagem, TrayIcon.MessageType.NONE);
        }

    }

}
