package br.com.eye.dao;

import br.com.eye.model.LeituraComputador;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class StatementLeituraComputador {

    public boolean setPrimeiraLeitura(LeituraComputador leitura, int codComputador) throws SQLException {
        String sql = "INSERT INTO leitura (cod_computador, ram, cpu, disco) VALUES (?, ?, ?, ?)";
        PreparedStatement query = Conexao.getConnection().prepareStatement(sql);
        query.setInt(1, codComputador);
        query.setDouble(2, leitura.getMemoriaDisponivel());
        query.setDouble(3, leitura.getCpuUsada());
        query.setDouble(4, leitura.getDiscoDisponivel());

        return query.execute();
    }

    public boolean updateLeitura(LeituraComputador leitura, int codComputador) throws SQLException {
        String sql = "UPDATE leitura SET ram = ?, cpu= ?, disco= ? WHERE cod_computador = ?";
        PreparedStatement query = Conexao.getConnection().prepareStatement(sql);
        query.setDouble(1, leitura.getMemoriaDisponivel());
        query.setDouble(2, leitura.getCpuUsada());
        query.setDouble(3, leitura.getDiscoDisponivel());
        query.setInt(4, codComputador);

        return query.execute();
    }

    public boolean existeLeituraRegistrada(int codComputador) throws SQLException {
        String sql = "SELECT leitura WHERE cod_computador = ?";
        PreparedStatement query = Conexao.getConnection().prepareStatement(sql);
        query.setInt(1, codComputador);
        ResultSet resultado = query.executeQuery();
        
        return (resultado.next());
    }
}
