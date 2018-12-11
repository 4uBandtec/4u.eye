using EYE.Controller;
using EYE.Model;
using System;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;

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
        public static void BreakSession()
        {
            Dashboard dash = new Dashboard();
            dash.Session.Abandon();
        }

        
        

        [ScriptMethod, WebMethod]
        public static Usuario[] GetUsuariosWorkspace()
        {
            ControllerUsuario controllerUsuario = new ControllerUsuario();

            Dashboard dash = new Dashboard();

            int totalUserWorkspace = controllerUsuario.ContaUsuarioWorkspace(dash.returnSession());
            Usuario[] usuarios = controllerUsuario.ListarUsuarios(dash.returnSession());

            ControllerComputador controllerComputador = new ControllerComputador();
            for (int i = 0; i < totalUserWorkspace; i++)
            {
                Computador[] computadores = new Computador[controllerComputador.ContarComputadorUsuario(usuarios[i].CodUsuario)];

                computadores = controllerComputador.ListarComputadoresUsuario(usuarios[i].CodUsuario);

                usuarios[i].ComputadoresUsuario = computadores;
            }

            return usuarios;
        }

        [ScriptMethod, WebMethod]
        public static LeituraAtual AtualizarComputadores(int codComputador)
        {

            LeituraAtual leitura = new LeituraAtual();

            ControllerLeituraAtual controllerLeituraAtual = new ControllerLeituraAtual();

            leitura.CpuAtual = controllerLeituraAtual.GetPorcentagemCPU(codComputador);
            leitura.HdAtual = controllerLeituraAtual.GetPorcentagemHD(codComputador);
            leitura.RamAtual = controllerLeituraAtual.GetPorcentagemRAM(codComputador);
            leitura.CodComputador = codComputador;



            return leitura;
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