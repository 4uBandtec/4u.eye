using Eye.Controller;
using Eye.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            new Usuario().Cadastrar(txtUsername, txtNome, txtEmail, txtSenha, txtDataNascimento, ddlSexo, codWorkspace, lblMensagem);

        }
    }
}