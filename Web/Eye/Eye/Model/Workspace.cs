using Eye.Controller;
using System.Web.UI.WebControls;
namespace Eye.Model

{
    public class Workspace
    {
        private int CodWorkspace { get; set; }
        private string Workspacename { get; set; }
        private string Senha { get; set; }
        private string Salt { get; set; }
        public bool Logar(TextBox txtWorkspacename, TextBox txtSenha)
        {
            Valida.StringVazia(txtWorkspacename, txtSenha);
            return (new ControllerWorkspace().AutenticaWorkspace(txtWorkspacename.Text, txtSenha.Text));
        }
        public int GetCodigo(string workspace)
        {
            return new ControllerWorkspace().GetCodigo(workspace);
        }
    }
}
