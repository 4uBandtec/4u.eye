using System.Web.UI.WebControls;
using Eye.Controller;

namespace Eye.Model
{
    public class Monitor
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
        public LeituraAtual Leitura { get; set; }


        public int ContarComputadorUsuario(int codUsuario)
        {
            return ControllerComputador.ContarComputadorUsuario(codUsuario);
        }

        public Monitor[] ListarComputadoresUsuario(int codUsuario)
        {
            return ControllerComputador.ListarComputadoresUsuario(codUsuario);
        }

    }
}