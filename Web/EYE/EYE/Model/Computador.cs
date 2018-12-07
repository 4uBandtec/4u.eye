using System;

namespace EYE.Model
{
    public class Computador
    {
		private const int INDEX_DATA = 0;
		private const int INDEX_HORA = 1;

		private int codComputador;
        private string user;
		private string nome;
		private int perfil;
        private string nomeComputador;
        private decimal hdTotal;
        private decimal ramTotal;
        private string sistemaOperacional;
        private string versaoSistema;
        private int versaoBits;
        private string processador;
        private int codUsuario;
		private string ultimaLeitura;

		public int CodComputador { get => codComputador; set => codComputador = value; }
		public string User { get => user; set => user = value; }
		public string Nome { get => nome; set => nome = value; }
		public int Perfil { get => perfil; set => perfil = value; }
		public string NomeComputador { get => nomeComputador; set => nomeComputador = value; }
		public decimal HdTotal { get => hdTotal; set => hdTotal = value; }
		public decimal RamTotal { get => ramTotal; set => ramTotal = value; }
		public string SistemaOperacional { get => sistemaOperacional; set => sistemaOperacional = value; }
		public string VersaoSistema { get => versaoSistema; set => versaoSistema = value; }
		public int VersaoBits { get => versaoBits; set => versaoBits = value; }
		public string Processador { get => processador; set => processador = value; }
		public int CodUsuario { get => codUsuario; set => codUsuario = value; }
		public string UltimaLeitura { get => ultimaLeitura; set => ultimaLeitura = value; }

		public static bool HoraAtualizada(string tempoCompleto)
		{
			var dataCompleta = tempoCompleto.Split(' ');
			var datas = dataCompleta[INDEX_DATA].Split('/');
			var horas = dataCompleta[INDEX_HORA].Split(':');
			var ano = int.Parse(datas[2]);
			var mes = int.Parse(datas[1]);
			var dia = int.Parse(datas[0]);
			var segundo = int.Parse(horas[2]);
			var minuto = int.Parse(horas[1]);
			var hora = int.Parse(horas[0]);

			var dataBanco = new DateTime(ano, mes, dia, hora, minuto, segundo);
			var dataAtrasada = DateTime.Now.AddMinutes(-5);
			return dataBanco > dataAtrasada;
		}
	}
}