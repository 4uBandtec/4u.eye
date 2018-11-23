using EYE.Controller;
using System;
using System.Globalization;

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
		}

		protected void btnCadastrar_Click(object sender, EventArgs e)
		{
			var codWorkspace = (string)Session["codWorkspace"];
			if (!new ControllerTarefa().Cadastrar(txtNome, txtDescricao, txtDataInicio, txtDataFim, txtDataConclusao, codWorkspace, lblMensagem))
			{
				return;
			}
		}
	}
}