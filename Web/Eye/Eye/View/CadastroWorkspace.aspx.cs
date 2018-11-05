using Eye.Model;
using System;

namespace Eye.View
{
    public partial class CadastroWorkspace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var codWorkspace = (string)Session["codWorkspace"];
            if (codWorkspace != null && codWorkspace != "0")
            {
                Response.Redirect("./Dashboard.html");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!new Workspace().WorkspacenameJaExiste(txtWorkspacename))
            {
                lblMensagem.Text = "Ops, já existe um Workspace chamado " + txtWorkspacename.Text + ", tente outra coisa.";
            }
            
            else if (!new Workspace().EmailJaExiste(txtEmail))
            {
                lblMensagem.Text = "Calma aí, parece que o email escolhido já está sendo usado, por favor digite outro.";
            }

            else if (new Workspace().Cadastrar(txtWorkspacename, txtNome, txtEmail, txtSenha))
            {
                Response.Redirect("./Login.aspx");//Ou chamar um metodo que limpa os campos e mostra "Cadastro efetuado"
            }
            else
            {
                lblMensagem.Text = "Parece que você digitou algo errado, certifique-se de que não esqueceu nada";
            }
        }

        protected void btnIrParaLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Login.aspx");

        }
    }
}