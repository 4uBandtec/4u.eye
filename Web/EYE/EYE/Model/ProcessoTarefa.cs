using System.Collections.Generic;

namespace EYE.Model
{
	public class ProcessoTarefa
	{

		private int codUsuario;
		private int codProcesso;
		private int tempoTarefa;

		public int CodUsuario { get => codUsuario; set => codUsuario = value; }
		public int CodProcesso { get => codProcesso; set => codProcesso = value; }
		public int TempoTarefa { get => tempoTarefa; set => tempoTarefa = value; }

		public static List<ProcessoTarefa> ConstruirLista(List<string> listaCodUsersTarefa, List<string> listaProcTarefa, List<string> listaTempoTarefa)
		{
			var lista = new List<ProcessoTarefa>();
			foreach (var usuario in listaCodUsersTarefa)
			{
				lista.Add(
					new ProcessoTarefa()
					{
						CodUsuario = int.Parse(usuario)
					});
			}
			var listaArray = lista.ToArray();
			var contador = 0;
			foreach (var processo in listaProcTarefa)
			{
				listaArray[contador].CodProcesso = int.Parse(processo);
				contador++;
			}
			contador = 0;
			foreach (var tempo in listaTempoTarefa)
			{
				listaArray[contador].TempoTarefa = int.Parse(tempo);
				contador++;
			}
			return lista;
		}
	}

}