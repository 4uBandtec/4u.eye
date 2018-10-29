/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.com.eye.controller;

import java.util.ArrayList;
import java.util.List;
import oshi.SystemInfo;
import oshi.hardware.CentralProcessor;
import oshi.hardware.HWDiskStore;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.software.os.FileSystem;
import oshi.software.os.OSFileStore;

/**
 *
 * @author Aluno
 */
public class ControllerLeituraComputador {
    
    
    
    SystemInfo systemInfo = new SystemInfo();
    HardwareAbstractionLayer hardware = systemInfo.getHardware();
    CentralProcessor processor = hardware.getProcessor();
    FileSystem fileSystem = systemInfo.getOperatingSystem().getFileSystem();
    
    
    public double getCPUUsada(){
        Double cl = processor.getSystemCpuLoad();
        return cl*100.0;
    }
    
    public double getMemoriaDisponivel(){
        return systemInfo.getHardware().getMemory().getAvailable();
    }
    
    public long getDiscoDisponivel(){
        OSFileStore[] fsArray = fileSystem.getFileStores();
        
        
        long disponivel = 0;
        
        for (OSFileStore fs : fsArray) {

            disponivel += fs.getUsableSpace();

        }
        
           return disponivel;
    }
    
}
