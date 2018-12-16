using EYE.Controller;
using System;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;

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

            var tema = ControllerTema.BuscaTema(new CadastroUsuario().returnSession());
            var modo = ControllerTema.BuscaModo(new CadastroUsuario().returnSession());

            int[] retorno = new int[2];
            retorno[0] = modo;
            retorno[1] = tema;

            return retorno;
        }

        [ScriptMethod, WebMethod]
        public static int BuscaTema()
        {
            return ControllerTema.BuscaTema(new CadastroUsuario().returnSession());
        }

        [ScriptMethod, WebMethod]
        public static int BuscaModo()
        {
            return ControllerTema.BuscaModo(new CadastroUsuario().returnSession());
        }

        [ScriptMethod, WebMethod]
        public static int BuscaIntensidade()
        {
            return ControllerTema.BuscaIntensidade(new CadastroUsuario().returnSession());
        }


        [ScriptMethod, WebMethod]
        public static bool TrocaTema(int novoTema)
        {
            bool tema = ControllerTema.TrocaTema(new CadastroUsuario().returnSession(), novoTema);

            return (tema);
        }


        [ScriptMethod, WebMethod]
        public static bool TrocaModo(int novoModo)
        {
            bool modo = ControllerTema.TrocaModo(new CadastroUsuario().returnSession(), novoModo);

            return (modo);
        }


        [ScriptMethod, WebMethod]
        public static bool TrocaIntensidade(int novaIntensidade)
        {
            bool intensidade = ControllerTema.TrocaIntensidade(new CadastroUsuario().returnSession(), novaIntensidade);

            return (intensidade);
        }
    }
}