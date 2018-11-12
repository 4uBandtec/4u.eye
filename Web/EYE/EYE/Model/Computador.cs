using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EYE.Model
{
    public class Computador
    {
        public int CodComputador { get; set; }
        public string User { get; set; }
        public int Perfil { get; set; }
        public string NomeComputador { get; set; }
        public decimal DiscoTotal { get; set; }
        public decimal RAMTotal { get; set; }
        public string SistemaOperacional { get; set; }
        public string VersaoSistema { get; set; }
        public int VersaoBits { get; set; }
        public string Processador { get; set; }
        public int CodUsuario { get; set; }

        

    }
}