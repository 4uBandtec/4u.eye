
using EYE.Model.DAO;
using EYE.Model;
using System.Web.UI.WebControls;

namespace EYE.Controller
{
    public class ControllerWorkspace
    {
        public bool Logar(TextBox txtWorkspacename, TextBox txtSenha)
        {

            
            if (!Validacao.StringVazia(txtWorkspacename, txtSenha))
            {
                return false;
            }


            var salt = StatementWorkspace.BuscaSalt(txtWorkspacename.Text);
            var senhaBanco = StatementWorkspace.BuscaSenhaHash(txtWorkspacename.Text);

            return ValidaSenha(senhaBanco, txtSenha.Text, salt);
            
        }
        
        public int GetCodigo(string workspacename)
        {
            return StatementWorkspace.BuscaCodigo(workspacename);
        }

        public static bool ValidaSenha(string senhaBanco, string senha, int salt)
        {
            if (senhaBanco == null || senhaBanco == "") {
                return false;
            }
            return senhaBanco.Equals(Criptografia.GerarSenhaHash(senha, salt));
        }

        public static bool VerificaEmailUnico(string email)
        {
            return StatementWorkspace.VerificaEmailUnico(email);
        }

        public static bool VerificaWorkspacenameUnico(string workspacename)
        {
            return StatementWorkspace.VerificaWorkspacenameUnico(workspacename);
        }


        public bool Cadastrar(TextBox txtWorkspacename, TextBox txtNome, TextBox txtEmail, TextBox txtSenha, Label lblMensagem)
        {
            if (!Validacao.StringVazia(txtWorkspacename, txtNome, txtEmail, txtSenha))
            {
                lblMensagem.Text = "Parece que você digitou algo errado, certifique-se de que não esqueceu nada";//Trocar essa frase
                return false;
            }
            else if (!Validacao.Email(txtEmail))
            {
                lblMensagem.Text = "Parece que você digitou algo errado, certifique-se de que não esqueceu nada";//Trocar essa frase
                return false;
            }
            else if (!VerificaWorkspacenameUnico(txtWorkspacename.Text))
            {
                lblMensagem.Text = "Ops, já existe um Workspace chamado " + txtWorkspacename.Text + ", tente outra coisa.";
                return false;
            }

            else if (!VerificaEmailUnico(txtEmail.Text))
            {
                lblMensagem.Text = "Calma aí, parece que o email escolhido já está sendo usado, por favor digite outro.";
                return false;
            }

            var workspace = new Workspace
            {
                Workspacename = txtWorkspacename.Text,
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Senha = txtSenha.Text
            };

            workspace.Salt = Criptografia.GerarSalt();
            workspace.Senha = Criptografia.GerarSenhaHash(workspace.Senha, workspace.Salt);
            return StatementWorkspace.InserirWorkspace(workspace);
        }

    }
}