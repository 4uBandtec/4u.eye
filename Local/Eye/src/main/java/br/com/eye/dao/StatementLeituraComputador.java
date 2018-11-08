package br.com.eye.dao;

import br.com.eye.model.LeituraComputador;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class StatementLeituraComputador {

    public boolean setPrimeiraLeitura(LeituraComputador leitura, int codComputador) throws SQLException {
        String sql = "INSERT INTO leitura_atual (cod_computador, ram, cpu, disco) VALUES (?, ?, ?, ?)";
        System.out.println("ENTROU INSERT");
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codComputador);
        query.setDouble(2, leitura.getMemoriaDisponivel());
        query.setDouble(3, leitura.getCpuUsada());
        query.setLong(4, leitura.getDiscoDisponivel());
        return query.execute();
    }

    public boolean updateLeitura(LeituraComputador leitura, int codComputador) throws SQLException {
        System.out.println("ENTROU UPDATE");
        String sql = "UPDATE leitura_atual SET ram = ?, cpu= ?, disco= ? WHERE cod_computador = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        System.out.println("leu");
        query.setDouble(1, leitura.getMemoriaDisponivel());
        System.out.println("leu2");
        query.setDouble(2, leitura.getCpuUsada());
        System.out.println("leu3");
        query.setLong(3, leitura.getDiscoDisponivel());
        System.out.println("leu4");
        query.setInt(4, codComputador);
        System.out.println("leu5");
        System.out.println("não foi esse2");

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
