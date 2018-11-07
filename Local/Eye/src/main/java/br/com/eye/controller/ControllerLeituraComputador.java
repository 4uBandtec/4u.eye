package br.com.eye.controller;

import br.com.eye.dao.StatementLeituraComputador;
import br.com.eye.model.LeituraComputador;
import java.sql.SQLException;
import oshi.SystemInfo;
import oshi.hardware.CentralProcessor;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.software.os.FileSystem;
import oshi.software.os.OSFileStore;

public class ControllerLeituraComputador {

    SystemInfo systemInfo = new SystemInfo();
    HardwareAbstractionLayer hardware = systemInfo.getHardware();
    CentralProcessor processor = hardware.getProcessor();
    FileSystem fileSystem = systemInfo.getOperatingSystem().getFileSystem();

    public double getCPUUsada() {
        Double cl = processor.getSystemCpuLoad();
        return cl * 100.0;
    }

    public double getMemoriaDisponivel() {
        return systemInfo.getHardware().getMemory().getAvailable();
    }

    public long getDiscoDisponivel() {
        OSFileStore[] fsArray = fileSystem.getFileStores();

        long disponivel = 0;

        for (OSFileStore fs : fsArray) {
            disponivel += fs.getUsableSpace();
        }
        return disponivel;
    }

    public LeituraComputador realizaLeitura() {
        return new LeituraComputador(getCPUUsada(), getMemoriaDisponivel(), getDiscoDisponivel());
    }

    public boolean setLeitura(int codUsuario) throws SQLException {
        return new StatementLeituraComputador().existeLeituraRegistrada(codUsuario)
                ? new StatementLeituraComputador().updateLeitura(leitura, codUsuario)
                : new StatementLeituraComputador().setPrimeiraLeitura(leitura, codUsuario);
    }
}
