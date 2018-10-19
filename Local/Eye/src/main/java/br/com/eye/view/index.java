package br.com.eye.view;

import br.com.eye.model.Computador;

public class index {

    public static void main(String[] args) {
        //Colocar aqui um metodo que verifica os componentes do banco e se estão atualizados com o banco
        Computador teste = new Computador();

        System.out.println(teste.getSistemaOperacional());
    }

}
