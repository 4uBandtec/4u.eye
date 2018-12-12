using EYE.Controller;
using System;

namespace EYE.View
{
	public partial class ExibirUsuario : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
	
			var codWorkspace = (string)Session["codWorkspace"];
			if (codWorkspace == null || codWorkspace == "0")
			{
				Response.Redirect("./Login.aspx");
			}			
				CarregarPainel();
		}
		public void CarregarPainel() {
			var codWorkspace = (string)Session["codWorkspace"];
			//pnlUsuario.Controls.Clear();
			//pnlUsuario.Dispose();
			pnlUsuario.Controls.Add(ControllerUsuario.CarregarPainel(int.Parse(codWorkspace)));
		}
	}
}