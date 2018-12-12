
namespace EYE.Model
{
	public class Sessao : System.Web.UI.Page
	{
		public void PageLoadRedirecionaLogin()
		{
			var codWorkspace = (string)Session["codWorkspace"];
			if (int.Parse(codWorkspace) == 0)
			{
				Response.Redirect("./Login.aspx");
			}
		}
		public int RetornaSessaoWorkspace()
		{
			var codWorkspace = (string)Session["codWorkspace"];
			return int.Parse(codWorkspace);
		}
	}
}