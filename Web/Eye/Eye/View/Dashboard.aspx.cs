
using EYE.Controller;
using EYE.Model;
using System;
using System.Web.Script.Services;
using System.Web.Services;

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
            return int.Parse((String)Session["codWorkspace"]);
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

            leitura.CPUAtual = controllerLeituraAtual.GetPorcentagemCPU(codComputador);
            leitura.HDAtual = controllerLeituraAtual.GetPorcentagemHD(codComputador);
            leitura.RAMAtual = controllerLeituraAtual.GetPorcentagemRAM(codComputador);
            



            return leitura;
        }

        

    }
}