package br.com.eye.view;

import br.com.eye.model.Usuario;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.util.ArrayList;
import java.util.List;
import javax.swing.JButton;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.JTextField;
import javax.swing.border.LineBorder;

public class TelaFuncionou extends JFrame implements ActionListener {

    JTextField  = new JTextField(),

    JLabel lblWorkspacename = new JLabel("Workspacename"),

    JButton btnProximo = new JButton("Logar");

    GridBagConstraints constraints = new GridBagConstraints();

    Font fontSergoe = new Font("Sergou Ui Light", Font.PLAIN, 40);

    Color bgColor = new Color(26, 26, 26);
    Color txtColor = new Color(200, 200, 200);
    Color redColor = new Color(226, 26, 47);

    LineBorder borderRed = new LineBorder(redColor, 1);

    public TelaFuncionou() {
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
        add(txtWorkspacename, constraints);
        
        setVisible(true);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
    }
}
