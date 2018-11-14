
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
        public long GetPorcentagemHD(int codComputador)
        {
            return StatementLeituraAtual.getHDAtual(codComputador);
        }
    }
}