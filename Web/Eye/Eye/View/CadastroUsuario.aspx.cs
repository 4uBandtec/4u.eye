using EYE.Controller;
using System;
using System.Web.Script.Services;
using System.Web.Services;

namespace Eye.View
{
    public partial class CadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var codWorkspace = (string)Session["codWorkspace"];
            if (codWorkspace == null || codWorkspace == "0")
            {
                Response.Redirect("./Login.aspx");
            }
        }

        protected void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            var codWorkspace = (string)Session["codWorkspace"];
            if (!new ControllerUsuario().Cadastrar(txtUsername, txtNome, txtEmail, txtSenha, txtDataNascimento, ddlSexo, codWorkspace, lblMensagem))
            {
                return;
            }
        }

        [ScriptMethod, WebMethod]
        public static void BreakSession()
        {
            CadastroUsuario cadUser = new CadastroUsuario();
            cadUser.Session.Abandon();
        }

        protected void btnIrPara_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Dashboard.aspx");
        }
    }
}