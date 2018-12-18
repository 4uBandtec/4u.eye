package br.com.eye.model;

import com.github.seratch.jslack.Slack;
import com.github.seratch.jslack.api.webhook.Payload;
import com.github.seratch.jslack.api.webhook.WebhookResponse;
import java.io.IOException;

public class SlackMensagem {

    private String url;
    private int cod_workspace;

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public int getCod_workspace() {
        return cod_workspace;
    }

    public void setCod_workspace(int cod_workspace) {
        this.cod_workspace = cod_workspace;
    }

    public static void EnviaMensagem(SlackMensagem obj, String mensagem) throws IOException {
        Payload payload = Payload.builder()
                .text(mensagem)
                .build();
        Slack slack = Slack.getInstance();
        WebhookResponse response = slack.send(obj.getUrl(), payload);
        LogMensagem.GravarLog("Notificação enviada para o Slack");
    }
}
