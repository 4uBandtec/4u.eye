package br.com.eye.view;

import br.com.eye.controller.ControllerUsuario;
import br.com.eye.model.LogMensagem;
import java.awt.Color;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JTextField;
import javax.swing.border.LineBorder;

public class TelaLogin extends JFrame implements ActionListener {

    JTextField txtUsername = new JTextField(),
            txtSenha = new JTextField();

    JLabel lblNome = new JLabel("Nome"),
            lblSenha = new JLabel("Senha");

    JButton btnLogar = new JButton("Logar");

    GridBagConstraints constraints = new GridBagConstraints();

    Font fontSergoe = new Font("Sergou Ui Light", Font.PLAIN, 40);

    Color bgColor = new Color(26, 26, 26);
    Color txtColor = new Color(200, 200, 200);
    Color redColor = new Color(226, 26, 47);

    LineBorder borderRed = new LineBorder(redColor, 1);

    public TelaLogin() {
        setSize(500, 500);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLayout(null);
        setLocationRelativeTo(null);
        setTitle("Login | EYE");

        setLayout(new GridBagLayout());
        getContentPane().setBackground(bgColor);

        constraints.fill = GridBagConstraints.HORIZONTAL;

        lblNome.setFont(fontSergoe);
        lblNome.setName("lblNome");

        lblNome.setForeground(txtColor);

        constraints.weightx = 1;
        constraints.fill = GridBagConstraints.HORIZONTAL;
        constraints.gridy = 1;
        constraints.gridx = 0;
        constraints.gridwidth = 3;

        add(lblNome, constraints);

        txtUsername.setFont(fontSergoe);
        txtUsername.setBorder(borderRed);
        txtUsername.setName("txtUsername");
        txtUsername.setForeground(txtColor);
        txtUsername.setBackground(bgColor);

        constraints.fill = GridBagConstraints.HORIZONTAL;
        constraints.weightx = 1;
        constraints.gridy = 2;
        constraints.gridx = 0;
        constraints.gridwidth = 3;
        add(txtUsername, constraints);

        lblSenha.setFont(fontSergoe);
        lblSenha.setName("lblSenha");
        lblSenha.setForeground(txtColor);

        constraints.weightx = 1;
        constraints.fill = GridBagConstraints.HORIZONTAL;
        constraints.gridy = 3;
        constraints.gridx = 0;
        constraints.gridwidth = 3;
        add(lblSenha, constraints);

        txtSenha.setFont(fontSergoe);
        txtSenha.setName("txtSenha");
        txtSenha.setForeground(txtColor);
        txtSenha.setBorder(borderRed);
        txtSenha.setBackground(bgColor);

        constraints.fill = GridBagConstraints.HORIZONTAL;
        constraints.weightx = 1;
        constraints.gridy = 4;
        constraints.gridx = 0;
        constraints.gridwidth = 3;
        add(txtSenha, constraints);

        btnLogar.setFont(fontSergoe);
        btnLogar.setBorder(borderRed);
        btnLogar.setName("btnLogar");
        btnLogar.setForeground(txtColor);
        btnLogar.setBackground(bgColor);
        btnLogar.addActionListener(this);

        constraints.fill = GridBagConstraints.HORIZONTAL;
        constraints.weighty = 1;
        constraints.insets = new Insets(10, 10, 10, 10);
        constraints.gridx = 1;
        constraints.gridwidth = 1;
        constraints.gridy = 5;
        add(btnLogar, constraints);

        setVisible(true);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        try {
            if (e.getSource() == btnLogar) {

                if (new ControllerUsuario().Logar(txtUsername.getText(), txtSenha.getText())) {
                    dispose();
                     LogMensagem.GravarLog("Login Identificado");
                    new TelaFuncionou(new ControllerUsuario().getCodUsuario(txtUsername.getText()));
                }
            }
        } catch (InterruptedException | SQLException ex) {
            Logger.getLogger(TelaLogin.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(TelaLogin.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
