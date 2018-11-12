
namespace EYE.Model
{
    public class LeituraAtual
    {
        private double ramAtual;
        private long cpuAtual;
        private double hdAtual;


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

        public double HDAtual
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

        public long CPUAtual
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