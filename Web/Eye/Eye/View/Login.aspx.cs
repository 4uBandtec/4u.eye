
using Eye.Models;
using System;

namespace Eye.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            new Workspace().Logar(txtWorkspacename, txtSenha);
        }
    }
}