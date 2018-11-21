
namespace EYE.Model
{
    public class LeituraAtual
    {
        private double ramAtual;
        private double cpuAtual;
        private long hdAtual;
        private int codComputador;

		public double RamAtual { get => ramAtual; set => ramAtual = value; }
		public double CpuAtual { get => cpuAtual; set => cpuAtual = value; }
		public long HdAtual { get => hdAtual; set => hdAtual = value; }
		public int CodComputador { get => codComputador; set => codComputador = value; }
	}
}