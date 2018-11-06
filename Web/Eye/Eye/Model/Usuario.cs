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

        public bool Cadastrar(TextBox txtUsername, TextBox txtNome, TextBox txtEmail, TextBox txtSenha, TextBox txtDataNascimento, DropDownList ddlSexo, string codWorkspace)
        {
            if (!Valida.StringVazia(txtUsername, txtNome, txtEmail, txtSenha, txtDataNascimento))
            {
                return false;
            }
            else if (!Valida.DropDownListVazia(ddlSexo))
            {
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
            return (new ControllerUsuario().Cadastrar(usuario));
        }
    }
}