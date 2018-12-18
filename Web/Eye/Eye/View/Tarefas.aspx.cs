using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using EYE.Controller;
using EYE.Model;

namespace EYE.View
{
    public partial class Tarefas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (new Sessao().RetornaSessaoWorkspace() == 0)
                Response.Redirect("./Login.aspx");
            if (IsPostBack == false)
            {
                var processo = ControllerTarefa.BuscaProcessoSemPerfil(new Sessao().RetornaSessaoWorkspace());
                lblNomeProcesso.Text = processo.NomeAplicacao;
                hdlCodProcesso.Value = processo.CodProcesso.ToString();
                ddlTipoPerfil.SelectedValue =processo.CodPerfil.ToString();
            }
        }

        [ScriptMethod, WebMethod]
        public static void BreakSession()
        {
            CadastroTarefas cadTarefa = new CadastroTarefas();
            cadTarefa.Session.Abandon();
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
        public static int[] BuscaTemaModo()
        {

            var tema = ControllerTema.BuscaTema(new Sessao().RetornaSessaoWorkspace());
            var modo = ControllerTema.BuscaModo(new Sessao().RetornaSessaoWorkspace());

            int[] retorno = new int[2];
            retorno[0] = modo;
            retorno[1] = tema;

            return retorno;
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


        [ScriptMethod, WebMethod]
        public static List<Tarefa> ListarTarefas()
        {
            return new ControllerTarefa().ListarTarefas(new Sessao().RetornaSessaoWorkspace());
        }

        protected void btnClassificar_OnClick(object sender, EventArgs e)
        {
            ControllerTarefa.ClassificarProcesso(hdlCodProcesso.Value, ddlTipoPerfil.SelectedValue);
        }
    }
}