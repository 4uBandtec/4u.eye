package br.com.eye.controller;

import oshi.SystemInfo;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.software.os.OperatingSystem;

public class ControllerComputador {

    SystemInfo si = new SystemInfo();

    public OperatingSystem getSistemaOperacional() {
        return si.getOperatingSystem();
    }

    public int getBit() {
        return si.getBitness();
    }
    HardwareAbstractionLayer hal = si.getHardware();
}
