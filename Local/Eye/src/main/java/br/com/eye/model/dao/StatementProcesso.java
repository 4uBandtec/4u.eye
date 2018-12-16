package br.com.eye.model.dao;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.time.format.FormatStyle;

public class StatementProcesso {

    public static int getProcesso(String nomeProcesso) throws SQLException {
        String sql = "SELECT cod_processo FROM processo  WHERE nome_processo = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setString(1, nomeProcesso);
        ResultSet resultado = query.executeQuery();
        return resultado.next() ? resultado.getInt("cod_processo") : 0;
    }

    public static boolean setProcessoNovo(String nomeProcesso) throws SQLException {
        String sql = "INSERT INTO processo (nome_processo, nome_aplicacao) OUTPUT INSERTED.cod_processo VALUES (?,?)";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setString(1, nomeProcesso);
        query.setString(2, "NULL");
         return query.execute();
    }

    public static boolean setLeituraProcesso(int codUsuario, int codProcesso) throws SQLException {
        String sql = "INSERT INTO leitura_processo (cod_usuario, cod_processo, data_uso) VALUES (?, ?, ?)";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        query.setInt(2, codProcesso);
        query.setString(3, LocalDateTime.now().format(DateTimeFormatter.ofLocalizedDateTime(FormatStyle.MEDIUM)));
        return query.execute();
    }

    public static int verificaPerfilCadastrado(int codUsuario, int codProcesso) throws SQLException {
        String sql = "SELECT cod_perfil FROM perfil_processo_usuario  WHERE cod_usuario = ? AND cod_processo =? ";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        query.setInt(2, codProcesso);
        ResultSet resultado = query.executeQuery();
        return resultado.next() ? resultado.getInt("cod_perfil") : 0;
    }

    public static boolean setPerfilProcesso(int codProcesso, int codUsuario) throws SQLException {
        String sql = "INSERT INTO perfil_processo_usuario (cod_usuario, cod_processo, cod_perfil) VALUES (?, ?, ?)";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        query.setInt(2, codProcesso);
        query.setInt(3, 5);
        return query.execute();
    }

    public static boolean verificaUsuarioExistente(int codUsuario) throws SQLException {
        String sql = "SELECT * FROM perfil_usuario  WHERE cod_usuario = ? ";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        ResultSet resultado = query.executeQuery();
        return resultado.next();
    }

    public static boolean insereUsuario(int codUsuario) throws SQLException {
        String sql = "INSERT INTO perfil_usuario (cod_usuario) VALUES (?)";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        return query.execute();
    }

    public static int getMinutosAcumulados(int codUsuario, String perfil) throws SQLException {
        String sql = "SELECT " + perfil + " FROM perfil_usuario  WHERE cod_usuario = ? ";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, codUsuario);
        ResultSet resultado = query.executeQuery();
        return resultado.next() ? (resultado.getInt(1)) : 0;
    }

    public static boolean acumulaMinutos(int codUsuario, int minutos, String perfil) throws SQLException {
        String sql = "UPDATE perfil_usuario set "+ perfil + " = ? WHERE cod_usuario = ?";
        PreparedStatement query = new Conexao().getConexao().prepareStatement(sql);
        query.setInt(1, minutos);
        query.setInt(2, codUsuario);
        return query.execute();
    }
}
