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
                return RAMAtual;
            }
            set
            {
                RAMAtual = value;
            }
        }

        public double HDAtual    // the Name property
        {
            get
            {
                return HDAtual;
            }
            set
            {
                HDAtual = value;
            }
        }

        public long CPUAtual    // the Name property
        {
            get
            {
                return CPUAtual;
            }
            set
            {
                CPUAtual = value;
            }
        }

    }
}