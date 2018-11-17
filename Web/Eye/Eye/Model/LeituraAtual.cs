
namespace EYE.Model
{
    public class LeituraAtual
    {
        private double ramAtual;
        private double cpuAtual;
        private long hdAtual;
        private int codComputador;


        public double RAMAtual
        {
            get
            {
                return ramAtual;
            }
            set
            {
                ramAtual = value;
            }
        }

        public long HDAtual
        {
            get
            {
                return hdAtual;
            }
            set
            {
                hdAtual = value;
            }
        }

        public double CPUAtual
        {
            get
            {
                return cpuAtual;
            }
            set
            {
                cpuAtual = value;
            }
        }

        public int CodComputador
        {
            get
            {
                return codComputador;
            }
            set
            {
                codComputador = value;
            }
        }

    }
}