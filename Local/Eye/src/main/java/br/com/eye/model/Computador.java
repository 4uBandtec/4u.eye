package br.com.eye.model;

import br.com.eye.controller.ControllerComputador;
import br.com.eye.dao.StatementComputador;

import java.sql.SQLException;

public class Computador {

    private Integer codComputador;
    private String nome;
    private String sistemaOperacional;
    private String versaoSistema;
    private Integer versaoBits;
    private String processador;
    private Double totalCpu;
    private Double totalDisco;
    private long totalMemoria;
    private Integer codUsuario;

    ControllerComputador controllerComputador = new ControllerComputador();
    StatementComputador statementComputador = new StatementComputador();

    public boolean equals(Computador computador) {

        return (this.sistemaOperacional.equalsIgnoreCase(computador.getSistemaOperacionalAtual())
                || this.versaoSistema.equalsIgnoreCase(computador.getVersaoSistemaAtual())
                || this.versaoBits == computador.getVersaoBitsAtual()
                || this.processador.equalsIgnoreCase(getProcessadorAtual())
                || this.versaoBits == computador.getVersaoBitsAtual()
                || this.totalCpu == computador.getTotalCpuAtual()
                || this.totalDisco == computador.getTotalDiscoAtual()
                || this.totalMemoria == computador.getTotalMemoriaAtual());

    }

    public Computador() {
    }

    public Computador(String sistemaOperacional, String versaoSistema, Integer versaoBits, String processador, Double totalCpu, Double totalDisco, long totalMemoria) {
        this.sistemaOperacional = sistemaOperacional;
        this.versaoSistema = versaoSistema;
        this.versaoBits = versaoBits;
        this.processador = processador;
        this.totalCpu = totalCpu;
        this.totalDisco = totalDisco;
        this.totalMemoria = totalMemoria;
    }

    public int getCodUsuario() {
        return codUsuario;
    }

    public void setCodUsuario(Integer codUsuario) {
        this.codUsuario = codUsuario;
    }

    public Integer getCodComputador(int codigoUsuario) throws SQLException {
        return statementComputador.getCodComputador(codigoUsuario);
    }

    public Integer getCodComputador() {
        return codComputador;
    }

    public void setCodComputador(Integer codComputador) {
        this.codComputador = codComputador;
    }

    public String getNomeAtual(Computador computador) throws SQLException {
        return statementComputador.getNome(computador.codComputador);
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getSistemaOperacionalAtual() {
        return (controllerComputador.getSistemaOperacional().split("[0-9]")[0]);
    }

    public String getSistemaOperacional() {
        return sistemaOperacional;
    }

    public void setSistemaOperacional(String sistemaOperacional) {
        this.sistemaOperacional = sistemaOperacional;
    }

    public String getVersaoSistemaAtual() {
        return controllerComputador.getVersaoSistema();
    }

    public String getVersaoSistema() {
        return versaoSistema;
    }

    public void setVersaoSistema(String versaoSistema) {
        this.versaoSistema = versaoSistema;
    }

    public int getVersaoBitsAtual() {
        return controllerComputador.getBit();
    }

    public Integer getVersaoBits() {
        return versaoBits;
    }

    public void setVersaoBits(Integer versaoBits) {
        this.versaoBits = versaoBits;
    }

    public String getProcessadorAtual() {
        return controllerComputador.getProcessador();
    }

    public String getProcessador() {
        return processador;
    }

    public void setProcessador(String processador) {
        this.processador = processador;
    }

    public Double getTotalCpuAtual() {
        return controllerComputador.getCPU();
    }

    public Double getTotalCpu() {
        return totalCpu;
    }

    public void setTotalCpu(Double totalCpu) {
        this.totalCpu = totalCpu;
    }

    public Double getTotalDiscoAtual() {
        return totalDisco;
    }

    public Double getTotalDisco() {
        return totalDisco;
    }

    public void setTotalDisco(Double totalDisco) {
        this.totalDisco = totalDisco;
    }

    public long getTotalMemoriaAtual() {
        return controllerComputador.getMemoria();
    }

    public long getTotalMemoria() {
        return totalMemoria;
    }

    public void setTotalMemoria(long totalMemoria) {
        this.totalMemoria = totalMemoria;
    }

    public Computador getComputadorSalvo() throws SQLException {
        return statementComputador.getComputadorSalvo(1);
    }

    public Computador getComputadorAtual() throws SQLException {
        return controllerComputador.getComputadorAtual(1);
    }

    public boolean verificaAtualizacao(Computador atual, Computador salvo) {
        return true;//Arumar metodo verificaAtualizacao();
    }
}
