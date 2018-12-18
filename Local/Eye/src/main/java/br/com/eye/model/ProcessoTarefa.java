package br.com.eye.model;

public class ProcessoTarefa {

    private int codProcessoTarefa;
    private int codTarefa;
    private int codProcesso;
    private String nomeProcesso;
    private int minutosMeta;
    private int minutosFeito;
    private boolean ativa;

    public ProcessoTarefa(int codProcessoTarefa, int codTarefa, int codProcesso, int minutosMeta, int minutosFeito, boolean ativa) {
        this.codProcessoTarefa = codProcessoTarefa;
        this.codTarefa = codTarefa;
        this.codProcesso = codProcesso;
        this.minutosMeta = minutosMeta;
        this.minutosFeito = minutosFeito;
        this.ativa = ativa;
    }

    public boolean isAtiva() {
        return ativa;
    }

    public void setAtiva(boolean ativa) {
        this.ativa = ativa;
    }

    public int getCodProcessoTarefa() {
        return codProcessoTarefa;
    }

    public void setCodProcessoTarefa(int codProcessoTarefa) {
        this.codProcessoTarefa = codProcessoTarefa;
    }

    public int getCodTarefa() {
        return codTarefa;
    }

    public void setCodTarefa(int codTarefa) {
        this.codTarefa = codTarefa;
    }

    public int getCodProcesso() {
        return codProcesso;
    }

    public void setCodProcesso(int codProcesso) {
        this.codProcesso = codProcesso;
    }

    public int getMinutosMeta() {
        return minutosMeta;
    }

    public void setMinutosMeta(int minutosMeta) {
        this.minutosMeta = minutosMeta;
    }

    public int getMinutosFeito() {
        return minutosFeito;
    }

    public void setMinutosFeito(int minutosFeito) {
        this.minutosFeito = minutosFeito;
    }

    public String getNomeProcesso() {
        return nomeProcesso;
    }

    public void setNomeProcesso(String nomeProcesso) {
        this.nomeProcesso = nomeProcesso;
    }
}
