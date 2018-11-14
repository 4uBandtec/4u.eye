
namespace EYE.Model
{
    public class LeituraAtual
    {
        private double ramAtual;
        private double cpuAtual;
        private long hdAtual;


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

    }
}