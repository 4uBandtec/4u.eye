package br.com.eye.model;

import br.com.eye.model.dao.StatementLeituraComputador;
import java.sql.SQLException;
import oshi.SystemInfo;
import oshi.hardware.CentralProcessor;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.software.os.FileSystem;
import oshi.software.os.OSFileStore;

public class LeituraComputador {

    private Double cpuUsada;
    private long memoriaDisponivel;
    private long discoDisponivel;

        
    
    SystemInfo systemInfo = new SystemInfo();
    HardwareAbstractionLayer hardware = systemInfo.getHardware();
    CentralProcessor processor = hardware.getProcessor();
    FileSystem fileSystem = systemInfo.getOperatingSystem().getFileSystem();

    
    public LeituraComputador() {
    }

    public LeituraComputador(Double cpuUsada, long memoriaDisponivel, long discoDisponivel) {
        this.cpuUsada = cpuUsada;
        this.memoriaDisponivel = memoriaDisponivel;
        this.discoDisponivel = discoDisponivel;
    }

    public LeituraComputador leituraOshi(){
        return new LeituraComputador (getCpuUsadaOshi(), getMemoriaDisponivelOshi(), getDiscoDisponivelOshi());
    }

    public Double getCpuUsada() {
        return cpuUsada;
    }

    public long getMemoriaDisponivel() {
        return memoriaDisponivel;
    }

    public long getDiscoDisponivel() {
        return discoDisponivel;
    }

    public void setCpuUsada(Double cpuUsada) {
        this.cpuUsada = cpuUsada;
    }

    public void setMemoriaDisponivel(long memoriaDisponivel) {
        this.memoriaDisponivel = memoriaDisponivel;
    }

    public void setDiscoDisponivel(long discoDisponivel) {
        this.discoDisponivel = discoDisponivel;
    }

    public Double getCpuUsadaOshi() {
        Double cl = processor.getSystemCpuLoad();
        return cl * 100.0;
    }

    public long getMemoriaDisponivelOshi() {
        return systemInfo.getHardware().getMemory().getAvailable();
    }

    public long getDiscoDisponivelOshi() {
        OSFileStore[] fsArray = fileSystem.getFileStores();

        long disponivel = 0;

        for (OSFileStore fs : fsArray) {
            disponivel += fs.getUsableSpace();
        }
        return disponivel;
    }

    

   

    public void setLeitura(int codComputador) throws SQLException, InterruptedException {

        while (true) {
            Thread.sleep(1000);
            if (new StatementLeituraComputador().existeLeituraRegistrada(codComputador)) {
                new StatementLeituraComputador().updateLeitura(new LeituraComputador().leituraOshi(), codComputador);
            } else {
                new StatementLeituraComputador().setPrimeiraLeitura(new LeituraComputador().leituraOshi(), codComputador);
            }
        }
    }
    
}
