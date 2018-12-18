package br.com.eye.model;

public class Tarefa {

    private String nome;
    private int codWorkspace;
    private ProcessoTarefa processos;

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public int getCodWorkspace() {
        return codWorkspace;
    }

    public void setCodWorkspace(int codWorkspace) {
        this.codWorkspace = codWorkspace;
    }

    public ProcessoTarefa getProcessos() {
        return processos;
    }

    public void setProcessos(ProcessoTarefa processos) {
        this.processos = processos;
    }
}
