using Eye.Model;
using System;

namespace Eye.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var codWorkspace =(string)Session["codWorkspace"];
            if (codWorkspace != null && codWorkspace!="0")
            {
                Response.Redirect("./Dashboard.aspx");
            }
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            if (new Workspace().Logar(txtWorkspacename, txtSenha))
            {
                Session["codWorkspace"] = new Workspace().GetCodigo(txtWorkspacename.Text).ToString();
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