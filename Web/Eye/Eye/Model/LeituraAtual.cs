namespace Eye.Model
{
    public class LeituraAtual
    {
        public double RAMAtual { get; set; }
        public long CPUAtual { get; set; }
        public double DiscoAtual { get; set; }

        public double GetPorcentagemRAM()
        {
            return 0;
        }
        public double GetPorcentagemCPU()
        {
            return 0;
        }
        public double GetPorcentagemDisco()
        {
            return 0;
        }
    }
    
}