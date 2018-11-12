using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EYE.Model
{
    public class LeituraAtual
    {
        private double ramAtual;
        private long cpuAtual;
        private double hdAtual;


        public double RAMAtual    // the Name property
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

        public double HDAtual    // the Name property
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

        public long CPUAtual    // the Name property
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