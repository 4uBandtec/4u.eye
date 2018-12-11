using EYE.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EYE.View
{
    public partial class CadastroSlack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var codWorkspace = (string)Session["codWorkspace"];
            if (codWorkspace == null || codWorkspace == "0")
            {
                Response.Redirect("./Login.aspx");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var codWorkspace = (string)Session["codWorkspace"];
            if (!new ControllerSlack().Cadastrar(txtUrl, txtCanal, codWorkspace, lblMensagem))
            {
                return;
            }
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {

            pnlOnline.Controls.Clear();
            var lista = ControllerComputador.RetornaUsuariosOnline(int.Parse((string)Session["codWorkspace"]));
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
    }
}