package br.com.eye.model;


import java.util.Objects;
import oshi.SystemInfo;
import oshi.software.os.FileSystem;
import oshi.software.os.OSFileStore;

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


    SystemInfo systemInfo = new SystemInfo();

    FileSystem fileSystem = systemInfo.getOperatingSystem().getFileSystem();

    
    public boolean equals(Computador computador) {

        return (this.sistemaOperacional.equalsIgnoreCase(computador.getSistemaOperacional())
                && this.getVersaoSistema().equalsIgnoreCase(computador.getVersaoSistema())
                && Objects.equals(this.getVersaoBits(), computador.getVersaoBits())
                && this.getProcessador().equalsIgnoreCase(computador.getProcessador())
                && Objects.equals(this.getTotalDisco(), computador.getTotalDisco())
                && Objects.equals(this.getTotalMemoria(), computador.getTotalMemoria()));
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

    

    public Integer getCodComputador() {
        return codComputador;
    }

    public void setCodComputador(Integer codComputador) {
        this.codComputador = codComputador;
    }


    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getSistemaOperacionalOshi() {
        return systemInfo.getOperatingSystem().toString().split("[0-9]")[0];
    }

    public String getSistemaOperacional() {
        return sistemaOperacional;
    }

    public void setSistemaOperacional(String sistemaOperacional) {
        this.sistemaOperacional = sistemaOperacional;
    }

    public String getVersaoSistemaOshi() {
        
        return systemInfo.getOperatingSystem().getVersion().toString();
    }

    public String getVersaoSistema() {
        return versaoSistema;
    }

    public void setVersaoSistema(String versaoSistema) {
        this.versaoSistema = versaoSistema;
    }

    public int getVersaoBitsOshi() {
        return systemInfo.getOperatingSystem().getBitness();
    }

    public Integer getVersaoBits() {
        return versaoBits;
    }

    public void setVersaoBits(Integer versaoBits) {
        this.versaoBits = versaoBits;
    }

    public String getProcessadorOshi() {
        return (systemInfo.getHardware().getProcessor()).toString();
    }

    public String getProcessador() {
        return processador;
    }

    public void setProcessador(String processador) {
        this.processador = processador;
    }

    public long getTotalDiscoOshi() {
        OSFileStore[] fsArray = fileSystem.getFileStores();
        long total = 0;

        for (OSFileStore fs : fsArray) {

            total += fs.getTotalSpace();
        }
        return total;
    }

    public Long getTotalDisco() {
        return totalDisco;
    }

    public void setTotalDisco(Long totalDisco) {
        this.totalDisco = totalDisco;
    }

    public Long getTotalMemoriaOshi() {
        return systemInfo.getHardware().getMemory().getTotal();
    }

    public Long getTotalMemoria() {
        return totalMemoria;
    }

    public void setTotalMemoria(Long totalMemoria) {
        this.totalMemoria = totalMemoria;
    }
    
    
    public Double getCPUOshi() {
        return systemInfo.getHardware().getProcessor().getSystemCpuLoad() * 100.0;
    }
}
