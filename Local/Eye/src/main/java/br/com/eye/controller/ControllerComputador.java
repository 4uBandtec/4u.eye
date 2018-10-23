package br.com.eye.controller;

import br.com.eye.dao.StatementComputador;
import br.com.eye.model.Computador;
import java.sql.SQLException;
import oshi.SystemInfo;

public class ControllerComputador {

    SystemInfo systemInfo = new SystemInfo();

    public Computador getComputadorAtual(int codUsuario) throws SQLException {
        StatementComputador statementComputador = new StatementComputador();
        return new Computador(
                statementComputador.getCodComputador(codUsuario),
                "temporario",
                getSistemaOperacional(),
                getVersaoSistema(),
                getBit(),
                getProcessador(),
                getCPU(),
                1.0,//Alterar para getDisco()
                getMemoria(),
                codUsuario
        );

    }

    public String getSistemaOperacional() {
        return systemInfo.getOperatingSystem().toString();
    }

    public String getVersaoSistema() {
        return systemInfo.getOperatingSystem().getVersion().toString();
        //getSistemaOperacional().getVersion();
        //String[] sistema = getSistemaOperacional().split("[0-9]");
        //return sistema[0];
    }

    public int getBit() {
        return systemInfo.getOperatingSystem().getBitness();
    }

    public String getProcessador() {
        return (systemInfo.getHardware().getProcessor()).toString();
    }

    public Double getCPU() {
        return systemInfo.getHardware().getProcessor().getSystemCpuLoad();
    }

    public void getDisco() {
        //
        //
    }

    public long getMemoria() {
        return systemInfo.getHardware().getMemory().getTotal();
    }

    public boolean verificaAtualizacao(Computador atual, Computador salvo) {
        return atual == salvo;//Falta completar
    }

}
