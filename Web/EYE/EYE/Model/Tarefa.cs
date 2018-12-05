using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EYE.Model
{
    public class Tarefa
    {
        private int codTarefa;
        private string nome;
        private string descricao;
        private string dataInicio;
        private string dataFim;
        private string dataConclusao;
        private int statusVida;
        private int codAndamento;
        private int codWorkspace;

        public int CodTarefa { get => codTarefa; set => codTarefa = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string DataInicio { get => dataInicio; set => dataInicio = value; }
        public string DataFim { get => dataFim; set => dataFim = value; }
        public string DataConclusao { get => dataConclusao; set => dataConclusao = value; }
        public int StatusVida { get => statusVida; set => statusVida = value; }
        public int CodAndamento { get => codAndamento; set => codAndamento = value; }
        public int CodWorkspace { get => codWorkspace; set => codWorkspace = value; }

        public Panel ConstruirConteudo(DropDownList ddlUsuarios, DropDownList ddlProcessos)
        {


            var conteudo = new Panel();
            var lblUsuario = new Label();
            lblUsuario.Text = "Quem vai participar dessa tarefa?";


            var lblProcesso = new Label();
            lblProcesso.Text = "Que processo será utilizado?";

            var lblTempo = new Label();
            lblTempo.Text = "Quantas horas essa pessoa vai demorar?";
            var txtTempo = new TextBox();
            

            ddlUsuarios.CssClass = "ddlUsuarios";
            ddlProcessos.CssClass = "ddlProcessos";
            txtTempo.CssClass = "txtTempo";

            ddlUsuarios.Enabled = false;
            ddlProcessos.Enabled = false;
            txtTempo.Enabled = false;

            txtTempo.Attributes.Add("type", "Number");
            




            conteudo.Controls.Add(lblUsuario);
            conteudo.Controls.Add(ddlUsuarios);
            conteudo.Controls.Add(lblProcesso);
            conteudo.Controls.Add(ddlProcessos);
            conteudo.Controls.Add(lblTempo);
            conteudo.Controls.Add(txtTempo);

            conteudo.ID = "conteudo0";
            conteudo.CssClass = "conteudoTarefa";
            return conteudo;
        }
    }
}