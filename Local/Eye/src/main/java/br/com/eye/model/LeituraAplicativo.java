package br.com.eye.model;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import oshi.SystemInfo;
import oshi.software.os.OSProcess;
import oshi.software.os.OperatingSystem;

public class LeituraAplicativo {

    String codAplicativo;
    String nome;
    String nomeNativo;
    long tempo;

    public LeituraAplicativo() {
    }

    public LeituraAplicativo(String nomeNativo, long tempo) {
        this.nomeNativo = nomeNativo;
        this.tempo = tempo;
    }

    public String getCodAplicativo() {
        return codAplicativo;
    }

    public void setCodAplicativo(String codAplicativo) {
        this.codAplicativo = codAplicativo;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getNomeNativo() {
        return nomeNativo;
    }

    public void setNomeNativo(String nomeNativo) {
        this.nomeNativo = nomeNativo;
    }

    public long getTempo() {
        return tempo;
    }

    public void setTempo(long tempo) {
        this.tempo = tempo;
    }

    public static List<LeituraAplicativo> getProcesso() {
        List<OSProcess> processos = Arrays.asList(new SystemInfo().getOperatingSystem().getProcesses(10, OperatingSystem.ProcessSort.CPU));
        List<LeituraAplicativo> leituras = new ArrayList();
        for (OSProcess processo : processos) {
            LeituraAplicativo proc = new LeituraAplicativo(
                    processo.getName(),
                    processo.getUserTime()
            );
            System.out.println(proc.getNomeNativo());
            System.out.println(proc.getTempo());
            System.out.println("");

            if (leituras.isEmpty()) {
                leituras.add(proc);
            } else {
                for (int i = 0; i < leituras.size(); i++) {
                    if (proc.getNomeNativo().equals(leituras.get(i).getNomeNativo())) {
                        proc.setTempo(proc.getTempo() + leituras.get(i).getTempo()); 
                    } else if (i == leituras.size() - 1) {
                        leituras.add(proc);
                    }
                }
            }
        }
        return leituras;
    }
}
