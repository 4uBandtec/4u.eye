using System;

namespace EYE.Model
{
	public class Sessao : System.Web.UI.Page
	{
		public int RetornaSessaoWorkspace()
		{
			var sucesso = Int32.TryParse((string)Session["codWorkspace"], out int codWorkspace);
			return codWorkspace;
		}
	}
}