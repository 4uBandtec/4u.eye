package br.com.eye.controller;

import br.com.eye.model.LeituraAplicativo;
import br.com.eye.model.dao.StatementAplicativo;
import java.sql.SQLException;
import java.util.List;

public class ControllerAplicativo {

    public static void setLeituraAplicativo(int codUsuario) throws SQLException {
        List<LeituraAplicativo> leituras = LeituraAplicativo.getProcesso();
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
                long minutos = StatementAplicativo.getMinutosAcumulados(codUsuario, campoPerfil);
                minutos = minutos + leitura.getTempo();
                StatementAplicativo.acumulaMinutos(codUsuario, minutos, campoPerfil);   
            }

        }
    }
}
