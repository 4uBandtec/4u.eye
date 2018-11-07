package br.com.eye.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class Conexao {

    public static Connection getConnection() {

        try {
            Class.forName("com.mysql.jdbc.Driver");
            return DriverManager.getConnection("jdbc:sqlserver://bandtecserver.database.windows.net:1433;database=bd4U;user=henriquegs@bandtecserver;password=digitalSCHO00L;encrypt=true;trustServerCertificate=false;hostNameInCertificate=*.database.windows.net;loginTimeout=30;", "root", "");
        } catch (ClassNotFoundException | SQLException e) {
            System.err.println(e.getMessage());
        }

        return null;

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
