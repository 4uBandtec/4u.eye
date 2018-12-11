/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.com.eye.controller;

import br.com.eye.model.LeituraAplicativo;
import br.com.eye.model.LeituraComputador;
import br.com.eye.model.LogMensagem;
import br.com.eye.model.dao.StatementLeituraComputador;
import java.io.IOException;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author aluno
 */
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
        List<LeituraAplicativo> leituras = new ArrayList();
        while (true) {
            contador++;
            try {
                if (new StatementLeituraComputador().existeLeituraRegistrada(codComputador)) {
                    new StatementLeituraComputador().updateLeitura(new LeituraComputador().leituraOshi(), codComputador);
                } else {
                    new StatementLeituraComputador().setPrimeiraLeitura(new LeituraComputador().leituraOshi(), codComputador);
                }
            } catch (SQLException ex) {
                Logger.getLogger(Threads.class.getName()).log(Level.SEVERE, null, ex);
            }
            try {
                LogMensagem.GravarLog("Leitura Armazenada");
            } catch (IOException ex) {
                Logger.getLogger(Threads.class.getName()).log(Level.SEVERE, null, ex);
            }
            if (contador % 12 == 0) {
                try {
                    leituras = ControllerAplicativo.setLeituraAplicativo(codUsuario, leituras);
                } catch (SQLException ex) {
                    Logger.getLogger(Threads.class.getName()).log(Level.SEVERE, null, ex);
                }
                contador = contador == 120000 ? 0 : contador;
                try {
                    LogMensagem.GravarLog("Processos Armazenados");
                } catch (IOException ex) {
                    Logger.getLogger(Threads.class.getName()).log(Level.SEVERE, null, ex);
                }
            }

            try {
                sleep(5000);
            } catch (InterruptedException ex) {
                Logger.getLogger(Threads.class.getName()).log(Level.SEVERE, null, ex);
            }
        }

    }

}
