package br.com.eye.model;

import br.com.eye.controller.ControllerComputador;
import br.com.eye.dao.StatementComputador;

import java.sql.SQLException;
import java.util.Objects;

public class Computador {

    private Integer codComputador;
    private String nome;
    private String sistemaOperacional;
    private String versaoSistema;
    private Integer versaoBits;
    private String processador;
    private Long totalMemoria;
    private Long totalDisco;
    private Integer codUsuario;

    ControllerComputador controllerComputador = new ControllerComputador();
    StatementComputador statementComputador = new StatementComputador();

    public boolean equals(Computador computador) {

        return (this.sistemaOperacional.equalsIgnoreCase(computador.getSistemaOperacional())
                || this.getVersaoSistema().equalsIgnoreCase(computador.getVersaoSistema())
                || Objects.equals(this.getVersaoBits(), computador.getVersaoBits())
                || this.getProcessador().equalsIgnoreCase(computador.getProcessador())
                || Objects.equals(this.getTotalDisco(), computador.getTotalDisco())
                || this.getTotalMemoria() == computador.getTotalMemoria());

    }

    public Computador() {
    }

    public Computador(String sistemaOperacional, String versaoSistema, Integer versaoBits, String processador, Long totalMemoria, Long totalDisco) {
        this.sistemaOperacional = sistemaOperacional;
        this.versaoSistema = versaoSistema;
        this.versaoBits = versaoBits;
        this.processador = processador;
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

    public long getTotalDiscoAtual() {
        return controllerComputador.getDisco();
    }

    public Long getTotalDisco() {
        return totalDisco;
    }

    public void setTotalDisco(Long totalDisco) {
        this.totalDisco = totalDisco;
    }

    public Long getTotalMemoriaAtual() {
        return controllerComputador.getMemoria();
    }

    public Long getTotalMemoria() {
        return controllerComputador.getMemoria();
    }

    public void setTotalMemoria(Long totalMemoria) {
        this.totalMemoria = totalMemoria;
    }

    public Computador getComputadorSalvo() throws SQLException {
        return statementComputador.getComputadorSalvo(1);
    }

    public Computador getComputadorAtual() throws SQLException {
        return controllerComputador.getComputadorAtual();
    }

    public boolean inserePrimeiroComputador(int codUsuario) throws SQLException {
        return statementComputador.existeComputadorRegistrado(codUsuario)
                ? true : statementComputador.setComputador(controllerComputador.getComputadorAtual(), codUsuario);
    }

    public boolean verificaAtualizacao(int codUsuario) throws SQLException {

        return (statementComputador.getComputadorSalvo(codUsuario)).equals(controllerComputador.getComputadorAtual());
        //Precisa de Banco para testar
    }
}
