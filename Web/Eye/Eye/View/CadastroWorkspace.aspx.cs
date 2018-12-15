using EYE.Controller;
using EYE.Model;
using System;

namespace Eye.View
{
    public partial class CadastroWorkspace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			new Sessao().PageLoadRedireciona();
		}

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!new ControllerWorkspace().Cadastrar(txtWorkspacename, txtNome, txtEmail, txtSenha, lblMensagem))
            {
                return;

            }
            Response.Redirect("./Login.aspx");//Ou chamar um metodo que limpa os campos e mostra "Cadastro efetuado"
        }

        protected void btnIrParaLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Login.aspx");

        }
    }
}