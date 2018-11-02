using Eye.Model;
using System;

namespace Eye.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((int)Session["codWorkspace"] != 0)
            {
                Response.Redirect("area_inicio/monitor.aspx");
            }
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            if (new Workspace().Logar(txtWorkspacename, txtSenha))
            {
                Session["codWorkspace"] = new Workspace().GetCodigo(txtWorkspacename.Text);
            }
            else lblMensagem.Text = "Login Incorreto";
        }
    }
}