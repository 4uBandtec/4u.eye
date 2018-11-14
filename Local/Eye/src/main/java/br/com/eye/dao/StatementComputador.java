package br.com.eye.dao;

import br.com.eye.model.Computador;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class StatementComputador {

    public boolean setComputador(Computador computador, int codUsuario) throws SQLException {
        String sql = "INSERT INTO computador (sistema_operacional, versao_sistema, versao_bits, processador, total_ram, total_hd , cod_usuario) VALUES (?, ?, ?, ?, ?, ?, ?)";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setString(1, computador.getSistemaOperacional());
        query.setString(2, computador.getVersaoSistema());
        query.setInt(3, computador.getVersaoBits());
        query.setString(4, computador.getProcessador());
        query.setLong(5, computador.getTotalMemoria());
        query.setLong(6, computador.getTotalDisco());
        query.setInt(7, codUsuario);

        return query.execute();
    }

    public Computador getComputadorSalvo(int codUsuario) throws SQLException {
        Computador computador = null;

        String sql = "SELECT sistema_operacional, versao_sistema, versao_bits, processador, total_ram, total_hd FROM computador WHERE cod_usuario = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        ResultSet resultado = query.executeQuery();
        if (resultado.next()) {
            computador = new Computador(
                    resultado.getString("sistema_operacional"),
                    resultado.getString("versao_sistema"),
                    resultado.getInt("versao_bits"),
                    resultado.getString("processador"),
                    resultado.getLong("total_ram"),
                    resultado.getLong("total_hd")
            );
        }
        return computador;
    }

    public Integer getCodComputador(int codUsuario) throws SQLException {
        String sql = "SELECT cod_computador FROM computador WHERE cod_usuario = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        ResultSet resultado = query.executeQuery();

        return resultado.next() ? resultado.getInt("cod_computador") : null;
    }

    public String getNome(int codComputador) throws SQLException {
        String sql = "SELECT nome FROM computador WHERE cod_computador = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codComputador);
        ResultSet resultado = query.executeQuery();
        return resultado.next() ? resultado.getString("nome") : "";
    }

    public boolean existeComputadorRegistrado(int codUsuario) throws SQLException {
        String sql = "SELECT * FROM computador WHERE cod_usuario = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        ResultSet resultado = query.executeQuery();

        return (resultado.next());
    }

}
