package br.com.eye.dao;

import br.com.eye.model.Computador;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class StatementComputador {

    Conexao conexao = new Conexao();

    public Computador getComputadorSalvo(int codUsuario) throws SQLException {
        Computador computador = null;
        String sql = "SELECT sistema_operacional, versao_sistema, versao_bits,  processador, total_cpu, total_discoFROM computador WHERE cod_usuario = ?";
        PreparedStatement query = conexao.getConnection().prepareStatement(sql);
        query.setInt(1, codUsuario);
        ResultSet resultado = query.executeQuery();
        if (resultado.next()) {
            computador = new Computador(
                    resultado.getString("sistema_operacional"),
                    resultado.getString("versao_sistema"),
                    resultado.getInt("versao_bits"),
                    resultado.getString("processador"),
                    resultado.getDouble("total_cpu"),
                    resultado.getDouble("total_disco"),
                    resultado.getLong("total_memoria")
            );
        }
        return computador;
    }

    public Integer getCodComputador(int codUsuario) throws SQLException {
        String sql = "SELECT cod_computador FROM computador WHERE cod_usuario = ?";

        PreparedStatement query = conexao.getConnection().prepareStatement(sql);
        query.setInt(1, codUsuario);
        ResultSet resultado = query.executeQuery();

        return resultado.next() ? resultado.getInt("cod_computador") : null;
    }

    public String getNome(int codComputador) throws SQLException {
        String sql = "SELECT nome FROM computador WHERE cod_computador = ?";
        PreparedStatement query = conexao.getConnection().prepareStatement(sql);
        query.setInt(1, codComputador);
        ResultSet resultado = query.executeQuery();
        return resultado.next() ? resultado.getString("nome") : "";
    }

}
