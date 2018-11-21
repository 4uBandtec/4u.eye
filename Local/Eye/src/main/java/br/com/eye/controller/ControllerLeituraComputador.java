package br.com.eye.controller;

import br.com.eye.model.dao.StatementLeituraComputador;
import java.sql.SQLException;


import br.com.eye.model.LeituraComputador;

public class ControllerLeituraComputador {

    LeituraComputador leituraComputador = new LeituraComputador();
    
    public double getCPUUsada() {
        return leituraComputador.getCpuUsadaOshi();
    }

    public double getMemoriaDisponivel() {
        return leituraComputador.getMemoriaDisponivelOshi();
    }

    public long getDiscoDisponivel() {
        return leituraComputador.getDiscoDisponivelOshi();
    }

    public int getCodComputador(int codUsuario) throws SQLException{
        return new StatementLeituraComputador().getCodComputador(codUsuario);
    }
    
    public void setLeitura(int codComputador) throws SQLException, InterruptedException {
        leituraComputador.setLeitura(codComputador);
    }
}
