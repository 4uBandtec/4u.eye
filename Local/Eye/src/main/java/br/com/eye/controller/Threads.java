package br.com.eye.controller;

import br.com.eye.model.LeituraProcesso;
import br.com.eye.model.LeituraComputador;
import br.com.eye.model.LogMensagem;
import br.com.eye.model.dao.StatementLeituraComputador;
import br.com.eye.model.dao.StatementWorkspace;
import java.awt.AWTException;
import java.io.IOException;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Threads extends Thread {

    private int codComputador;
    private int codUsuario;

    public Threads(int codComputador, int codUsuario) {
        this.codUsuario = codUsuario;
        this.codComputador = codComputador;
        start();
    }

    @Override
    public void run() {

        int contador = 0;
        List<LeituraProcesso> leituras = new ArrayList();
        while (true) {
            contador++;
            try {
                if (new StatementLeituraComputador().existeLeituraRegistrada(codComputador)) {
                    new StatementLeituraComputador().updateLeitura(new LeituraComputador().leituraOshi(), codComputador);
                } else {
                    new StatementLeituraComputador().setPrimeiraLeitura(new LeituraComputador().leituraOshi(), codComputador);
                }
                LogMensagem.GravarLog("Leitura Armazenada");

                if (contador % 12 == 0) {
                    leituras = ControllerAplicativo.setLeituraAplicativo(codUsuario, leituras);
                    contador = contador == 120000 ? 0 : contador;
                    LogMensagem.GravarLog("Processos Armazenados");
                }
                if (contador % 24 == 0) {
                    ControllerNotificacao.EnviaSlack(StatementWorkspace.getCodWorkspace(codUsuario));
                    ControllerNotificacao.EnviaLocal(codUsuario);
                }
                sleep(5000);
            } catch (SQLException | IOException | InterruptedException | AWTException ex) {
                Logger.getLogger(Threads.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }

}
