/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.com.eye.controller;


import br.com.eye.model.dao.StatementTarefa;
import java.sql.SQLException;

/**
 *
 * @author henri
 */
public class ControllerTarefa {
    public static boolean ativaTarefa(int codTarefa, int codProcesso, int codUsuario) throws SQLException{
        return StatementTarefa.ativaTarefa(codTarefa, codProcesso, codUsuario);
    }
    
    public static boolean desativaTarefas(int codUsuario) throws SQLException{
        return StatementTarefa.desativaTarefas(codUsuario);
    }
}
