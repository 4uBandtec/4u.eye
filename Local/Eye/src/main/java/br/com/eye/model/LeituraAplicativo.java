package br.com.eye.model;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import oshi.SystemInfo;
import oshi.software.os.OSProcess;
import oshi.software.os.OperatingSystem;

public class LeituraAplicativo {

    private String codAplicativo;
    private String nome;
    private String nomeNativo;
    private double tempo;

    public LeituraAplicativo() {
    }

    public LeituraAplicativo(String nomeNativo, double tempo) {
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

    public double getTempo() {
        return tempo;
    }

    public void setTempo(double tempo) {
        this.tempo = tempo;
    }

    public static List<LeituraAplicativo> getProcesso(List<LeituraAplicativo> leituras) {
        List<OSProcess> processos = Arrays.asList(new SystemInfo().getOperatingSystem().getProcesses(10, OperatingSystem.ProcessSort.CPU));
        if (!leituras.isEmpty()) {
            for (LeituraAplicativo leitura : leituras) {
                leitura.setTempo(-leitura.getTempo());
            }
        }
        for (OSProcess processo : processos) {
            LeituraAplicativo proc = new LeituraAplicativo(
                    processo.getName(),
                    processo.getUserTime() / 1000
            );
            if (leituras.isEmpty()) {
                leituras.add(proc);
            } else {
                for (int i = 0; i < leituras.size(); i++) {
                    if (proc.getNomeNativo().equals(leituras.get(i).getNomeNativo())) {
                        double tempo = proc.getTempo() + leituras.get(i).getTempo();
                        if (tempo > 0) {
                            leituras.get(i).setTempo(tempo);
                        } else {
                            leituras.get(i).setTempo(0);
                        }
                    } else if (i == leituras.size() - 1) {
                        leituras.add(proc);
                    }
                }
            }
        }
        return leituras;
    }

    public static String retornaNomeCampo(int codPerfil) {
        switch (codPerfil) {
            case 1:
                return "minutos_jogos";
            case 2:
                return "minutos_trabalho";
            case 3:
                return "minutos_social";
            default:
                return "minutos_outros";
        }
    }
}
