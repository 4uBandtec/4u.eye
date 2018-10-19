package br.com.eye.controller;

import oshi.SystemInfo;
import oshi.hardware.CentralProcessor;
import oshi.hardware.GlobalMemory;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.software.os.OperatingSystem;
import oshi.util.FormatUtil;

public class ControllerComputador {

    SystemInfo systemInfo = new SystemInfo();

    HardwareAbstractionLayer hal = systemInfo.getHardware();

    public void getCodigoComputador() {
       //Banco
       //
    }
    public void getNomeComputador() {
       //Banco
       //
    }
    
    public OperatingSystem getSistemaOperacional() {
        return systemInfo.getOperatingSystem();
    }

    public void getVersaoProcessador() {
        //
        //
    }

    public int getBit() {
        return systemInfo.getOperatingSystem().getBitness();
    }

    public CentralProcessor getProcessador() {
        return hal.getProcessor();
    }

    public double getCPU() {
        return hal.getProcessor().getSystemCpuLoad();
    }

    public void getDisco() {
        //
        //
    }

    public long getMemoria() {
        return hal.getMemory().getTotal();
    }
    
    
}
