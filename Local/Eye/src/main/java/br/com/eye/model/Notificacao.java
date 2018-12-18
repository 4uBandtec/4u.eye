package br.com.eye.model;

import java.awt.AWTException;
import java.awt.Image;
import java.awt.SystemTray;
import java.awt.Toolkit;
import java.awt.TrayIcon;
import java.io.IOException;
import java.net.MalformedURLException;

public class Notificacao {

    public void construirNotificacaoLocal(String mensagem, TrayIcon.MessageType tipo) throws AWTException, MalformedURLException, IOException {
        SystemTray tray = SystemTray.getSystemTray();
        Image image = Toolkit.getDefaultToolkit().createImage(getClass().getResource("icon.png"));
        TrayIcon trayIcon = new TrayIcon(image, "");
        trayIcon.setImageAutoSize(true);
        tray.add(trayIcon);
        trayIcon.displayMessage("EYE", mensagem, tipo);
        LogMensagem.GravarLog("Notificação enviada para a aplicação Local");
    }
}
