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
            Valida.StringVazia(txtWorkspacename, txtSenha);
            return (new ControllerWorkspace().AutenticarWorkspace(txtWorkspacename.Text, txtSenha.Text));
        }
        public bool Cadastrar(TextBox txtWorkspacename, TextBox txtNome, TextBox txtEmail, TextBox txtSenha)
        {
            Valida.StringVazia(txtWorkspacename, txtNome, txtEmail, txtSenha);
            Valida.Email(txtEmail);
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
    }
}

