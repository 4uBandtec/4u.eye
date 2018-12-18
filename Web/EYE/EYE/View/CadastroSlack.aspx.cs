﻿using EYE.Controller;
using EYE.Model;
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
			if (new Sessao().RetornaSessaoWorkspace() == 0)
				Response.Redirect("./Login.aspx");

			new ControllerSlack().VerificaSlackCadastrado(txtUrl, btnCadastrar, new Sessao().RetornaSessaoWorkspace());

		}

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
			if (!new ControllerSlack().Cadastrar(txtUrl, new Sessao().RetornaSessaoWorkspace(), lblMensagem))
			{
				return;
			}
			else
				Response.Redirect("./CadastroSlack.aspx");
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