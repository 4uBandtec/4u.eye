
using EYE.Model.DAO;

namespace EYE.Controller
{
    public class ControllerLeituraAtual
    {
        public double GetPorcentagemRAM(int codComputador)
        {
            return StatementLeituraAtual.GetRAMAtual(codComputador);
        }
        public double GetPorcentagemCPU(int codComputador)
        {
            return StatementLeituraAtual.GetCPUAtual(codComputador);
        }
        public long GetPorcentagemHD(int codComputador)
        {
            return StatementLeituraAtual.GetHDAtual(codComputador);
        }
        public string getUltimaLeitura(int codComputador)
        {
            return StatementLeituraAtual.GetUltimaLeitura(codComputador);
        }
    }
}