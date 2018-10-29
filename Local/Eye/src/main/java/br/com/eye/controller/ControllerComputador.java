package br.com.eye.controller;
import br.com.eye.model.Computador;
import java.sql.SQLException;
import oshi.SystemInfo;
import oshi.software.os.FileSystem;
import oshi.software.os.OSFileStore;

public class ControllerComputador {

    SystemInfo systemInfo = new SystemInfo();
    
    FileSystem fileSystem = systemInfo.getOperatingSystem().getFileSystem();

    public Computador getComputadorAtual(int codUsuario) throws SQLException {
        return new Computador(
                getSistemaOperacional(),
                getVersaoSistema(),
                getBit(),
                getProcessador(),
                getCPU(),
                getDisco(),
                getMemoria()
        );
    }

    public String getSistemaOperacional() {
        return systemInfo.getOperatingSystem().toString();
    }

    public String getVersaoSistema() {
        return systemInfo.getOperatingSystem().getVersion().toString();

    }

    public int getBit() {
        return systemInfo.getOperatingSystem().getBitness();
    }

    public String getProcessador() {
        return (systemInfo.getHardware().getProcessor()).toString();
    }

    public Double getCPU() {
        
        return systemInfo.getHardware().getProcessor().getSystemCpuLoad()*100.0;
    }

    public long getDisco() {
       
        OSFileStore[] fsArray = fileSystem.getFileStores();
        
        
        long total = 0;
        
        for (OSFileStore fs : fsArray) {

            total += fs.getTotalSpace();

        }
        
           return total;
    }

    public long getMemoria() {
        return systemInfo.getHardware().getMemory().getTotal();
    }

    public boolean verificaAtualizacao(Computador atual, Computador salvo) {
        return atual == salvo;//Falta completar
    }

}
