package br.com.eye.model;

import br.com.eye.controller.ControllerAplicativo;
import br.com.eye.model.dao.StatementLeituraComputador;
import br.com.eye.model.Computador;
import java.io.IOException;
import java.sql.SQLException;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;
import static jdk.nashorn.internal.objects.NativeMath.round;
import oshi.SystemInfo;
import oshi.hardware.CentralProcessor;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.software.os.FileSystem;
import oshi.software.os.OSFileStore;

public class LeituraComputador {

    private Double cpuUsada;
    private long memoriaDisponivel;
    private long discoDisponivel;

    DecimalFormat formato = new DecimalFormat(".##");

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

    public LeituraComputador leituraOshi() {
        return new LeituraComputador(getCpuUsadaOshi(), getMemoriaDisponivelOshi(), getDiscoDisponivelOshi());
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

        return Double.parseDouble(formato.format(cl * 100.0).replaceAll(",", "."));
    }

    public long getMemoriaDisponivelOshi() {
        Computador computador = new Computador();
        return computador.getTotalMemoriaOshi() - systemInfo.getHardware().getMemory().getAvailable();
    }

    public long getDiscoDisponivelOshi() {
        OSFileStore[] fsArray = fileSystem.getFileStores();

        long disponivel = 0;

        for (OSFileStore fs : fsArray) {
            disponivel += fs.getUsableSpace();
        }
        return disponivel;
    }

    public void setLeitura(int codComputador, int codUsuario) throws SQLException, InterruptedException, IOException {
        int contador = 0;
        List<LeituraAplicativo> leituras = new ArrayList();
        while (true) {
            contador++;
            Thread.sleep(5000);
            if (new StatementLeituraComputador().existeLeituraRegistrada(codComputador)) {
                new StatementLeituraComputador().updateLeitura(new LeituraComputador().leituraOshi(), codComputador);
            } else {
                new StatementLeituraComputador().setPrimeiraLeitura(new LeituraComputador().leituraOshi(), codComputador);
            }
            LogMensagem.GravarLog("Leitura Armazenada");
            if (contador % 12 == 0) {
                leituras = ControllerAplicativo.setLeituraAplicativo(codUsuario, leituras);
                contador = contador == 120000 ? 0 : contador;
                LogMensagem.GravarLog("Processos Armazenados");
            }

        }
    }

}
