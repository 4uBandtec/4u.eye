package br.com.eye.dao;

import br.com.eye.model.Computador;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class StatementComputador {

    Conexao conexao = new Conexao();

    public Computador getComputadorSalvo(int codUsuario) throws SQLException {
        Computador computador = null;
        String sql = "SELECT * FROM computador WHERE cod_usuario = ?";
        PreparedStatement query = conexao.getConnection().prepareStatement(sql);
        query.setInt(1, codUsuario);
        ResultSet resultado = query.executeQuery();
        if (resultado.next()) {
            computador = new Computador(
                    resultado.getInt("cod_computador"),
                    resultado.getString("nome"),
                    resultado.getString("sistema_operacional"),
                    resultado.getString("versao_sistema"),
                    resultado.getInt("versao_bits"),
                    resultado.getString("processador"),
                    resultado.getLong("total_cpu"),
                    resultado.getDouble("total_disco"),
                    resultado.getDouble("total_memoria"),
                    resultado.getDouble("total_memoria"),
                    codUsuario);
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

    public Computador getComputadorSalvo() {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

}
