package br.com.eye.model;

import br.com.eye.controller.ControllerComputador;
import oshi.software.os.OperatingSystem;

public class Computador {

    private int codComputador;
    private String nome;
    OperatingSystem sistemaOperacional;
    private String versaoSistema;
    private int versaoBits;
    private String processador;
    private Double totalCpu;
    private Double totalDisco;
    private Double totalMemoria;
    private int codUsuario;

    public Double getTotalCpu() {
        return totalCpu;
    }

    public void setTotalCpu(Double totalCpu) {
        this.totalCpu = totalCpu;
    }

    public Double getTotalDisco() {
        return totalDisco;
    }

    public void setTotalDisco(Double totalDisco) {
        this.totalDisco = totalDisco;
    }

    public Double getTotalMemoria() {
        return totalMemoria;
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
        return new ControllerComputador().getSistemaOperacional();
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
        return versaoBits;
    }

    public void setVersaoBits(int versaoBits) {
        this.versaoBits = versaoBits;
    }

    public String getProcessador() {
        return processador;
    }

    public void setProcessador(String processador) {
        this.processador = processador;
    }

}
