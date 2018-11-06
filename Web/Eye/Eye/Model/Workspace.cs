using Eye.Controller;
using System.Web.UI.WebControls;
namespace Eye.Model

{
    public class Workspace
    {
        public int CodWorkspace { get; set; }
        public string Workspacename { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Salt { get; set; }

        public bool Logar(TextBox txtWorkspacename, TextBox txtSenha)
        {
            if (!Valida.StringVazia(txtWorkspacename, txtSenha))
            {
                return false;
            }

            if (!new ControllerWorkspace().AutenticarWorkspace(txtWorkspacename.Text, txtSenha.Text))
            {
                txtWorkspacename.Focus();
                return false;
            }
            return (new ControllerWorkspace().AutenticarWorkspace(txtWorkspacename.Text, txtSenha.Text));
        }
        public bool Cadastrar(TextBox txtWorkspacename, TextBox txtNome, TextBox txtEmail, TextBox txtSenha, Label lblMensagem)
        {
            if (!Valida.StringVazia(txtWorkspacename, txtNome, txtEmail, txtSenha))
            {
                lblMensagem.Text = "Parece que você digitou algo errado, certifique-se de que não esqueceu nada";//Trocar essa frase
                return false;
            }
            else if (!Valida.Email(txtEmail))
            {
                lblMensagem.Text = "Parece que você digitou algo errado, certifique-se de que não esqueceu nada";//Trocar essa frase
                return false;
            }
            else if (!new Workspace().WorkspacenameJaExiste(txtWorkspacename))
            {
                lblMensagem.Text = "Ops, já existe um Workspace chamado " + txtWorkspacename.Text + ", tente outra coisa.";
                return false;
            }

            else if (!new Workspace().EmailJaExiste(txtEmail))
            {
                lblMensagem.Text = "Calma aí, parece que o email escolhido já está sendo usado, por favor digite outro.";
                return false;
            }
            var workspace = new Workspace();
            workspace.Workspacename = txtWorkspacename.Text;
            workspace.Nome = txtNome.Text;
            workspace.Email = txtEmail.Text;
            workspace.Senha = txtSenha.Text;

            return (new ControllerWorkspace().Cadastrar(workspace));
        }
        public int GetCodigo(string workspace)
        {
            return new ControllerWorkspace().GetCodigo(workspace);
        }

        public bool EmailJaExiste(TextBox txtEmail)
        {
            return new ControllerWorkspace().VerificaEmailUnico(txtEmail.Text);
        }

        public bool WorkspacenameJaExiste(TextBox txtWorkspacename)
        {
            return new ControllerWorkspace().VerificaWorkspacenameUnico(txtWorkspacename.Text);
        }
    }
}

