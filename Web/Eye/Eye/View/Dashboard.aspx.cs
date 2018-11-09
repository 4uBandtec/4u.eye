<<<<<<< HEAD
﻿using Eye.Model;
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

            Usuario usuario = new Usuario();
            int codWorkspaceInt = Int32.Parse(codWorkspace);

            int totalUserWorkspace = usuario.ContaUsuariosWorkspace(codWorkspaceInt);
            Usuario[] usuarios = usuario.ListarUsuarios(codWorkspaceInt);

            Monitor monitor = new Monitor();
            for (int i = 0; i < totalUserWorkspace; i++)
            {
                Monitor[] monitores = new Monitor[monitor.ContarComputadorUsuario(usuarios[i].CodUsuario)];

                monitores = monitor.ListarComputadoresUsuario(usuarios[i].CodUsuario);

                usuarios[i].ComputadoresUsuario = monitores;
            }

            for (int i = 0; i < totalUserWorkspace; i++)
            {
                lblMensagem.Text += usuarios[i].Nome + " :";
                for (int j = 0; j < usuarios[i].ComputadoresUsuario.Length; j++)
                {
                    lblMensagem.Text += i+" "+j+" "+usuarios[i].ComputadoresUsuario[j].NomeComputador+"\n\n\naa";
                }
            }
        }

        
        [ScriptMethod, WebMethod]
        public static double AtualizarMonitores(int codComputador)
        {
            LeituraAtual testeAjax = new LeituraAtual();
            testeAjax.CPUAtual = 1234;
            testeAjax.RAMAtual = 2345;
            testeAjax.DiscoAtual = codComputador * new Random().Next();
            return testeAjax.DiscoAtual;
        }
    }
=======
﻿using Eye.Model;
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

            Monitor monitor = new Monitor();
            for (int i = 0; i < totalUserWorkspace; i++)
            {
                Monitor[] monitores = new Monitor[monitor.ContarComputadorUsuario(usuarios[i].CodUsuario)];

                monitores = monitor.ListarComputadoresUsuario(usuarios[i].CodUsuario);

                usuarios[i].ComputadoresUsuario = monitores;
            }

            for (int i = 0; i < totalUserWorkspace; i++)
            {
                lblMensagem.Text += usuarios[i].Nome + " :";
                for (int j = 0; j < usuarios[i].ComputadoresUsuario.Length; j++)
                {
                    lblMensagem.Text += i+" "+j+" "+usuarios[i].ComputadoresUsuario[j].NomeComputador+"\n\n\naa";
                }
            }
        }
    }
>>>>>>> fc7153b011ad8848d672828fe3312307cab9f766
}