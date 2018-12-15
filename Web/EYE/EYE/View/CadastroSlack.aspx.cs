using EYE.Controller;
using EYE.Model;
using System;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace EYE.View
{
    public partial class CadastroSlack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			new Sessao().PageLoadRedireciona();
		}

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!new ControllerSlack().Cadastrar(txtUrl, txtCanal, new Sessao().RetornaSessaoWorkspace(), lblMensagem))
            {
                return;
            }
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {

            pnlOnline.Controls.Clear();
            var lista = ControllerComputador.RetornaUsuariosOnline(new Sessao().RetornaSessaoWorkspace());
            var index = 0;
            foreach (var item in lista)
            {
                Label lblUser = new Label();
                lblUser.ID = "lblUser" + index;
                lblUser.CssClass = "lblUser";
                lblUser.Text = $"{item}";
                index++;
                pnlOnline.Controls.Add(lblUser);
            }
        }

        [ScriptMethod, WebMethod]
        public static int BuscaTema()
        {
            return ControllerTema.BuscaTema(new Sessao().RetornaSessaoWorkspace());
        }

        [ScriptMethod, WebMethod]
        public static bool TrocaTema(int novoTema)
        {
            return ControllerTema.TrocaTema(new Sessao().RetornaSessaoWorkspace(), novoTema);
        }
    }
}