using EYE.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
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

        public int returnSession()
        {
            var codWorkspace = (string)Session["codWorkspace"];
            if (codWorkspace == null || codWorkspace == "0")
            {
                return 0;
            }
            else
            {
                return int.Parse((String)Session["codWorkspace"]);
            }
        }


        [ScriptMethod, WebMethod]
        public static int[] BuscaTemaModo()
        {

            var tema = ControllerTema.BuscaTema(new CadastroSlack().returnSession());
            var modo = ControllerTema.BuscaModo(new CadastroSlack().returnSession());

            int[] retorno = new int[2];
            retorno[0] = modo;
            retorno[1] = tema;

            return retorno;
        }

        [ScriptMethod, WebMethod]
        public static int BuscaTema()
        {
            return ControllerTema.BuscaTema(new CadastroSlack().returnSession());
        }

        [ScriptMethod, WebMethod]
        public static int BuscaModo()
        {
            return ControllerTema.BuscaModo(new CadastroSlack().returnSession());
        }

        [ScriptMethod, WebMethod]
        public static int BuscaIntensidade()
        {
            return ControllerTema.BuscaIntensidade(new CadastroSlack().returnSession());
        }


        [ScriptMethod, WebMethod]
        public static bool TrocaTema(int novoTema)
        {
            bool tema = ControllerTema.TrocaTema(new CadastroSlack().returnSession(), novoTema);

            return (tema);
        }


        [ScriptMethod, WebMethod]
        public static bool TrocaModo(int novoModo)
        {
            bool modo = ControllerTema.TrocaModo(new CadastroSlack().returnSession(), novoModo);

            return (modo);
        }


        [ScriptMethod, WebMethod]
        public static bool TrocaIntensidade(int novaIntensidade)
        {
            bool intensidade = ControllerTema.TrocaIntensidade(new CadastroSlack().returnSession(), novaIntensidade);

            return (intensidade);
        }
    }
}