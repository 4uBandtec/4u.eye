using EYE.Controller;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Script.Services;
using System.Web.Services;

namespace EYE.View
{

	public partial class CadastroTarefas : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
		{
			var codWorkspace = (string)Session["codWorkspace"];
			if (codWorkspace == null || codWorkspace == "0")
			{
				Response.Redirect("./Login.aspx");
			}
			txtDataInicio.Text= DateTime.Now.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
            var conteudo = new ControllerTarefa().CarregarPainel(int.Parse(codWorkspace));
            pnlConfiguracao.Controls.Add(conteudo);
        }

		protected void btnCadastrar_Click(object sender, EventArgs e)
		{
			var codWorkspace = (string)Session["codWorkspace"];
			if (!new ControllerTarefa().Cadastrar(txtNome, txtDescricao, txtDataInicio, txtDataFim, codWorkspace, lblMensagem))
			{
				return;
			}
		}
        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            var codWorkspace = (string)Session["codWorkspace"];
            var conteudo = new ControllerTarefa().CarregarPainel(int.Parse(codWorkspace));
            pnlConfiguracao.Controls.Add(conteudo);
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
        public static void BreakSession()
        {
            CadastroTarefas cadTarefa = new CadastroTarefas();
            cadTarefa.Session.Abandon();
        }

        [ScriptMethod, WebMethod]
        public static bool CadastraTarefa(List<string> listaCodUsersTarefa, List<string> listaProcTarefa, List<string> listaTempoTarefa)
        {
            int codWorkspace = new CadastroTarefas().returnSession();

            //Livia coloca a função de cadastrar tarefa aqui;
            //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

            return true;
        }
    }
}