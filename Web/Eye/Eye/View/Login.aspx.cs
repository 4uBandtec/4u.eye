using EYE.Controller;
using EYE.Model;
using System;

namespace Eye.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			new Sessao().PageLoadRedireciona();
		}

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            if (new ControllerWorkspace().Logar(txtWorkspacename, txtSenha))
            {
                Session["codWorkspace"] = new ControllerWorkspace().GetCodigo(txtWorkspacename.Text).ToString();
                Response.Redirect("./Dashboard.aspx");
            }
            else lblMensagem.Text = "Login Incorreto";
        }

        protected void btnIrPara_Click(object sender, EventArgs e)
        {
            Response.Redirect("./CadastroWorkspace.aspx");
        }
    }
}