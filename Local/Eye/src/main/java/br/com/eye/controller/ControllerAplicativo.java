package br.com.eye.controller;

import br.com.eye.model.LeituraProcesso;
import br.com.eye.model.dao.StatementProcesso;
import java.sql.SQLException;
import java.util.List;

public class ControllerAplicativo {

    public static List<LeituraProcesso> setLeituraAplicativo(int codUsuario, List<LeituraProcesso> leituras) throws SQLException {
       leituras = LeituraProcesso.getProcesso(leituras);
        for (LeituraProcesso leitura : leituras) {
            int codProcesso = StatementProcesso.getProcesso(leitura.getNomeNativo());
            if (codProcesso == 0) {
                StatementProcesso.setProcessoNovo(leitura.getNomeNativo());
                codProcesso = StatementProcesso.getProcesso(leitura.getNomeNativo());
            }
            StatementProcesso.setLeituraProcesso(codUsuario, codProcesso);
            int codPerfil = StatementProcesso.verificaPerfilCadastrado(codUsuario, codProcesso);
            if (codPerfil == 0) {
                StatementProcesso.setPerfilProcesso(codProcesso, codUsuario);
            } else if (codPerfil != 5) {
                if (!StatementProcesso.verificaUsuarioExistente(codUsuario)) {
                    StatementProcesso.insereUsuario(codUsuario);
                }
                String campoPerfil = LeituraProcesso.retornaNomeCampo(codPerfil);
                int minutos = StatementProcesso.getMinutosAcumulados(codUsuario, campoPerfil);
                minutos = (int) (minutos + leitura.getTempo() / 60);
                StatementProcesso.acumulaMinutos(codUsuario, minutos, campoPerfil);
            }
        }     
        return leituras;
    }
}
