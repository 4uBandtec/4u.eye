using System.Web.UI.WebControls;
using Eye.Models;
namespace Eye.Models

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

            return true;
        }
    }

  
}
