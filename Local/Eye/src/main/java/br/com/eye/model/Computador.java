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

    public Computador() {
    }

    public Computador(Integer codComputador, String nome, String sistemaOperacional, String versaoSistema, Integer versaoBits, String processador, Double totalCpu, Double totalDisco, long totalMemoria, Integer codUsuario) {
        this.codComputador = codComputador;
        this.nome = nome;
        this.sistemaOperacional = sistemaOperacional;
        this.versaoSistema = versaoSistema;
        this.versaoBits = versaoBits;
        this.processador = processador;
        this.totalCpu = totalCpu;
        this.totalDisco = totalDisco;
        this.totalMemoria = totalMemoria;
        this.codUsuario = codUsuario;
    }

    public Computador(int aInt, String string, String string0, String string1, int aInt0, String string2, long aLong, double aDouble, double aDouble0, double aDouble1, int codUsuario) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    public Integer getCodComputador(int codigoUsuario) throws SQLException {
        return statementComputador.getCodComputador(codigoUsuario);
    }

    public String getNome(Computador computador) throws SQLException {
        return statementComputador.getNome(computador.codComputador);
    }

    public String getSistemaOperacional() {
        return controllerComputador.getSistemaOperacional();
    }

    public String getVersaoSistema() {
        return controllerComputador.getVersaoSistema();
    }

    public int getVersaoBits() {
        return controllerComputador.getBit();
    }

    public String getProcessador() {
        return controllerComputador.getProcessador();
    }

    public Double getTotalCpu() {
        return controllerComputador.getCPU();
    }

    public Double getTotalDisco() {
        return totalDisco;
    }

    public long getTotalMemoria() {
        return controllerComputador.getMemoria();
    }

    public int getCodUsuario() {
        return codUsuario;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public void setCodComputador(Integer codComputador) {
        this.codComputador = codComputador;
    }

    public void setSistemaOperacional(String sistemaOperacional) {
        this.sistemaOperacional = sistemaOperacional;
    }

    public void setVersaoSistema(String versaoSistema) {
        this.versaoSistema = versaoSistema;
    }

    public void setVersaoBits(Integer versaoBits) {
        this.versaoBits = versaoBits;
    }

    public void setProcessador(String processador) {
        this.processador = processador;
    }

    public void setTotalCpu(Double totalCpu) {
        this.totalCpu = totalCpu;
    }

    public void setTotalDisco(Double totalDisco) {
        this.totalDisco = totalDisco;
    }

    public void setTotalMemoria(long totalMemoria) {
        this.totalMemoria = totalMemoria;
    }

    public void setCodUsuario(Integer codUsuario) {
        this.codUsuario = codUsuario;
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
