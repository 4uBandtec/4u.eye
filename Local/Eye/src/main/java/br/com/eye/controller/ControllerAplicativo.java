package br.com.eye.controller;

import br.com.eye.model.LeituraAplicativo;
import br.com.eye.model.dao.StatementAplicativo;
import java.sql.SQLException;
import java.util.List;

public class ControllerAplicativo {

    public static List<LeituraAplicativo> setLeituraAplicativo(int codUsuario, List<LeituraAplicativo> leituras) throws SQLException {
       leituras = LeituraAplicativo.getProcesso(leituras);
        for (LeituraAplicativo leitura : leituras) {
            int codProcesso = StatementAplicativo.getProcesso(leitura.getNomeNativo());
            if (codProcesso == 0) {
                StatementAplicativo.setProcessoNovo(leitura.getNomeNativo());
                codProcesso = StatementAplicativo.getProcesso(leitura.getNomeNativo());
            }
            StatementAplicativo.setLeituraProcesso(codUsuario, codProcesso);
            int codPerfil = StatementAplicativo.verificaPerfilCadastrado(codUsuario, codProcesso);
            if (codPerfil == 0) {
                StatementAplicativo.setPerfilProcesso(codProcesso, codUsuario);
            } else if (codPerfil != 5) {
                if (!StatementAplicativo.verificaUsuarioExistente(codUsuario)) {
                    StatementAplicativo.insereUsuario(codUsuario);
                }
                String campoPerfil = LeituraAplicativo.retornaNomeCampo(codPerfil);
                int minutos = StatementAplicativo.getMinutosAcumulados(codUsuario, campoPerfil);
                minutos = (int) (minutos + leitura.getTempo() / 60);
                StatementAplicativo.acumulaMinutos(codUsuario, minutos, campoPerfil);
            }
        }     
        return leituras;
    }
}
