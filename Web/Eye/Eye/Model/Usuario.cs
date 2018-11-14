using Eye.Controller;
using System.Web.UI.WebControls;

namespace Eye.Model
{
    public class Usuario
    {
        public int CodUsuario { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public int Salt { get; set; }
        public string CodWorkspace { get; set; }

        public bool Cadastrar(TextBox txtUsername, TextBox txtNome, TextBox txtEmail, TextBox txtSenha, TextBox txtDataNascimento, DropDownList ddlSexo, string codWorkspace, Label lblMensagem)
        {
            if (!Valida.StringVazia(txtUsername, txtNome, txtEmail, txtSenha, txtDataNascimento))
            {
                lblMensagem.Text = "Parece que você digitou algo errado, certifique-se de que não esqueceu nada";//Trocar essa frase
                return false;
            }
            else if (!Valida.DropDownListVazia(ddlSexo))
            {
                lblMensagem.Text = "Parece que você digitou algo errado, certifique-se de que não esqueceu nada";//Trocar essa frase
                return false;
            }
            else if (!UsernameJaExiste(txtUsername))
            {
                lblMensagem.Text = "Ops, já existe um Usuario chamado " + txtUsername.Text + ", tente outra coisa.";
                return false;
            }
            else if (!EmailJaExiste(txtEmail))
            {
                lblMensagem.Text = "Calma aí, parece que o email escolhido já está sendo usado, por favor digite outro.";
                return false;
            }
            var usuario = new Usuario();
            usuario.Username = txtUsername.Text;
            usuario.Nome = txtNome.Text;
            usuario.Email = txtEmail.Text;
            usuario.Senha = txtSenha.Text;
            usuario.DataNascimento = txtDataNascimento.Text;
            usuario.Sexo = ddlSexo.SelectedValue;
            usuario.CodWorkspace = codWorkspace;
            return (ControllerUsuario.Cadastrar(usuario));
        }
        public bool EmailJaExiste(TextBox txtEmail)
        {
            return ControllerUsuario.VerificaEmailUnico(txtEmail.Text);
        }

        public bool UsernameJaExiste(TextBox txtUsername)
        {
            return ControllerUsuario.VerificaUsernameUnico(txtUsername.Text);
        }
    }
}