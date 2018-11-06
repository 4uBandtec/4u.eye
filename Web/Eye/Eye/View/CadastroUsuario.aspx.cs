using Eye.Model;
using System;

namespace Eye.View
{
    public partial class CadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var codWorkspace = (string)Session["codWorkspace"];
        }

        protected void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            var codWorkspace = (string)Session["codWorkspace"];
            if (!new Usuario().Cadastrar(txtUsername, txtNome, txtEmail, txtSenha, txtDataNascimento, ddlSexo, codWorkspace, lblMensagem))
            {
                return;
            }
        }
    }
}