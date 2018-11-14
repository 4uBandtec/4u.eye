package br.com.eye.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Conexao {

    public Connection getConexao() {
        try {
            Connection conexao;
            String cadeidaDeConexao = "jdbc:sqlserver://bandtecserver.database.windows.net:1433;database=bd4U;user=henriquegs@bandtecserver;password=digitalSCH00L;encrypt=true;trustServerCertificate=false;hostNameInCertificate=*.database.windows.net;loginTimeout=30;";
            conexao = DriverManager.getConnection(cadeidaDeConexao);
            conexao.setAutoCommit(true);
            return conexao;
        } catch (SQLException ex) {
            Logger.getLogger(Conexao.class.getName()).log(Level.SEVERE, null, ex);
            throw new RuntimeException(ex);
        }
    }

    public void fecharConexao(Connection conexao) {

        try {
            if (conexao != null) {
                conexao.close();
            }
        } catch (SQLException e) {
            System.err.println();
        }
    }
}
