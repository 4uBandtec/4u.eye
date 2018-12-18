using EYE.Controller;
using EYE.Model;
using System;

namespace EYE.View
{
	public partial class DashboardTarefa : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (new Sessao().RetornaSessaoWorkspace() == 0)
				Response.Redirect("./Login.aspx");

			new ControllerTarefa().ListarTarefas(new Sessao().RetornaSessaoWorkspace());
		}
	}
}