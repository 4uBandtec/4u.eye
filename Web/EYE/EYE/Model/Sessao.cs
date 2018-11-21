using System;

namespace EYE.Model
{
	public class Sessao : System.Web.UI.Page
	{
		public static  int RetornaSessao()
		{
			return int.Parse((String)Session["codWorkspace"]);
		}
	}
}