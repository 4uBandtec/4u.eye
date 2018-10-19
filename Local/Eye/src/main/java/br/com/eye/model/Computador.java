package br.com.eye.model;

import br.com.eye.controller.ControllerComputador;
import oshi.hardware.CentralProcessor;
import oshi.software.os.OperatingSystem;

public class Computador {

    private int codComputador;
    private String nome;
    OperatingSystem sistemaOperacional;
    private String versaoSistema;
    private int versaoBits;
    CentralProcessor processador;
    private long totalCpu;
    private Double totalDisco;
    private Double totalMemoria;
    private int codUsuario;

    ControllerComputador controllerComputador = new ControllerComputador();

    public int getCodComputador() {
        return codComputador;
    }

    public void setCodComputador(int codComputador) {
        this.codComputador = codComputador;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public OperatingSystem getSistemaOperacional() {
        return controllerComputador.getSistemaOperacional();
    }

    public void setSistemaOperacional(String sistemaOperacional) {
        //this.sistemaOperacional = sistemaOperacional;
    }

    public String getVersaoSistema() {
        return versaoSistema;
    }

    public void setVersaoSistema(String versaoSistema) {
        this.versaoSistema = versaoSistema;
    }

    public int getVersaoBits() {
        return controllerComputador.getBit();
    }

    public void setVersaoBits(int versaoBits) {
        this.versaoBits = versaoBits;
    }

    public CentralProcessor getProcessador() {
        return controllerComputador.getProcessador();
    }

    public void setProcessador(String processador) {
        //this.processador = processador;
    }

    public double getTotalCpu() {
        return controllerComputador.getCPU();
    }

    public void setTotalCpu(Double totalCpu) {

    }

    public Double getTotalDisco() {
        return totalDisco;
    }

    public void setTotalDisco(Double totalDisco) {
        this.totalDisco = totalDisco;
    }

    public long getTotalMemoria() {
        return controllerComputador.getMemoria();
    }

    public void setTotalMemoria(Double totalMemoria) {
        this.totalMemoria = totalMemoria;
    }

    public int getCodUsuario() {
        return codUsuario;
    }

    public void setCodUsuario(int codUsuario) {
        this.codUsuario = codUsuario;
    }
}
