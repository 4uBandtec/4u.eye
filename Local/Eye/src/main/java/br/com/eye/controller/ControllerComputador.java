package br.com.eye.controller;

import java.sql.SQLException;


import br.com.eye.model.Computador;

import br.com.eye.model.dao.StatementComputador;

public class ControllerComputador {

    
    StatementComputador statementComputador = new StatementComputador();
    Computador computador = new Computador();
    
    
    public Computador getComputadorOshi() {
        return new Computador(
                getSistemaOperacionalAtual(),
                getVersaoSistemaOshi(),
                getVersaoBitsOshi(),
                getProcessadorOshi(),
                getTotalMemoriaOshi(),
                getTotalDiscoOshi()
        );
    }

    

    public String getVersaoSistemaOshi() {
        
        return computador.getVersaoSistemaOshi();
    }

    public int getVersaoBitsOshi() {
        return computador.getVersaoBitsOshi();
    }

    public String getProcessadorOshi() {
        return computador.getProcessadorOshi();
    }


    public Long getTotalDiscoOshi() {
        return computador.getTotalDiscoOshi();
    }

    public Long getTotalMemoriaOshi() {
        return computador.getTotalMemoriaOshi();
    }
    
    public Integer getCodComputador(int codigoUsuario) throws SQLException {
        return statementComputador.getCodComputador(codigoUsuario);
    }
    
    
    public String getNomeAtual(Computador computador) throws SQLException {
        return statementComputador.getNome(computador.getCodComputador());
    }
    
    public String getSistemaOperacionalAtual() {
        return (computador.getSistemaOperacionalOshi().split("[0-9]")[0]);
    }
    
    
    public Computador getComputadorSalvo(int codUsuario) throws SQLException {
        return statementComputador.getComputadorSalvo(codUsuario);
    }

    public boolean inserePrimeiroComputador(int codUsuario) throws SQLException {
        if(statementComputador.existeComputadorRegistrado(codUsuario))
        {
            
           if( !verificaAtualizacao(codUsuario)){
               
               statementComputador.updateComputador(statementComputador.getCodComputador(codUsuario));
            }
        }
        else{
            statementComputador.setComputador(getComputadorOshi(), codUsuario);
        }
        return true;
    }

    public boolean verificaAtualizacao(int codUsuario) throws SQLException {

        return (statementComputador.getComputadorSalvo(codUsuario)).equals(getComputadorOshi());
        //Precisa de Banco para testar
    }

    
    
}
