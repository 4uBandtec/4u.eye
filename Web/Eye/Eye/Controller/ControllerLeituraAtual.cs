using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EYE.Model.DAO;

namespace EYE.Controller
{
    public class ControllerLeituraAtual
    {
        public double GetPorcentagemRAM(int codComputador)
        {
            return StatementLeituraAtual.getRAMAtual(codComputador);
        }
        public double GetPorcentagemCPU(int codComputador)
        {
            return StatementLeituraAtual.getCPUAtual(codComputador);
        }
        public double GetPorcentagemHD(int codComputador)
        {
            return StatementLeituraAtual.getHDAtual(codComputador);
        }
    }
}