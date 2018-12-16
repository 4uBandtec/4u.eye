using EYE.Controller;
using EYE.Model;
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
			if (new Sessao().RetornaSessaoWorkspace() == 0)
				Response.Redirect("./Login.aspx");
		}

		protected void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            if (!new ControllerUsuario().Cadastrar(txtUsername, txtNome, txtEmail, txtSenha, txtDataNascimento, ddlSexo, new Sessao().RetornaSessaoWorkspace(), lblMensagem))
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
        public static int BuscaModo()
        {
            return ControllerTema.BuscaModo(new Sessao().RetornaSessaoWorkspace());
        }

        [ScriptMethod, WebMethod]
        public static int BuscaIntensidade()
        {
            return ControllerTema.BuscaIntensidade(new Sessao().RetornaSessaoWorkspace());
        }


        [ScriptMethod, WebMethod]
        public static bool TrocaTema(int novoTema)
        {
            bool tema = ControllerTema.TrocaTema(new Sessao().RetornaSessaoWorkspace(), novoTema);

            return (tema);
        }


        [ScriptMethod, WebMethod]
        public static bool TrocaModo(int novoModo)
        {
            bool modo = ControllerTema.TrocaModo(new Sessao().RetornaSessaoWorkspace(), novoModo);

            return (modo);
        }


        [ScriptMethod, WebMethod]
        public static bool TrocaIntensidade(int novaIntensidade)
        {
            bool intensidade = ControllerTema.TrocaIntensidade(new Sessao().RetornaSessaoWorkspace(), novaIntensidade);

            return (intensidade);
        }
    }
}