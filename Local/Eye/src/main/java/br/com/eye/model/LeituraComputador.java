
package br.com.eye.model;

import br.com.eye.controller.ControllerLeituraComputador;

public class LeituraComputador {
    private Double cpuUsada;
    private Double memoriaDisponivel;
    private long discoDisponivel;

    ControllerLeituraComputador controllerLeituraComputador = new ControllerLeituraComputador();
    
    public Double getCpuUsada() {
        return controllerLeituraComputador.getCPUUsada();
    }

    public void setCpuUsada(Double cpuUsada) {
        this.cpuUsada = cpuUsada;
    }

    public Double getMemoriaDisponivel() {
        return controllerLeituraComputador.getMemoriaDisponivel();
    }

    public void setMemoriaDisponivel(Double RamUsada) {
        this.memoriaDisponivel = memoriaDisponivel;
    }

    public long getDiscoDisponivel() {
        return controllerLeituraComputador.getDiscoDisponivel();
    }

    public void setDiscoDisponivel(long discoDisponivel) {
        this.discoDisponivel = discoDisponivel;
    }
    
}
