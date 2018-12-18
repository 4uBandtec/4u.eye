package br.com.eye.view;

import br.com.eye.controller.ControllerLeituraComputador;
import br.com.eye.controller.ControllerComputador;
import br.com.eye.controller.ControllerTarefa;
import br.com.eye.model.LeituraProcesso;
import br.com.eye.model.Tarefa;
import java.awt.Color;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;
import java.sql.SQLException;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.SwingConstants;
import javax.swing.border.LineBorder;

public class TelaCaptacao extends JFrame implements ActionListener {

    List<Tarefa> listaTarefa;
    JLabel lblFuncionou = new JLabel("Capturando Dados...", SwingConstants.CENTER);

    JLabel lblTarefas = new JLabel("Tarefas", SwingConstants.CENTER);

    GridBagConstraints constraints = new GridBagConstraints();

    Font fontSergoe = new Font("Sergou Ui Light", Font.PLAIN, 40);
    JButton btnStartTarefa = new JButton("Iniciar tarefa");
    JButton btnStopTarefa = new JButton("Pausar tarefas");

    JComboBox cmbTarefas = new JComboBox();

    Color bgColor = new Color(26, 26, 26);
    Color txtColor = new Color(200, 200, 200);
    Color redColor = new Color(226, 26, 47);

    LineBorder borderRed = new LineBorder(redColor, 1);

    private int codUsuario;

    public TelaCaptacao(int codUsuario) throws InterruptedException, SQLException, IOException {
        this.codUsuario = codUsuario;
        setSize(500, 500);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLayout(null);
        setLocationRelativeTo(null);
        setTitle("Captando Dados | EYE");

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

        lblTarefas.setFont(fontSergoe);
        lblTarefas.setName("lblFuncionou");

        lblTarefas.setForeground(txtColor);

        constraints.fill = GridBagConstraints.HORIZONTAL;
        constraints.weightx = 1;
        constraints.gridy = 4;
        constraints.gridx = 0;
        constraints.gridwidth = 3;

        add(lblTarefas, constraints);

        cmbTarefas.setFont(fontSergoe);
        cmbTarefas.setBorder(borderRed);
        cmbTarefas.setName("cmbTarefas");
        cmbTarefas.setForeground(txtColor);
        cmbTarefas.setBackground(bgColor);
        cmbTarefas.addActionListener(this);

        constraints.fill = GridBagConstraints.HORIZONTAL;
        constraints.weighty = 1;
        constraints.insets = new Insets(10, 10, 10, 10);
        constraints.gridx = 1;
        constraints.gridwidth = 1;
        constraints.gridy = 5;
        add(cmbTarefas, constraints);

        btnStartTarefa.setFont(fontSergoe);
        btnStartTarefa.setBorder(borderRed);
        btnStartTarefa.setName("btnStartTarefa");
        btnStartTarefa.setForeground(txtColor);
        btnStartTarefa.setBackground(bgColor);
        btnStartTarefa.addActionListener(this);

        constraints.fill = GridBagConstraints.HORIZONTAL;
        constraints.weighty = 1;
        constraints.insets = new Insets(10, 10, 10, 10);
        constraints.gridx = 1;
        constraints.gridwidth = 1;
        constraints.gridy = 6;
        add(btnStartTarefa, constraints);

        btnStopTarefa.setFont(fontSergoe);
        btnStopTarefa.setBorder(borderRed);
        btnStopTarefa.setName("btnStopTarefa");
        btnStopTarefa.setForeground(txtColor);
        btnStopTarefa.setBackground(bgColor);
        btnStopTarefa.addActionListener(this);
        
        constraints.fill = GridBagConstraints.HORIZONTAL;
        constraints.weighty = 1;
        constraints.insets = new Insets(10, 10, 10, 10);
        constraints.gridx = 1;
        constraints.gridwidth = 1;
        constraints.gridy = 7;
        add(btnStopTarefa, constraints);

        setVisible(true);

        if (new ControllerComputador().inserePrimeiroComputador(codUsuario)) {
            new ControllerLeituraComputador().setLeitura(codUsuario);
        }
        listaTarefa = ControllerTarefa.getTarefa(codUsuario, cmbTarefas);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getSource() == btnStartTarefa) {
            try {
                ControllerTarefa.startTarefa(listaTarefa, cmbTarefas.getSelectedIndex(), codUsuario);
            } catch (SQLException ex) {
                Logger.getLogger(TelaCaptacao.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        if (e.getSource() == btnStopTarefa) {
            try {
                ControllerTarefa.desativaTarefa(codUsuario);
            } catch (SQLException ex) {
                Logger.getLogger(TelaCaptacao.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }
}
