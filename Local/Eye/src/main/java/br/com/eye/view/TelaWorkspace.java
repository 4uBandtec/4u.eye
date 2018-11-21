package br.com.eye.view;

import br.com.eye.controller.ControllerWorkspace;
import java.awt.Color;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JButton;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JTextField;
import javax.swing.border.LineBorder;

public class TelaWorkspace extends JFrame implements ActionListener {

    JTextField txtWorkspacename = new JTextField();

    JLabel lblWorkspacename = new JLabel("Workspacename");

    JButton btnProximo = new JButton("Proximo");

    GridBagConstraints constraints = new GridBagConstraints();

    Font fontSergoe = new Font("Sergou Ui Light", Font.PLAIN, 40);

    Color bgColor = new Color(26, 26, 26);
    Color txtColor = new Color(200, 200, 200);
    Color redColor = new Color(226, 26, 47);

    LineBorder borderRed = new LineBorder(redColor, 1);

    public TelaWorkspace() {
        setSize(500, 500);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setLayout(null);
        setLocationRelativeTo(null);
        setTitle("Workspace | EYE");

        setLayout(new GridBagLayout());
        getContentPane().setBackground(bgColor);

        constraints.fill = GridBagConstraints.HORIZONTAL;

        lblWorkspacename.setFont(fontSergoe);
        lblWorkspacename.setName("lblWorkspacename");

        lblWorkspacename.setForeground(txtColor);

        constraints.weightx = 1;
        constraints.fill = GridBagConstraints.HORIZONTAL;
        constraints.gridy = 1;
        constraints.gridx = 0;
        constraints.gridwidth = 3;

        add(lblWorkspacename, constraints);

        txtWorkspacename.setFont(fontSergoe);
        txtWorkspacename.setBorder(borderRed);
        txtWorkspacename.setName("txtWorkspacename");
        txtWorkspacename.setForeground(txtColor);
        txtWorkspacename.setBackground(bgColor);

        constraints.fill = GridBagConstraints.HORIZONTAL;
        constraints.weightx = 1;
        constraints.gridy = 2;
        constraints.gridx = 0;
        constraints.gridwidth = 3;
        add(txtWorkspacename, constraints);

        btnProximo.setFont(fontSergoe);
        btnProximo.setBorder(borderRed);
        btnProximo.setName("btnProximo");
        btnProximo.setForeground(txtColor);
        btnProximo.setBackground(bgColor);
        btnProximo.addActionListener(this);

        constraints.fill = GridBagConstraints.HORIZONTAL;
        constraints.weighty = 1;
        constraints.insets = new Insets(10, 10, 10, 10);
        constraints.gridx = 1;
        constraints.gridwidth = 1;
        constraints.gridy = 5;
        add(btnProximo, constraints);

        setVisible(true);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getSource() == btnProximo) {
            try {
<<<<<<< HEAD
                if (new ControllerWorkspace().ValidarWorkspace(txtWorkspacename.getText())) {
=======
                if (new ControllerWorkspace().WorkspaceValido(txtWorkspacename.getText())) {
>>>>>>> 4287f4d4939e422c23471e5bd48b4e22fd8b88fe
                    dispose();
                    new TelaLogin();
                }
            } catch (SQLException ex) {
                Logger.getLogger(TelaWorkspace.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }
}
