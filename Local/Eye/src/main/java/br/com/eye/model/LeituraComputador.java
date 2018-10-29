/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.com.eye.model;

import br.com.eye.controller.ControllerComputador;
import br.com.eye.controller.ControllerLeituraComputador;
import java.util.List;

/**
 *
 * @author Aluno
 */
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
