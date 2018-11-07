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

        public Monitor[] ComputadoresUsuario { get; set; }

        public bool Cadastrar(TextBox txtUsername, TextBox txtNome, TextBox txtEmail, TextBox txtSenha, TextBox txtDataNascimento, DropDownList ddlSexo, string codWorkspace, Label lblMensagem)
        {
            if (!Valida.StringVazia(txtUsername, txtNome, txtEmail, txtSenha, txtDataNascimento))
            {
                lblMensagem.Text = "Parece que você digitou algo errado, certifique-se de que não esqueceu nada";
                return false;
            }
            else if (!Valida.DropDownListVazia(ddlSexo))
            {
                lblMensagem.Text = "Você não me disse seu sexo, por favor escolha um";
                return false;
            }
            else if (!UsernameJaExiste(txtUsername))
            {
                lblMensagem.Text = "Má noticia, alguém já tem o Username " + txtUsername.Text + ", seja mais criativo";
                return false;
            }
            else if (!EmailJaExiste(txtEmail))
            {
                lblMensagem.Text = "Alguém já usa esse e-mail, ele não pode ser usado de novo";
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

            if (ControllerUsuario.Cadastrar(usuario)){
                lblMensagem.Text = "O novo usuário foi cadastrado, dê as boas vindas á ele por mim";

                txtUsername.Text = "";
                txtNome.Text = "";
                txtEmail.Text = "";
                txtSenha.Text = "";
                txtDataNascimento.Text = "";
                ddlSexo.SelectedValue = "";

                return true;
            }
            lblMensagem.Text = "Ops, deu algo errado, acho que a culpa é nossa";
            return false;
        }
        public bool EmailJaExiste(TextBox txtEmail)
        {
            return ControllerUsuario.VerificaEmailUnico(txtEmail.Text);
        }

        public bool UsernameJaExiste(TextBox txtUsername)
        {
            return ControllerUsuario.VerificaUsernameUnico(txtUsername.Text);
        }

        public int ContaUsuariosWorkspace(int codWorkspace)
        {
            return ControllerUsuario.ContaUsuarioWorkspace(codWorkspace);
        }

        public Usuario[] ListarUsuarios(int codWorkspace)
        {
            return ControllerUsuario.ListarUsuarios(codWorkspace);
        }
    }
}