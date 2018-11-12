
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

            ControllerUsuario controllerUsuario = new ControllerUsuario();
            int codWorkspaceInt = Int32.Parse(codWorkspace);

            int totalUserWorkspace = controllerUsuario.ContaUsuarioWorkspace(codWorkspaceInt);
            Usuario[] usuarios = controllerUsuario.ListarUsuarios(codWorkspaceInt);

            ControllerComputador controllerComputador = new ControllerComputador();
            for (int i = 0; i < totalUserWorkspace; i++)
            {
                Computador[] computadores = new Computador[controllerComputador.ContarComputadorUsuario(usuarios[i].CodUsuario)];

                computadores = controllerComputador.ListarComputadoresUsuario(usuarios[i].CodUsuario);

                usuarios[i].ComputadoresUsuario = computadores;
            }

            for (int i = 0; i < totalUserWorkspace; i++)
            {
                lblMensagem.Text += usuarios[i].Nome + " :";
                for (int j = 0; j < usuarios[i].ComputadoresUsuario.Length; j++)
                {
                    lblMensagem.Text += i + " " + j + " " + usuarios[i].ComputadoresUsuario[j].NomeComputador + "\n\n\naa";
                }
            }
        }


        [ScriptMethod, WebMethod]
        public static double AtualizarMonitores(int codComputador)
        {
            LeituraAtual testeAjax = new LeituraAtual();
            testeAjax.CPUAtual = 1234;
            testeAjax.HDAtual = 2345;
            testeAjax.RAMAtual = codComputador * new Random().Next();
            return testeAjax.RAMAtual;
        }

    }
}