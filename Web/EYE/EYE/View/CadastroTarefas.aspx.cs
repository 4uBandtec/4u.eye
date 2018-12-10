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
		public static bool CadastraTarefa(TextBox txtNome, TextBox txtDescricao, TextBox txtDataInicio, TextBox txtDataFim, Label lblMensagem,  List<string> listaCodUsersTarefa, List<string> listaProcTarefa, List<string> listaTempoTarefa)
		{
			return !new ControllerTarefa().Cadastrar(txtNome, txtDescricao, txtDataInicio, txtDataFim, new Sessao().RetornaSessaoWorkspace(), lblMensagem, listaCodUsersTarefa, listaProcTarefa, listaTempoTarefa);
        }
	}
}