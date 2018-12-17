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
			if (new Sessao().RetornaSessaoWorkspace() == 0)
				Response.Redirect("./Login.aspx");

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
			return !new ControllerTarefa().Cadastrar(txtNome, txtDescricao, txtDataInicio, txtDataFim, new Sessao().RetornaSessaoWorkspace(), lblMensagem, listaCodUsersTarefa, listaProcTarefa, listaTempoTarefa, notificacaoEquipe, notificacaoUsuarios);
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