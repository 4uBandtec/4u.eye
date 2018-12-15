namespace EYE.Model
{
	public class Sessao : System.Web.UI.Page
	{
		public void PageLoadRedireciona()
		{
			var codWorkspace = (string)Session["codWorkspace"];
			if (int.Parse(codWorkspace) == 0)

				Response.Redirect("./Login.aspx");			
			else 
				Response.Redirect("./Dashboard.aspx");			
		}
		public int RetornaSessaoWorkspace()
		{
			var codWorkspace = (string)Session["codWorkspace"];
			return int.Parse(codWorkspace);
		}
	}
}