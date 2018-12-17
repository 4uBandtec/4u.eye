using EYE.Controller;
using EYE.Model;
using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace Eye.View
{
	public partial class Dashboard : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (new Sessao().RetornaSessaoWorkspace() == 0)
				Response.Redirect("./Login.aspx");
		}

		[ScriptMethod, WebMethod]
		public static void BreakSession()
		{
			Dashboard dash = new Dashboard();
			dash.Session.Abandon();
		}

		[ScriptMethod, WebMethod]
		public static Usuario[] GetUsuariosWorkspace()
		{
			ControllerUsuario controllerUsuario = new ControllerUsuario();

			Dashboard dash = new Dashboard();

			int totalUserWorkspace = controllerUsuario.ContaUsuarioWorkspace(new Sessao().RetornaSessaoWorkspace());
			Usuario[] usuarios = controllerUsuario.ListarUsuarios(new Sessao().RetornaSessaoWorkspace());

			ControllerComputador controllerComputador = new ControllerComputador();
			for (int i = 0; i < totalUserWorkspace; i++)
			{
				Computador[] computadores = new Computador[controllerComputador.ContarComputadorUsuario(usuarios[i].CodUsuario)];

				computadores = controllerComputador.ListarComputadoresUsuario(usuarios[i].CodUsuario);

				usuarios[i].ComputadoresUsuario = computadores;
			}

			return usuarios;
		}

		[ScriptMethod, WebMethod]
		public static LeituraAtual AtualizarComputadores(int codComputador)
		{

			LeituraAtual leitura = new LeituraAtual();

			ControllerLeituraAtual controllerLeituraAtual = new ControllerLeituraAtual();

			leitura.CpuAtual = controllerLeituraAtual.GetPorcentagemCPU(codComputador);
			leitura.HdAtual = controllerLeituraAtual.GetPorcentagemHD(codComputador);
			leitura.RamAtual = controllerLeituraAtual.GetPorcentagemRAM(codComputador);
			leitura.UltimaLeitura = controllerLeituraAtual.getUltimaLeitura(codComputador);
			leitura.CodComputador = codComputador;



			return leitura;
		}

		protected void Timer_Tick(object sender, EventArgs e)
		{

			pnlOnline.Controls.Clear();
			var lista = ControllerComputador.RetornaUsuariosOnline(new Sessao().RetornaSessaoWorkspace());
			var index = 0;
			foreach (var item in lista)
			{
				Label lblUser = new Label();
				lblUser.ID = "lblUser" + index;
				lblUser.CssClass = "lblUser";
				lblUser.Text = $"{item}";
				index++;
				pnlOnline.Controls.Add(lblUser);
			}
		}



		[ScriptMethod, WebMethod]
		public static List<string> RetornaUsuariosOnlineMonitor()
		{
			return ControllerComputador.RetornaUsuariosOnline(new Sessao().RetornaSessaoWorkspace());
		}

		[ScriptMethod, WebMethod]
		public static int[] BuscaTemaModo()
		{

			var tema = ControllerTema.BuscaTema(new Sessao().RetornaSessaoWorkspace());
			var modo = ControllerTema.BuscaModo(new Sessao().RetornaSessaoWorkspace());

			int[] retorno = new int[2];
			retorno[0] = modo;
			retorno[1] = tema;

			return retorno;
		}

		[ScriptMethod, WebMethod]
		public static int BuscaTema()
		{
			return ControllerTema.BuscaTema(new Sessao().RetornaSessaoWorkspace());
		}

		[ScriptMethod, WebMethod]
		public static int BuscaModo()
		{
			return ControllerTema.BuscaModo(new Sessao().RetornaSessaoWorkspace());
		}

		[ScriptMethod, WebMethod]
		public static int BuscaIntensidade()
		{
			return ControllerTema.BuscaIntensidade(new Sessao().RetornaSessaoWorkspace());
		}


		[ScriptMethod, WebMethod]
		public static bool TrocaTema(int novoTema)
		{
			bool tema = ControllerTema.TrocaTema(new Sessao().RetornaSessaoWorkspace(), novoTema);

			return (tema);
		}


		[ScriptMethod, WebMethod]
		public static bool TrocaModo(int novoModo)
		{
			bool modo = ControllerTema.TrocaModo(new Sessao().RetornaSessaoWorkspace(), novoModo);

			return (modo);
		}


		[ScriptMethod, WebMethod]
		public static bool TrocaIntensidade(int novaIntensidade)
		{
			bool intensidade = ControllerTema.TrocaIntensidade(new Sessao().RetornaSessaoWorkspace(), novaIntensidade);

			return (intensidade);
		}
	}
}