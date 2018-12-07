using EYE.Model.DAO;
using EYE.Model;
using System.Collections.Generic;

namespace EYE.Controller
{
    public class ControllerComputador
    {
        public int ContarComputadorUsuario(int codUsuario)
        {
            return StatementComputador.ContaComputador(codUsuario);
        }
        public Computador[] ListarComputadoresUsuario(int codUsuario)
        {
            return StatementComputador.ListarComputadores(codUsuario);
        }
		public static List<string> RetornaUsuariosOnline(int codWorkspace)
		{
			var computadores = StatementComputador.ListaUltimaLeituraComputador(codWorkspace);
			computadores = StatementComputador.AdicionaNomeUsuario(computadores);
			var lista = new List<string>();
			foreach (var item in computadores)
			{
				if (Computador.HoraAtualizada(item.UltimaLeitura))
					lista.Add(item.Nome);
			}

            lista.Add("teste1");
            lista.Add("teste da silva");
            lista.Add("testerônimo soares");
            lista.Add("gadwuhjkok ijmca kinkjkjk");
            lista.Add("teste1");
            lista.Add("teste da silva");
            lista.Add("testerônimo soares");
            lista.Add("gadwuhjkok ijmca kinkjkjk");
            lista.Add("NomeMuitoGrandeSemEspaçoPraTestarSeDáPraColocarUmNomeMuitoGrandeSemEspaço");
            lista.Add("teste1");
            lista.Add("teste da silva");
            lista.Add("testerônimo soares");
            lista.Add("gadwuhjkok ijmca kinkjkjk");
            lista.Add("teste1");
            lista.Add("teste da silva");
            lista.Add("testerônimo soares");
            lista.Add("gadwuhjkok ijmca kinkjkjk");
            lista.Add("teste1");
            lista.Add("teste da silva");
            lista.Add("testerônimo soares");
            lista.Add("gadwuhjkok ijmca kinkjkjk");
            lista.Add("NomeMuitoGrandeSemEspaçoPraTestarSeDáPraColocarUmNomeMuitoGrandeSemEspaço");
            lista.Add("teste1");
            lista.Add("teste da silva");
            lista.Add("testerônimo soares");
            lista.Add("gadwuhjkok ijmca kinkjkjk");
            lista.Add("teste1");
            lista.Add("teste da silva");
            lista.Add("testerônimo soares");
            lista.Add("gadwuhjkok ijmca kinkjkjk");
            lista.Add("teste1");
            lista.Add("teste da silva");
            lista.Add("testerônimo soares");
            lista.Add("gadwuhjkok ijmca kinkjkjk");
            lista.Add("NomeMuitoGrandeSemEspaçoPraTestarSeDáPraColocarUmNomeMuitoGrandeSemEspaço");
            lista.Add("teste1");
            lista.Add("teste da silva");
            lista.Add("testerônimo soares");
            lista.Add("gadwuhjkok ijmca kinkjkjk");
            return lista;
		}
	}
}