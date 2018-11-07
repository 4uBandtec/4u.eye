using Eye.Model;
using System;

namespace Eye.View
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var codWorkspace = (string)Session["codWorkspace"];
            if (codWorkspace == null || codWorkspace == "0")
            {
                Response.Redirect("./Login.aspx");
            }

            Usuario usuario = new Usuario();
            int codWorkspaceInt = Int32.Parse(codWorkspace);

            int totalUserWorkspace = usuario.ContaUsuariosWorkspace(codWorkspaceInt);
            Usuario[] usuarios = usuario.ListarUsuarios(codWorkspaceInt);

            for (int i = 0; i < totalUserWorkspace; i++)
            {
                lblMensagem.Text += usuarios[i].Nome+" ";
            }
        }
    }
}