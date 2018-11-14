package br.com.eye.model;

import br.com.eye.controller.ControllerLeituraComputador;

public class LeituraComputador {

    private Double cpuUsada;
    private Double memoriaDisponivel;
    private long discoDisponivel;

    public LeituraComputador() {
    }

    public LeituraComputador(Double cpuUsada, Double memoriaDisponivel, long discoDisponivel) {
        this.cpuUsada = cpuUsada;
        this.memoriaDisponivel = memoriaDisponivel;
        this.discoDisponivel = discoDisponivel;
    }

    ControllerLeituraComputador controllerLeituraComputador = new ControllerLeituraComputador();

    public LeituraComputador leituraOshi(){
        return new LeituraComputador (getCpuUsadaOshi(), getMemoriaDisponivelOshi(), getDiscoDisponivelOshi());
    }

    public Double getCpuUsada() {
        return cpuUsada;
    }

    public Double getMemoriaDisponivel() {
        return memoriaDisponivel;
    }

    public long getDiscoDisponivel() {
        return discoDisponivel;
    }

    public void setCpuUsada(Double cpuUsada) {
        this.cpuUsada = cpuUsada;
    }

    public void setMemoriaDisponivel(Double memoriaDisponivel) {
        this.memoriaDisponivel = memoriaDisponivel;
    }

    public void setDiscoDisponivel(long discoDisponivel) {
        this.discoDisponivel = discoDisponivel;
    }

    public Double getCpuUsadaOshi() {
        return controllerLeituraComputador.getCPUUsada();
    }

    public Double getMemoriaDisponivelOshi() {
        return controllerLeituraComputador.getMemoriaDisponivel();
    }

    public long getDiscoDisponivelOshi() {
        return controllerLeituraComputador.getDiscoDisponivel();
    }

}
