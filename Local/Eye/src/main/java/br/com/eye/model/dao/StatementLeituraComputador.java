package br.com.eye.model.dao;

import br.com.eye.model.LeituraComputador;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.time.format.FormatStyle;

public class StatementLeituraComputador {

    public int getCodComputador(int codUsuario) throws SQLException {
        String sql = "SELECT cod_computador FROM Computador WHERE cod_usuario = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        ResultSet resultado = query.executeQuery();
        return resultado.next() ? resultado.getInt("cod_computador") : 0;
    }

    public boolean setPrimeiraLeitura(LeituraComputador leitura, int codComputador) throws SQLException {
        String sql = "INSERT INTO leitura_atual (cod_computador, ram, cpu, hd, ultima_leitura) VALUES (?, ?, ?, ?, ?)";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codComputador);
        query.setDouble(2, leitura.getMemoriaDisponivel());
        query.setDouble(3, leitura.getCpuUsada());
        query.setLong(4, leitura.getDiscoDisponivel());
        query.setString(5,LocalDateTime.now().format(DateTimeFormatter.ofLocalizedDateTime(FormatStyle.MEDIUM)));
        return query.execute();
    }

    public boolean updateLeitura(LeituraComputador leitura, int codComputador) throws SQLException {
        String sql = "UPDATE leitura_atual SET ram = ?, cpu= ?, hd= ?, ultima_leitura = ? WHERE cod_computador = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setDouble(1, leitura.getMemoriaDisponivel());
        query.setDouble(2, leitura.getCpuUsada());
        query.setLong(3, leitura.getDiscoDisponivel());
        query.setString(4,LocalDateTime.now().format(DateTimeFormatter.ofLocalizedDateTime(FormatStyle.MEDIUM)));
        query.setInt(5, codComputador);

        return query.execute();
    }

    public boolean existeLeituraRegistrada(int codComputador) throws SQLException {
        String sql = "SELECT * FROM leitura_atual WHERE cod_computador = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codComputador);
        ResultSet resultado = query.executeQuery();
        return (resultado.next());
    }
}
