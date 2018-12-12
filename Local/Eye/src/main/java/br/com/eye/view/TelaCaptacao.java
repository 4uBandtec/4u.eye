package br.com.eye.view;

import br.com.eye.controller.ControllerLeituraComputador;
import br.com.eye.controller.ControllerComputador;
import br.com.eye.model.LeituraAplicativo;
import java.awt.Color;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;
import java.sql.SQLException;
import java.util.List;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.border.LineBorder;

public class TelaCaptacao extends JFrame implements ActionListener {

    JLabel lblFuncionou = new JLabel("Pegando informações");

    GridBagConstraints constraints = new GridBagConstraints();

    Font fontSergoe = new Font("Sergou Ui Light", Font.PLAIN, 40);

    Color bgColor = new Color(26, 26, 26);
    Color txtColor = new Color(200, 200, 200);
    Color redColor = new Color(226, 26, 47);

    LineBorder borderRed = new LineBorder(redColor, 1);

    public TelaCaptacao(int codUsuario) throws InterruptedException, SQLException, IOException {
        setSize(500, 500);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLayout(null);
        setLocationRelativeTo(null);
        setTitle("Funcionou | EYE");

        setLayout(new GridBagLayout());
        getContentPane().setBackground(bgColor);

        constraints.fill = GridBagConstraints.HORIZONTAL;

        lblFuncionou.setFont(fontSergoe);
        lblFuncionou.setName("lblFuncionou");

        lblFuncionou.setForeground(txtColor);

        constraints.fill = GridBagConstraints.HORIZONTAL;
        constraints.weightx = 1;
        constraints.gridy = 2;
        constraints.gridx = 0;
        constraints.gridwidth = 3;

        add(lblFuncionou, constraints);

        setVisible(true);

        if (new ControllerComputador().inserePrimeiroComputador(codUsuario)) {
            new ControllerLeituraComputador().setLeitura(codUsuario);
        }
    }
    @Override
    public void actionPerformed(ActionEvent e) {
    }
}
