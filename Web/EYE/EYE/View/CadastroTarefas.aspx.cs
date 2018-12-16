using EYE.Controller;
using EYE.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace EYE.View
{

	public partial class CadastroTarefas : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			new Sessao().PageLoadRedirecionaLogin();
			txtDataInicio.Text = DateTime.Now.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
			var conteudo = new ControllerTarefa().CarregarPainel(new Sessao().RetornaSessaoWorkspace());
			pnlConfiguracao.Controls.Add(conteudo);
		}

		protected void btnAdicionar_Click(object sender, EventArgs e)
		{
			var conteudo = new ControllerTarefa().CarregarPainel(new Sessao().RetornaSessaoWorkspace());
			pnlConfiguracao.Controls.Add(conteudo);
		}

		[ScriptMethod, WebMethod]
		public static void BreakSession()
		{
			CadastroTarefas cadTarefa = new CadastroTarefas();
			cadTarefa.Session.Abandon();
		}

		[ScriptMethod, WebMethod]
		public static bool CadastraTarefa(string txtNome, string txtDescricao, string txtDataInicio, string txtDataFim, string lblMensagem,  List<string> listaCodUsersTarefa, List<string> listaProcTarefa, List<string> listaTempoTarefa, bool notificacaoEquipe, bool notificacaoUsuarios)
		{
			return !new ControllerTarefa().Cadastrar(txtNome, txtDescricao, txtDataInicio, txtDataFim, new Sessao().RetornaSessaoWorkspace(), lblMensagem, listaCodUsersTarefa, listaProcTarefa, listaTempoTarefa);
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {

            pnlOnline.Controls.Clear();
            var lista = ControllerComputador.RetornaUsuariosOnline(int.Parse((string)Session["codWorkspace"]));
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

        public int returnSession()
        {
            var codWorkspace = (string)Session["codWorkspace"];
            if (codWorkspace == null || codWorkspace == "0")
            {
                return 0;
            }
            else
            {
                return int.Parse((String)Session["codWorkspace"]);
            }
        }

        [ScriptMethod, WebMethod]
        public static int[] BuscaTemaModo()
        {

            var tema = ControllerTema.BuscaTema(new CadastroTarefas().returnSession());
            var modo = ControllerTema.BuscaModo(new CadastroTarefas().returnSession());

            int[] retorno = new int[2];
            retorno[0] = modo;
            retorno[1] = tema;

            return retorno;
        }

        [ScriptMethod, WebMethod]
        public static int BuscaTema()
        {
            return ControllerTema.BuscaTema(new CadastroTarefas().returnSession());
        }

        [ScriptMethod, WebMethod]
        public static int BuscaModo()
        {
            return ControllerTema.BuscaModo(new CadastroTarefas().returnSession());
        }

        [ScriptMethod, WebMethod]
        public static int BuscaIntensidade()
        {
            return ControllerTema.BuscaIntensidade(new CadastroTarefas().returnSession());
        }


        [ScriptMethod, WebMethod]
        public static bool TrocaTema(int novoTema)
        {
            bool tema = ControllerTema.TrocaTema(new CadastroTarefas().returnSession(), novoTema);

            return (tema);
        }


        [ScriptMethod, WebMethod]
        public static bool TrocaModo(int novoModo)
        {
            bool modo = ControllerTema.TrocaModo(new CadastroTarefas().returnSession(), novoModo);

            return (modo);
        }


        [ScriptMethod, WebMethod]
        public static bool TrocaIntensidade(int novaIntensidade)
        {
            bool intensidade = ControllerTema.TrocaIntensidade(new CadastroTarefas().returnSession(), novaIntensidade);

            return (intensidade);
        }
    }
}