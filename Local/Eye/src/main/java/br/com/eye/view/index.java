package br.com.eye.view;

import br.com.eye.model.Computador;
import br.com.eye.model.LeituraComputador;
import java.text.DecimalFormat;
import oshi.util.FormatUtil;

public class index {

    public static void main(String[] args) throws InterruptedException {
        //Colocar aqui um metodo que verifica os componentes do banco e se estão atualizados com o banco
        new TelaLogin();
        Computador computer = new Computador();
        LeituraComputador leitura = new LeituraComputador();
        
        DecimalFormat df = new DecimalFormat("#.##"); //Pra deixar as coisas com 2 casas decimais

        int i = 0;
        
        while(true){
            Thread.sleep(5000);
            
            double ramTotal = computer.getTotalMemoria();
            double ramDisponivel = leitura.getMemoriaDisponivel();
            double ramUsada = ramTotal - ramDisponivel;
            
            
            long discoTotal = computer.getTotalDiscoAtual();
            long discoDisponivel = leitura.getDiscoDisponivel();
            long discoUsado = discoTotal - discoDisponivel;
            
            
            
            
            
            System.out.println("\n\n\n\nSO "+computer.getSistemaOperacionalAtual());
            
            System.out.println("SO ver "+computer.getVersaoSistemaAtual());
            
            System.out.println("BITS "+computer.getVersaoBitsAtual());
            
            System.out.println("Processador "+computer.getProcessadorAtual());
            
            
            System.out.println("\nUso da CPU "+df.format(leitura.getCpuUsada())+"%");
            
            System.out.println("\n\t RAM:");
            System.out.println("Total: "+FormatUtil.formatBytesDecimal((long) ramTotal));
            System.out.println("Disponivel: "+FormatUtil.formatBytesDecimal((long) ramDisponivel));
            System.out.println("Usada: "+FormatUtil.formatBytesDecimal((long) ramUsada));
            
            
            
            System.out.println("\n\t DISCO:");
            System.out.println("Total: "+FormatUtil.formatBytesDecimal((long) discoTotal));
            System.out.println("Disponivel: "+FormatUtil.formatBytesDecimal((long) discoDisponivel));
            System.out.println("Usada: "+FormatUtil.formatBytesDecimal((long) discoUsado));
            
        }
    }

}
